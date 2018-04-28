using _20180302_EXAMEN02_020159.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
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
            try {
                List<String> tasks = File.ReadAllLines("tasks.txt").ToList();
                if (tasks.Count > 0) {
                    taskQueue = new Queue<String>();
                    foreach (String t in tasks) {
                        taskQueue.Enqueue(t);
                    }
                }
            }
            catch (Exception e) { }
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
                    saveQueue(taskQueue);
                }
            }
            Console.WriteLine("All tasks have been assigned.");
        }

        private void saveQueue(Queue<String> taskQueue) {
            const string sPath = "tasks.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in taskQueue) {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();
        }

        public void undoAction() {
            if (robotTaskStack.Count > 0) {
                RobotTask command = this.robotTaskStack.Pop();
                command.undo();
            }
        }

    }
}
