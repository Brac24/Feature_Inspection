using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using BrightIdeasSoftware;
/*ALL TABLES REFER TO THE ATI_FeatureInspection Database */
//THIS IS THE similarWithDifferentDataTables BRANCH
namespace Feature_Inspection
{

    public partial class AlternateUI : Form
    {

        
        string connection_string = "DSN=unipointDB;UID=jbread;PWD=Cloudy2Day";
        public static string opKeyGlobal;
        public static string partNumGlobal;
        public static string jobNumGlobal;
        public static string opService;
        public static int inspectionKeyGlobal;
        public static bool formClosing;
        public static bool featuresExistInPosition = false;
        messagePrompt messPrompt = new messagePrompt();

        BindingSource binding = new BindingSource();
        BindingSource binding2 = new BindingSource();

        
        ListViewItem currentInspection;
        
        string[] inspectionValues = new string[7];  // This will contain info from one of the queried values. Is used as input to currentInspection ListViewItem
        bool newInspection = false;
        public static bool inspectionExists = false; //Does an inspection already exist for a specific opkey? Checks the Inpsection table
        bool submit;
        List<DataGridViewRow> featureData = new List<DataGridViewRow>();

        string featureKey;


        public AlternateUI()
        {
            InitializeComponent();
            this.FormClosing += Close_AlternateUI;
        }

        /// <summary>
        /// When this form first loads you should load it with the previous inspection.
        /// Look for an incomplete inspection in the Inspection table. A user cannot enter a new opkey until the 
        /// last inspection has been completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlternateUI_Load(object sender, EventArgs e)
        {
            partNumberLabelValue.Text = null;
            jobNumberLabelValue.Text = null;
            opNumberLabelValue.Text = null;
            statusLabelValue.Text = null;


            // event handlers
            
            textBox1.KeyPress += checkEnterKeyPressed;
            textBox1.Validating += Validating;
            textBox1.Validated += Validated;            

        }

        private void Close_AlternateUI(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void queryInspectionStatus()
        {
            string status = null;

            string query;

            try
            {
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    conn.Open();

                    query = "SELECT status FROM ATI_FeatureInspection.dbo.Inspection WHERE Inspection_Key = " + getInspectionKey() + ";";

                    OdbcCommand comm = new OdbcCommand(query, conn);
                    OdbcDataReader reader = comm.ExecuteReader();

                    if (reader.Read())
                    {
                        status = reader.GetString(reader.GetOrdinal("status"));
                    }
                }
            }
            catch
            {
                status = null;
            }

            statusLabelValue.Text = status;
            
        }

        //Returns whether an inspection exists for a specifif OpKey
        public bool getInspectionExists()
        {
            return inspectionExists;
        }

        public bool getFeaturesExistInPosition()
        {
            return featuresExistInPosition;
        }
        public int getOpKey()
        {
            return Int32.Parse(opKeyGlobal);
        }
        public string getOpService()
        {
            return opService;
        }

        public string getPartNo()
        {
            return partNumGlobal;
        }

        public int getInspectionKey()
        {
            return inspectionKeyGlobal;
        }

