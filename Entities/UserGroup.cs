namespace TestVK.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }

        public Codes Code { get; set;  } = Codes.User;

        public string? Description { get; set;  }
        public enum Codes
        {
            Admin,
            User
        }
    }
    
}
