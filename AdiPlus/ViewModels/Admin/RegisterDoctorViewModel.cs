namespace AdiPlus.ViewModels.Admin
{
    public class RegisterDoctorViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserImage => "https://img.icons8.com/material-outlined/200/000000/user--v1.png";
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public int CabinetId { get; set; }
    }
}