        private bool featuresExistInPositionTable()
        {
            string query;
            bool featuresInPositionTable = false;
            int countValues = 0;

            using (OdbcConnection conn = new OdbcConnection(connection_string))
            {
                conn.Open();

                query = "SELECT Feature_Key, Position_Key, Place, Piece_ID FROM ATI_FeatureInspection.dbo.Position\n " +
                        "WHERE Feature_Key IN (SELECT Feature_Key FROM ATI_FeatureInspection.dbo.Features WHERE Part_Number_FK = (SELECT Part_Number FROM ATI_FeatureInspection.dbo.Operation WHERE Op_Key = (SELECT Op_Key FROM ATI_FeatureInspection.dbo.Inspection WHERE Inspection_Key = " + inspectionKeyGlobal + ")));";

                OdbcCommand comm = new OdbcCommand(query, conn);
                OdbcDataReader reader = comm.ExecuteReader();

                while(reader.Read())
                {
                    countValues++; //Count the amount values that need to be measured
                }

                //If there is at least one value to be measured
                if (countValues > 0)
                {
                    featuresInPositionTable = true;  //There are features in the table
                }
                else
                    featuresExistInPosition = false;
            }

            return featuresInPositionTable;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private bool checkOpKeyTextBoxEmpty(TextBox opkey)
        {
            bool empty = false;

            if(opkey.Text.Equals(String.Empty))
            {
                empty = true;
            }

            return empty;
        }

        private void getInfoFromOpKeyEntry(TextBox opkey)
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    conn.Open();


                    opKeyGlobal = opkey.Text;


                    string query = "SELECT Job.Part_Number, Job_Operation.Job, Job_Operation.Operation_Service\n" +
                                   "FROM PRODUCTION.dbo.Job\n" +
                                   "INNER JOIN PRODUCTION.dbo.Job_Operation\n" +
                                   "ON Job.Job = Job_Operation.Job\n" +
                                   "WHERE Job_Operation.Job_Operation = '" + opkey.Text + "';";

                    OdbcCommand com = new OdbcCommand(query, conn);
                    OdbcDataReader reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        partNumberLabelValue.Text = reader.GetString(reader.GetOrdinal("Part_Number"));
                        jobNumberLabelValue.Text = reader.GetString(reader.GetOrdinal("Job"));
                        opNumberLabelValue.Text = reader.GetString(reader.GetOrdinal("Operation_Service"));
                        partNumberLabelValue.Visible = true;
                        jobNumberLabelValue.Visible = true;
                        opNumberLabelValue.Visible = true;

                        partNumGlobal = partNumberLabelValue.Text;
                        jobNumGlobal = jobNumberLabelValue.Text;
                        opService = opNumberLabelValue.Text;
                    }
                    else
                    {
                        partNumberLabelValue.Text = null;
                        jobNumberLabelValue.Text = null;
                        opNumberLabelValue.Text = null;
                        opKeyGlobal = null;
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Please insert a valid OpKey ");
            }
            
        }

        private void queryInspectionKeyFromInspectionTable()
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    conn.Open();

