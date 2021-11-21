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

namespace inheritance
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Gadget> techList = new List<Gadget>();
        public MainWindow()
        {
            InitializeComponent();
            Sum();
        }
        protected void fill_Click(object sender, RoutedEventArgs e)
        {
            techList.Clear();
            var rnd = new Random();
            for(byte i=0; i < 15; i++)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        techList.Add(new Laptop());
                        break;
                    case 1:
                        techList.Add(new Smartphone());
                        break;
                    case 2:
                        techList.Add(new Tablet());
                        break;
                }
            }
            Sum();
        }
        protected void Sum()
        {
            list.Text = string.Empty;
            byte phones = 0, laptops = 0, tablets = 0;
            foreach(var tech in techList)
            {
                if(tech is Laptop)
                {
                    laptops++;
                    list.Text += $"ноутбук №{laptops}\n";
                }
                else if(tech is Tablet)
                {
                    tablets++;
                    list.Text += $"планшет №{tablets}\n";
                }
                else if(tech is Smartphone)
                {
                    phones++;
                    list.Text += $"телефон №{phones} \n";
                }
            }
            infoBox.Text = $"ноутбуков {laptops}  планшетов {tablets}  смартфонов {phones}";
        }
        private void Take_Click(object sender, RoutedEventArgs e)
        {
            if (this.techList.Count == 0)
            {
                infoBox.Text = "Автомат пуст";
                Images.Source = null;
                takeInfoBox.Text = "";
            }
            else
            {
                
                takeInfoBox.Text = this.techList[0].getInfo();
                string nameOfGadget = techList[0] is Smartphone ? "Phone" : techList[0] is Laptop ? "Laptop" : "Tablet";
                Images.Source = new BitmapImage(new Uri($@"C:\Users\reven\Source\Repos\inheritance\inheritance\{nameOfGadget}.jpg"));
                this.techList.RemoveAt(0);
                Sum();
            }
        }
    }
}
