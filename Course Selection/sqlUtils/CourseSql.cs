namespace Course_Selection.sqlUtils
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CourseSql : DbContext
    {
        public CourseSql()
            : base("name=CourseSql")
        {
        }

        public virtual DbSet<C> C { get; set; }
        public virtual DbSet<CS> CS { get; set; }
        public virtual DbSet<S> S { get; set; }
        public virtual DbSet<SC> SC { get; set; }
        public virtual DbSet<SLogin> SLogin { get; set; }
        public virtual DbSet<SS> SS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C>()
                .Property(e => e.cno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<C>()
                .Property(e => e.cname)
                .IsUnicode(false);

            modelBuilder.Entity<CS>()
                .Property(e => e.scodeno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CS>()
                .Property(e => e.cno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<S>()
                .Property(e => e.sno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<S>()
                .Property(e => e.sname)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<S>()
                .Property(e => e.ssex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<S>()
                .Property(e => e.scodeno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<S>()
                .Property(e => e._class)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SC>()
                .Property(e => e.sno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SC>()
                .Property(e => e.cno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SLogin>()
                .Property(e => e.sno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SLogin>()
                .Property(e => e.spaw)
                .IsUnicode(false);

            modelBuilder.Entity<SS>()
                .Property(e => e.scodeno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SS>()
                .Property(e => e.ssname)
                .IsUnicode(false);
        }
    }
}
