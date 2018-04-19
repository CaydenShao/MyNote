using MyNote.Business.Notes.Business.V1;
using MyNote.Business.Notes.Business.V2;
using MyNote.Business.Notes.Interface;
using MyNote.Common.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Notes.Business
{
    public class NoteApprovedRecordBusinessFactory
    {
        private static NoteApprovedRecordBusinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteApprovedRecordBusinessFactory()
        { }

        #endregion

        #region Properties

        public static NoteApprovedRecordBusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteApprovedRecordBusinessFactory();
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

        #endregion

        #region Public methods

        public INoteApprovedRecordManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteApprovedRecordBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteApprovedRecordBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
