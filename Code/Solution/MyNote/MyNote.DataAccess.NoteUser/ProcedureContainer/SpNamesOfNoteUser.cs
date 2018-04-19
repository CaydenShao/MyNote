using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.NoteUser.ProcedureContainer
{
    public static class SpNamesOfNoteUser
    {
        /// <summary>
        /// 添加一条NoteUser记录，并返回添加成功的记录
        /// </summary>
        public const string Sp_Insert_NoteUser = "Sp_Insert_NoteUser";
        /// <summary>
        /// 通过Id获取NoteUser记录
        /// </summary>
        public const string Sp_Select_NoteUserById = "Sp_Select_NoteUserById";
        /// <summary>
        /// 通过PhoneNumber获取NoteUser记录
        /// </summary>
        public const string Sp_Select_NoteUserByPhoneNumber = "Sp_Select_NoteUserByPhoneNumber";
        /// <summary>
        /// 通过Token获取NoteUser记录
        /// </summary>
        public const string Sp_Select_NoteUserByToken = "Sp_Select_NoteUserByToken";
        /// <summary>
        /// 通过Id和Token获取NoteUser记录
        /// </summary>
        public const string Sp_Select_NoteUserByIdAndToken = "Sp_Select_NoteUserByIdAndToken";
        /// <summary>
        /// 通过Id更新Token列
        /// </summary>
        public const string Sp_Update_NoteUserToken = "Sp_Update_NoteUserToken";
    }
}
