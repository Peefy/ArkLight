using System;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace ArkLight.Mvvm
{
    public class Command : ICommand
    {
        private readonly Func<object, bool> _canExecute;

        private readonly Action<object> _execute;

        [method: CompilerGenerated]
        [CompilerGenerated]
        public event EventHandler CanExecuteChanged;

        public Command(Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this._execute = execute;
        }

        public Command(Action execute) : this(delegate (object o)
        {
            execute();
        })
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
        }

        public Command(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
            this._canExecute = canExecute;
        }

        public Command(Action execute, Func<bool> canExecute) : this(delegate (object o)
        {
            execute();
        }, (object o) => canExecute())
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        public void ChangeCanExecute()
        {
            EventHandler expr_06 = this.CanExecuteChanged;
            if (expr_06 == null)
            {
                return;
            }
            expr_06(this, EventArgs.Empty);
        }
    }
}
