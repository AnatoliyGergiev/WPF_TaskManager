using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_TaskManager.Models
{
    //class Application
    //{
    //    public String ProcessName { get; set; }
    //    public int Id { get; set; }
    //    public long Memory { get; set; }
    //    public DateTime StartTime { get; set; }

    //}

    public interface IProcessesModel
    {
        ObservableCollection<Proc> Processes { get; set; }
        event EventHandler ProcessesUpdated;
        void UpdateProcesses();
        void KillProcess(Proc pr);
    }
    
    public class ProcessesModel : IProcessesModel
    {
        public ObservableCollection<Proc> Processes { get; set; }
        public event EventHandler ProcessesUpdated = delegate { };

        public ProcessesModel()
        {
            Processes = new ObservableCollection<Proc>();
            foreach (Process proc in Process.GetProcesses())
            {
                Processes.Add(new Proc(proc));
            }
        }

        public void UpdateProcesses()
        {
            Processes.Clear();
            foreach (Process proc in Process.GetProcesses())
            {
                Processes.Add(new Proc(proc));
            }
            ProcessesUpdated(this,EventArgs.Empty);
        }
        public void KillProcess(Proc pr)
        {
            Process.GetProcessById(pr.Id).Kill();
        }

    }


}
