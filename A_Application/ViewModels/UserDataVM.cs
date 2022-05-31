namespace crudApi.A_Application.ViewModels
{
    public class  UserDataVM : BaseVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
    }
}