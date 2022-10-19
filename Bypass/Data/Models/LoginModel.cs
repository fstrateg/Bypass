using System.ComponentModel.DataAnnotations;

namespace Bypass.Data.Models
{
    public class LoginModel
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string LastError { get; set; }
        public bool Validate()
        {
            LastError = "";
            if (string.IsNullOrEmpty(User))
            {
                LastError = "Введите имя пользователя!";
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                LastError = "Введите пароль!";
                return false;
            }

            return true;
        }
    }
}
