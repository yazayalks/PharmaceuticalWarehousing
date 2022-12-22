using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaceuticalWarehousing.Models
{
    
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType? UserType { get; set; }
        public List<AccessRight> AccessRights { get; set; }

    }
}
