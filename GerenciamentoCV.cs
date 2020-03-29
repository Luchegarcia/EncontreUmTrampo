using System;
using System.Windows.Forms;

namespace VagasMoni
{
    public partial class GerenciamentoCV : Form
    {
        //Mostra a pasta onde os currículos são salvos(Button1) ou direcionam para o construtot(Button2)
        public GerenciamentoCV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\EncontreUmTrampo\Curriculos\Criados\");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CriarCV criaCVS = new CriarCV();
            criaCVS.Show();
        }
    }
}
