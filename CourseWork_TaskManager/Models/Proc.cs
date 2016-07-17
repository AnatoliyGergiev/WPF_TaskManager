using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_TaskManager.Models
{
    public class Proc
    {
        public string ProcessName { get; set; }
        public int Id { get; set; }
        public long Memory { get; set; }
        public DateTime StartTime { get; set; }
        public Proc(Process pr)
        {
            ProcessName = pr.ProcessName;
            Id = pr.Id;
            Memory = pr.PagedMemorySize64;
            try
            {
                StartTime = pr.StartTime;
            }catch(Exception )
            { StartTime = Convert.ToDateTime("01.01.1970"); }
        }
    }
}
