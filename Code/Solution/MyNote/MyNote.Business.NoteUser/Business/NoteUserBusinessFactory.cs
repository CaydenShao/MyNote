using MyNote.Business.NoteUser.Business.V1;
using MyNote.Business.NoteUser.Business.V2;
using MyNote.Business.NoteUser.Interface;
using MyNote.Common.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.NoteUser.Business
{
    public class NoteUserBusinessFactory
    {
        private static NoteUserBusinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteUserBusinessFactory()
        { }

        #endregion

        #region Properties

        public static NoteUserBusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteUserBusinessFactory();
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

        public INoteUserManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteUserBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteUserBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
