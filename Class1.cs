using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Constantes
{
    internal class Constantes
    {
        public const Int16 LINHAS = 33;
        public const Int16 COLUNAS = 4;

        public static Dictionary<int, String> CHECKS = new Dictionary<int, String>
        {
            {1, "Verificar se todas as novas funcionalidades implementadas operam conforme esperado."},
            {2, "Verificar as ações dos botões e seu comportamento caso não seja selecionado nenhum registro para testar sua funcionalidade."},
            {3, "Verificar se o formulário está abrindo centralizado."},
            {4, "Verificar se está sendo possível mover o formulário."},
            {5, "Verificar se os botões da tela possuem atalhos. Se é possível fechar o formulário com esc, não tem a necessidade de adicionar atalhos para os botões sair e fechar. Botões como o \" Personalizar\" também não precisa de atalho."},
            {6, "Verificar se os botões estão respeitando o estilo de personalização definido pelo usuário."},
            {7, "Verificar se a sequência do foco está correta."},
            {8, "Verificar se é possível passar o foco com a tecla ENTER."},
            {9, "Verificar se os campos de texto estão respeitando a quantidade máxima de caracteres para não gerar estouro."},
            {10, "Verificar se operações de consulta, edição e inserção estão tratando o uso de aspas simples."},
            {11, "Verificar se o campo de pesquisa está funcionando corretamente quando colocamos aspas simples nos campos."},
            {12, "Verificar se está sendo possível fazer a pesquisa através da tecla F1."},
            {13, "Verificar se está funcionando os atalhos para os campos de datas, tais como H, + e -"},
            {14, "Verificar se os campos numéricos estão realizando operações matemáticas. (TEXTBOX)"},
            {15, "Verificar se os componentes dos formulários ( labels, textbox, frame e etc) estão respeitando a fonte padrão."},
            {16, "Verificar se está cortando alguma informação inferior a 9.999.999,99"},
            {17, "Verificar alinhamento de campos numéricos (ex: Quantidade, valor unitário, valor total) estão alinhados a direita"},
            {18, "Verificar alinhamento de campos de código se estão alinhados a direita."},
            {19, "Verificar se o formulário apresenta erros ortográficos."},
            {20, "Verificar a seleção com duplo clique quando é feito a seleção de registros a partir de um grid."},
            {21, "Verificar se os grids possuem barras de rolagem vertical e horizontal"},
            {22, "Verificar se os grids respeitam as personalizações definidas pelo usuário"},
            {23, "Testar a integração da customização com as funcionalidades existentes do ERP."},
            {24, "Avaliar se a customização é fácil de usar e entender pelos usuários finais."},
            {25, "Verificar se as operações de leitura e escrita no banco de dados são executadas corretamente sem erros."},
            {26, "Garantir que a customização não comprometa a integridade dos dados existentes no banco de dados."},
            {27, "Confirmar se a customização está devidamente documentada."},
            {28, "Avaliar o desempenho da customização, especialmente em operações que demandam mais recursos."},
            {29, "Assegurar que as customizações não afetem negativamente a funcionalidade existente que os usuários dependem."},
            {30, "Garantir que a interface do usuário das customizações seja consistente, intuitiva e esteja livre de erros visuais."},
            {31, "Executar uma suite de testes de regressão completa para todas as funcionalidades existentes que possam ser impactadas pelas novas customizações."},
            {32, "Verificar se os fluxos de trabalho críticos do negócio continuam a operar como esperado após as customizações. Isso inclui testes de ponta a ponta para processos de negócios chave."},
            {33, "Testar se a geração de relatórios e a exibição de dados não são afetadas negativamente pelas novas customizações."}
        };

        public static Dictionary<int, String> AREAS = new Dictionary<int, string>
        {
            {1, "Funcionalidade" },
            {2, "Integração" },
            {3, "Usabilidade" },
            {4, "Dados"},
            {5, "Documentação" },
            {6, "Performace" },
            {7, "Compatibilidade de versões Anteriores" },
            {8, "Testes de Interface do Usuário (UI)" },
            {9, "Testes de Regressão" },
            {10, "Fluxos de Trabalho Críticos" },
            {11, "Integridade dos Relatórios" }
        };
    }
}
