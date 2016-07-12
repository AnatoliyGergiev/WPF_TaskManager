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
        private readonly IProcessesModel _model;
        private readonly ICommand _updateCommand;
        private readonly ICommand _killCommand;


        public ObservableCollection<Proc>
            Processes { get { return _model.Processes; } }


        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }
        public ICommand KillCommand
        {
            get { return _killCommand; }
        }

        public ProcessesViewModel(IProcessesModel processModel)
        {
            _model = processModel;
            _model.ProcessesUpdated +=
                model_ProcessesUpdated;
            _updateCommand = new UpdateCommand(this);
            _killCommand = new KillCommand(this);
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
        public void KillProcess(Proc pr)
        {
            _model.KillProcess(pr);
        }
    }
}
