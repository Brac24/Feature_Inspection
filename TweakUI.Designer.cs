namespace Feature_Inspection
{
    partial class TweakUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aTIFeatureInspectionDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aTI_FeatureInspectionDataSet = new Feature_Inspection.ATI_FeatureInspectionDataSet();
            this.featureKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plusToleranceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minusToleranceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piecesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inheritedFromFeatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNumberFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationNumberFKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTIFeatureInspectionDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTI_FeatureInspectionDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.featureKeyDataGridViewTextBoxColumn,
            this.nominalDataGridViewTextBoxColumn,
            this.plusToleranceDataGridViewTextBoxColumn,
            this.minusToleranceDataGridViewTextBoxColumn,
            this.featureNameDataGridViewTextBoxColumn,
            this.placesDataGridViewTextBoxColumn,
            this.activeDataGridViewTextBoxColumn,
            this.piecesDataGridViewTextBoxColumn,
            this.inheritedFromFeatureDataGridViewTextBoxColumn,
            this.partNumberFKDataGridViewTextBoxColumn,
            this.operationNumberFKDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Features";
            this.dataGridView1.DataSource = this.aTIFeatureInspectionDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(503, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(310, 167);
            this.dataGridView1.TabIndex = 0;
            // 
            // aTIFeatureInspectionDataSetBindingSource
            // 
            this.aTIFeatureInspectionDataSetBindingSource.DataSource = this.aTI_FeatureInspectionDataSet;
            this.aTIFeatureInspectionDataSetBindingSource.Position = 0;
            // 
            // aTI_FeatureInspectionDataSet
            // 
            this.aTI_FeatureInspectionDataSet.DataSetName = "ATI_FeatureInspectionDataSet";
            this.aTI_FeatureInspectionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // featureKeyDataGridViewTextBoxColumn
            // 
            this.featureKeyDataGridViewTextBoxColumn.DataPropertyName = "Feature_Key";
            this.featureKeyDataGridViewTextBoxColumn.HeaderText = "Feature_Key";
            this.featureKeyDataGridViewTextBoxColumn.Name = "featureKeyDataGridViewTextBoxColumn";
            this.featureKeyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nominalDataGridViewTextBoxColumn
            // 
            this.nominalDataGridViewTextBoxColumn.DataPropertyName = "Nominal";
            this.nominalDataGridViewTextBoxColumn.HeaderText = "Nominal";
            this.nominalDataGridViewTextBoxColumn.Name = "nominalDataGridViewTextBoxColumn";
            // 
            // plusToleranceDataGridViewTextBoxColumn
            // 
            this.plusToleranceDataGridViewTextBoxColumn.DataPropertyName = "Plus_Tolerance";
            this.plusToleranceDataGridViewTextBoxColumn.HeaderText = "Plus_Tolerance";
            this.plusToleranceDataGridViewTextBoxColumn.Name = "plusToleranceDataGridViewTextBoxColumn";
            // 
            // minusToleranceDataGridViewTextBoxColumn
            // 
            this.minusToleranceDataGridViewTextBoxColumn.DataPropertyName = "Minus_Tolerance";
            this.minusToleranceDataGridViewTextBoxColumn.HeaderText = "Minus_Tolerance";
            this.minusToleranceDataGridViewTextBoxColumn.Name = "minusToleranceDataGridViewTextBoxColumn";
            // 
            // featureNameDataGridViewTextBoxColumn
            // 
            this.featureNameDataGridViewTextBoxColumn.DataPropertyName = "Feature_Name";
            this.featureNameDataGridViewTextBoxColumn.HeaderText = "Feature_Name";
            this.featureNameDataGridViewTextBoxColumn.Name = "featureNameDataGridViewTextBoxColumn";
            // 
            // placesDataGridViewTextBoxColumn
            // 
            this.placesDataGridViewTextBoxColumn.DataPropertyName = "Places";
            this.placesDataGridViewTextBoxColumn.HeaderText = "Places";
            this.placesDataGridViewTextBoxColumn.Name = "placesDataGridViewTextBoxColumn";
            // 
            // activeDataGridViewTextBoxColumn
            // 
            this.activeDataGridViewTextBoxColumn.DataPropertyName = "Active";
            this.activeDataGridViewTextBoxColumn.HeaderText = "Active";
            this.activeDataGridViewTextBoxColumn.Name = "activeDataGridViewTextBoxColumn";
            // 
            // piecesDataGridViewTextBoxColumn
            // 
            this.piecesDataGridViewTextBoxColumn.DataPropertyName = "Pieces";
            this.piecesDataGridViewTextBoxColumn.HeaderText = "Pieces";
            this.piecesDataGridViewTextBoxColumn.Name = "piecesDataGridViewTextBoxColumn";
            // 
            // inheritedFromFeatureDataGridViewTextBoxColumn
            // 
            this.inheritedFromFeatureDataGridViewTextBoxColumn.DataPropertyName = "InheritedFromFeature";
            this.inheritedFromFeatureDataGridViewTextBoxColumn.HeaderText = "InheritedFromFeature";
            this.inheritedFromFeatureDataGridViewTextBoxColumn.Name = "inheritedFromFeatureDataGridViewTextBoxColumn";
            // 
            // partNumberFKDataGridViewTextBoxColumn
            // 
            this.partNumberFKDataGridViewTextBoxColumn.DataPropertyName = "Part_Number_FK";
            this.partNumberFKDataGridViewTextBoxColumn.HeaderText = "Part_Number_FK";
            this.partNumberFKDataGridViewTextBoxColumn.Name = "partNumberFKDataGridViewTextBoxColumn";
            // 
            // operationNumberFKDataGridViewTextBoxColumn
            // 
            this.operationNumberFKDataGridViewTextBoxColumn.DataPropertyName = "Operation_Number_FK";
            this.operationNumberFKDataGridViewTextBoxColumn.HeaderText = "Operation_Number_FK";
            this.operationNumberFKDataGridViewTextBoxColumn.Name = "operationNumberFKDataGridViewTextBoxColumn";
            // 
            // dataListView1
            // 
            this.dataListView1.CellEditUseWholeCell = false;
            this.dataListView1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.aTI_FeatureInspectionDataSet, "Features.Feature_Key", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.dataListView1.DataSource = null;
            this.dataListView1.Location = new System.Drawing.Point(169, 220);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.Size = new System.Drawing.Size(547, 321);
            this.dataListView1.TabIndex = 1;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            // 
            // TweakUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 622);
            this.Controls.Add(this.dataListView1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TweakUI";
            this.Text = "TweakUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTIFeatureInspectionDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTI_FeatureInspectionDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource aTIFeatureInspectionDataSetBindingSource;
        private ATI_FeatureInspectionDataSet aTI_FeatureInspectionDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plusToleranceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minusToleranceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn piecesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inheritedFromFeatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNumberFKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationNumberFKDataGridViewTextBoxColumn;
        private BrightIdeasSoftware.DataListView dataListView1;
    }
}