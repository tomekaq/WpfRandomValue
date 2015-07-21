using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfRandomValue
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

        public void @do(int amount){
            var rb = new DataAccess();
            for (int i = 0; i < amount; i++)
            {
                rb.Generate();
            }

            var ObservableSet = rb.ModelCollection();
            var list = rb.GenerateSecond(ObservableSet);

            this.DataContext = list;
        }

        private void btnDo_Click(object sender, RoutedEventArgs e)
        {
            int input = int.Parse(inputBox.Text);
            @do(input);
        }
    }
}
