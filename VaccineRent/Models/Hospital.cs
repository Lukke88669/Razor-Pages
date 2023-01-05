using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VaccineRent.Models
{
    public class Hospital
    {
        [Display(Name = "編號")]
        public int ID { get; set; }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "縣市")]
        public string Country { get; set; }

        [Display(Name = "Moderna")]
        public Boolean HaveModerna { get; set; }

        [Display(Name = "AZ")]
        public Boolean HaveAZ { get; set; }

        [Display(Name = "BNT")]
        public Boolean HaveBNT { get; set; }
        public Hospital() { }
    }
}
