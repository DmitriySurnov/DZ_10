using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Zadanie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private new readonly Dictionary<string, MenuItem> Language = new Dictionary<string, MenuItem>();
        public MainWindow()
        {
            InitializeComponent();
            Language.Add("en", PM_1_3_2);
            Language.Add("ru", PM_1_3_1);
            Language.Add("es", PM_1_3_3);
            Language_Changed(Thread.CurrentThread.CurrentUICulture.Parent.ToString());
        }
        private void Language_Changed(string s)
        {
            Title = Lengs.Title;
            PM_1.Header = Lengs.PM_1;
            PM_2.Header = Lengs.PM_2;
            PM_1_1.Header = Lengs.PM_1_1;
            PM_1_2.Header = Lengs.PM_1_2;
            PM_1_3.Header = Lengs.PM_1_3;
            PM_1_4.Header = Lengs.PM_1_4;
            PM_1_5.Header = Lengs.PM_1_5;
            PM_1_3_1.Header = Lengs.PM_1_3_1;
            PM_1_3_2.Header = Lengs.PM_1_3_2;
            PM_1_3_3.Header = Lengs.PM_1_3_3;
            foreach (var el in Language)
                el.Value.IsEnabled = (el.Key != s) ? true : false;
        }

        private void PM_1_3_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            foreach (var el in Language)
                if ((MenuItem)sender == el.Value)
                    s = el.Key;
            if (s.Length == 0)
                return;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(s);
            Language_Changed(s);
        }
    }
}
