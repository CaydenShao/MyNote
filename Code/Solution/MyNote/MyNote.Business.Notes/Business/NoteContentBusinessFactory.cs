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
    public class NoteContentBusinessFactory
    {
        private static NoteContentBusinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteContentBusinessFactory()
        { }

        #endregion

        #region Properties

        public static NoteContentBusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteContentBusinessFactory();
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

        public INoteContentManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteContentBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteContentBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
