using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace VagasMoni
{
    public partial class Consultar : Form
    {
        public string ide { get; set; }

        public Consultar()
        {
            InitializeComponent();
            
            BindGrid();
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void BindGrid()
        // Esse Form de Consulta vai realizar a conexão com banco de dados e mostrar o que tem na tabela com os dados
        //inseridos no Form de cadastro. Basicamente é realizar um Select e associalos ao Fill para que possa ser compreendido
        //pelo Data Grid View , o Data Grid View é um recurso para manipular dados provenientes de um banco de dados.
        //Algumas adaptações via dll e Program.cs(https://stackoverflow.com/questions/3179028/mixed-mode-assembly-in-net-4) foram realizadas para
        //que o Data Grid View pudesse ser utilizado com Drive ODBC do SQLite. Devido a isso a sintaxe de conexão foi alterada...De todo modo funcionou
        {
            String connectionString = @"Data Source=C:\EncontreUmTrampo\cadastro.db";
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(connectionString);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand("select ID,Vaga,Empresa,Area,Local,Data,Etapa from Trampo");
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteScalar();
            System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
            System.Data.DataSet ds = new System.Data.DataSet();

            da.Fill(ds);

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;
            conn.Close();
        }

        private void Consultar_Load(object sender, EventArgs e)
        {
            

        }
    private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Os dados serão exportados para um Form dedicado que irá mostrar todos os dados e a interação com o usuário 
            // de um modo mais amigável , ao clicar no  dado da linha que corresponde a uma vaga cadastrada serão direcionadas
            // as informações mais relevantes.
            Vaga vag = new Vaga();
               vag.Show();
            vag.idVaga = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            vag.label1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            vag.label2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            vag.label10.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            //Aqui tivemos antecipar e alterar a classificação dos modificadores do Form Vaga para realizar processamento
            //no banco de dados , isso seria possivel se o método tivesse algum objeto declarado , como para aplicar no form 
            //vaga teriamos que criar dentro do Form Load. Realizei por aqui como meotodologia alternativa 

            
            SQLiteConnection con;
                SQLiteCommand cmd;

                con = new SQLiteConnection(@"Data Source=C:\EncontreUmTrampo\cadastro.db");
                con.Open();
                cmd = new SQLiteCommand(con);
                cmd = con.CreateCommand();
                cmd.CommandText = "Select Curriculos From Trampo Where ID=" + vag.idVaga;
                SQLiteDataReader reader = cmd.ExecuteReader();

                String ver = reader["Curriculos"].ToString();

                if (ver == "Sim")
                {
                    vag.label8.Visible = false;
                    vag.label4.Text = "Existe currículo para essa Vaga";
                    vag.label4.Visible = true;
                }
                else
                {
                    vag.label4.Visible = false;
                }
            con.Close();
            
        }
    }
}


