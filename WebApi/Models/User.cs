using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class User: IdentityUser
    {
        [Column(TypeName ="nvarchar(12)")]
        public string FirstName { get; set; }
        [Column(TypeName ="nvarchar(16)")]
        public string LastName { get; set; }
    }
}
