using _20180302_EXAMEN02_020159.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159 {
    class Client {

        private List<Robot> robots;
        private Stack<RobotTask> robotTaskStack;
        private RobotTaskFactory taskFactory;

        public Client(List<Robot> robots) {
            this.robotTaskStack = new Stack<RobotTask>();
            this.taskFactory = new RobotTaskFactory();
            this.robots = robots;
        }

        public void doTasks(Queue<String> taskQueue) {
            int robotIndex = 0, invokerIndex = 0;
            Invoker invoker = new Invoker(taskQueue.Count);
            while (taskQueue.Count > 0) {
                Robot currentRobot = this.robots[robotIndex];
                if (currentRobot.isFull()) {
                    robotIndex++;
                    if (robotIndex >= robots.Count) {
                        robotIndex = 0;
                    }
                    continue;
                }
                else {
                    String nextTask = taskQueue.Dequeue();
                    RobotTask robotTask = this.taskFactory.assignTask(nextTask, currentRobot);
                    invoker.setTask(robotTask, invokerIndex);
                    invoker.threadedInvoke(invokerIndex);
                    this.robotTaskStack.Push(robotTask);
                    invokerIndex++;
                }
            }
            Console.WriteLine("All tasks have been assigned.");
        }

        public void undoAction() {
            if (robotTaskStack.Count > 0) {
                RobotTask command = this.robotTaskStack.Pop();
                command.undo();
            }
        }

    }
}
