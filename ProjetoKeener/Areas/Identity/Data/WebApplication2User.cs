using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjetoKeener.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebApplication2User class
    public class WebApplication2User : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Sobrenome { get; set; }
    }
}
