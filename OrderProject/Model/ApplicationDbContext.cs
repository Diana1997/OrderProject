using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProject.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<CommentOnTheVisit> CommentOnTheVisits { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<FieldOption> FieldOptions { set; get; }
        public DbSet<Hair> Hairs { set; get; }
        public DbSet<HairSizeSettings> HairSizeSettings { set; get; }
        public DbSet<Image> Images { set; get; }
        public DbSet<Lens> Lenses { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<Picture> Pictures { set; get; }
        public DbSet<ReportField> ReportFields { set; get; }
        public DbSet<Research> Researchs { set; get; }
        public DbSet<Setting> Settings { set; get; }
        public DbSet<StatisticalSettings> StatisticalSettings { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Visit> Visits { set; get; }
        public DbSet<Diagnostic> Diagnostics { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
