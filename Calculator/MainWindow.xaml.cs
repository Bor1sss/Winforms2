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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string Example {  get; set; }

        public int Raz {  get; set; }
        

        public bool NewNumb {  get; set; }
        public string[] NumbsString {  get; set; }

        

        public char? Operator {  get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Raz = 0;
            NewNumb = false;
            NumbsString = new string[3];
    
            Example = "";
        }
        private void PrintExample()
        {
           

            Text1.Text = Example;
            
        }

        private void PrintCurrentNumb()
        {
            Text2.Text = NumbsString[2];
        }
        private void bt1_Click(object sender, RoutedEventArgs e)
        {


            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '1';
            PrintCurrentNumb();


        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '2';
            PrintCurrentNumb();


        


        }

        private void btPlus_Click(object sender, RoutedEventArgs e)
        {

           
            Operator = '+';
            NewNumb = true;
            NumbsString[0] = NumbsString[2];
            
            Example = NumbsString[0] + Operator;

           

            PrintExample();
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '3';
            PrintCurrentNumb();

        }

        private void btEqual_Click(object sender, RoutedEventArgs e)
        {
            double Result=0;
            if (Operator != null)
            {
                Example= NumbsString[0] + Operator;
                Example += NumbsString[2];
                Example += '=';
               

                PrintExample();
                switch (Operator)
                {

                    case '+':
                   
                      
                       Result = Convert.ToDouble(NumbsString[0]) + Convert.ToDouble(NumbsString[2]);

                       NumbsString[2] = Result.ToString();
                    
                      break;
                    case '-':


                        Result = Convert.ToDouble(NumbsString[0]) - Convert.ToDouble(NumbsString[2]);

                        NumbsString[2] = Result.ToString();

                        break;
                    case '*':


                        Result = Convert.ToDouble(NumbsString[0]) * Convert.ToDouble(NumbsString[2]);

                        NumbsString[2] = Result.ToString();

                        break;

                    case '/':

                        try
                        {
                            Result = Convert.ToDouble(NumbsString[0]) / Convert.ToDouble(NumbsString[2]);

                            NumbsString[2] = Result.ToString();
                        }
                        catch {
                            Text2.Text = "Infinity";
                        }
                        break;



                    default:
                        break;


                    }
                PrintCurrentNumb();
               
            }
            }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '4';
            PrintCurrentNumb();

        }

        private void bt5_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '5';
            PrintCurrentNumb();

        }

        private void bt6_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
                NewNumb = false;
            }
            NumbsString[2] += '6';
            PrintCurrentNumb();

        }

        private void bt7_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '7';
            PrintCurrentNumb();

        }

        private void bt8_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '8';
            PrintCurrentNumb();

        }

        private void bt9_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '9';
            PrintCurrentNumb();

        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {

            NumbsString[2] = "";
            PrintCurrentNumb();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Example = "";
            NumbsString[0] = "";
            NumbsString[1] = "";
            NumbsString[2] = "";
            Text1.Clear();
            Text2.Clear();
        }

        private void btMulti_Click(object sender, RoutedEventArgs e)
        {
            Operator = '*';
            NewNumb = true;
            NumbsString[0] = NumbsString[2];
            NumbsString[2] = "";
            Example = NumbsString[0] + Operator;



            PrintExample();
        }

        private void btMinus_Click(object sender, RoutedEventArgs e)
        {
            Operator = '-';
            NewNumb = true;
            NumbsString[0] = NumbsString[2];
            NumbsString[2] = "";
            Example = NumbsString[0] + Operator;



            PrintExample();
        }

        private void btDot_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += ',';
            PrintCurrentNumb();
        }

        private void SLASH_Click(object sender, RoutedEventArgs e)
        {
            Operator = '/';
            NewNumb = true;
            NumbsString[0] = NumbsString[2];
            NumbsString[2] = "";
            Example = NumbsString[0] + Operator;



            PrintExample();
        }

        private void bt0_Click(object sender, RoutedEventArgs e)
        {
            if (NewNumb)
            {
                NumbsString[2] = "";
                NewNumb = false;
            }
            NumbsString[2] += '0';
            PrintCurrentNumb();
        }

        private void LT_Click(object sender, RoutedEventArgs e)
        {
           NumbsString[2]=NumbsString[2].Remove(NumbsString.Length-1);
        }
    }
 }
