using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159 {
    class Robot {

        private string robotClass;
        private string id;
        private int taskCapacity;
        public int taskQuantity;

        public Robot(String id, String robotClass) {
            this.robotClass = robotClass;
            this.id = id;
            switch (robotClass.ToLower()) {
                case "small":
                    this.taskCapacity = 1;
                    break;
                case "medium":
                    this.taskCapacity = 2;
                    break;
                case "large":
                    this.taskCapacity = 3;
                    break;
                default:
                    this.taskCapacity = 1;
                    break;
            }
            this.taskQuantity = 0;
        }

        private bool work(int millisecond) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool flag = false;
            while (!flag) {
                if (sw.ElapsedMilliseconds > millisecond) {
                    flag = true;
                }
            }
            sw.Stop();
            return true;
        }

        public bool isFull() {
            return taskQuantity == taskCapacity;
        }

        private void onFinish() {
            if (this.taskQuantity > 0) {
                this.taskQuantity--;
            }
        }

        public void cook() {
            Console.WriteLine(robotClass + " robot " + id + " is now cooking. " + DateTime.Now);
            bool finished = work(3000);
            Console.WriteLine(robotClass + " robot " + id + " has finished cooking. " + DateTime.Now);
            onFinish();
        }

        public void paint() {
            Console.WriteLine(robotClass + " robot " + id + " is now painting. " + DateTime.Now);
            bool finished = work(2000);
            Console.WriteLine(robotClass + " robot " + id + " has finished painting. " + DateTime.Now);
            onFinish();
        }

        public void repair() {
            Console.WriteLine(robotClass + " robot " + id + " is now repairing. " + DateTime.Now);
            bool finished = work(4000);
            Console.WriteLine(robotClass + " robot " + id + " has finished repairing. " + DateTime.Now);
            onFinish();
        }

        public void rescue() {
            Console.WriteLine(robotClass + " robot " + id + " is now rescuing kitties." + DateTime.Now);
            bool finished = work(5000);
            Console.WriteLine(robotClass + " robot " + id + " has finished rescuing kitties. " + DateTime.Now);
            onFinish();
        }

        public void fight() {
            Console.WriteLine(robotClass + " robot " + id + " is now fighting." + DateTime.Now);
            bool finished = work(6000);
            Console.WriteLine(robotClass + " robot " + id + " has finished fighting. " + DateTime.Now);
            onFinish();
        }
    }
}
