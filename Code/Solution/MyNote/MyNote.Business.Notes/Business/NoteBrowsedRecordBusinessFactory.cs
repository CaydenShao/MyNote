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
    public class NoteBrowsedRecordBusinessFactory
    {
        private static NoteBrowsedRecordBusinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private NoteBrowsedRecordBusinessFactory()
        { }

        #endregion

        #region Properties

        public static NoteBrowsedRecordBusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new NoteBrowsedRecordBusinessFactory();
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

        public INoteBrowsedRecordManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteBrowsedRecordBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new NoteBrowsedRecordBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
