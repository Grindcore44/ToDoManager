using System;
using Xunit;

namespace ToDoManager.Core.Tests
{
    public class UnitTest1
    {
        //[Fact]
        //public void DoneStatusTaskTest()
        //{
        //    // arrange
        //    ToDoFactory toDoFactory = new ToDoFactory();
        //    var name = "Name";
        //    var timeComplete = new DateTime(2022, 7, 26, 23, 59, 59);
        //    var expectedCurrent = new DateTime(2022, 7, 26, 23, 59, 59);
        //    var toDo = toDoFactory.CreateToDo(name, timeComplete, expectedCurrent);

        //    //act
        //    toDo.DoneStatusTask();
        //    var actualCurrent = toDo.ExecutionTimeTask;



        //    // assert
        //    Assert.Equal(expectedCurrent, actualCurrent);
        //}

        [Fact]

        public void PostponeSatusTaskTest()
        {
            // arrange
            ToDoFactory toDoFactory = new ToDoFactory();
            var name = "Name";
            var allotedTime = DateTime.Now;
            var newAllotedTime = new DateTime(2022, 7, 26, 23, 59, 59);
            var toDo = toDoFactory.CreateToDo(name, allotedTime);
            var expectedCurrent = newAllotedTime;

            // act
            toDo.PostponeSatusTask(newAllotedTime);
            var actualCurrent = toDo.DeadLineTimeTask;

            // assert
            Assert.Equal(expectedCurrent, actualCurrent);
        }

        [Fact]
        public void ReopenOpenTask()
        {
            // arrange
            ToDoFactory toDoFactory = new ToDoFactory();
            var name = "Name";
            var allotedTime = DateTime.Now;
            var toDo = toDoFactory.CreateToDo(name, allotedTime);
            var expectedName = toDo.NameTask;
            var expectedAllotedTime = toDo.DeadLineTimeTask;
            var expectedExequtedTime = toDo.ExecutionTimeTask;

            // act
            toDo.ReturnToWorkTask();
            var actualName = toDo.NameTask;
            var actualAllotedTime = toDo.DeadLineTimeTask;
            var actualExequtedTime = toDo.ExecutionTimeTask;

            // assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedAllotedTime, actualAllotedTime);
            Assert.Equal(expectedExequtedTime, actualExequtedTime);
        }

        [Fact]
        public void ReopenCompletedTask()
        {
            // arrange
            ToDoFactory toDoFactory = new ToDoFactory();
            var name = "Name";
            var allotedTime = DateTime.Now;
            var executionTime = new DateTime(2022, 7, 26, 23, 59, 59);
            var toDo = toDoFactory.CreateToDo(name, allotedTime, executionTime);
            var expectedName = toDo.NameTask;
            var expectedAllotedTime = toDo.DeadLineTimeTask;

            // act
            toDo.ReturnToWorkTask();
            var actualName = toDo.NameTask;
            var actualAllotedTime = toDo.DeadLineTimeTask;
            var actualExecutedTime = toDo.ExecutionTimeTask;

            // assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedAllotedTime, actualAllotedTime);
            Assert.Null(actualExecutedTime);
        }

        [Fact]
        public void ReopenCompletedTaskAllotedTime()
        {
            // arrange
            ToDoFactory toDoFactory = new ToDoFactory();
            var name = "Name";
            var allotedTime = DateTime.Now;
            var exequtionTime = new DateTime(2022, 7, 25, 23, 59, 59);
            var toDo = toDoFactory.CreateToDo(name, allotedTime, exequtionTime);
            var newAllotedTime = new DateTime(2022, 8, 26, 23, 59, 59);
            var expectedName = toDo.NameTask;
            var expectedAllotedTime = toDo.DeadLineTimeTask;// или лучше прописать точное значение?

            // act
            toDo.ReturnToWorkTask(newAllotedTime);
            var actualName = toDo.NameTask;
            var actualAllotedTime = toDo.DeadLineTimeTask;
            var actualExequtedTime = toDo.ExecutionTimeTask;

            // assert
            Assert.Equal(expectedName, actualName);
            Assert.NotEqual(expectedAllotedTime, actualAllotedTime);
            Assert.Null(actualExequtedTime);
        }
    }
}



