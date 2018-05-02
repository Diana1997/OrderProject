using System.Collections.Generic;

namespace OrderProject.Model
{
    public class FieldOption
    {

        public int FieldOptionID { set; get; }
        public string Title { set; get; }
        public bool? Selected { set; get; }
        public string Text { set; get; }

        public ICollection<ReportField> ReportFields { set; get; }
        public FieldOption()
        {
            ReportFields = new List<ReportField>();
        }
    }
}