using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class DietifyConsultContext : DbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Consultant> Consultants { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<BlogComment> BlogComments { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<SiteContact> SiteContacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("dbcontext ismi");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .HasOne(x => x.SenderUser)
            .WithMany(y => y.SenderMessage)
            .HasForeignKey(z => z.SenderID)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Message>()
            .HasOne(x => x.ReceiverUser)
            .WithMany(y => y.ReceiverMessage)
            .HasForeignKey(z => z.ReceiverID)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
