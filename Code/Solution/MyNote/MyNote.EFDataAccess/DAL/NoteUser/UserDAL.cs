using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.EFDataAccess.Entities.NoteUser;
using MyNote.EFDataAccess.Extensions.NoteUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.EFDataAccess.DAL.NoteUser
{
    public class UserDAL
    {
        private static UserDAL instance = null;
        private static object syncRoot = new object();
        private MyNoteContext dbContext = null;

        #region Constructors

        private UserDAL()
        {
            this.dbContext = new MyNoteContext();
        }

        #endregion

        #region Properties

        public static UserDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new UserDAL();
                        }
                    }
                }

                return instance;
            }
        }

        public static object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        private MyNoteContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        #endregion

        #region Public methods

        public User AddUser(User user)
        {
            UserEntity entity = user.ToEntity();
            entity.CreateTime = DateTime.Now;
            entity.LastLoginTime = DateTime.Now;
            this.dbContext.Users.Add(entity);
            this.dbContext.SaveChanges();
            return entity.ToModel();
        }

        public User AddUser(UserEntity entity)
        {
            this.dbContext.Users.Add(entity);
            return entity.ToModel();
        }

        public User GetUserById(int id)
        {
            UserEntity entity = this.dbContext.Users.FirstOrDefault(u => u.Id == id);
            return entity == null ? null : entity.ToModel();
        }

        public User GetUserByPhoneNumber(string phoneNumber)
        {
            UserEntity entity = this.dbContext.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            return entity == null ? null : entity.ToModel();
        }

        public UserEntity GetUserEntityByPhoneNumber(string phoneNumber)
        {
            return this.dbContext.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }

        public User GetUserByToken(string token)
        {
            UserEntity entity = this.dbContext.Users.FirstOrDefault(u => u.Token == token);
            return entity == null ? null : entity.ToModel();
        }

        public User GetUserByIdAndToken(int id, string token)
        {
            UserEntity entity = this.dbContext.Users.FirstOrDefault(u => u.Id == id && u.Token == token);
            return entity == null ? null : entity.ToModel();
        }

        public User UpdateTokenById(int id, string token)
        {
            UserEntity entity = this.dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (entity == null)
            {
                return null;
            }
            else
            {
                entity.Token = token;
                this.dbContext.SaveChanges();
                return entity.ToModel();
            }
        }

        #endregion
    }
}
