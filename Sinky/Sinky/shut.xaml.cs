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

namespace Sinky
{
    /// <summary>
    /// Interaction logic for shut.xaml
    /// </summary>
    public partial class shut : UserControl
    {
        public shut()
        {
            InitializeComponent();
        }

        private void GridLogOff_MouseDown(object sender, MouseButtonEventArgs e)
        {
            funcClose logoff = new funcClose();
            logoff.FecharApp();
        }
    }
}
