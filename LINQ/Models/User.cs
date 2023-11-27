namespace ProgramacionFuncionalCSharp.LINQ
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public List<string> Rols { get; set; }

        public User(int id, string username, int age, string gender, List<string> rols)
        {
            this.Id = id;
            this.Username = username;
            this.Age = age;
            this.Gender = gender;
            this.Rols = rols;
        }

        public static List<User> Users()
        {
            List<User> users = new()
            {
                new User(1, "user1", 60, "Male", new List<string> { "Admin", "Developer" }),
                new User(2, "user2", 25, "Female", new List<string> { "User" }),
                new User(3, "user3", 30, "Male", new List<string> { "User" }),
                new User(4, "user4", 65, "Female", new List<string> { "Admin", "Supervisor" }),
                new User(5, "user5", 50, "Male", new List<string> { "Tester", "PM" }),
                new User(6, "user6", 45, "Female", new List<string> { "Developer", "Designer" }),
                new User(7, "user7", 50, "Male", new List<string> { "QA", "Designer" }),
                new User(8, "user8", 45, "Female", new List<string> { "Tester", "Designer" }),
                new User(9, "user9", 60, "Male", new List<string> { "Developer", "Designer" }),
                new User(10, "user10", 65, "Female", new List<string> { "Designer" }),
                new User(11, "user11", 30, "Male", new List<string> { "Logistic" })
            };
            return users;
        }
    }
}