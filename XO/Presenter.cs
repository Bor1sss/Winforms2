using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public class Presenter
    {
        private readonly IModel _model;
        private readonly View _view;
        private readonly AiModel _aiModel;
       

        public Presenter(IModel model, View view,AiModel aiModel)
        {
            _model = model;
            _view = view;
            _aiModel = aiModel;
            _aiModel.isAiMove= true; 
            _view.isPlayer = _model.isPlayer1;
            _view.Changes += new EventHandler<EventArgs>(GameStart);
        
        }
        private void GameStart(object sender, EventArgs e)
        {
          

            if (_aiModel.isOn == false)
            {
                _model.cords = _view.cords;
                _model.GameStart();
                _view.isPlayer = _model.isPlayer1;
                if (_model.isWin == false)
                {


                }
                else if (_model.isWin == true)
                {

                    _view.ShowWinMessage();
                    _model.Reset();
                }
                else
                {
                    _view.ShowLoseMessage();
                    _model.Reset();
                }

            }
            else
            {

                _model.cords = _view.cords;
             
                if(_model.isWin==false)
                {
                    
                    _model.GameStart();
                    _view.isPlayer = _model.isPlayer1;

                    _aiModel.field = _model.field;
                    _aiModel.GenerateMove();

                    _model.cords[0] = _aiModel.X;
                    _model.cords[1] = _aiModel.Y;
                    _aiModel.isAiMove = false;
                    _view.EmulateButtonClick(_aiModel.X, _aiModel.Y);

                    _model.GameStart();

                    _view.isPlayer = _model.isPlayer1;

                    string a = "";
                    foreach (var item in _model.field)
                    {
                        a += item;
                    }
                    _view.ShowText(a);

                } 
                if (_model.isWin == true)
                {

                    _view.ShowWinMessage();
                    _model.Reset();
                }
                else if(!_model.isPossible)
                {
                    _view.ShowLoseMessage();
                    _model.Reset();
                }
            }
        }
    }

}
