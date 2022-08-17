using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace Sinky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

        }

        private void ImgClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }



        

        

       

        private void ImgLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string login = Convert.ToString(txtLogin.Text);
            string senha = Convert.ToString(txtSenha.Text);


            SqlConnection conexao;
            string connString = "Data Source=localhost;Initial Catalog=tese;User ID=sa;Password=labfiap#2019$";

            conexao = new SqlConnection(connString);

            bool conect;
            try
            {
                conexao.Open();
                conect = true;

            }
            catch
            {

                lblErroBD.Visibility = Visibility.Visible;
                conect = false;
                //pg2.Show();
            }
            if (conect == true)
            {
                //Pegar os dados do BD
                SqlCommand query;

                string consulta;
                //string resposta = "";

                //Fazer a consulta
                consulta = "select * from funcionarios where login = '" + login + "' and senha = '" + senha + "';";
                query = new SqlCommand(consulta, conexao);

                query.Connection = conexao;
                query.CommandText = consulta;

                //bool linhas = query.ExecuteReader().HasRows;
                var test = query.ExecuteReader();

                bool linhas = test.HasRows;




                if (linhas == true)
                {

                    test.Read();
                    var nome = test["nome"].ToString();
                    //pg2.lblTeste.Content = nome;
                    home pg2 = new home();

                    pg2.Show();
                }

                else
                {
                    lblErro.Visibility = Visibility.Visible;
                }
            }

        }
    }
}
