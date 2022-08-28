namespace ToDoManager.Core;

public class ToDoFactory
{
    private uint _idCount = 0;

    public ToDoFactory()
    { }

    public ToDoFactory(uint idCount)
    { 
        _idCount = GuardCheksMore(idCount);
    }

    public ToDo CreateToDo(string nameTask, DateTime deadLine, DateTime? executionTimeTask = null)
    {
        uint tempId = _idCount;
        _idCount += 1;
        return new ToDo(tempId, nameTask, deadLine, executionTimeTask);
    }

    public ToDo CreateToDo(uint id, string nameTask, DateTime deadLine, DateTime? executionTimeTask = null)
    {
        if (id > _idCount)
        { 
            throw new ArgumentOutOfRangeException("this id is double");
        }
        _idCount = id + 1;
        return new ToDo(id, nameTask, deadLine, executionTimeTask);
    }

    public uint GuardCheksMore(uint value)
    {
        if (value < _idCount)
        {
            throw new ArgumentOutOfRangeException("this id is double");
        }
        return value;
    }
}