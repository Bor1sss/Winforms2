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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool IsPossible {  get; set; }
        public int[,] MatrixGame { get; set; }
        public Border[,] borders { get; set; }

        public int _Score {  get; set; }
        public int _HighScore {  get; set; }
        public TextBlock[,] textBlocks { get; set; }
        public SolidColorBrush[] solidBrush { get; set; }
        public MainWindow()
        {
            InitializeComponent(); 

            IsPossible = true;
            borders = new Border[4,4];
            textBlocks = new TextBlock[4,4];


            solidBrush = new SolidColorBrush[12];

            solidBrush[0] = new SolidColorBrush(Colors.LightGray); // Серый (фон)
            solidBrush[1] = new SolidColorBrush(Color.FromRgb(238, 228, 218)); // Бежевый (плитки с числом 2)
            solidBrush[2] = new SolidColorBrush(Color.FromRgb(237, 224, 200)); // Оранжевый (плитки с числом 4)
            solidBrush[3] = new SolidColorBrush(Color.FromRgb(242, 177, 121)); // Красный (плитки с числом 8)
            solidBrush[4] = new SolidColorBrush(Color.FromRgb(245, 149, 99));  // Светло-фиолетовый (плитки с числом 16)
            solidBrush[5] = new SolidColorBrush(Color.FromRgb(246, 124, 95));  // Синий (плитки с числом 32)
            solidBrush[6] = new SolidColorBrush(Color.FromRgb(124, 252, 0));  // Салатовый (плитки с числом 64)
            solidBrush[7] = new SolidColorBrush(Color.FromRgb(178, 34, 34));  // Коричневый (плитки с числом 128)
            solidBrush[8] = new SolidColorBrush(Color.FromRgb(139, 69, 19));  // Темно-коричневый (плитки с числом 256)
            solidBrush[9] = new SolidColorBrush(Color.FromRgb(0, 128, 0));    // Темно-зеленый (плитки с числом 512)
            solidBrush[10] = new SolidColorBrush(Color.FromRgb(128, 0, 128)); // Фиолетовый (плитки с числом 1024)
            solidBrush[11] = new SolidColorBrush(Color.FromRgb(0, 0, 128));

            borders[0,0] = A00;
            borders[0,1] = A01;
            borders[0,2] = A02;
            borders[0,3] = A03;

            borders[1,0] = A10;
            borders[1,1] = A11;
            borders[1,2] = A12;
            borders[1,3] = A13;

            borders[2, 0] = A20;
            borders[2, 1] = A21;
            borders[2, 2] = A22;
            borders[2, 3] = A23;

            borders[3, 0] = A30;
            borders[3, 1] = A31;
            borders[3, 2] = A32;
            borders[3, 3] = A33;

            textBlocks[0, 0] = T00;
            textBlocks[0, 1] = T01;
            textBlocks[0, 2] = T02;
            textBlocks[0, 3] = T03;

            textBlocks[1, 0] = T10;
            textBlocks[1, 1] = T11;
            textBlocks[1, 2] = T12;
            textBlocks[1, 3] = T13;

            textBlocks[2, 0] = T20;
            textBlocks[2, 1] = T21;
            textBlocks[2, 2] = T22;
            textBlocks[2, 3] = T23;

            textBlocks[3, 0] = T30;
            textBlocks[3, 1] = T31;
            textBlocks[3, 2] = T32;
            textBlocks[3, 3] = T33;

            Score.Text = "Score \n";
            HighScore.Text = "High Score \n";

            MatrixGame = new int[4, 4];
            Array.Clear(MatrixGame, 0, 16);




        }
        private void GenerateNumb()
        {
            Random random = new Random();
            int result = random.Next(0,100);
            bool flagCorrect = false;
            int i=0;
            int j=0;

            bool isPossible = false;
            foreach (var item in MatrixGame)
            {
                if (item == 0)
                {
                    isPossible = true;
                }
            }
            if (isPossible)
            {
                do
                {

                    i = random.Next(0, 4);
                    j = random.Next(0, 4);
                    if (MatrixGame[i, j] == 0)
                    {
                        flagCorrect = false;
                    }
                    else
                    {
                        flagCorrect = true;
                    }
                } while (flagCorrect);
            }

            if(result <= 10) {

                MatrixGame[i,j] = 4;
            }
            else
            {
                MatrixGame[i,j] = 2;
            }

        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            CheckForPossibility(MatrixGame);
            ClearMatrix();
            
            switch (e.Key)
            {
               
                case Key.Left:
                    GenerateNumb();
                    SumNeighborDuplicatesLeft4x4(MatrixGame);
                    SortLeft4x4(MatrixGame);
                    break;
                case Key.Up:
                    GenerateNumb();
                    SumNeighborDuplicatesUp4x4(MatrixGame);
                    SortUp4x4(MatrixGame);
                    break;
                case Key.Right:
                    GenerateNumb();
                    SumNeighborDuplicatesRight4x4(MatrixGame);
                    SortRight4x4(MatrixGame);
                    break;
                case Key.Down:
                    GenerateNumb();
                    SumNeighborDuplicatesDown4x4(MatrixGame);
                    SortDown4x4(MatrixGame);
                    break;
                default:
                    break;
            }
            DrawMatrix();
            
        }


       
        private void DrawMatrix()
        {
            _Score = 0;
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _Score += MatrixGame[i, j];
                    if (MatrixGame[i, j] != 0)
                    {
                        textBlocks[i, j].Text = MatrixGame[i, j].ToString();
                        switch (MatrixGame[i,j])
                        {
                       
                            case 2:
                                borders[i, j].Background = solidBrush[1]; break;
                            case 4:
                                borders[i, j].Background = solidBrush[2]; break;
                            case 8:
                                borders[i, j].Background = solidBrush[3]; break;
                            case 16:
                                borders[i, j].Background = solidBrush[4]; break;
                            case 32:
                                borders[i, j].Background = solidBrush[5]; break;
                            case 64:
                                borders[i, j].Background = solidBrush[6]; break;
                            case 128:
                                borders[i, j].Background = solidBrush[7]; break;
                            case 256:
                                borders[i, j].Background = solidBrush[8]; break;
                            case 512:
                                borders[i, j].Background = solidBrush[9]; break;

                            case 1024:
                                borders[i, j].Background = solidBrush[10]; break;
                            case 2048:
                                borders[i, j].Background = solidBrush[11]; break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        borders[i, j].Background = solidBrush[0];
                    }
                }
            }
            Score.Text = $"Score \n {_Score}";
            if (_HighScore < _Score)
            {
                _HighScore = _Score;
              
            }
            HighScore.Text = $"HighScore \n {_HighScore}";
        }

        private void ClearMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    textBlocks[i, j].Text = "";
                }
            }
        }

        //left
        private void SumNeighborDuplicatesLeft4x4(int[,] array)
        {

            for (int j = 0; j < 4; j++)
            {


                for (int i = 1, k = 0; i <= 3; i++)
                {
                    if (array[j, k] != array[j, i] && array[j, i] != 0)
                    {
                        k++;
                        
                    }

                    else if (array[j, k] == array[j, i])
                    {
                        array[j, k] += array[j, i];
                        array[j, i] = 0;
                        k++;
                    }


                }
            }
        }

        //right
        private void SumNeighborDuplicatesRight4x4(int[,] array)
        {

            for (int j = 0; j < 4; j++)
            {


                for (int i = 2, k = 3; i >= 0; i--)
                {
                    if (array[j, k] != array[j, i] && array[j, i] != 0)
                    {
                        k--;
                    }

                    else if (array[j, k] == array[j, i])
                    {
                        array[j, k] += array[j, i];
                        array[j, i] = 0;
                        k--;
                    }


                }
            }
        }

        //up
        private void SumNeighborDuplicatesUp4x4(int[,] array)
        {
            for (int j = 0; j < 4; j++)
            {


                for (int i = 1, k = 0; i <= 3; i++)
                {
                    if (array[k, j] != array[i, j] && array[i, j] != 0)
                    {
                        k++;
                    }

                    else if (array[k, j] == array[i, j])
                    {
                        array[k, j] += array[i, j];
                        array[i, j] = 0;
                        k++;
                    }


                }
            }


        }


        //down
        private void SumNeighborDuplicatesDown4x4(int[,] array)
        {

            for (int j = 0; j < 4; j++)
            {


                for (int i = 2, k = 3; i >= 0; i--)
                {
                    if (array[k, j] != array[i, j] && array[i, j] != 0)
                    {
                        k--;
                    }

                    else if (array[k, j] == array[i, j])
                    {
                        array[k, j] += array[i, j];
                        array[i, j] = 0;
                        k--;
                    }


                }
            }
        }


        //SortDown
        private void SortDown4x4(int[,] array)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 2, k = 3; i >= 0; i--)
                {
                    if (array[k, j] == 0)
                    {
                        for (int z = k; z >= 0; z--)
                        {
                            if (array[z, j] != 0)
                            {
                                array[k, j] = array[z, j];
                                array[z, j] = 0;
                                k--;
                                break;
                            }
                        }
                    }
                    else
                    {
                        k--;
                    }

                }
            }
        }



        //SortUp
        private void SortUp4x4(int[,] array)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 1, k = 0; i <= 3; i++)
                {
                    if (array[k, j] == 0)
                    {
                        for (int z = k; z <4; z++)
                        {
                            if (array[z, j] != 0)
                            {
                                array[k, j] = array[z, j];
                                array[z, j] = 0;
                                k++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        k++;
                    }

                }
            }
        }


        //SortRight
        private void SortRight4x4(int[,] array)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 2, k = 3; i >= 0; i--)
                {
                    if (array[j, k] == 0)
                    {
                        for (int z = k; z >= 0; z--)
                        {
                            if (array[j, z] != 0)
                            {
                                array[j, k] = array[j, z];
                                array[j, z] = 0;
                                k--;
                                break;
                            }
                        }
                    }
                    else
                    {
                        k--;
                    }

                }
            }
        }


        //SortLeft
        private void SortLeft4x4(int[,] array)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 1, k = 0; i <= 3; i++)
                {
                    if (array[j, k] == 0)
                    {
                        for (int z = k; z < 4; z++)
                        {
                            if (array[j, z] != 0)
                            {
                                array[j, k] = array[j, z];
                                array[j, z] = 0;
                                k++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        k++;
                    }

                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
        
           Reset();
        }

        private void Reset()
        {
            Array.Clear(MatrixGame, 0, 16);
            _Score = 0;
            ClearMatrix();
            DrawMatrix();
        }
        private void CheckForPossibility(int[,]array)
        {
            if (!CanMoveLeft(array)&&!CanMoveRight(array)&&!CanMoveDown(array)&&!CanMoveUp(array))
            {
                MessageBoxResult res = MessageBox.Show("You lose", "Restart?", MessageBoxButton.OKCancel);
                if (res == MessageBoxResult.OK)
                {
                    Reset();
                }
                else
                {
                    this.Close();
                }
            }
        
        }
        //left
        private bool CanMoveLeft(int[,] array)
        {

            for (int j = 0; j < 4; j++)
            {


                for (int i = 1, k = 0; i <= 3; i++)
                {
                    if (array[j, k] != array[j, i] && array[j, i] != 0)
                    {
                        k++;
                        IsPossible = false;
                    }

                    else if (array[j, k] == array[j, i])
                    {
                        IsPossible = true;
                        return true;
                    }


                }
            }
           return false; 
        }

        //right
        private bool CanMoveRight(int[,] array)
        {

            for (int j = 0; j < 4; j++)
            {


                for (int i = 2, k = 3; i >= 0; i--)
                {
                    if (array[j, k] != array[j, i] && array[j, i] != 0)
                    {
                        k--;
                        IsPossible = false;
                    }

                    else if (array[j, k] == array[j, i])
                    {
                     
                        k--;
                        IsPossible = true;
                        return true;
                    }


                }
            }
            return false;
        }

        //up
        private bool CanMoveUp(int[,] array)
        {
            for (int j = 0; j < 4; j++)
            {


                for (int i = 1, k = 0; i <= 3; i++)
                {
                    if (array[k, j] != array[i, j] && array[i, j] != 0)
                    {
                        k++;
                        IsPossible = false;
                    }

                    else if (array[k, j] == array[i, j])
                    {
                       

                        k++;
                        IsPossible = true;
                        return true;
                    }


                }
            }

            return false;
        }


        //down
        private bool CanMoveDown(int[,] array)
        {

            for (int j = 0; j < 4; j++)
            {


                for (int i = 2, k = 3; i >= 0; i--)
                {
                    if (array[k, j] != array[i, j] && array[i, j] != 0)
                    {
                        k--;

                        IsPossible = false;
                    }

                    else if (array[k, j] == array[i, j])
                    {
                
                        k--;
                        IsPossible = true;
                        return true;
                    }


                }
            }
            return false;
        }

    }


















}
