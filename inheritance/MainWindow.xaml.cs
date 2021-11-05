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
        private void fill_Click(object sender, RoutedEventArgs e)
        {
            techList.Clear();
            var rnd = new Random();
            for(byte i=0; i < 15; i++)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        techList.Add(new Laptops());
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
            byte phones = 0, laptops = 0, tablet = 0;
            foreach(var tech in techList)
            {
                if(tech is Laptops)
                {
                    laptops++;
                }
                else if(tech is Tablet)
                {
                    tablet++;
                }
                else if(tech is Smartphone)
                {
                    phones++;
                }
            }
            infoBox.Text = $"кол-во ноутбуков {laptops} кол-во планшетов {tablet} кол-во смартфонов {phones}";
        }
        private void Take_Click(object sender, RoutedEventArgs e)
        {
            if (this.techList.Count == 0)
            {
                infoBox.Text = "Автомат пуст";
            }
            else
            {
                var temp = this.techList[0];
                this.techList.RemoveAt(0);
                takeInfoBox.Text = temp.getInfo();
                Sum();
            }
        }
    }
}
