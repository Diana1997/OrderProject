using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Model
{
    public class Picture
    {
        [Key]
        public int PictureID { set; get; }
        [Required]
        public bool Selected { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public byte[] Data { set; get; }
    }
}
