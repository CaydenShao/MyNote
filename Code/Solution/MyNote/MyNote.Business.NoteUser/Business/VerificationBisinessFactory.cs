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
    public class VerificationBisinessFactory
    {
        private static VerificationBisinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private VerificationBisinessFactory()
        { }

        #endregion

        #region Properties

        public static VerificationBisinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new VerificationBisinessFactory();
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

        public IVerificationManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new VerificationBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new VerificationBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
