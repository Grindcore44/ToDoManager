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
        //    var name = "Name";
        //    var timeComplete = new DateTime(2022, 7, 26, 23, 59, 59);
        //    var expectedCurrent = DateTime.Now;
        //    var toDo = new ToDo(name, timeComplete, expectedCurrent);

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
            var name = "Name";
            var allotedTime = DateTime.Now;
            var newAllotedTime = new DateTime(2022, 7, 26, 23, 59, 59);
            var toDo = new ToDo(name, allotedTime);
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
            var name = "Name";
            var allotedTime = DateTime.Now;
            var toDo = new ToDo(name, allotedTime);
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
            var name = "Name";
            var allotedTime = DateTime.Now;
            var executionTime = new DateTime(2022, 7, 26, 23, 59, 59);
            var toDo = new ToDo(name, allotedTime, executionTime);
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
            var name = "Name";
            var allotedTime = DateTime.Now;
            var exequtionTime = new DateTime(2022, 7, 25, 23, 59, 59);
            var toDo = new ToDo(name, allotedTime, exequtionTime);
            var newAllotedTime = new DateTime(2022, 8, 26, 23, 59, 59);
            var expectedName = toDo.NameTask;
            var expectedExequtedTime = toDo.ExecutionTimeTask; // или лучше прописать точное значение?
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



