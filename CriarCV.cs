using System;

using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Formatting;
using Spire.Doc.Fields;
using System.Windows.Forms;
using HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment;
using System.IO;

namespace VagasMoni
{
    public partial class CriarCV : Form
    {
        public CriarCV()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            string doc1 = @"C:\EncontreUmTrampo\Curriculos\Criados\" + "Curriculo " +textBox1.Text ;
            string pdf1 = @"C:\EncontreUmTrampo\Curriculos\Criados\" + "Curriculo " +textBox1.Text ;
           
            Document document = new Document(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\Template.docx");


            Titulo();
            DadosPessoais();

            CVConstrutor(document.Sections[0]);
            

            document.SaveToFile("Samble.docx", FileFormat.Docx);
            
            
                File.Copy("Samble.docx", doc1 + ".docx", true);   
            
           
            document.SaveToFile("Samble.pdf", FileFormat.PDF);
           
                File.Copy("Samble.pdf", pdf1 +".pdf" , true);

            
            MessageBox.Show("Arquivos Criados");
        }
        private void CVConstrutor(Section section)
        {
            /////////// TITULO
            Document docBuild = new Document();
            docBuild.LoadFromFile(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\titulo.docx");
            Section s = docBuild.Sections[0];
            Paragraph p1 = s.Paragraphs[0];
            Paragraph NewPara1 = (Paragraph)p1.Clone();
            var paragraph1 = section.AddParagraph();
            paragraph1.AppendText(NewPara1.Text);

            ///////////////////// DADOS
           
            Document docBuild2 = new Document();
            docBuild2.LoadFromFile(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\Dados.docx");
            Section s2 = docBuild2.Sections[0];
            Paragraph p2 = s2.Paragraphs[0];
            Paragraph NewPara2 = (Paragraph)p2.Clone();
            var paragraph2 = section.AddParagraph();
            paragraph2.AppendText(NewPara2.Text);




            ///////////////////// Formacao

        }

        public void Titulo()
        {
            var document1 = new Document();
            var section1 = document1.AddSection();

            section1.AddParagraph().AppendText(textBox1.Text + "\n");
            section1.AddParagraph().ApplyStyle(BuiltinStyle.Heading2);
            document1.SaveToFile(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\titulo.docx", FileFormat.Docx);

        }
        
        public void DadosPessoais()
        {
            var document2 = new Document();
            var section1 = document2.AddSection();
            
            section1.AddParagraph().AppendText("Endereço:" + textBox2.Text + "\n");
            section1.AddParagraph().AppendText("Telefone:" + textBox3.Text + "\n");
            section1.AddParagraph().AppendText("E-Mail:" + textBox4.Text + "\n");
            section1.AddParagraph().ApplyStyle(BuiltinStyle.Subtitle);

            document2.SaveToFile(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\Dados.docx", FileFormat.Docx);

        }


        public void Formacao()
        {

        }

        private void CriarCV_Load(object sender, EventArgs e)
        {
            File.Copy(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\sentinelarenew.docx", @"C:\EncontreUmTrampo\Curriculos\Criados\Templates\sentinela.docx ", true);
            File.Copy(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\CloneStart\Dados.docx",@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\Dados.docx", true);
            File.Copy(@"C:\EncontreUmTrampo\Curriculos\Criados\Templates\CloneStart\Titulo.docx", @"C:\EncontreUmTrampo\Curriculos\Criados\Templates\Titulo.docx", true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( comboBox1.Text == "Ensino Fundamental (1o. Grau)" || comboBox1.Text == "Ensino Médio (2o. Grau)" )
            {
                label11.Visible = false;
                textBox6.Visible = false;
            }
            else
            {
                label11.Visible = true;
                textBox6.Visible = true;
            }
        }
        
        private void LimparDadosExp()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            

        }
        public void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
