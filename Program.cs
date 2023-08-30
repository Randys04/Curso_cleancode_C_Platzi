﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTasksList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string optionSelected = Console.ReadLine();
            return Convert.ToInt32(optionSelected);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                listTasks();

                string taskSelected = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskSelected) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string removedTask = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + removedTask + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskName = Console.ReadLine();
                TaskList.Add(taskName);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTasksList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                listTasks();
            }
        }

        private static void listTasks()
        {
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + TaskList[i]);
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu
    {
        Add     = 1,
        Remove  = 2,
        List    = 3,
        Exit    = 4
    }
}
