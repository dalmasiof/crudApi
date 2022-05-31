namespace crudApi.C_Domain
{
    public class UserData:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
    }
}