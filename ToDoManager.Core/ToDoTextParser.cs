using System.Text;

namespace ToDoManager.Core;

public class ToDoTextParser
{
    private string _nameFile;
    private string _maxIdNameFile;
    private ToDoFactory _toDoFactory; 

    public ToDoTextParser(ToDoFactory toDoFactory, string nameFile, string maxIdNameFile = null)
    {
        _nameFile = nameFile;
        _maxIdNameFile = maxIdNameFile;
        _toDoFactory = toDoFactory;
    }
    public void SaveInFile(IEnumerable<ToDo> data)
    {
        var dataSerializator = new DataSerializator();
        string path = _nameFile;
        string pathMaxId = _maxIdNameFile;
        using var streamWriter = File.CreateText(path);
        using var maxIdStreamWriter = File.CreateText(pathMaxId);
        uint maxToDoId = 0;

        foreach (var toDo in data)
        {
            uint temp = toDo.Id;
            if (temp >= maxToDoId)
            {
                maxToDoId = temp;
            }
        }

        maxIdStreamWriter.WriteLine(dataSerializator.SerializatingToString(maxToDoId));

        foreach (var toDo in data)
        {
            streamWriter.WriteLine(dataSerializator.SerializatingToString(toDo));
        }
    }

    public IEnumerable<ToDo> ReadFromFile(string nameFile, string maxIdNameFile)
    {
        using var streamReader = File.OpenText(nameFile);
        using var maxIdtreamReader = File.OpenText(maxIdNameFile);
        int? temp = null;
        ToDoDto? toDodto = null;
        bool readPropertyDescription = false;
        StringBuilder propertyDescription = new StringBuilder();
        StringBuilder value = new StringBuilder();
        List<ToDo> listTodo = new List<ToDo>();
        uint maxId = 0;

        do
        {
            temp = maxIdtreamReader.Read();
            if (temp.Value == -1)
            {
                break;
            }

            var charSymbol = Convert.ToChar(temp);
            if (charSymbol == '№')
            {
                if (propertyDescription.ToString() == "MaxToDoId")
                {
                    maxId = uint.Parse(value.ToString());
                }
                propertyDescription.Clear();
                readPropertyDescription = true;
            }
            else if (readPropertyDescription)
            {
                if (charSymbol == '^')
                {
                    value.Clear();
                    readPropertyDescription = false;
                }
                else
                {
                    propertyDescription.Append(charSymbol);
                }
            }
            else if (readPropertyDescription == false)
            {
                value.Append(charSymbol);
            }
        }
        while (true);

        do
        {
            temp = streamReader.Read();
            if (temp.Value == -1)
            {
                break;
            }

            var charSymbol = Convert.ToChar(temp);
            if (charSymbol == '$')
            {
                toDodto = new ToDoDto();
            }
            else if (charSymbol == '%')
            {
                listTodo.Add(_toDoFactory.CreateToDo(toDodto.Id, toDodto.NameTask, toDodto.DeadLineTimeTask, toDodto.ExecutionTimeTask));
            }
            else if (charSymbol == '№')
            {
                if (propertyDescription.ToString() == "Id")
                {
                    toDodto.Id = uint.Parse(value.ToString());
                }
                else if (propertyDescription.ToString() == "NameTask")
                {
                    toDodto.NameTask = value.ToString();
                }
                else if (propertyDescription.ToString() == "DeadLineTimeTask")
                {
                    toDodto.DeadLineTimeTask = DateTime.Parse(value.ToString());
                }
                else if (propertyDescription.ToString() == "ExecutionTimeTask")
                {
                    toDodto.ExecutionTimeTask = DateTime.Parse(value.ToString());
                }
                propertyDescription.Clear();
                readPropertyDescription = true;
            }
            else if (readPropertyDescription)
            {
                if (charSymbol == '^')
                {
                    value.Clear();
                    readPropertyDescription = false;
                }
                else
                {
                    propertyDescription.Append(charSymbol);
                }
            }
            else if (readPropertyDescription == false)
            {
                value.Append(charSymbol);
            }
        }
        while (true);

        return listTodo;
    }

    private class ToDoDto
    {
        public uint Id { get; set; }
        public string NameTask { get; set; }
        public DateTime DeadLineTimeTask { get; set; }
        public DateTime? ExecutionTimeTask { get; set; }

    }
}

public class DataSerializator
{
    public string SerializatingToString(ToDo todo)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder
            .Append($"$№{nameof(todo.Id)}^{todo.Id}№")
            .Append($"{nameof(todo.NameTask)}^{todo.NameTask}№")
            .Append($"{nameof(todo.DeadLineTimeTask)}^{todo.DeadLineTimeTask:O}№")
            .Append($"{nameof(todo.ExecutionTimeTask)}^{todo.ExecutionTimeTask:O}№")
            .Append($"%");
        return stringBuilder.ToString();
    }

    public string SerializatingToString(uint maxToDoId)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"№MaxToDoId^{maxToDoId}№");
        return stringBuilder.ToString();
    }
}

