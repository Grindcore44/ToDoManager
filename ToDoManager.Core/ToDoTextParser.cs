﻿using System.Text;

namespace ToDoManager.Core;

public class ToDoTextParser
{
    private string _nameFile;

    public ToDoTextParser(string nameFile)
    {
        _nameFile = nameFile;
    }
    public void SaveInFile(IEnumerable<ToDo> data)
    {
        var dataSerializator = new DataSerializator();
        string path = _nameFile;

        using var streamWriter = File.CreateText(path);

        foreach (var todo in data)
        {
            streamWriter.WriteLine(dataSerializator.SerializatingToString(todo));
        }
    }

    public IEnumerable<ToDo> ReadFromFile(string nameFile)
    {
        using var streamReader = File.OpenText(nameFile);
        int? temp = null;
        Dto? dto = null;
        bool readPropertyDescription = false;
        StringBuilder propertyDescription = new StringBuilder();
        StringBuilder value = new StringBuilder();
        List<ToDo> listTodo = new List<ToDo>();

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
                dto = new Dto();
            }
            else if (charSymbol == '%')
            {
                ToDo toDo = new ToDo(dto.NameTask, dto.DeadLineTimeTask, dto.ExecutionTimeTask);
                listTodo.Add(toDo);
            }
            else if (charSymbol == '№')
            {
                if (propertyDescription.ToString() == "Id")
                {
                    dto.Id = uint.Parse(value.ToString());
                }
                else if (propertyDescription.ToString() == "NameTask")
                {
                    dto.NameTask = value.ToString();
                }
                else if (propertyDescription.ToString() == "DeadLineTimeTask")
                {
                    dto.DeadLineTimeTask = DateTime.Parse(value.ToString());
                }
                else if (propertyDescription.ToString() == "ExecutionTimeTask")
                {
                    dto.ExecutionTimeTask = DateTime.Parse(value.ToString());
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

    private class Dto
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
            .Append($"$№{nameof(todo.Id)}^{todo.Id}")
            .Append($"№{nameof(todo.NameTask)}^{todo.NameTask}")
            .Append($"№{nameof(todo.DeadLineTimeTask)}^{todo.DeadLineTimeTask}")
            .Append($"№{nameof(todo.ExecutionTimeTask)}^{todo.ExecutionTimeTask}")
            .Append($"%");
        return stringBuilder.ToString();
    }
}
