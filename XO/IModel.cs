using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public interface IModel
    {


        bool isPossible { get; set; }
        bool isPlayer1 { get; set; }

         bool? isWin { get; set; }
         int[] cords { get; set; }
         char[,] field { set; get; }
         void Reset();
         void GameStart();
         void CheckForWin();
    }

    public class ModelXo : IModel
    {
    
        public bool isPossible {  get; set; }
        public bool? isWin { set; get; }
        public bool isPlayer1 { get; set; }
        public char[,] field { set; get; }
        public int[] cords { set; get; }

        public ModelXo(bool p)
        {
            field = new char[3, 3];
            isPlayer1 = p;
            cords = new int[2];
            isWin = false;
            for (int i = 0,k=0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = k.ToString()[0];
                    k++;
                }
            }
        }
        public void Reset()
        {
            cords = new int[2];
            isPlayer1 = true;
            field = new char[3, 3];
            isWin = false;
        }
        public void GameStart()
        {
            CheckForWin();

            if (isPlayer1)
            {
                field[cords[0], cords[1]] = 'X';
                isPlayer1 = !isPlayer1;
            }
            else
            {
                field[cords[0], cords[1]] = 'O';
                isPlayer1 = !isPlayer1;
            }
            CheckForWin();
        }
        bool CheckForPossibility()
        {

            for (int i = 0, k = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == k.ToString()[0])
                    {
                        isPossible = true;
                        return true;
                    }
                    else
                    {
                        isPossible = false;
                        
                    }
                    k++;
                }
            }
            return false;
        }
        public void CheckForWin()
        {
           
            if (isPossible)
            {
                //Horizontal
                if (field[0, 0] == field[0, 1] && field[0, 0] == field[0, 2])
                {
                    isWin = true;
                }
                else if ((field[1, 0] == field[1, 1] && field[1, 0] == field[1, 2]))
                {
                    isWin = true;
                }
                else if ((field[2, 0] == field[2, 1] && field[2, 0] == field[2, 2]))
                {
                    isWin = true;
                }
                //Vertical
                else if ((field[0, 0] == field[1, 0] && field[1, 0] == field[2, 0]))
                {
                    isWin = true;
                }
                else if ((field[0, 1] == field[1, 1] && field[1, 1] == field[2, 1]))
                {
                    isWin = true;
                }
                else if ((field[0, 2] == field[1, 2] && field[1, 2] == field[2, 2]))
                {
                    isWin = true;
                }
                //cross
                else if (field[0, 0] == field[1, 1] && field[0, 0] == field[2, 2])
                {
                    isWin = true;
                }
                else if (field[2, 0] == field[1, 1] && field[2, 0] == field[0, 2])
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                }
            }
            else
            {
                isWin = null;
            }
            CheckForPossibility();
        }


    }

}
