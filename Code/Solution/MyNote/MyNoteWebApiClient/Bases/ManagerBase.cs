using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteWebApiClient.Bases
{
    public class ManagerBase
    {
        /// <summary>
        /// 格式：http://127.0.0.1:81/
        /// </summary>
        protected string baseAddr = string.Empty;

        #region Constructors

        public ManagerBase(string _baseAddr)
        {
            this.baseAddr = _baseAddr;
        }

        #endregion

        #region Properties

        public string BaseAddr
        {
            get
            {
                return this.baseAddr;
            }
            set
            {
                this.baseAddr = value;
            }
        }

        #endregion

        #region Public methods

        public bool CheckBaseAddr()
        {
            if (string.IsNullOrEmpty(this.baseAddr))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
