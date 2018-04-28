using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159.Tasks {
    class Cook : RobotTask {

        Robot robot;

        public Cook(Robot robot) : base() {
            this.robot = robot;
        }

        public void execute() {
            this.robot.cook();
        }
        public void undo() {
            Console.WriteLine("Undoing Cook Task.");
        }
    }
}
