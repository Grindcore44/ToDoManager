public class ToDoID
{
    private uint _ID = 0;
    private static ToDoID _instance;

    public static ToDoID GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ToDoID();
        }
        return _instance;
    }

    public uint GetID()
    {
       return _ID = _ID + 1;    
    }

}




