using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180302_EXAMEN02_020159 {
    class Program {

        static void Main(string[] args) {
            Random random = new Random();
            Queue<String> taskQueue = new Queue<String>();
            List<String> tasks = new List<String>() { "Cook", "Fight", "Paint", "Repair", "Rescue" };
            List<Robot> robots = new List<Robot>();
            List<String> robotClasses = new List<String>() { "Small", "Medium", "Large" };

            for (int i = 0; i < 20; i++) {
                int index = random.Next(0, 5);
                taskQueue.Enqueue(tasks[index]);
            }

            for (int i = 0; i < 5; i++) {
                int index = random.Next(0, 3);
                robots.Add(new Robot("R" + i, robotClasses[index]));
            }

            Client client = new Client(robots);
            client.doTasks(taskQueue);

            Console.ReadLine();
        }
    }
}
