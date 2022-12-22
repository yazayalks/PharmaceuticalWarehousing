using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalWarehousing.Models
{
    public class PaymentAccount // Расчётный счёт
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public Bank Bank { get; set; }
        public List<Counterparty> Counterparties { get; set; }
    }
}
