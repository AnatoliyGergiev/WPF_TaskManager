using CourseWork_TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork_TaskManager.ViewModels
{
    class ProcessesViewModel : Notifier, IProcessesViewModel
    {
        private ICommand killCommand;

        private ICommand toggleExecuteCommand { get; set; }

        private bool canExecute = true;

        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get
            {
                return toggleExecuteCommand;
            }
            set
            {
                toggleExecuteCommand = value;
            }
        }

        public ICommand KillCommand
        {
            get
            {
                return killCommand;
            }
            set
            {
                killCommand = value;
            }
        }

    
        public void ShowMessage(object obj)
        {
            _model.KillProcess(obj);
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
        
        
        
        private readonly IProcessesModel _model;
        private readonly ICommand _updateCommand;
        //private readonly ICommand _killCommand;


        public ObservableCollection<Proc>
            Processes { get { return _model.Processes; } }


        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }
        //public ICommand KillCommand
        //{
        //    get { return _killCommand; }
        //}

        public ProcessesViewModel(IProcessesModel processModel)
        {
            _model = processModel;
            _model.ProcessesUpdated +=
                model_ProcessesUpdated;
            _updateCommand = new UpdateCommand(this);
            //_killCommand = new KillCommand(this);
            KillCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);

        }

        private void model_ProcessesUpdated(object sender,
                                          EventArgs e)
        {
            //_model.UpdateProcesses();
        }

        public void UpdateProcesses()
        {
            _model.UpdateProcesses();
        }
        //public void KillProcess(Proc pr)
        //{
        //    _model.KillProcess(pr);
        //}
    }
}
