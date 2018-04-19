using MyNote.Business.Common.Business.V1;
using MyNote.Business.Common.Business.V2;
using MyNote.Business.Common.Interface;
using MyNote.Common.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Business.Common.Business
{
    public class SecurityCheckBusinessFactory
    {
        private static SecurityCheckBusinessFactory instance = null;
        private static object syncRoot = new object();

        #region Constructors

        private SecurityCheckBusinessFactory()
        { }

        #endregion

        #region Properties

        public static SecurityCheckBusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SecurityCheckBusinessFactory();
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

        public ISecurityCheckManager Create(string version)
        {
            if (version.StartsWith(VersionsHead.V1, StringComparison.OrdinalIgnoreCase))
            {
                return new SecurityCheckBusinessV1();
            }
            else if (version.StartsWith(VersionsHead.V2, StringComparison.OrdinalIgnoreCase))
            {
                return new SecurityCheckBusinessV2();
            }
            else
            {
                throw new NotImplementedException("该版本暂未实现：" + version);
            }
        }

        #endregion
    }
}
