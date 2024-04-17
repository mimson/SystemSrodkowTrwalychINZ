using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Models.ViewModel
{
    public class LoginViewModel
    {
        //Formatowanie textboxa jako mail
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //Formatowanie textboxa jako haslo
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}