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
    public class NoteCommentBusinessFactory
    {
        private static NoteCommentBusinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteCommentBusinessFactory()
        { }

        #endregion

        #region Properties

        public static NoteCommentBusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteCommentBusinessFactory();
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

        public INoteCommentManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteCommentBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteCommentBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
