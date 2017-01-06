using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feature_Inspection
{
    public partial class FirstMainForm : Form
    {
        string connection_string = "DSN=unipointDB;UID=jbread;PWD=Cloudy2Day";

        public FirstMainForm()
        {
            InitializeComponent();
        }
    }
}
