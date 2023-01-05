using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VaccineRent.Models
{
    public class Rent
    {
        [Display(Name = "編號")]
        public int ID { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "手機")]
        public string Phone { get; set; }

        [Display(Name = "生日")]
        public string Birthday { get; set; }

        [Display(Name = "預約日期時間")]
        public DateTime ResDateTime { get; set; }

        [Display(Name = "醫院")]
        public string Hospital_Name { get; set; }

        public Rent() { }
    }
}
