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

namespace TimedShutdown
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ev_0(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 0;
        }

        private void Ev_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 1;
        }

        private void Ev_2(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 2;
        }

        private void Ev_3(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 3;
        }

        private void Ev_4(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 4;
        }

        private void Ev_5(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 5;
        }

        private void Ev_6(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 6;
        }

        private void Ev_7(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 7;
        }

        private void Ev_8(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 8;
        }

        private void Ev_9(object sender, RoutedEventArgs e)
        {
            textBox1.Text += 9;
        }

        private void Ev_Del(object sender, RoutedEventArgs e)
        {
            string content = textBox1.Text;

            try
            {
                content = content.Remove(content.Length - 1);
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            
            textBox1.Text = content;
        }


        private void Ev_OK(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                /*
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C shutdown -s -t 0";
                process.StartInfo = startInfo;
                process.Start();
                
                string lul = "/C shutdown -s -t 0" ;
                Console.WriteLine(lul);
                */

                Console.WriteLine("Leer");
            }
            else
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C shutdown -s -t " + textBox1.Text;
                process.StartInfo = startInfo;
                process.Start();
                /*
                string lul = "/C shutdown -s -t " + textBox1.Text;
                Console.WriteLine(lul);
                Console.WriteLine(textBox1.Text);
                */
            }
        }
    }
}
