using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagasMoni
{
    public partial class Vaga : Form
    {

        //Neste Form ele vai mostrar algumas informações dedicadas.
        //Também possibilitará que usuário realize algumas atualizações em relação ao Status e anexe o currículo utilizado.
        public Vaga()
        {
            InitializeComponent();
            this.idVaga = idVaga;

        }
        //Como precisamos do valor da variavel de outro form para utilização no SQL , é necessário declara-la como publica 
        //E apontar o this.idVaga = idVaga na classe.
        public string idVaga { get; set;}
        private void Vaga_Load(object sender, EventArgs e)
        {
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            // Aqui ocorre o atrelamento de um curriculo para diretório da vaga.
            // Realizada conexão com banco de dados , nós vamos atrelar a informação que está no banco para nossa variável
            // da nossa aplicação , anteriormente estavamos fazendo o contrário ( Aplicação --> Banco ) 
            SQLiteConnection con;
            SQLiteCommand cmd , cmd2;

            con = new SQLiteConnection(@"Data Source=C:\EncontreUmTrampo\cadastro.db");
            con.Open();
            cmd = new SQLiteCommand(con);
            cmd = con.CreateCommand();
            cmd2 = con.CreateCommand();
            
            cmd.CommandText = "Select DiretorioCV From Trampo where ID ="+idVaga;

            //  A relação do comando abaixo é indicar que um curriculo ou arquivo está na pasta 
            // para posteriormente indicarmos isso no Form para o usuário. Todavia não é um aspecto correto, pois
            // se houver um fechamento do Open Dialog será creditado o comando abaixo. Poderiamos realizar mais um if
            // ou um Else do OpenDialog,que desfazeria essa ação. Como a informação que ele vai alterar é na informação de 
            // uma Label pouco relevante , nesse momento eu preferi deixar assim . Posteriormente podemos aplicar uma lógica
            //que trabelhe melhor com esse tipo de comportamento.

            cmd2.CommandText = "Update Trampo set Curriculos='Sim' where ID ="+idVaga;

            // Pelo comando abaixo vamos ler o banco e na string loc vamos armazenar essa informação.

            SQLiteDataReader reader = cmd.ExecuteReader();
            cmd2.ExecuteReader();

            String loc = reader["DiretorioCV"].ToString();
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
               
                string dest = loc + "\\"+ Path.GetFileName(source);

                File.Copy(source, dest , true);
                label4.Visible = true;
                label8.Visible = true;
                label4.Text = openFileDialog1.FileName;
                MessageBox.Show("Curriculo Atrelado a vaga");
            }

            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Esse botão realiza a função de atualizar o Status da vaga no banco.
            // A diferença das outra interações via banco foi a inclusão do catch
            // O catch é um boa pratica para que programa não entre em crash total e é uma boa prática
            //Caso ocorra alguma coisa errada no laço try , será apontado id e detalhes do erro.
           
            try
            { 
            SQLiteConnection con;
            SQLiteCommand cmd;

            con = new SQLiteConnection(@"Data Source=C:\EncontreUmTrampo\cadastro.db");
            con.Open();
            cmd = new SQLiteCommand(con);
            cmd = con.CreateCommand();
            cmd.CommandText = "Update Trampo set Etapa='"+comboBox1.Text+"'where ID =" +idVaga;
            SQLiteDataReader reader = cmd.ExecuteReader();
                con.Close();
            MessageBox.Show("Atualizado");
                this.comboBox1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Segue erro: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Esse botão vai pegar o diretório da vaga e se clicado vai abri-lo.
            try
            {
                SQLiteConnection con;
                SQLiteCommand cmd;

                con = new SQLiteConnection(@"Data Source=C:\EncontreUmTrampo\cadastro.db");
                con.Open();
                cmd = new SQLiteCommand(con);
                cmd = con.CreateCommand();
                cmd.CommandText = "select DiretorioCV From Trampo where ID =" + idVaga;

                SQLiteDataReader reader = cmd.ExecuteReader();

                String loc = reader["DiretorioCV"].ToString();
                System.Diagnostics.Process.Start(loc);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Segue erro: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox1.Refresh();
        }
    }
    }

