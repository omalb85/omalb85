using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XWinService.UI
{
    public struct WindowsFocusControls
    {
        #region Member Variables

        private Control m_DataboundControl;
        private int m_TabIndex;

        #endregion

        #region Constructors

        public WindowsFocusControls(Control objControl, int TabIndex)
        {
            m_DataboundControl = objControl;
            m_TabIndex = TabIndex;
        }

        #endregion

        #region Properties

        public Control DataboundControl
        {
            get { return m_DataboundControl; }
            set { m_DataboundControl = value; }
        }

        public int TabIndex
        {
            get { return m_TabIndex; }
            set { m_TabIndex = value; }
        }

        #endregion
    }
}
