using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159.Tasks {
    class NoTask : RobotTask {

        public NoTask() {

        }

        public void execute() {
            Console.WriteLine("Task not implemented.");
        }

        public void undo() {
            Console.WriteLine("No Task -> nothing to undo.");
        }
    }
}
