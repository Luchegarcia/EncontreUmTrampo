using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

// Aqui dentro deste Form será realizado o cadastro das vagas
namespace VagasMoni
{
    public partial class SQLiteConnectionStringBuilder : Form
    {
        public SQLiteConnectionStringBuilder()
        {
            InitializeComponent();
            this.diretorio = diretorio;
        }

        // A ideia com string diretorio é um recurso para ser utilizado em outras funções, ou seja , em outro Form neste caso 
        // poderiam utilizar o valor atribuido a essa variável.
        public string diretorio { get; set; }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Utilizamos o SQLite (SQLite.NET no menu de Referencias)  como operador relacional no banco de dados.
            //Realizei algumas adaptações para esse projeto , mas a DLL e comunicação com IDE( Ambiente de Desenvolvimento) e Linguagem funcionou super bem.
            // A sintaxe e a forma como relacionar os dados criados no IDE é uma grande vantagem, vendo o código por si só
            // conseguimos ver como funciona , o relacionamento com banco de dados é essencial para armazenar os dados gerados

            // SQLLite é gratuíto e pode ser criado e gerenciado SQLiteDatabaseBrowserPortable ( https://sqlitebrowser.org/)
            //Outra ventagem é que o SQLLite é compativel com muitas outras plataformas ( (Mobile - iOS , Android) Desktop - Linux , MacOS , Windows)
            //Na hipótese  de uma versão Mobile seria possivel utilizar esse banco de Dados 
            SQLiteConnection con;
            SQLiteCommand cmd;

        
            RandomGenerator generator = new RandomGenerator();

            // Aqui será gerado três caractreres , no caso letras para criação de um diretório que irá armazenar curriculo enviado para vaga
            // A opção por gerar um diretorio com iniciais aleatórias se deu por dois motivos:
            // - Poderiamos usar um index com uma identificação sequencial alimentada por um contador (++) porém dependendo da conjuntura
            // de armazenamento ( Criação , Remoção, Alteração ou repetição ) poderia ocorrer erros
            // - Achei uma oportunidade legal para utilizar a classe RandomNumber e acredito que com isso possamos diminuir a possbilidade
            // de algum erro por estrutura logica , ou perda de informação popr uma possibilidade de gerar um diretório com mesmo nome ou Path.

            string str = generator.RandomString(3, false);

            //Fixamos os dados do programa dentro da raiz do HD por dois fatos:
            // - Facil extração
            // - Problemas relativos a permissão do Windows ou acesso de usuários são descartados 
            string folderName = @"C:\EncontreUmTrampo\Curriculos\";
            string EmpresaVaga = textBox2.Text +" " +textBox1.Text;
            diretorio = folderName + str + " " + EmpresaVaga;
                 Directory.CreateDirectory(diretorio);

            // Aqui declaramos a conexão com banco de dados que criamos com SQLite
            // Seguimos os protocolos de conexão com banco e comando para escrever os dados oriundos do Form de Cadastro no Banco
            con = new SQLiteConnection(@"Data Source=C:\EncontreUmTrampo\cadastro.db");
            con.Open();
            cmd = new SQLiteCommand(con);
            cmd = con.CreateCommand();
            cmd.CommandText = "Insert into Trampo (Vaga,Empresa,Area,Local,Data,Etapa,DiretorioCV) " +
                "Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + comboBox1.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + diretorio + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Processo Realizado");
            //Após comunicação com banco , o comando abaixo fechará o Form
            this.Close();
        }
        
           
               
        private void Cadastro_Load(object sender, EventArgs e)
        {
            //Esse comando vai permitir que Textbox pegue a data atual , mas se o Usuário quiser mudar , ele vai conseguir
            textBox5.Text = DateTime.Now.ToString("d");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
    

