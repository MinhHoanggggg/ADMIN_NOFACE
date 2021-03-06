using System.Data.Entity;

namespace NOFACE_ADMIN.Models
{
    public partial class NofaceDbContext : DbContext
    {
        public NofaceDbContext()
            : base("name=NofaceDbContext")
        {
        }

        public virtual DbSet<Achievements> Achievements { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Avt> Avt { get; set; }
        public virtual DbSet<Ban> Ban { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<LikeComment> LikeComment { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Medals> Medals { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achievements>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<Ban>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<Comment>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<Friends>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<Friends>()
                .Property(e => e.IDFriends)
                .IsFixedLength();

            modelBuilder.Entity<LikeComment>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<Likes>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<Medals>()
                .Property(e => e.ImgMedal)
                .IsFixedLength();

            modelBuilder.Entity<Post>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<Post>()
                .Property(e => e.ImagePost)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comment)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Likes)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Img)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.IDUser)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Ban)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comment)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friends)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IDFriends);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friends1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.IDUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Likes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
