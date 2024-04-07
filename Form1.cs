using Spire.Doc;
using System.Collections.Frozen;
using System.Drawing;
using CONST = Constantes;
using connector;
using MySqlConnector;
using System.Diagnostics.Metrics;

namespace ChecklistCQPDOC
{
    public partial class Form1 : Form
    {

        private class Campos
        {

            private string? autor = null;
            private string? tarefa;
            private string versao = "1.0";
            private string descricao = "Criação do Documento";
            private string data = DateTime.Today.ToString("dd/MM/yyyy");
            private List<bool> passou = new List<bool>();
            private List<String> obs = new List<String>();

            public string Autor { get => autor ??= "SemNome"; set => autor = value; }
            public string? Tarefa { get => tarefa ??= ""; set => tarefa = value; }
            public string Versao { get => versao; set => versao = value; }
            public string Descricao { get => descricao; set => descricao = value; }
            public string Data { get => data; set => data = value; }
            public List<bool> Passou { get => passou; set => passou = value; }
            public List<string> Obs { get => obs; set => obs = value; }

            public Campos()
            {
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void GerarCheckList_Click(object sender, EventArgs e)
        {

            if (VerificarCamposVazios())
            {
                MessageBox.Show("Campo Autor e Tarefa não podem estar vazios!\nPorfavor preencha-os.", "..::AVISO::..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ = new Campos();

            Campos campos = AtualizaCampos();

            SubstituirCampos(campos);

            AtualizaBD(campos);

            MessageBox.Show($"Checklist gerado: {campos.Tarefa}", "..::FINALIZADO::..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limpaCampos();
        }

        private void limpaCampos()
        {
            txt_Autor.Text = "";
            txt_Tarefa.Text = "";

            lbl_dataAtual.Text = "";

            for(int i=1; i<=CONST.Constantes.LINHAS; i++)
            {
                string checkbox = "checkBox" + i;
                string memo = "memo" + i;
                
                CheckBox cb = (CheckBox)tlp_checklist.Controls.Find(checkbox, true).FirstOrDefault();
                TextBox txtBox = (TextBox)tlp_checklist.Controls.Find(memo, true).FirstOrDefault();

                cb.Checked = false;
                txtBox.Text = "";

            }
        }

        private void criaTarefa()
        {
            connection con = new connection();
            MySqlCommand cmd = new MySqlCommand($"Insert into tarefas values ({(txt_Tarefa.Text.Trim())}, '{txt_Autor.Text.Trim()}', CURRENT_TIMESTAMP())", con.Con);
            cmd.ExecuteNonQuery();

            for (int i = 1; i <= CONST.Constantes.CHECKS.Count; i++)
            {
                cmd = new MySqlCommand($"Insert into requisitos values ({i}, {txt_Tarefa.Text}, DEFAULT, DEFAULT)", con.Con);
                cmd.ExecuteNonQuery();
            }
        }

        private void AtualizaBD(Campos campos)
        {
            connection con = new connection();
            MySqlCommand cmd = new MySqlCommand();

            if (!tarefaExiste())
            {
                criaTarefa();
            }

            for (int i = 1; i <= CONST.Constantes.CHECKS.Count; i++)
            {
                string Obs = "memo" + i;

                TextBox tb = (TextBox)tlp_checklist.Controls.Find(Obs, true).FirstOrDefault();

                using (cmd = new MySqlCommand("UPDATE requisitos SET Observacao = @Observacao WHERE id_requisito = @id_requisito AND id_Tarefa = @id_Tarefa", con.Con))
                {
                    cmd.Parameters.AddWithValue("@Observacao", campos.Obs[i - 1]);
                    cmd.Parameters.AddWithValue("@id_requisito", i);
                    cmd.Parameters.AddWithValue("@id_Tarefa", campos.Tarefa);

                    cmd.ExecuteNonQuery();
                }


                string cb = "checkBox" + i;
                CheckBox checkb = (CheckBox)tlp_checklist.Controls.Find(cb, true).FirstOrDefault();

                if (checkb != null)
                {
                    cmd = new MySqlCommand($"UPDATE requisitos set passou = {checkb.Checked} WHERE id_requisito = @id_requisito AND id_Tarefa = @id_Tarefa", con.Con);

                    cmd.Parameters.AddWithValue("@id_requisito", i);
                    cmd.Parameters.AddWithValue("@id_tarefa", campos.Tarefa);


                    cmd.ExecuteNonQuery();
                }

            }


        }

        private bool tarefaExiste()
        {
            connection con = new connection();

            MySqlCommand cmd = new MySqlCommand($"select id_tarefa from Tarefas where id_tarefa = {(txt_Tarefa.Text)}", con.Con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VerificarCamposVazios()
        {
            if (txt_Autor.Text == "" || txt_Tarefa.Text == "")
            {
                return true;
            }

            return false;
        }

        private static void SubstituirCampos(Campos campos)
        {

            Document doc = new Document();
            doc.LoadFromFile(@"C:\RelatoriosCQP\RelatorioBase.docx");


            doc.Replace("{autor}", campos.Autor, true, true);
            doc.Replace("{tarefa}", campos.Tarefa, true, true);
            doc.Replace("{descricao}", campos.Descricao, true, true);
            doc.Replace("{versao}", campos.Versao, true, true);
            doc.Replace("{data}", campos.Data, true, true);

            for (int i = 0; i < campos.Passou.Count(); i++)
            {
                if (campos.Passou[i])
                {
                    doc.Replace("{p" + (i + 1) + "}", "Sim", true, true);
                }
                else
                {
                    doc.Replace("{p" + (i + 1) + "}", "Não", true, true);
                }

                doc.Replace("{o" + (i + 1) + "}", campos.Obs[i], true, true);
            }

            doc.SaveToFile(@$"C:\RelatoriosCQP\Gerados\{campos.Tarefa}.docx", FileFormat.Docx2013);

        }

        private Campos AtualizaCampos()
        {
            Campos camposTemp = new Campos();

            camposTemp.Autor = txt_Autor.Text;
            camposTemp.Tarefa = txt_Tarefa.Text;

            for (int i = 1; i <= CONST.Constantes.LINHAS; i++)
            {
                string checkbox = "checkBox" + i;
                string memo = "memo" + i;

                CheckBox cb = (CheckBox)tlp_checklist.Controls.Find(checkbox, true).FirstOrDefault();
                TextBox txtBox = (TextBox)tlp_checklist.Controls.Find(memo, true).FirstOrDefault();

                if (cb.Checked)
                {
                    camposTemp.Passou.Add(true);
                }
                else
                {
                    camposTemp.Passou.Add(false);
                }

                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    camposTemp.Obs.Add("Nada a informar.");
                }
                else
                {
                    camposTemp.Obs.Add(txtBox.Text);
                }

            }

            return (camposTemp);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CarregaTarefas();
        }

        private void CarregaTarefas()
        {



            tlp_checklist.SuspendLayout();

            tlp_checklist.ColumnCount = CONST.Constantes.COLUNAS;
            tlp_checklist.RowCount = CONST.Constantes.LINHAS;

            tlp_checklist.ColumnStyles.Clear();
            tlp_checklist.RowStyles.Clear();
            tlp_checklist.Controls.Clear();



            float[] columnWidths = { 130F, 500F, 30F, 200F };
            foreach (float width in columnWidths)
            {
                tlp_checklist.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, width));
            }

            for (int i = 1; i <= CONST.Constantes.LINHAS; i++)
            {
                tlp_checklist.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            }



            List<Label> labelList = new List<Label>();
            List<CheckBox> checkboxList = new List<CheckBox>();
            List<TextBox> textboxList = new List<TextBox>();
            List<Label> areaList = new List<Label>();

            for (int i = 0; i < CONST.Constantes.LINHAS; i++)
            {
                Label labelDesc = new Label
                {
                    Width = 1000,
                    AutoEllipsis = true,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Text = CONST.Constantes.CHECKS[i + 1]
                };
                labelList.Add(labelDesc);

                CheckBox checkbox = new CheckBox
                {
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    CheckAlign = ContentAlignment.MiddleCenter,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Name = "checkBox" + (i + 1)
                };
                checkboxList.Add(checkbox);

                TextBox textbox = new TextBox
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.FixedSingle,
                    Multiline = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                    Name = "memo" + (i + 1)

                };
                textboxList.Add(textbox);

                Label area = new Label
                {
                    Width = 1000,
                    AutoEllipsis = true,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Text = (DefineArea(i))
                };
                areaList.Add(area);
            }


            for (int i = 0; i < CONST.Constantes.LINHAS; i++)
            {
                tlp_checklist.Controls.Add(areaList[i], 0, i);
                tlp_checklist.Controls.Add(labelList[i], 1, i);
                tlp_checklist.Controls.Add(checkboxList[i], 2, i);
                tlp_checklist.Controls.Add(textboxList[i], 3, i);
            }

            tlp_checklist.ResumeLayout();

        }

        private string DefineArea(int i)
        {
            if (i < 22) return CONST.Constantes.AREAS[1];
            if (i < 23) return CONST.Constantes.AREAS[2];
            if (i < 24) return CONST.Constantes.AREAS[3];
            if (i < 26) return CONST.Constantes.AREAS[4];
            if (i < 27) return CONST.Constantes.AREAS[5];
            if (i < 28) return CONST.Constantes.AREAS[6];
            if (i < 29) return CONST.Constantes.AREAS[7];
            if (i < 30) return CONST.Constantes.AREAS[8];
            if (i < 31) return CONST.Constantes.AREAS[9];
            if (i < 32) return CONST.Constantes.AREAS[10];


            return CONST.Constantes.AREAS[11];
        }

        private void txt_Tarefa_Leave(object sender, EventArgs e)
        {
            connection con = new connection();
            MySqlCommand cmd = new MySqlCommand($"select nome_testador, data from tarefas where id_tarefa = {txt_Tarefa.Text}", con.Con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txt_Autor.Text = reader["nome_testador"].ToString();
                lbl_dataAtual.Text = reader["data"].ToString();
            }

            reader.Close();

            for (int i = 1; i <= CONST.Constantes.CHECKS.Count; i++)
            {
                string obs = "memo" + i;
                string passou = "checkBox" + i;

                CheckBox cb = (CheckBox)tlp_checklist.Controls.Find(passou, true).FirstOrDefault();
                TextBox txt = (TextBox)tlp_checklist.Controls.Find(obs, true).FirstOrDefault();

                cmd = new MySqlCommand($"SELECT passou, observacao from requisitos where id_tarefa = {txt_Tarefa.Text} and id_requisito = {i} ", con.Con);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cb.Checked = (reader["passou"] == DBNull.Value) ? false : Convert.ToBoolean(reader["passou"]);
                    txt.Text = reader["Observacao"].ToString();
                }

                reader.Close();
            }


        }

        private void criarAutoComplete()
        {
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            connection con = new connection();
            MySqlCommand cmd = new MySqlCommand("select nome_Testador from tarefas", con.Con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                autocomplete.Add(reader["nome_Testador"].ToString());
            }



            txt_Autor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Autor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Autor.AutoCompleteCustomSource = autocomplete;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            criarAutoComplete();
        }
    }
}
