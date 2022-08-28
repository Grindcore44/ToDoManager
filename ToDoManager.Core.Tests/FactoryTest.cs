using System;
using Xunit;


namespace ToDoManager.Core.Tests
{
    public class FactoryTest
    {

        [Fact]

        public void CreateToDoTest()
        {
            // arrenge
            var toDoFactory = new ToDoFactory();
            var name1 = "name1";
            var name2 = "name2";
            uint id = 0;

            // act
            var currentWithId = toDoFactory.CreateToDo(id, name2, DateTime.Now);
            var currentWithoutId = toDoFactory.CreateToDo(name1, DateTime.Now);
            
            //assert
            Assert.NotEqual(currentWithoutId.Id, currentWithId.Id);
        }





    }
}
