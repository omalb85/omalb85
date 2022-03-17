using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL
{
  public  class ErrorLog
    {
        public string ErrorPopertyName { get; set; }
        public string ErrorMessage { get; set; }

        public List<ErrorLog> ErrorList { get; set; }

        public void ClearErrors()
        {
            this.ErrorList = new List<ErrorLog>();
            this.ErrorMessage = "";
            this.ErrorPopertyName = "";
        }

        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);

                                      //.Where(c => c.GetType() == type);
        }
        public  Control SetError(Control Controls,string PropName)
        {

            Control FindCtrl = null;
            try
            {
                var listCont = GetAll(Controls);
                foreach (var ctrl in listCont)
                {
                    foreach (Binding binding in ctrl.DataBindings)
                    {
                        var propname = binding.PropertyName;
                        var Databinding = ctrl.DataBindings[0];
                        var member = binding.BindingMemberInfo.BindingMember;
                        if (member == PropName)
                        {
                            FindCtrl = ctrl;
                            break;
                        }
                    }
                    //var binding = ctrl.DataBindings[0];
                    //var member = binding.BindingMemberInfo.BindingMember;
                    //if (member == PropName)
                    //{
                    //    FindCtrl = ctrl;
                    //    break;
                    //}

                }
            }
            catch(Exception ex)
            {

            }
            return FindCtrl;
        }
    }
}
