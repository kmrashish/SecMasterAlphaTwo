namespace com.ivp.polaris.filewatcher
{
    partial class P_File_Watcher_Service
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
            this.JassWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.JassWatcher)).BeginInit();
            // 
            // JassWatcher
            // 
            this.JassWatcher.EnableRaisingEvents = true;
            this.JassWatcher.Changed += new System.IO.FileSystemEventHandler(this.JassWatcher_Changed);
            this.JassWatcher.Created += new System.IO.FileSystemEventHandler(this.JassWatcher_Created);
            // 
            // P_File_Watcher_Service
            // 
            this.ServiceName = "P_File_Watcher_Service";
            ((System.ComponentModel.ISupportInitialize)(this.JassWatcher)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher JassWatcher;
    }
}
