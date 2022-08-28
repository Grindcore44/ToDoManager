namespace ToDoManager.Core
{
    public class ToDoRepository
    {
        ToDoFactory _toDoFactory;
        public ToDoRepository(ToDoFactory toDoFactory)
        {
            _toDoFactory = toDoFactory;
        }
        private Dictionary<uint, ToDo> _memory = new Dictionary<uint, ToDo>();

        public void Add(ToDo toDo)
        {
            var id = toDo.Id;
            _memory.Add(id, toDo);
        }

        public void Update(ToDo toDo)
        {
            var id = toDo.Id;
            _memory[id] = toDo;
        }

        public void Remove(ToDo toDo)
        {
            var id = toDo.Id;
            _memory.Remove(id);
        }

        public IEnumerable<ToDo> GetToDoByTime(DateTime? from, DateTime? to) //IEnumerable интерфейс для всех коолекций
        {
            foreach (var toDo in _memory.Values)
            {
                if ((from.HasValue == false || from <= toDo.DeadLineTimeTask) && (to.HasValue == false || to >= toDo.DeadLineTimeTask))
                {
                    yield return toDo;       
                }
            }
        }

        public IEnumerable<ToDo> GetToDoById(uint fromId, uint toId) //IEnumerable интерфейс для всех коолекций
        {
            foreach (var toDo in _memory.Values)
            {
                if ((toDo.Id >= fromId) && (toDo.Id <= toId))
                {
                    yield return toDo;
                }
            }
        }
    }
}

