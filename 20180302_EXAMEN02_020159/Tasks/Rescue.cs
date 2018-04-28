using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159.Tasks {
    class Rescue : RobotTask {

        Robot robot;

        public Rescue(Robot robot) : base() {
            this.robot = robot;
        }

        public void execute() {
            this.robot.rescue();
        }
        public void undo() {
            Console.WriteLine("Undoing Rescue Task.");
        }
    }
}
