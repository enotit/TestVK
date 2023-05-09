namespace TestVK.Entities
{
    public class UserState
    {
        public int Id { get; set; }

        public Codes Code { get; set; } = Codes.Active;

        public string? Description { get; set; }

        public enum Codes
        {
            Active,
            Blocked
        }
    }
}
