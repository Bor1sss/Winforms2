using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
   
    public interface View
    {

        int[] cords { set; get; }
        bool isPlayer { set; get; }
        event EventHandler<EventArgs>Changes;

        void ShowWinMessage();
        void ShowLoseMessage();
        void EmulateButtonClick(int x, int y);

        void ShowText(string s);

    }
}
