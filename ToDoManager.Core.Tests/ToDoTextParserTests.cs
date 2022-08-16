﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ToDoManager.Core.Tests;

public class ToDoTextParserTests
{
    [Fact]
    public void SerializatingToStringTest()
    {
        //arrage
        var name = "Name";
        var deadLineTime = DateTime.Now;
        var executionTime = new DateTime(2022, 7, 26, 23, 59, 59);
        var todo = new ToDo(name, deadLineTime, executionTime);
        var dataSerializator = new DataSerializator();
        string expectedCurrent = $"$№{nameof(todo.Id)}^{todo.Id}№{nameof(todo.NameTask)}^{todo.NameTask}№{nameof(todo.DeadLineTimeTask)}^{todo.DeadLineTimeTask:O}№{nameof(todo.ExecutionTimeTask)}^{todo.ExecutionTimeTask:O}№%";

        //act
        string actualCurrent = dataSerializator.SerializatingToString(todo);

        //assert
        Assert.Equal(expectedCurrent, actualCurrent);

    }


    [Fact]
    public void ToDoTextParserPotokToStringTests()
    {
        //arrage
        var name = "Name";
        var deadLineTime = DateTime.Now;
        var executionTime = new DateTime(2022, 7, 26, 23, 59, 59);
        var toDo = new ToDo(name, deadLineTime, executionTime);

        var name2 = "Name2";
        var deadLineTime2 = DateTime.Now;
        var executionTime2 = new DateTime(2022, 11, 11, 11, 11, 11);
        var toDo2 = new ToDo(name2, deadLineTime2, executionTime2);

        var name3 = "Name3";
        var deadLineTime3 = DateTime.Now;
        var executionTime3 = new DateTime(2022, 10, 10, 10, 10, 10);
        var toDo3 = new ToDo(name3, deadLineTime3, executionTime3);

        string path = "ToDoTextParserPotokToStringTests.txt";
        var toDoList = new List<ToDo>();
        var toDoTextParser = new ToDoTextParser(path);
        string? stringLine = null;
        List<string> aclualContent = new List<string>();
        var dataSerializator = new DataSerializator();

        var expectedCurrent = dataSerializator.SerializatingToString(toDo);
        toDoList.Add(toDo);

        var expectedCurrent2 = dataSerializator.SerializatingToString(toDo2);
        toDoList.Add(toDo2);

        var expectedCurrent3 = dataSerializator.SerializatingToString(toDo3);
        toDoList.Add(toDo3);
        //act
        toDoTextParser.SaveInFile(toDoList);

        //assert
        var streamReader = new StreamReader(path);
        while ((stringLine = streamReader.ReadLine()) != null)
        {
            aclualContent.Add( stringLine);
        }

        Assert.Equal(expectedCurrent, aclualContent[0]);
        Assert.Equal(expectedCurrent2, aclualContent[1]);
        Assert.Equal(expectedCurrent3, aclualContent[2]);
    }

    [Fact]

    public void ReadFromFileTest()
    {
        //arrage
        var name = "Name";
        var deadLineTime = DateTime.Now;
        var executionTime = new DateTime(2022, 7, 26, 23, 59, 59);
        var toDo = new ToDo(name, deadLineTime, executionTime);

        var name2 = "Name2";
        var deadLineTime2 = DateTime.Now;
        var executionTime2 = new DateTime(2022, 11, 11, 11, 11, 11);
        var toDo2 = new ToDo(name2, deadLineTime2, executionTime2);

        var name3 = "Name3";
        var deadLineTime3 = DateTime.Now;
        var executionTime3 = new DateTime(2022, 10, 10, 10, 10, 10);
        var toDo3 = new ToDo(name3, deadLineTime3, executionTime3);

        string path = "ReadFromFileTest.txt";
        var toDoList = new List<ToDo>();
        var toDoTextParser = new ToDoTextParser(path);
        toDoList.Add(toDo);
        toDoList.Add(toDo2);
        toDoList.Add(toDo3);
        toDoTextParser.SaveInFile(toDoList);
        var expectedContent = new List<ToDo>();
        for (int i = 0; i < toDoList.Count; i++)
        {
            expectedContent.Add(toDoList[i]);
        }
        //act
        var actualContent = new List<ToDo>();
        actualContent = toDoTextParser.ReadFromFile(path).ToList();
        //assert
        Assert.Equal(expectedContent, actualContent);

    }
}
