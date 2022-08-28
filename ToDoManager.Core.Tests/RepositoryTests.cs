using System;
using System.Collections.Generic;
using Xunit;

namespace ToDoManager.Core.Tests;


public class RepositoryTests
{
    [Fact]

    public void GetToDoByTimeFromToTest()
    {
        //arrage
        ToDoFactory toDoFactory = new ToDoFactory();
        var name = "Name";
        var deadLineTime = new DateTime(2044, 11, 11, 11, 11, 11);
        var toDo = toDoFactory.CreateToDo(name, deadLineTime);


        var name2 = "Name2";
        var deadLineTime2 = new DateTime(2033, 11, 11, 11, 11, 11);
        var toDo2 = toDoFactory.CreateToDo(name2, deadLineTime2);

        var name3 = "Name3";
        var deadLineTime3 = new DateTime(2022, 10, 10, 10, 10, 10);
        var toDo3 = toDoFactory.CreateToDo(name3, deadLineTime3);

        var toDoRepository = new ToDoRepository();
        var expectedCurrent = new List<ToDo>();
        expectedCurrent.Add(toDo);
        expectedCurrent.Add(toDo2);
        expectedCurrent.Add(toDo3);

        //act
        toDoRepository.Add(toDo);
        toDoRepository.Add(toDo2);
        toDoRepository.Add(toDo3);
        var actualCurrent = toDoRepository.GetToDoByTime(toDo3.DeadLineTimeTask, toDo.DeadLineTimeTask);

        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    [Fact]

    public void GetToDoByTimeNullToTest()
    {
        //arrage
        ToDoFactory toDoFactory = new ToDoFactory();
        var name = "Name";
        var deadLineTime = new DateTime(2044, 11, 11, 11, 11, 11);
        var toDo = toDoFactory.CreateToDo(name, deadLineTime);

        var name2 = "Name2";
        var deadLineTime2 = new DateTime(2033, 11, 11, 11, 11, 11);
        var toDo2 = toDoFactory.CreateToDo(name2, deadLineTime2);

        var name3 = "Name3";
        var deadLineTime3 = new DateTime(2022, 10, 10, 10, 10, 10);
        var toDo3 = toDoFactory.CreateToDo (name3, deadLineTime3);

        var toDoRepository = new ToDoRepository();
        var expectedCurrent = new List<ToDo>();
        expectedCurrent.Add(toDo);
        expectedCurrent.Add(toDo2);
        expectedCurrent.Add(toDo3);

        //act
        toDoRepository.Add(toDo);
        toDoRepository.Add(toDo2);
        toDoRepository.Add(toDo3);
        var actualCurrent = toDoRepository.GetToDoByTime(null, toDo.DeadLineTimeTask);

        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    [Fact]

    public void GetToDoByTimeFromNullTest()
    {
        //arrage
        ToDoFactory toDoFactory = new ToDoFactory();
        var name = "Name";
        var deadLineTime = new DateTime(2044, 11, 11, 11, 11, 11);
        var toDo = toDoFactory.CreateToDo(name, deadLineTime);

        var name2 = "Name2";
        var deadLineTime2 = new DateTime(2033, 11, 11, 11, 11, 11);
        var toDo2 = toDoFactory.CreateToDo(name2, deadLineTime2);

        var name3 = "Name3";
        var deadLineTime3 = new DateTime(2022, 10, 10, 10, 10, 10);
        var toDo3 = toDoFactory.CreateToDo(name3, deadLineTime3);

        var toDoRepository = new ToDoRepository();
        var expectedCurrent = new List<ToDo>();
        expectedCurrent.Add(toDo);
        expectedCurrent.Add(toDo2);

        //act
        toDoRepository.Add(toDo);
        toDoRepository.Add(toDo2);
        toDoRepository.Add(toDo3);
        var actualCurrent = toDoRepository.GetToDoByTime(toDo2.DeadLineTimeTask, null);

        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    [Fact]


    public void GetToDoByTimeNullNullTest()
    {
        //arrage
        ToDoFactory toDoFactory = new ToDoFactory();
        var name = "Name";
        var deadLineTime = new DateTime(2044, 11, 11, 11, 11, 11);
        var toDo = toDoFactory.CreateToDo(name, deadLineTime);

        var name2 = "Name2";
        var deadLineTime2 = new DateTime(2033, 11, 11, 11, 11, 11);
        var toDo2 = toDoFactory.CreateToDo(name2, deadLineTime2);

        var name3 = "Name3";
        var deadLineTime3 = new DateTime(2022, 10, 10, 10, 10, 10);
        var toDo3 = toDoFactory.CreateToDo(name3, deadLineTime3);

        var toDoRepository = new ToDoRepository();
        var expectedCurrent = new List<ToDo>();
        expectedCurrent.Add(toDo);
        expectedCurrent.Add(toDo2);
        expectedCurrent.Add(toDo3);

        //act
        toDoRepository.Add(toDo);
        toDoRepository.Add(toDo2);
        toDoRepository.Add(toDo3);
        var actualCurrent = toDoRepository.GetToDoByTime(null, null);

        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }
}

