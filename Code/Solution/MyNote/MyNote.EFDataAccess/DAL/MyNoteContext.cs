using MyNote.EFDataAccess.DbInitializers;
using MyNote.EFDataAccess.Entities.Config;
using MyNote.EFDataAccess.Entities.Notes;
using MyNote.EFDataAccess.Entities.NoteUser;
using MyNote.EFDataAccess.EntityMaps;
using MyNote.EFDataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DAL
{
    public class MyNoteContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// 使用配置文件指定数据库位置和名字对于控制上下文类的连接参数也许是最简单和最有效的方式，另一个好处是如果我们想为开发，生产和临时环境创建各自的连接字符串，那么在配置文件中更改连接字符串并在开发时将它指向确定的数据库也是一种方法。
        /// 这里要注意的重要的事情是在配置文件中定义的连接字符串具有最高优先权，它会覆盖所有在其它地方指定的连接参数。
        /// 从最佳实践的角度，也许不推荐使用配置文件。注入连接字符串是一种更好的方式，因为它给开发者更多的控制权和监管权。
        /// 如果在配置文件中还有一个和数据库上下文类名同名的connectionString，那么就会使用这个同名的连接字符串。无论我们对传入的连接字符串名称如何改变，都是无济于事的，也就是说和数据库上下文类名同名的连接字符串优先权更大。
        /// </summary>
        public MyNoteContext() : base("name=ConnectionStringEF")
        {
            // EF默认使用CreateDatabaseIfNotExists作为默认初始化器，如果要覆盖这个策略，那么需要在DbContext类中的构造函数中使用Database.SetInitializer方法
            DbInitializer.SetMyNoteDbInitializerMode(DbInitializerType.DropCreateDatabaseIfModelChanges);
            // 如果处于生产环境，那么我们肯定不想丢失已存在的数据。这时我们就需要关闭该初始化器，只需要将null传给Database.SetInitializer方法
            //DbInitializer.SetMyNoteDbInitializerMode(DbInitializerType.Null);
        }

        #endregion

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<VerificationEntity> Verifications { get; set; }

        public DbSet<NoteEntity> Notes { get; set; }

        public DbSet<NoteContentEntity> NoteContents { get; set; }

        public DbSet<NoteCommentEntity> NoteComments { get; set; }

        public DbSet<NoteBrowsedRecordEntity> NoteBrowsedRecords { get; set; }

        public DbSet<NoteApprovedRecordEntity> NoteApprovedRecords { get; set; }

        public DbSet<CommentContentEntity> CommentContents { get; set; }

        public DbSet<FtpConfigEntity> FtpConfigs { get; set; }

        public DbSet<SysInfoEntity> SysInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new NoteMap());
            modelBuilder.Configurations.Add(new NoteCommentMap());
            //// 调用WillCascadeOnDelete的另一种选择是，从 model builder中移除全局的约定，在数据库上下文的OnModelCreating方法中关闭整个数据库模型的级联删除规则
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
