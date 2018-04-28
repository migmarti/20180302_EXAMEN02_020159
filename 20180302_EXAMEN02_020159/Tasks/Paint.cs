using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159.Tasks {
    class Paint : RobotTask {

        Robot robot;

        public Paint(Robot robot) : base() {
            this.robot = robot;
        }

        public void execute() {
            this.robot.paint();
        }
        public void undo() {
            Console.WriteLine("Undoing Paint Task.");
        }
    }
}
