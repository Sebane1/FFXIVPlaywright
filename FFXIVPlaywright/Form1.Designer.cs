
namespace FFXIVPlaywright {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.macroTextBox = new System.Windows.Forms.TextBox();
            this.parseTextButton = new System.Windows.Forms.Button();
            this.actorsList = new System.Windows.Forms.ListBox();
            this.charactersLabel = new System.Windows.Forms.Label();
            this.macroPreviewBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cleanQuotations = new System.Windows.Forms.CheckBox();
            this.openButton = new System.Windows.Forms.Button();
            this.chatLogSimulatorText = new System.Windows.Forms.TextBox();
            this.simulateLogButton = new System.Windows.Forms.Button();
            this.chatTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // macroTextBox
            // 
            this.macroTextBox.Location = new System.Drawing.Point(12, 25);
            this.macroTextBox.Multiline = true;
            this.macroTextBox.Name = "macroTextBox";
            this.macroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.macroTextBox.Size = new System.Drawing.Size(388, 448);
            this.macroTextBox.TabIndex = 0;
            this.macroTextBox.TextChanged += new System.EventHandler(this.macroTextBox_TextChanged);
            // 
            // parseTextButton
            // 
            this.parseTextButton.Location = new System.Drawing.Point(136, 478);
            this.parseTextButton.Name = "parseTextButton";
            this.parseTextButton.Size = new System.Drawing.Size(98, 21);
            this.parseTextButton.TabIndex = 1;
            this.parseTextButton.Text = "Process Macros";
            this.parseTextButton.UseVisualStyleBackColor = true;
            this.parseTextButton.Click += new System.EventHandler(this.parseTextButton_Click);
            // 
            // actorsList
            // 
            this.actorsList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.actorsList.FormattingEnabled = true;
            this.actorsList.Location = new System.Drawing.Point(406, 25);
            this.actorsList.Name = "actorsList";
            this.actorsList.Size = new System.Drawing.Size(108, 446);
            this.actorsList.TabIndex = 2;
            this.actorsList.SelectedIndexChanged += new System.EventHandler(this.actorListBox_SelectedIndexChanged);
            // 
            // charactersLabel
            // 
            this.charactersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.charactersLabel.AutoSize = true;
            this.charactersLabel.Location = new System.Drawing.Point(394, 9);
            this.charactersLabel.Name = "charactersLabel";
            this.charactersLabel.Size = new System.Drawing.Size(37, 13);
            this.charactersLabel.TabIndex = 3;
            this.charactersLabel.Text = "Actors";
            this.charactersLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // macroPreviewBox
            // 
            this.macroPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.macroPreviewBox.Enabled = false;
            this.macroPreviewBox.Location = new System.Drawing.Point(520, 25);
            this.macroPreviewBox.Multiline = true;
            this.macroPreviewBox.Name = "macroPreviewBox";
            this.macroPreviewBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.macroPreviewBox.Size = new System.Drawing.Size(388, 448);
            this.macroPreviewBox.TabIndex = 4;
            this.macroPreviewBox.TextChanged += new System.EventHandler(this.macroPreviewBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Generated Player Macro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Group Macro";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 478);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(56, 21);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cleanQuotations
            // 
            this.cleanQuotations.AutoSize = true;
            this.cleanQuotations.Location = new System.Drawing.Point(240, 481);
            this.cleanQuotations.Name = "cleanQuotations";
            this.cleanQuotations.Size = new System.Drawing.Size(125, 17);
            this.cleanQuotations.TabIndex = 9;
            this.cleanQuotations.Text = "Dont Use Quotations";
            this.cleanQuotations.UseVisualStyleBackColor = true;
            this.cleanQuotations.CheckedChanged += new System.EventHandler(this.cleanQuotations_CheckedChanged);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(74, 478);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(56, 21);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // chatLogSimulatorText
            // 
            this.chatLogSimulatorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatLogSimulatorText.Location = new System.Drawing.Point(12, 505);
            this.chatLogSimulatorText.Multiline = true;
            this.chatLogSimulatorText.Name = "chatLogSimulatorText";
            this.chatLogSimulatorText.ReadOnly = true;
            this.chatLogSimulatorText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatLogSimulatorText.Size = new System.Drawing.Size(891, 123);
            this.chatLogSimulatorText.TabIndex = 11;
            this.chatLogSimulatorText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // simulateLogButton
            // 
            this.simulateLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simulateLogButton.Location = new System.Drawing.Point(12, 634);
            this.simulateLogButton.Name = "simulateLogButton";
            this.simulateLogButton.Size = new System.Drawing.Size(98, 21);
            this.simulateLogButton.TabIndex = 12;
            this.simulateLogButton.Text = "Simulate Macro";
            this.simulateLogButton.UseVisualStyleBackColor = true;
            this.simulateLogButton.Click += new System.EventHandler(this.simulateLogButton_Click);
            // 
            // chatTimer
            // 
            this.chatTimer.Tick += new System.EventHandler(this.chatTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 680);
            this.Controls.Add(this.simulateLogButton);
            this.Controls.Add(this.chatLogSimulatorText);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.cleanQuotations);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.macroPreviewBox);
            this.Controls.Add(this.charactersLabel);
            this.Controls.Add(this.actorsList);
            this.Controls.Add(this.parseTextButton);
            this.Controls.Add(this.macroTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Group Macro Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox macroTextBox;
        private System.Windows.Forms.Button parseTextButton;
        private System.Windows.Forms.ListBox actorsList;
        private System.Windows.Forms.Label charactersLabel;
        private System.Windows.Forms.TextBox macroPreviewBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox cleanQuotations;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox chatLogSimulatorText;
        private System.Windows.Forms.Button simulateLogButton;
        private System.Windows.Forms.Timer chatTimer;
    }
}

