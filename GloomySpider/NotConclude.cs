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
        public NotConclude()
        {
            InitializeComponent();
        }

        private void NotConclude_Load(object sender, EventArgs e)
        {
            this.requestTR();
        }

        private void requestTR()
        {
            //GloomyAPI.Instance.SetInputValue();
        }
    }
}
