namespace ToDoManager.Core;

public class ToDoFactory
{
    private uint _idCount = 0;
    ToDoTextParser _toDoTextParser;

    public ToDoFactory(ToDoTextParser toDoTextParser)
    {
        _toDoTextParser = toDoTextParser;
    }

    public ToDoFactory(uint idCount = 0)
    {
        _idCount = idCount+1;
    }

    public ToDo CreateToDo(string nameTask, DateTime deadLine, DateTime? executionTimeTask = null)
    {
        uint tempId = _idCount;
        _idCount += 1;
        return new ToDo(tempId, nameTask, deadLine, executionTimeTask);
    }

    public ToDo CreateToDo(uint id, string nameTask, DateTime deadLine, DateTime? executionTimeTask = null)
    {
        if (id >= _idCount)
        {
            throw new ArgumentOutOfRangeException("no exist");
        }

        return new ToDo(id, nameTask, deadLine, executionTimeTask);
    }
}