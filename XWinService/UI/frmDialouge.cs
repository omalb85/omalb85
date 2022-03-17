using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XWinService
{
    public partial class frmDialouge : Form
    {
        public string m_Message { get; set; }
        public frmDialouge(string Message)
        {
            InitializeComponent();
            this.m_Message = Message;
        }

        private  void frmDialouge_Load(object sender, EventArgs e)
        {
            lblMessage.Text = this.m_Message;
           // await Task.Delay(3000);
            //lblMessage.Text = "Done!!";
            //this.DialogResult = DialogResult.OK;
        }

       
    }
}
