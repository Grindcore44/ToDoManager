using ToDoManager.Core;



namespace ToDoManager.Core
{
    public class ToDo 
    {
        
        private string _nameTask;
        private DateTime _deadLine;
        private DateTime? _executionTimeTask;

        public ToDo(uint id, string nameTask, DateTime allottedTimeTask, DateTime? executionTimeTask)
        {
            Id = id;
            _nameTask = nameTask;
            _deadLine = allottedTimeTask;
            _executionTimeTask = executionTimeTask;
        }
        public ToDo(string nameTask, DateTime allottedTimeTask) : this(nameTask, allottedTimeTask, null)
        //this вызывает другой конструктор и передает ему аргументы
        {

        }

        public ToDo(string nameTask, DateTime deadLine, DateTime? executionTimeTask)
        {
            _nameTask = nameTask;
            _deadLine = deadLine;
            _executionTimeTask = executionTimeTask;
            var toDoID = ToDoID.GetInstance();
            Id = toDoID.GetID();
        }
 
        public uint Id { get; }
        public string NameTask => _nameTask;
        public bool RequestTaskStatus => _executionTimeTask != null;
        public DateTime DeadLineTimeTask => _deadLine;
        public DateTime? ExecutionTimeTask => _executionTimeTask;

        public void DoneStatusTask()
        {
            _executionTimeTask = DateTime.Now;
        }

        public void PostponeSatusTask(DateTime time)
        {
            _deadLine = time;
        }

        public void ReturnToWorkTask()
        {
            _executionTimeTask = null;
        }

        public void ReturnToWorkTask(DateTime time)
        {
            _executionTimeTask = null;
            _deadLine = time;
        }

        public override bool Equals(object? obj)
        {
            if (obj is ToDo toDo) //если обж является ТУДУ то создает экземплаяр туду и записывает туда объект
            {
                return Id == toDo.Id && NameTask == toDo.NameTask
                                     && RequestTaskStatus == toDo.RequestTaskStatus
                                     && DeadLineTimeTask.Equals (toDo.DeadLineTimeTask)
                                     && Nullable.Equals(ExecutionTimeTask, toDo.ExecutionTimeTask);
            }
            return false;
        }

        public override string ToString()
        {
            return $"Id: {Id} Name: {NameTask} DeadLine: {DeadLineTimeTask} CloseTime: {ExecutionTimeTask} Closed: {RequestTaskStatus}";
        }
    }
}




