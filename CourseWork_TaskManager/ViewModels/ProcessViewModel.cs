using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_TaskManager.ViewModels
{
    public interface IProcessViewModel
    {
    }
    public class ProcessViewModel : Notifier, IProcessViewModel
    {
        private int _id;
        private string _processName;
        private long _memory;
        private DateTime _startTime;

        public ProcessViewModel()
        { }

        public ProcessViewModel(Process process)
        {
            if (process == null)
                return;
            ID = process.Id;
            ProcessName = process.ProcessName;
            Memory = process.PagedMemorySize64;
            StartTime = process.StartTime;
        }
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string ProcessName
        {
            get { return _processName; }
            set
            {
                _processName = value;
                NotifyPropertyChanged("ProcessName");
            }
        }

        public long Memory
        {
            get { return _memory; }
            set
            {
                _memory = value;
                NotifyPropertyChanged("Memory");
            }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                NotifyPropertyChanged("StartTime");
            }
        }

    }
}
