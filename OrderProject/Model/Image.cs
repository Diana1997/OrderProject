using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Model
{
    public class Image
    {
        public int ImageID { set; get; }
        [Required]
        public DateTime DateTime { set; get; }
        public string Title { set; get; }
        [Required]
        public byte[] ImageContent { set; get; }
        public ICollection<Patient> Patients { set; get; }
        public ICollection<Research> Researchs { set; get; }
        public Image()
        {
            Patients = new List<Patient>();
            Researchs = new List<Research>();
        }
    }
}
