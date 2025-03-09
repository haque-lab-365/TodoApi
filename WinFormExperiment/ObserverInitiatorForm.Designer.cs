namespace WinFormExperiment
{
    partial class ObserverInitiatorForm
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
            btnNotify = new Button();
            btnOpenObserver = new Button();
            SuspendLayout();
            // 
            // btnNotify
            // 
            btnNotify.Location = new Point(330, 301);
            btnNotify.Name = "btnNotify";
            btnNotify.Size = new Size(94, 29);
            btnNotify.TabIndex = 0;
            btnNotify.Text = "Notify";
            btnNotify.UseVisualStyleBackColor = true;
            btnNotify.Click += btnNotify_Click;
            // 
            // btnOpenObserver
            // 
            btnOpenObserver.Location = new Point(430, 301);
            btnOpenObserver.Name = "btnOpenObserver";
            btnOpenObserver.Size = new Size(237, 29);
            btnOpenObserver.TabIndex = 1;
            btnOpenObserver.Text = "Open Observer";
            btnOpenObserver.UseVisualStyleBackColor = true;
            btnOpenObserver.Click += btnOpenObserver_Click;
            // 
            // ObserverInitiatorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 684);
            Controls.Add(btnOpenObserver);
            Controls.Add(btnNotify);
            Name = "ObserverInitiatorForm";
            Text = "Main Form |  Acting as the subject and trigger notifications to the observers";
            ResumeLayout(false);
        }

        #endregion

        private Button btnNotify;
        private Button btnOpenObserver;
    }
}