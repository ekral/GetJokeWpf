using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2
{
    public class MujCommand : ICommand
    {
        private Action<object> _execute;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Execute start");

            _execute(parameter);

            System.Diagnostics.Debug.WriteLine("Execute Joke end");

        }

        public MujCommand(Action<object> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }
    }
}
