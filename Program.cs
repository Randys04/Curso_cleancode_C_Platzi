


List<string> TaskList = new List<string>();


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
        
/// <summary>
/// Show the options for tasks
/// </summary>
/// <returns>Returns option selected by user</returns>
int ShowMainMenu()
{
    try
    {
        string optionSelected;
        do
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            optionSelected = Console.ReadLine();
            if (Convert.ToInt32(optionSelected) > 4 || Convert.ToInt32(optionSelected) < 1)
            {
                Console.WriteLine("La opcion ingresada no es valida");
            }
            return Convert.ToInt32(optionSelected);
        } while (Convert.ToInt32(optionSelected) > 4 || Convert.ToInt32(optionSelected) < 1);
                

    }
    catch(Exception ex)
    {
        Console.WriteLine("Ha ocurrido un error al ingresar la opcion");
        return 0;
    }
            
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        
        listTasks();

        string taskSelected = Console.ReadLine();
        
        // Remove one position because arrays starts in 0
        int indexToRemove = Convert.ToInt32(taskSelected) - 1;
        if(indexToRemove  > (TaskList.Count - 1) || indexToRemove < 0) 
        {
            Console.WriteLine("El numero de tarea seleccionado no es valido");
        }
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                string removedTask = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {removedTask} eliminada");
            }
        }           
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea seleccionada");
    }
}

void ShowMenuAdd()
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

void ShowMenuTasksList()
{
    if (TaskList?.Count > 0)
    {
        listTasks();
    } 
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void listTasks()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    TaskList.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));
    Console.WriteLine("----------------------------------------");
}
    

public enum Menu
{
    Add     = 1,
    Remove  = 2,
    List    = 3,
    Exit    = 4
}

