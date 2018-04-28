using _20180302_EXAMEN02_020159.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159 {
    class Invoker {

        RobotTask[] tasks;
        int taskCount;

        public Invoker(int taskCount) {
            Console.WriteLine("Invoker initialized with " + taskCount + " tasks.");
            this.taskCount = taskCount;
            this.tasks = new RobotTask[taskCount];
            initializeTasks();
        }

        private void initializeTasks() {
            for (int i = 0; i < this.taskCount; i++) {
                setTask(new NoTask(), i);
            }
        }

        public void setTask(RobotTask Task, int index) {
            if (index < this.taskCount) {
                this.tasks[index] = Task;
            }
            else {
                Console.WriteLine("Set Task Error: Index out of range.");
            }
        }

        public void threadedInvoke(int index) {
            new Thread(delegate() {
                invoke(index);
            }).Start(); 
        }

        public RobotTask invoke(int index) {
            if (index < this.taskCount) {
                tasks[index].execute();
            }
            else {
                Console.WriteLine("Invoke Error: Index out of range.");
                return null;
            }
            return tasks[index];
        }

        public void undo(int index) {
            if (index < this.taskCount) {
                tasks[index].undo();
            }
            else {
                Console.WriteLine("Undo Error: Index out of range.");
            }
        }

    }
}
