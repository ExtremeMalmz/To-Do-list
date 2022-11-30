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
        
        //getter for list
        public List<TheTasks> Tasks 
        { 
            get 
            {
                /// <summary>
                ///  getter for the list task
                /// </summary>
                
                return tasks; 
            } 
        }
        public TaskManager()
        {
            /// <summary>
            /// constrcutor for the EventManager class
            /// </summary>

            //creates a new list for the TaskManager
            tasks = new List<TheTasks>();
        }

        public void AddATask(TheTasks task)
        {
            /// <summary>
            ///  //adds an object to the task list
            /// </summary>

            tasks.Add(task);
            //PrintAllTasks();
        }

        public void PrintAllTasks()
        {
            /// <summary>
            ///  //debug which prints out all the items in the tasks list
            /// </summary>
            
            Console.WriteLine("--ALL TASKS--");
            foreach (TheTasks task in tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
    }
}
