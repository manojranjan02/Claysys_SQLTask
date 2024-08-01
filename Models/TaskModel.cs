namespace Claysys_SQLTask.Models
{
    public class TaskModel
    {
        public class Client
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Project
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ClientId { get; set; }
        }

    }
}
