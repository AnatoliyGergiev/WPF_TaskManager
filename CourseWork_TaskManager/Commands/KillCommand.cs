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
    internal class KillCommand : ICommand
    {
        private IProcessesViewModel _vm;

        public KillCommand(IProcessesViewModel viewModel)
        {
            _vm = viewModel;
            //_vm.PropertyChanged += vm_PropertyChanged;
        }

        private void vm_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            //if (string.Compare(e.PropertyName,
            //                   ProcessesViewModel.
            //                   SELECTED_PROJECT_PROPERRTY_NAME)
            //    == ARE_EQUAL)
            //{
            //    CanExecuteChanged(this, new EventArgs());
            //}
        }

        public bool CanExecute(object parameter)
        {
            //if (_vm.SelectedProject == null)
            //    return false;
            //return ((ProjectViewModel)_vm.SelectedProject).ID
            //       > NONE_SELECTED;
            return true;
        }

        public event EventHandler CanExecuteChanged
            = delegate { };

        public void Execute(object parameter)
        {
            _vm.KillProcess((Proc)parameter);
        }
    }
}
