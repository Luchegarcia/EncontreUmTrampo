using System;
using System.Windows.Forms;


namespace VagasMoni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Aqui começam o apontamento para os outros Forms , cada botão aponta para um novo form ( Janela)
        private void button1_Click(object sender, EventArgs e)
        {
            // Este botão redirecionará para para tela de Cadastro
            SQLiteConnectionStringBuilder Cadastro = new SQLiteConnectionStringBuilder();
            Cadastro.Show();

        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            // Este botão redirecionará para para tela de Consulta
            Consultar Consult = new Consultar();
            Consult.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Este botão redirecionará para tela de Gerenciamento de Currículos
            GerenciamentoCV grcv = new GerenciamentoCV();
            grcv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Este botão redirecionará para tela de Recrutamento 
            RecrutadoresPlataformas Recrut = new RecrutadoresPlataformas();
            Recrut.Show();
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {
            // Existe um TextBox que gera aleatoriamente frases de motivação
            // Existem uma Classe chamada RandomNumbersSample que faz a geração de numeros aleatórios, ela realiza outras funções que serão importantes e vão ser vistas ao decorre
            // Conforme o numero , dentro do laço Switch será exibida uma mensagem
            // Essa função fica dentro do Form Load pois ele deve ser gerado no momento da abertura da aplicação
            String frase;
            RandomGenerator generator = new RandomGenerator();
            int sort = generator.RandomNumber(1,6);

            switch (sort)
            {
                case 1:
                    frase = "Acredite em si mesmo! Tenha fé em suas habilidades!";
                    textBox1.Text = frase;
                    break;
                case 2:
                    frase = "Tenha persistência para conseguir os seus objetivos";
                    textBox1.Text = frase;
                    break;
                case 3:
                    frase = "O sucesso consiste em ir de fracasso em fracasso sem perder o entusiasmo";
                    textBox1.Text = frase;
                    break;
                case 4:
                    frase = "Aprenda com seus fracassos e prossiga para o próximo desafio";
                    textBox1.Text = frase;
                    break;
                case 5:
                    frase = "Antes de melhorar, piora!";
                    textBox1.Text = frase;
                    break;
                case 6:
                    frase = "Corra riscos: se você vencer, você será feliz; se você perder, você será sábio";
                    textBox1.Text = frase;
                    break;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Este botão redirecionará para para tela de About , recurso comum nos programas para mais detalhes sobre o produto
            AboutBox1 Sobre = new AboutBox1();
            Sobre.Show();
        }

        
    }
}
