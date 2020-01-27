using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        string path = System.AppDomain.CurrentDomain.BaseDirectory + "/date.txt";
        DateTime dt;
        public MainWindow()
        {
            InitializeComponent();
            if (System.IO.File.Exists(path))
            {
                dt = DateTime.Parse(File.ReadAllText(path));
            }
            var aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
            
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                TimeSpan t = dt.Subtract(DateTime.Now);
                Console.WriteLine(t);
                if (System.IO.File.Exists(path))
                {
                    if (t.CompareTo(TimeSpan.Zero) < 0)
                    {
                        TimeRemaining.Content = "Last shutdown is done.";
                    }
                    else
                    {
                        string format = @"dd\:hh\:mm\:ss";
                        TimeRemaining.Content = t.ToString(format);
                    }
                    
                }
                else
                {
                    TimeRemaining.Content = "No shutdown scheduled!";
                }

            });
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
                if (IsValid(textBox1.Text))
                {
                    long timeconvert;
                    if (minutesRadio.IsChecked == true)
                    {
                        timeconvert = Int64.Parse(textBox1.Text) * 60;
                    }
                    else if (hoursRadio.IsChecked == true)
                    {
                        timeconvert = Int64.Parse(textBox1.Text) * 3600;
                    }
                    else
                    {
                        timeconvert = Int64.Parse(textBox1.Text);
                    }
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C shutdown -s -t " + timeconvert.ToString();
                    // startInfo.Arguments = "/C shutdown -s -t " + timeconvert.ToString() + " -c " + timeconvert.ToString();
                    process.StartInfo = startInfo;
                    process.Start();
                    DateTime shutdownTime = DateTime.Now.AddSeconds(timeconvert);
                    dt = shutdownTime;
                    System.IO.File.WriteAllText(path, shutdownTime.ToString("dd/MM/yyyy hh:mm:ss"));
                    Console.WriteLine(shutdownTime.ToString("dd/MM/yyyy hh:mm:ss"));

                    /*
                    string lul = "/C shutdown -s -t " + textBox1.Text;
                    Console.WriteLine(lul);
                    Console.WriteLine(textBox1.Text);
                    */
                }
                else
                {
                    MessageBox.Show("Only numbers are allowed!!", "Error!");
                }
            }
        }

        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i);
        }

        private void Ev_Abort(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C shutdown -a";
            process.StartInfo = startInfo;
            process.Start();

            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (System.IO.IOException ee)
                {
                    Console.WriteLine(ee.Message);
                    return;
                }
            }
        }
    }
}
