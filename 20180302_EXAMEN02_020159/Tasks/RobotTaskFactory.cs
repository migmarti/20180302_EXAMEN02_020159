using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159.Tasks {
    class RobotTaskFactory {
        public RobotTask assignTask(String taskName, Robot robot) {
            switch (taskName.ToLower()) {
                case "cook":
                    robot.taskQuantity++;
                    return new Cook(robot);
                case "paint":
                    robot.taskQuantity++;
                    return new Paint(robot);
                case "rescue":
                    robot.taskQuantity++;
                    return new Rescue(robot);
                case "repair":
                    robot.taskQuantity++;
                    return new Repair(robot);
                case "fight":
                    robot.taskQuantity++;
                    return new Repair(robot);
                default:
                    break;
            }
            return null;
        }
    }
}
