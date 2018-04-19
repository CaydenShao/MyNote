using MyNote.Business.Common;
using MyNote.Business.Common.Bases;
using MyNote.Business.Notes.Business;
using MyNote.Business.Notes.Interface;
using MyNote.Common.Enums;
using MyNote.Common.Helpers;
using MyNote.Contracts.DataContracts.Notes;
using MyNote.DataAccess.Notes.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Manager
{
    public class NoteBrowsedRecordManager : ManagerBase, INoteBrowsedRecordManager
    {
        #region Constructors

        public NoteBrowsedRecordManager(string version)
            : base(version)
        {

        }

        #endregion

        #region Public methods

        public ManagerResult<NoteBrowsedRecord> AddNoteBrowsedRecord(int noteId, int userId)
        {
            INoteBrowsedRecordManager business = NoteBrowsedRecordBusinessFactory.Instance.Create(this.Version);
            return business.AddNoteBrowsedRecord(noteId, userId);
        }

        public ManagerResult<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByNoteId(int noteId)
        {
            INoteBrowsedRecordManager business = NoteBrowsedRecordBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteBrowsedRecordsByNoteId(noteId);
        }

        public ManagerResult<List<NoteBrowsedRecord>> GetNoteBrowsedRecordsByUserId(int userId)
        {
            INoteBrowsedRecordManager business = NoteBrowsedRecordBusinessFactory.Instance.Create(this.Version);
            return business.GetNoteBrowsedRecordsByUserId(userId);
        }

        #endregion
    }
}
