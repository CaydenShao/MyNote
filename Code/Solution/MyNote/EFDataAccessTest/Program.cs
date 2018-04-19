using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.EFDataAccess.DAL.Notes;
using MyNote.EFDataAccess.DAL.NoteUser;
using MyNote.EFDataAccess.DbInitializers;
using MyNote.EFDataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDataAccessTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            User user = UserDAL.Instance.GetUserById(1);
            MessageBox.Show(user.Name);
            Note note = NoteDAL.Instance.AddNote(new Note()
            {
                AuthorId = 1,
                Title = "Entity Framework",
                CreateTime = DateTime.Now,
                DeletedTime = DateTime.Now,
                IsDeleted = false,
                IsShared = false,
                LastBrowsedTime = DateTime.Now,
                Remark = "Code First"
            });
            MessageBox.Show(note.Id.ToString());
            Application.Run(new Form1());
        }
    }
}
