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
            this.aTIFeatureInspectionDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aTI_FeatureInspectionDataSet = new Feature_Inspection.ATI_FeatureInspectionDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.aTIFeatureInspectionDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTI_FeatureInspectionDataSet)).BeginInit();
            this.SuspendLayout();
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
            // TweakUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 622);
            this.Name = "TweakUI";
            this.Text = "TweakUI";
            ((System.ComponentModel.ISupportInitialize)(this.aTIFeatureInspectionDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTI_FeatureInspectionDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource aTIFeatureInspectionDataSetBindingSource;
        private ATI_FeatureInspectionDataSet aTI_FeatureInspectionDataSet;
    }
}