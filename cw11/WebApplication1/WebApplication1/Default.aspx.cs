using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private DateTime _data;

        public Default()
        {
            _data = new DateTime();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDateToLabel();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SetDateToLabel();
        }

        private void SetDateToLabel()
        {
            _data = DateTime.Now;
            Label1.Text = _data.Year + "-" +
                          _data.Month + "-" +
                          _data.Day + " " +
                          _data.Hour + ":" +
                          _data.Minute + ":" +
                          _data.Second + ":" +
                          _data.Millisecond;
        }
    }
}