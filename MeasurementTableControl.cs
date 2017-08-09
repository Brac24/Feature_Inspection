using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feature_Inspection
{
    [System.ComponentModel.ComplexBindingProperties("DataSource", "DataMember")]
    public partial class MeasurementTableControl : UserControl
    {
        
        public MeasurementTableControl()
        {
            InitializeComponent();
        }

        private void mesasurementsTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
