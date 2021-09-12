namespace crudApi.C_Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }

    }
}