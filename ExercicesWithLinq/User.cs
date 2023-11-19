
namespace ProgramacionFuncionalCSharp.ExercicesWithLinq
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public User(int id, string username, int age, string gender)
        {
            this.Id = id;
            this.Username = username;
            this.Age = age;
            this.Gender = gender;
        }

        public static List<User> Users()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "user1", 20, "Male"));
            users.Add(new User(2, "user2", 25, "Female"));
            users.Add(new User(3, "user3", 30, "Male"));
            users.Add(new User(4, "user4", 35, "Female"));
            users.Add(new User(5, "user5", 40, "Male"));
            users.Add(new User(6, "user6", 45, "Female"));
            users.Add(new User(7, "user7", 50, "Male"));
            users.Add(new User(8, "user8", 55, "Female"));
            users.Add(new User(9, "user9", 60, "Male"));
            users.Add(new User(10, "user10", 65, "Female"));
            users.Add(new User(11, "user11", 70, "Male"));
            return users;
        }
    }
}