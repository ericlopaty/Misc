namespace DataUpdater
{
    partial class ServiceDataUpdater
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serviceInterval = new System.Windows.Forms.Timer(this.components);
            // 
            // serviceInterval
            // 
            this.serviceInterval.Interval = 10000;
            this.serviceInterval.Tick += new System.EventHandler(this.serviceInterval_Tick);
            // 
            // ServiceDataUpdater
            // 
            this.ServiceName = "Service1";

        }

        #endregion

        private System.Windows.Forms.Timer serviceInterval;
    }
}
