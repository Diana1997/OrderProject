using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Model
{
    public class Hair
    {
        public int HairID { set; get; }
        public int Width { set; get; }
        public int X1 { set; get; }
        public int X2 { set; get; }
        public int Y1 { set; get; }
        public int Y2 { set; get; }
        public  ICollection<Research> Researchs { set; get; }
        public Hair()
        {
            Researchs = new List<Research>();
        }
    }
}
