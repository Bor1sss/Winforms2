using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Final_Gallery.Commands
{
    public class Command : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;
        protected internal object sender;
        private Action<Point> moveImage;
        private Func<bool> canMoveImage;

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public Command(Action<Point> moveImage, Func<bool> canMoveImage)
        {
            this.moveImage = moveImage;
            this.canMoveImage = canMoveImage;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            sender = parameter;
            _execute(parameter);
        }


    }
}
