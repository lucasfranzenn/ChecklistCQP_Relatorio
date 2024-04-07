namespace ChecklistCQPDOC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_Autor = new TextBox();
            btn_gerarCheckList = new Button();
            txt_Tarefa = new TextBox();
            tlp_checklist = new TableLayoutPanel();
            lbl_autor = new Label();
            lbl_tarefa = new Label();
            lbl_data = new Label();
            lbl_dataAtual = new Label();
            SuspendLayout();
            // 
            // txt_Autor
            // 
            txt_Autor.AutoCompleteMode = AutoCompleteMode.Append;
            txt_Autor.BorderStyle = BorderStyle.FixedSingle;
            txt_Autor.Location = new Point(72, 18);
            txt_Autor.Name = "txt_Autor";
            txt_Autor.Size = new Size(125, 27);
            txt_Autor.TabIndex = 0;
            // 
            // btn_gerarCheckList
            // 
            btn_gerarCheckList.Location = new Point(864, 12);
            btn_gerarCheckList.Name = "btn_gerarCheckList";
            btn_gerarCheckList.Size = new Size(227, 60);
            btn_gerarCheckList.TabIndex = 2;
            btn_gerarCheckList.Text = "&Gerar CheckList";
            btn_gerarCheckList.UseVisualStyleBackColor = true;
            btn_gerarCheckList.Click += GerarCheckList_Click;
            // 
            // txt_Tarefa
            // 
            txt_Tarefa.BorderStyle = BorderStyle.FixedSingle;
            txt_Tarefa.Location = new Point(279, 18);
            txt_Tarefa.Name = "txt_Tarefa";
            txt_Tarefa.Size = new Size(125, 27);
            txt_Tarefa.TabIndex = 1;
            txt_Tarefa.Leave += txt_Tarefa_Leave;
            // 
            // tlp_checklist
            // 
            tlp_checklist.AutoScroll = true;
            tlp_checklist.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tlp_checklist.ColumnCount = 2;
            tlp_checklist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.8F));
            tlp_checklist.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.2F));
            tlp_checklist.Location = new Point(12, 78);
            tlp_checklist.Name = "tlp_checklist";
            tlp_checklist.RowCount = 2;
            tlp_checklist.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_checklist.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_checklist.Size = new Size(1079, 648);
            tlp_checklist.TabIndex = 3;
            // 
            // lbl_autor
            // 
            lbl_autor.AutoSize = true;
            lbl_autor.Location = new Point(17, 20);
            lbl_autor.Name = "lbl_autor";
            lbl_autor.Size = new Size(49, 20);
            lbl_autor.TabIndex = 4;
            lbl_autor.Text = "Autor:";
            // 
            // lbl_tarefa
            // 
            lbl_tarefa.AutoSize = true;
            lbl_tarefa.Location = new Point(221, 20);
            lbl_tarefa.Name = "lbl_tarefa";
            lbl_tarefa.Size = new Size(52, 20);
            lbl_tarefa.TabIndex = 5;
            lbl_tarefa.Text = "Tarefa:";
            // 
            // lbl_data
            // 
            lbl_data.AutoSize = true;
            lbl_data.Location = new Point(491, 20);
            lbl_data.Name = "lbl_data";
            lbl_data.Size = new Size(44, 20);
            lbl_data.TabIndex = 6;
            lbl_data.Text = "Data:";
            // 
            // lbl_dataAtual
            // 
            lbl_dataAtual.AutoSize = true;
            lbl_dataAtual.Location = new Point(550, 20);
            lbl_dataAtual.Name = "lbl_dataAtual";
            lbl_dataAtual.Size = new Size(0, 20);
            lbl_dataAtual.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 752);
            Controls.Add(lbl_dataAtual);
            Controls.Add(lbl_data);
            Controls.Add(lbl_tarefa);
            Controls.Add(lbl_autor);
            Controls.Add(tlp_checklist);
            Controls.Add(txt_Tarefa);
            Controls.Add(btn_gerarCheckList);
            Controls.Add(txt_Autor);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Gerador de Checklist";
            Load += Form1_Load;
            Shown += Form1_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Autor;
        private Button btn_gerarCheckList;
        private TextBox txt_Tarefa;
        private TableLayoutPanel tlp_checklist;
        private Label lbl_autor;
        private Label lbl_tarefa;
        private Label lbl_data;
        private Label lbl_dataAtual;
    }
}
