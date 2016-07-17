using CourseWork_TaskManager.Models;
using CourseWork_TaskManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork_TaskManager
{
    //internal class KillCommand : ICommand
    //{
    //    private IProcessesViewModel _vm;

    //    public KillCommand(IProcessesViewModel viewModel)
    //    {
    //        _vm = viewModel;
    //        //_vm.PropertyChanged += vm_PropertyChanged;
    //    }

    //    private void vm_PropertyChanged(object sender,
    //        PropertyChangedEventArgs e)
    //    {
    //        //if (string.Compare(e.PropertyName,
    //        //                   ProcessesViewModel.
    //        //                   SELECTED_PROJECT_PROPERRTY_NAME)
    //        //    == ARE_EQUAL)
    //        //{
    //        //    CanExecuteChanged(this, new EventArgs());
    //        //}
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        //if (_vm.SelectedProject == null)
    //        //    return false;
    //        //return ((ProjectViewModel)_vm.SelectedProject).ID
    //        //       > NONE_SELECTED;
    //        return true;
    //    }

    //    public event EventHandler CanExecuteChanged
    //        = delegate { };

    //    public void Execute(object parameter)
    //    {
    //        _vm.KillProcess((Proc)parameter);
    //    }
    //}
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        private Predicate<object> canExecute;

        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<object> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}
