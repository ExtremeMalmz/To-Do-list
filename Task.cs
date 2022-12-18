using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Space
{
    /// <summary>
    ///   //TheTasks are the individual tasks which the user can input
    /// </summary>
    internal class TheTasks
    {
        private string dateAndTime;
        private string importanceLevel;
        private string textOnToDo;

        /// <summary>
        ///  //constructor for TheTasks
        /// </summary>
        public TheTasks(string dateAndTime, string importanceLevel, string textOnToDo)
        { 
            this.dateAndTime = dateAndTime;
            this.importanceLevel = importanceLevel;
            this.textOnToDo = textOnToDo;
        }

        /// <summary>
        /// To string which returns a string in the dateTime, importancelevel, textontodo format
        /// </summary>
        public override string ToString()
        {
            return dateAndTime + " " + importanceLevel + " " + textOnToDo;
        }
    }
}
