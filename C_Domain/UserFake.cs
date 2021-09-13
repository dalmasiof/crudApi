namespace crudApi.C_Domain
{
    public class UserFake : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }

    }
}