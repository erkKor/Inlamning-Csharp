using ConsoleApp.Model;

namespace ConsoleApp.Tests
{
    public class List_Tests
    {
        private List<User> users;
        User user;
        

        public List_Tests()
        {
            users = new List<User>();
            user = new User();
        }

        [Fact]
        public void Add_User_To_List()
        {
            users.Add(user);

            Assert.Single(users);
        }
    }
}