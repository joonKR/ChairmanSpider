using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GloomySpider
{
    public partial class NotConclude : Form
    {
        GloomyMainForm pForm;
        private List<OPT10075_실시간미체결> oPT10075_dataList;

        public NotConclude()
        {
            InitializeComponent();
        }

        public NotConclude(GloomyMainForm parentForm)
        {
            this.pForm = parentForm;
            InitializeComponent();
        }

        public NotConclude(GloomyMainForm parentForm, List<OPT10075_실시간미체결> oPT10075_dataList) : this(parentForm)
        {
            this.oPT10075_dataList = oPT10075_dataList;
        }

        private void NotConclude_Load(object sender, EventArgs e)
        {
            //Get_OPT10075_실시간미체결요청();
        }
    }
}
