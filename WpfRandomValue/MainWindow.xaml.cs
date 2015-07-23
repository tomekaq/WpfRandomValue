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

        public void @do(int maxValue,int amount){
            var rb = new DataAccess();
            rb.CleanTable();
            for (int i = 0; i < amount; i++)
            {
                rb.Generate(maxValue);
            }

            var ObservableSet = rb.ModelCollection();
            var list = rb.GenerateSecond(ObservableSet);

            this.DataContext = list;
        }

        private void btnDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int maxValue = int.Parse(inputBox1.Text);
                int amount = int.Parse(inputBox2.Text);
                if ((maxValue != 0) && (amount != 0))
                    @do(maxValue, amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podaj maxValue");
            }
        }
    }
}
