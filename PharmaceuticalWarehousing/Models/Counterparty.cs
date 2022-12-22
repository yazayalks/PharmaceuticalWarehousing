using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalWarehousing.Models
{
    public class Counterparty //Контрагент
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(5)]
        public string Title { get; set; }
        [MinLength(5)]
        public string Street { get; set; }
        [MinLength(5)]
        public string House { get; set; }
        [MinLength(5)]
        public string Flat { get; set; }
        public string Phone { get; set; }
        public string ITN { get; set; }

        public List<Waybill> Waybills { get; set; }
        public List<Invoice> Invoices { get; set; }
        public PaymentAccount PaymentAccount { get; set; }

    }
}