                    string getInspectionKey = "SELECT Inspection_Key FROM ATI_FeatureInspection.dbo.Inspection\n" +
                                             "WHERE Op_Key=" + opKeyGlobal + ";";
                    OdbcCommand conncommand2 = new OdbcCommand(getInspectionKey, conn);
                    OdbcDataReader reader1 = conncommand2.ExecuteReader();
                    while (reader1.Read())
                    {
                        inspectionKeyGlobal = reader1.GetInt32(reader1.GetOrdinal("Inspection_Key"));
                    }

                }
            }
            catch
            {

            }
            
        }

        /// <summary>
        /// This event is triggered when the user presses the Enter key. It is the initial step needed 
        /// to begin inspecting.
        /// 1) Check if the the opkey exists in the Operation table. If it does not then create it
        /// 2) If the op did not exist then automatically create an inspection for it in the Inspection table.
        /// 3) Check if 
        /// 4) If it exists then check if it is complete else create a new inspection for it in inspection table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool opExists = false;
            
            //Check the enter key was pressed
            if (e.KeyChar == (char)13)
            {

                queryInspectionKeyFromInspectionTable();

            }

        }

        private bool opKeyExistsInInspection()
        {
            //Query checking if an inspection for an opkey exists in the Inspection table
            using (OdbcConnection conn = new OdbcConnection(connection_string))
            {
                conn.Open();

                string status;
                string inspectExist = "SELECT Op_Key, Inspection_Key, status FROM ATI_FeatureInspection.dbo.Inspection\n" +
                                      "WHERE Op_Key = " + textBox1.Text;
                OdbcCommand command = new OdbcCommand(inspectExist, conn);
                OdbcDataReader reader = command.ExecuteReader();

                // If there is a value in the reader then there is inspection 
                if (reader.Read())
                {
                    inspectionExists = true;

                    status = reader.GetString(reader.GetOrdinal("status"));
                    if (status == "Complete")
                    {
                        inspectionExists = false; //If the old inspection is complete allow for the creation of a new one
                    }
                    else
                    {
                        inspectionKeyGlobal = reader.GetInt32(reader.GetOrdinal("Inspection_Key"));
                    }
                }
                else
                    inspectionExists = false;
            }

            return inspectionExists;
        }
        private void insertOpKeyToOperation()
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    conn.Open();

                    string insertOperation = "INSERT INTO ATI_FeatureInspection.dbo.Operation (Op_Key, Job_Number, Part_Number, Operation_Number)\n" +
                                             " VALUES (convert(int," + opKeyGlobal + "),'" + jobNumGlobal + "','" + partNumGlobal + "','" + opService + "');";

                    OdbcCommand com3 = new OdbcCommand(insertOperation, conn);
                    com3.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a valid opkey");
            }
            
        }

        private void insertOpKeyToInspection()
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    conn.Open();
                    string insertInspection = "INSERT INTO ATI_FeatureInspection.dbo.Inspection (Op_Key,status)\n" +
                                            "VALUES (" + opKeyGlobal + ",'Incomplete');";

                    OdbcCommand conncommand = new OdbcCommand(insertInspection, conn);
                    conncommand.ExecuteNonQuery();
                }
            }
            catch
            {
                
            }
            
               
        }

       
        private bool opKeyExistsInOperationTable()
        {
            bool opExists = false;

            try
            {
                // Will check if OpKey exists in the Operation table
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    conn.Open();


                    string query2 = "SELECT *\n" +
                                    "FROM ATI_FeatureInspection.dbo.Operation\n" +
                                    "WHERE Op_Key = '" + opKeyGlobal + "';";

                    OdbcCommand com2 = new OdbcCommand(query2, conn);
                    OdbcDataReader reader2 = com2.ExecuteReader();


                    while (reader2.Read())
                    {
                        opExists = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a valid opkey");
            }
            

            return opExists;
        }

        private void bindData()
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                using (OdbcCommand com = conn.CreateCommand())
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(com))
                {
                    /*string query = "SELECT Feature_Name, Nominal, Plus_Tolerance, Minus_Tolerance \n" +
                                                           "FROM ATI_FeatureInspection.dbo.Features \n" +
                                                           "WHERE Feature_Key IN " + featureKey + ";"; ;*/


                    string query = "SELECT   Position.Feature_Key, Piece_ID, Place, Features.Feature_Name, Features.Nominal, Features.Plus_Tolerance, Features.Minus_Tolerance, Measured_Value FROM ATI_FeatureInspection.dbo.Position " +
                                   "INNER JOIN ATI_FeatureInspection.dbo.Features " +
                                   "ON Position.Feature_Key = Features.Feature_Key " +
                                   "WHERE Position.Inspection_Key_FK = " + getInspectionKey();

                    com.CommandText = query;
                    DataTable t = new DataTable();
                    adapter.Fill(t);

                    dataListView1.DataSource = null;
                    dataListView1.DataSource = t;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Youre a foo", e.Message);
            }
        }

        //Opens the user input form and reopens main form after closed
        private void openUserInputForm()
        {
            this.Hide();
            //Form userInput = new UserInputForm();
            UserInputForm userInput = new UserInputForm();
            userInput.ShowDialog();
            if (userInput.getSubmitClicked())
            {
                featureKey = "(" + String.Join(",", userInput.getFeatureKeysSelected()) + ")";

                bindData();
                textBox1.Focus();
                

            }
            userInput = null;
            Show();

        }

        private void openMessagePrompt(messagePrompt mes)
        {
            this.Hide();
            mes.ShowDialog();
            newInspection = mes.getNewInspectionValue();
            mes = null;
            Show();

        }
        private void newInspecButton_Click(object sender, EventArgs e)
        {
            //openUserInputForm();
        }

        private void addFeatureButton_Click(object sender, EventArgs e)
        {
            queryInspectionKeyFromInspectionTable(); //Let form know what the inspection key is before going in to user input form

            if (partNumberLabelValue.Text != "" && opNumberLabelValue.Text != "")
            {
                openUserInputForm();
            }

            else
            {
                string message = "Please Enter a valid OpKey";
                string caption = "Invalid OpKey";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, button);

                if (result == DialogResult.OK)
                {

                }
            }


        }

        private void submitFeatures()
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataListView2_BeforeCreatingGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
        {
            //e.Canceled = true;
            
        }

        private void dataListView1_BeforeCreatingGroups(object sender, BrightIdeasSoftware.CreateGroupsEventArgs e)
        {
            /*
            int groupNumber = 0;
            foreach(BrightIdeasSoftware.OLVGroup group in e.Groups)
            {
                foreach(OLVListItem item in group.Items)
                {
                     rowObject = item.RowObject as DataListView;
                    groupNumber += rowObject.
                }
            }
            */
           // e.Canceled = true;
          
            dataListView1.AutoResizeColumns();

            dataListView1.Refresh();
            dataListView1.Update();
            dataListView1.AllColumns[6].CellEditUseWholeCell = true;
            dataListView1.AllColumns[0].IsEditable = false;
            dataListView1.AllColumns[1].IsEditable = false;
            dataListView1.AllColumns[2].IsEditable = false;
            dataListView1.AllColumns[3].IsEditable = false;
            dataListView1.AllColumns[4].IsEditable = false;
            dataListView1.AllColumns[5].IsEditable = false;
            dataListView1.AllColumns[6].IsEditable = false;

        }

        private void dataListView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            List<float> measuredValues = new List<float>();

        }


        private void dataListView1_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {

            try
            {
                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    conn.Open();
                    string query = "UPDATE ATI_FeatureInspection.dbo.Position SET Measured_Value= " + Decimal.Parse(e.NewValue.ToString())
                                   + " WHERE Feature_Key=" + dataListView1.AllColumns[0].GetValue(e.RowObject) + " AND Piece_ID = "+ dataListView1.AllColumns[1].GetValue(e.RowObject) +
                                      "AND Place = "+dataListView1.AllColumns[2].GetValue(e.RowObject)+" ;";

                    OdbcCommand conncommand = new OdbcCommand(query, conn);
                    conncommand.ExecuteNonQuery();
                    e.NewValue = Decimal.Parse(e.NewValue.ToString());

                }
            }
            catch (FormatException err)
            {
                MessageBox.Show("Please insert a number ", err.Message);
                e.NewValue = e.Value;
                

                using (OdbcConnection conn = new OdbcConnection(connection_string))
                {
                    
                    conn.Open();
                    string query = "UPDATE ATI_FeatureInspection.dbo.Position SET Measured_Value= " + Decimal.Parse(e.Value.ToString())
                                   + " WHERE Feature_Key=" + dataListView1.AllColumns[0].GetValue(e.RowObject) + " AND Piece_ID = " + dataListView1.AllColumns[1].GetValue(e.RowObject) +
                                      "AND Place = " + dataListView1.AllColumns[2].GetValue(e.RowObject) + " ;";

                    OdbcCommand conncommand = new OdbcCommand(query, conn);
                    conncommand.ExecuteNonQuery();
                    e.NewValue = Decimal.Parse(e.Value.ToString());

                    dataListView1.Refresh();
                    dataListView1.RefreshSelectedObjects();
                }
            }
        }

        private void dataListView1_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            //Will check if the value in the measured value column is a number or not
            try
            {
                e.NewValue = Decimal.Parse(e.NewValue.ToString());
            }
            catch
            {
                //If not use the last value that was being used
                e.NewValue = Decimal.Parse(e.Value.ToString());
            }
            
            
        }

        private void finishInspectionButton_Click(object sender, EventArgs e)
        {
            using (OdbcConnection conn = new OdbcConnection(connection_string))
            {
                conn.Open();

                string query = "UPDATE ATI_FeatureInspection.dbo.Inspection SET status= 'Complete'" +
                               "WHERE Inspection_Key=" + inspectionKeyGlobal;

                OdbcCommand com = new OdbcCommand(query, conn);
                com.ExecuteNonQuery();
            }

            queryInspectionStatus(); //Change staus in form
        }

        //private void inspection

        
        /// <summary>
        /// This event is triggered when the user presses the Enter key. It is the initial step needed 
        /// to begin inspecting.
        /// 1) Validate OpKey Entry
        /// 2) Once all validation has been done we can now check if this information exists in the operation table
        /// 3) If the opkey does not exist in the operation table create it in the Operation table and create an inspection for it
        /// 4) If it already exists in operation but not in the Inspection table create an inspection for it
        /// 5) Now the initial information has been set in the database now we wait for a user action such as adding features
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkEnterKeyPressed(object sender, KeyPressEventArgs e)
     {
            if(e.KeyChar == ((char)13))
            {
                //If empty

                if (checkOpKeyTextBoxEmpty(textBox1))
                {
                    invalidOpKeyMessage();
                }
                else
                {
                    featuresExistInPosition = false;
                    getInfoFromOpKeyEntry(textBox1);
                    if (opNumberLabelValue.Text.Equals(String.Empty))
                    {
                        invalidOpKeyMessage();
                    }
                    else if (!opKeyExistsInOperationTable())
                    {
                        insertOpKeyToOperation();
                        insertOpKeyToInspection();
                    }
                    else if (!opKeyExistsInInspection())
                    {
                        insertOpKeyToInspection();
                    }
                    else if (featuresExistInPositionTable())
                    {
                        queryInspectionStatus();
                        featuresExistInPosition = true; //This is to let the other form know that there is already an inspection begun for this opkey
                        bindData();
                    }
                    else
                        bindData();

                    queryInspectionKeyFromInspectionTable();
                    queryInspectionStatus();

                    if (statusLabelValue.Text.Equals("Complete  "))
                    {
                        dataListView1.CellEditActivation = ObjectListView.CellEditActivateMode.None;
                    }
                    else
                        dataListView1.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClickAlways;
                }
            }
            //Do not allow spaces in opkey textbox
            else if(e.KeyChar == ((char)32))
            {
                string message = "Spaces are not permitted";
                string caption = "No Spaces Please";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, button);
                e.KeyChar = ((char)0);
            }
        }

        private void Validating(object sender, CancelEventArgs e)
        {
            
            if(formClosing)
            {

            }
            else if ((sender as TextBox).Text.Equals(string.Empty))
            {
                //e.Cancel = true;
                invalidOpKeyMessage();
            }
           else if (textBox1.Text != opKeyGlobal)
            {
                e.Cancel = true;
                string message = "Please press Enter in the OpKey text field";
                string caption = "OpKey has changed";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, button);
            }
            else if(validateValidOpKey(opNumberLabelValue))
            {

            }
            else
            {
                e.Cancel = true;
                string message = "Please Hit Enter in the OpKey Text Field before continuing";
                string caption = "Must Press Enter to Continue";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, button);
            }
        }

        private void Validated(object sender, EventArgs e)
        {

        }


        private bool validateValidOpKey(object sender)
        {
            Label infoLabelText = sender as Label;

            bool validOpKey = false;
            if (infoLabelText.Text != "")
            {
                validOpKey = true;
                
            }
            else
                opNumberLabelValue.Hide();


            return validOpKey;
        }

        private void invalidOpKeyMessage()
        {

            string message = "Please Enter a valid OpKey";
            string caption = "Invalid OpKey";
            MessageBoxButtons button = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, button);
        }
        /*
        private void LabelValue_TextChanged(object sender, EventArgs e)
        {
            //If invalid opkey
            if(!validateValidOpKey(sender))
            {
                invalidOpKeyMessage(); //Tell user that it is invalid
            }
            
        }
        */

        private void AlternateUI_Click(object sender, EventArgs e)
        {

        }

        private void AlternateUI_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataListView1_AfterCreatingGroups(object sender, CreateGroupsEventArgs e)
        {
            dataListView1.AutoResizeColumns();
            
        }

        private void dataListView1_CellEditFinished(object sender, CellEditEventArgs e)
        {
            
        }
    }
}
