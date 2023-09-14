using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XO
{
    public interface AiModel
    {
         char[,] field { get; set; }

         bool isOn {  get; set; }
         bool isAiMove { get; set; }
         int X { get; set; }
         int Y { get; set; }
         void GenerateMove();

    }
    public class AiXO:AiModel
    {
        public bool isOn { get; set; }
        public bool isAiMove { get; set; }
        public char[,] field { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public AiXO(bool isOn)
        {
            this.isOn = isOn;
        }

        
        public void GenerateMove()
        {
            bool GenerateRandom = false;
            if (field[0, 0] == field[0, 1])
            {
                if (field[0, 2] != 'O'&& field[0,2]!='X')
                {
                    X=0; Y=2;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[0, 1] == field[0, 2])
            {
                if (field[0, 0] != 'O' && field[0,0] != 'X')
                {
                    X = 0; Y = 0;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[0, 0] == field[0, 2])
            {
                if (field[0, 1] != 'O' && field[0, 1] != 'X')
                {
                    X = 0; Y = 1;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[1, 0] == field[1, 1])
            {
                if (field[1, 2] != 'O' && field[1, 2] != 'X')
                {
                    X = 1; Y = 2;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[1, 1] == field[1, 2])
            {
                if (field[1, 0] != 'O' && field[1, 0] != 'X')
                {
                    X = 1; Y = 0;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[1, 0] == field[1, 2])
            {
                if (field[1, 1] != 'O' && field[1, 1] != 'X')
                {
                    X = 1; Y = 1;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[2, 0] == field[2, 1])
            {
                if (field[2, 2] != 'O' && field[2, 2] != 'X')
                {
                    X = 2; Y = 2;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[2, 1] == field[2, 2])
            {
                if (field[2, 0] != 'O' && field[2, 0] != 'X')
                {
                    X = 2; Y = 0;
                }
                else
                {
                    GenerateRandom = true;
                }
            }
            else if (field[2,0] == field[2, 2])
            {
                if (field[2, 1] != 'O' && field[2, 1] != 'X')
                {
                    X = 2; Y = 1;
                }
                { GenerateRandom = true; }
            }

            // Проверка вертикалей
            else if (field[0, 0] == field[1, 0])
            {
                if (field[2, 0] != 'O' && field[2,0]!='X')
                {
                    X = 2; Y = 0;
                }
                else { GenerateRandom = true; }
            }
            else if (field[1, 0] == field[2, 0])
            {
                if (field[0, 0] != 'O' && field[0, 0] != 'X')
                {
                    X = 0; Y = 0;
                }
                else { GenerateRandom = true; }
            }
            else if (field[0, 0] == field[2, 0])
            {
                if (field[1, 0] != 'O' && field[1, 0] != 'X')
                {
                    X = 1; Y = 0;
                }
                else { GenerateRandom = true; }
            }


            else if (field[0, 1] == field[1, 1])
            {
                if (field[2, 1] != 'O' && field[2, 1] != 'X')
                {
                    X = 2; Y = 1;
                }
                else { GenerateRandom = true; }
            }
            else if (field[1, 1] == field[2, 1])
            {
                if (field[0, 1] != 'O' && field[0, 1] != 'X')
                {
                    X = 0; Y = 1;
                }
                else { GenerateRandom = true; }
            }
            else if (field[0, 1] == field[2, 1])
            {
                if (field[1, 1] != 'O' && field[1, 1] != 'X')
                {
                    X = 1; Y = 1;
                }
                else { GenerateRandom = true; }
            }

            else if (field[0, 2] == field[1, 2])
            {
                if (field[2, 2] != 'O' && field[2, 2] != 'X')
                {
                    X = 2; Y = 2;
                }
                    else { GenerateRandom = true; }
            }
            else if (field[1, 2] == field[2, 2])
            {
                if (field[0, 2] != 'O' && field[0, 2] != 'X')
                {
                    X = 0; Y = 2;
                }
                else { GenerateRandom = true; }
            }
            else if (field[0, 2] == field[2, 2])
            {
                if (field[1, 2] != 'O' && field[1, 2] != 'X')
                {
                    X = 1; Y = 2;
                }
                else { GenerateRandom = true; }
            }
            // Проверка диагоналей
            else if (field[0, 0] == field[1, 1])
            {
                if (field[2, 2] != 'O' && field[2, 2] != 'X')
                {
                    X = 2; Y = 2;
                }
                    else { GenerateRandom = true; }
            }
            else if (field[1, 1] == field[2, 2])
            {
                if (field[0, 0] != 'O' && field[0, 0] != 'X')
                {
                    X = 0; Y = 0;
                }
                else { GenerateRandom = true; }
            }
            else if (field[0, 0] == field[2, 2])
            {
                if (field[1, 1] != 'O' && field[1, 1] != 'X')
                {
                    X = 1; Y = 1;
                }
                else { GenerateRandom = true; }
            }

            else if (field[0, 2] == field[1, 1])
            {
                if (field[2, 0] != 'O' && field[2, 0] != 'X')
                {
                    X = 2; Y = 0;
                }
                else { GenerateRandom = true; }
            }
            else if (field[1, 1] == field[2, 0])
            {
                if (field[0, 2] != 'O' && field[0, 2] != 'X')
                {
                    X = 0; Y = 2;
                    GenerateRandom = true;
                }
                else { GenerateRandom = true; }
            }
            else if (field[2, 0] == field[0, 2])
            {
                if (field[1, 1] != 'O' && field[1, 1] != 'X')
                {
                    X = 1; Y = 1;
                    
                }
                else { GenerateRandom = true; }
            }
            else
            {
                GenerateRandom = true;
            }

            if (GenerateRandom)
            {
                while (true)
                {
                    Random random = new Random();
                    X = random.Next(0, 2);
                    Y = random.Next(0, 2);
                    if (field[X, Y] != 'O' && field[X, Y] != 'X')
                    {
                        break;
                    }
                }
            }
            
        }

    }
}
