using MyNote.Contracts.DataContracts.Notes;
using MyNote.Contracts.DataContracts.NoteUser;
using MyNote.DataAccess.Notes.DAL;
using MyNote.DataAccess.NoteUser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //bool result = NoteDAL.Instance.AddNoteAndContents(new Note()
                //{
                //    AuthorId = 1,
                //    Remark = "测试笔记1",
                //    IsShared = false
                //}, 
                //new List<NoteContent>
                //{
                //    new NoteContent()
                //    {
                //        Type = 0,
                //        Content = "测试笔记1的内容1"
                //    },
                //    new NoteContent()
                //    {
                //        Type = 0,
                //        Content = "测试笔记1的内容2"
                //    },
                //    new NoteContent()
                //    {
                //        Type = 0,
                //        Content = "测试笔记1的内容3"
                //    }
                //});

                //Console.WriteLine(result.ToString());
                //int totalRows = 0;
                //List<Note> notes = NoteDAL.Instance.SearchByAuthorId(5, 1, 1, out totalRows);
                //Console.WriteLine(totalRows.ToString());
                User user = UserDAL.Instance.GetUserByIdDR(1);
                Console.WriteLine(user.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
