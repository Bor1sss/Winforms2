using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace MathGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public int correct {  get; set; }
        public int[] Numbs {  get; set; }
        public int CurTimeSeconds {  get; set; }
        public int CurTimeMinutes { get; set; }

        public Button[] buttons;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            TextB.Text = "60";
            ScrollBar.Value = 60;
            correct = 0;
            timer.Tick += new EventHandler(timer1_tick);
            buttons = new Button[16];
            buttons[0] = b1;
            buttons[1] = b2;
            buttons[2] = b3;
            buttons[3] = b4;
            buttons[4] = b5;
            buttons[5] = b6;
            buttons[6] = b7;
            buttons[7] = b8;
            buttons[8] = b9;
            buttons[9] = b10;
            buttons[10] = b11;
            buttons[11] = b12;
            buttons[12] = b13;
            buttons[13] = b14;
            buttons[14] = b15;
            buttons[15] = b16;
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }

        }

        private async void timer1_tick(object sender, EventArgs e)
        {

            CurTimeSeconds--;
            if (CurTimeMinutes==0 && CurTimeSeconds==0)
            {
                NewGame.IsEnabled = true;
                ScrollBar.IsEnabled = true;
                timer.Stop();
                MessageBox.Show("You Lose");
                ClearEverything();
         
            }
            if (CurTimeSeconds < 0)
            {
                CurTimeSeconds = 59;
                CurTimeMinutes--;
            }

            

            Window1.Title = $"{(CurTimeMinutes)} : {(CurTimeSeconds)}";
           

        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b1);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b2);
        }

  
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b3);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b4);
        }
        private void b5_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b5);
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b6);
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b7);
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b8);
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b9);
        }

        private void b10_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b10);
        }

        private void b11_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b11);
        }

        private void b12_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b12);
        }

        private void b13_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b13);
        }

        private void b14_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b14);
        }

        private void b15_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b15);
        }

        private void b16_Click(object sender, RoutedEventArgs e)
        {
            CheckForCorrect(b16);
        }


        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
       
            CurTimeSeconds = (int)e.NewValue;
            TextB.Text = CurTimeSeconds.ToString();

           

        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            
            
            CurTimeSeconds=(int)ScrollBar.Value;
            ScrollBar.IsEnabled = false;
            NewGame.IsEnabled = false;


            CurTimeMinutes=CurTimeSeconds/60;
            CurTimeSeconds = CurTimeSeconds - CurTimeMinutes * 60;


            timer.Stop();
            timer.Start();
            Numbs = new int[16];
            Random random = new Random();
            int randomNumb;
            for (int i = 0; i < Numbs.Length; i++)
            {
                do 
                {
                    randomNumb = random.Next(0, 100);
                  

                } while (Numbs.Contains(randomNumb));
                Numbs[i] = randomNumb;
                buttons[i].Content = Numbs[i];
                buttons[i].IsEnabled = true;




            }

            int n = Numbs.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Numbs[j] > Numbs[j + 1])
                    {
                        Button tempButton = buttons[j];
                        buttons[j] = buttons[j + 1];
                        buttons[j + 1]= tempButton;

                        int temp = Numbs[j];
                        Numbs[j] = Numbs[j + 1];
                        Numbs[j + 1] = temp;



                        swapped = true;
                    }
                }

                
                if (!swapped)
                    break;
            }

          



        }

        private void CheckForCorrect(Button bt)
        {
            if (buttons[correct] == bt)
            {

                buttons[correct].IsEnabled = false;
                ListBox.Items.Add(Numbs[correct]);
                correct++;
                ProgBar.Value = correct;
                
            }
            if (correct == 16) {

                MessageBoxResult res = MessageBox.Show("YOu win");
                correct= 0;
                ProgBar.Value = 0;
                timer.Stop();
               
                ClearEverything();

            }
        }

     
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StartNew_Click(object sender, RoutedEventArgs e)
        {
            ClearEverything();
        }

        private void ClearEverything()
        {
            correct = 0;
            ScrollBar.IsEnabled = true;
            NewGame.IsEnabled = true;
            ProgBar.Value = 0;
            foreach (var item in buttons)
            {
                item.Content = null;
                item.IsEnabled = false;
            }
            ListBox.Items.Clear();
            ScrollBar.IsEnabled = true;
            NewGame.IsEnabled = true;
            timer.Stop();
        }
    }
}
