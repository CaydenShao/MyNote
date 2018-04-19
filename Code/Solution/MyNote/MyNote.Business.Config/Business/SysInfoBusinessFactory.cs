using MyNote.Business.Config.Business.V1;
using MyNote.Business.Config.Business.V2;
using MyNote.Business.Config.Interface;
using MyNote.Common.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Config.Business
{
    public class SysInfoBusinessFactory
    {
        private static SysInfoBusinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private SysInfoBusinessFactory()
        { }

        #endregion

        #region Properties

        public static SysInfoBusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SysInfoBusinessFactory();
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

        public ISysInfoManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new SysInfoBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new SysInfoBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
