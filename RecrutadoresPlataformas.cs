using System;
using System.Windows.Forms;

namespace VagasMoni
{
    public partial class RecrutadoresPlataformas : Form
    {
        //Direcionamento para as princípais plataformas de recrutamento e seleção
        //Próprio recurso do Windows direciona para abertura do site com navegador definido como padrão
        public RecrutadoresPlataformas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.catho.com.br/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.infojobs.com.br/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://br.jooble.org/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.maturi.com.br/");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.br.freelancer.com/prolancer");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.reachr.com.br/");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.vagas.com.br/");
        }

        private void RecrutadoresPlataformas_Load(object sender, EventArgs e)
        {

        }
    }
}
