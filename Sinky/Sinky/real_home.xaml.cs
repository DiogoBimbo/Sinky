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
    /// Interaction logic for real_home.xaml
    /// </summary>
    public partial class real_home : UserControl
    {
        public real_home()
        {
            InitializeComponent();
            
            //Hora
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            //Banco de dados

            

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblHora.Content = DateTime.Now.ToShortTimeString();
            //Data
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string ano = DateTime.Now.Year.ToString();
            string allDate = dia + '/' + mes + '/' + ano;
            lblDate.Content = allDate;
        }
    }
}
