namespace crudApi.A_Application.ViewModels
{
    public class UserVM : BaseVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
    }
}