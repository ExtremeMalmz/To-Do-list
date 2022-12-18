using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_Space;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Task_Manager_Space
{
    /// <summary>
    ///  //TaskManager takes care of the handling of the list of Tasks 
    /// </summary>
    internal class TaskManager
    {
        private List<TheTasks> tasks;

        /// <summary>
        ///  getter for the list task
        /// </summary>
        public List<TheTasks> Tasks 
        { 
            get
            { 
                return tasks; 
            } 
        }

        /// <summary>
        /// constrcutor for the EventManager class
        /// </summary>
        public TaskManager()
        {
            

            //creates a new list for the TaskManager
            tasks = new List<TheTasks>();
        }

        /// <summary>
        ///  //adds an object to the task list
        /// </summary>
        public void AddATask(TheTasks task)
        {
            tasks.Add(task);
        }

        /// <summary>
        ///  //debug which prints out all the items in the tasks list
        /// </summary>
        public void PrintAllTasks()
        {
            Console.WriteLine("--ALL TASKS--");
            foreach (TheTasks task in tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
    }
}
