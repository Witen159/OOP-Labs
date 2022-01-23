using System;

namespace Reports.Client.Managers.Task_manager.TaskOption
{
    public class UpdateTask : ITaskOption
    {
        private ITaskOption _getOption = null;
        public void Option()
        {
            Console.WriteLine("1. Change task state");
            Console.WriteLine("2. Change task employee");
            Console.WriteLine("3. Comment task");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            switch (choice)
            {
                case 1:
                    _getOption = new ChangeTaskState();
                    break;
                case 2:
                    _getOption = new ChangeTaskEmployee();
                    break;
                case 3:
                    _getOption = new CommentTask();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    return;
            }
            _getOption.Option();
        }
    }
}