namespace MyFirstAPI.Controllers.DTOS
{
    public class PutUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
    }

    public class PostUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
    }
}
