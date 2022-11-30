//TODO Link the files text with the list in the taskmanager! GJ we almost DONE

using static System.Windows.Forms.LinkLabel;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Task_Space;
using Task_Manager_Space;
using System.Windows.Forms;
using System.DirectoryServices;

namespace Assignmen6
{
    public partial class ToDoList : Form
    {
        /// <summary>
        ///  This is where the form code is, which can then be used with other namespaces
        /// </summary>
        
        private TaskManager taskmanager = new TaskManager();
        public ToDoList()
        {
            /// <summary>
            ///  //constructor for the form, anything in here will run at the start of the program
            /// </summary>

            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            /// <summary>
            ///  //Initializing of the GUI setting things 
            ///  to values that need to be done for the smooth running of the 
            /// </summary>
            
            //setting the datasource of the combobox to enum class
            priorityComboBox.DataSource = Enum.GetValues(typeof(ImportanceTypes));
            //making it so that only a dropdownlist is visible in the combobox, otherwise people can type things in there
            priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //sets a clock within the datetimepicker
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //24 hour format
            dateTimePicker1.CustomFormat = "MM/dd/yyyy-HH:mm:ss-tt";

            //empties the listbox
            eventListBox.DataSource = null;
            eventListBox.Items.Clear();

            //Sets the text in the to do list textbox to empty
            toDoTextBox.Text = "";

            MessageBox.Show("For the time in the date time picker please use your arrow keys!");
        }

        private void saveDataFile_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// //allows the user to create a TXT file in which to save data
            /// </summary>
            
            SaveFileDialog sfd = new SaveFileDialog();
            
            //sets the file to a txt file
            sfd.Filter = "Text file|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                
                StreamWriter writer = new StreamWriter(path);

                //writes the things in the eventListBox to a file
                foreach (object eventInListBox in eventListBox.Items)
                {
                    Console.WriteLine(eventInListBox.ToString());
                    writer.WriteLine(eventInListBox);
                }
                writer.Close();
            }
        }

        private void openDataFile_Click(object sender, EventArgs e)
        {
            /// <summary>
            ///   //opens a file which gets set to the listboxs data 
            /// </summary>

            //clears the listBox as we do not want the previous files data in the new file + also sets the datasource to
            //null as to not crash it
            eventListBox.DataSource = null;
            eventListBox.Items.Clear();

            //create new object of taskmanager as to not get duplicates from previously added tasks
            taskmanager = new TaskManager();

            //creates objects of task and adds them to the list

            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;

                StreamReader reader = new StreamReader(path);

                string lineInFile;

                // Read and display lines from the file until the end of
                // the file is reached.
                while ((lineInFile = reader.ReadLine()) != null)
                {
                    //sets what we want the file row to be split by
                    char[] delimiterChars = { ' ', ' ', '\n' };
                    //create a words which contains all the words we split the file row by
                    string[] words = lineInFile.Split(delimiterChars);

                    //prints out all the words in the array, keeping this for debug purposes and future work
                    /*
                    foreach (var word in words)
                    {
                        System.Console.WriteLine($"{word}");
                    }
                    */

                    //the Zen of python says that explicit is better than implicit
                    string datetime = words[0];
                    string priority = words[1];
                    string toDoText = words[2];
                    TheTasks newTask = new TheTasks(datetime, priority, toDoText);
                    taskmanager.AddATask(newTask);

                    //updates the listbox with our new values
                    var x = taskmanager.Tasks;
                    eventListBox.DataSource = x.Cast<TheTasks>().ToList();
                }
                reader.Close();
            }
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            /// <summary>
            ///  //adds an event to the list if there is nothing empty
            /// </summary>

            string datetime = dateTimePicker1.Text;
            string priority = priorityComboBox.Text;
            string toDoText = toDoTextBox.Text;

            TheTasks newTask = new TheTasks(datetime,priority,toDoText);
            taskmanager.AddATask(newTask);

            var x = taskmanager.Tasks;
            eventListBox.DataSource = x.Cast<TheTasks>().ToList();
        }

        private void newFile_Click(object sender, EventArgs e)
        {
            /// <summary>
            ///  creates a new file which means we just initialize the application
            /// </summary>
            
            InitializeGUI();
        }

        private void exitFile_Click(object sender, EventArgs e)
        {
            /// <summary>
            ///  //When the user wants to exit the application, though they are presented which the choice of not exiting
            /// </summary>
            
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //exits the application
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //basically a pass, continue the program
                Console.WriteLine("");
            }
        }
    }
}