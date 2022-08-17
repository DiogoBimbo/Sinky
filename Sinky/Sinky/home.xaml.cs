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
using System.Windows.Shapes;
using System.Management;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace Sinky
{
    /// <summary>
    /// Lógica interna para home.xaml
    /// </summary>
    public partial class home : Window
    {
        public home()
        {
            InitializeComponent();


            SqlConnection conexao;
            string connString = "Data Source=localhost;Initial Catalog=tese;User ID=sa;Password=labfiap#2019$";
            conexao = new SqlConnection(connString);

            bool connect;
            try
            {
                conexao.Open();
                connect = true;
            }
            catch
            {
                real_home.lblBemVindo.Content = "Erro";
                connect = false;
            }
            if (connect == true)
            {
                SqlCommand query;

                string consulta;

                consulta = "select agenda.id_agenda,funcionarios.nome as 'Nome Funcionario',cliente.nome AS 'Nome Cliente',servico.nome_servico,agenda.dia,agenda.hora from agenda JOIN funcionarios ON agenda.id_FK_func = funcionarios.id_func JOIN cliente ON agenda.id_FK_cliente = cliente.id_cliente JOIN servico ON agenda.id_FK_servico = servico.id_servico order by agenda.hora DESC";

                query = new SqlCommand(consulta, conexao);

                query.Connection = conexao;
                query.CommandText = consulta;

                var test = query.ExecuteReader();

                bool linhas = test.HasRows;

                if (linhas == true)
                {
                    SqlDataAdapter adptador;
                    adptador = new SqlDataAdapter(consulta, conexao);


                    test.Read();
                    int qtd_linhas = test.VisibleFieldCount;
                    for (int i = 0; i < qtd_linhas; i++)
                    {
                        string num = (i+1).ToString();
                        string label1Nae = ("lblNomeFunc1_"+num).ToString();
                        var lblFunci1 = (Label)real_home.FindName(label1Nae);

                        try
                        {

                            var nome = test["Nome Funcionario"].ToString();

                            lblFunci1.Content = nome;
                            


                        }
                        catch
                        {
                            
                        }
                        


                    }
                }


            }
        }


        
        static void SetTextboxSafe()
        {
            
        }

        private void ImgClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnShut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //rctShut.Visibility = Visibility.Visible;
            localShut.Visibility = Visibility.Visible;
        }

        
    }
}
