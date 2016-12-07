namespace Numeric_Precision
{
    partial class Demonstration
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtMainDisplay = new System.Windows.Forms.RichTextBox();
            this.txtMainInput1 = new System.Windows.Forms.TextBox();
            this.txtMainInput2 = new System.Windows.Forms.TextBox();
            this.cboMainOperator = new System.Windows.Forms.ComboBox();
            this.lblMainInput1 = new System.Windows.Forms.Label();
            this.lblMainInput2 = new System.Windows.Forms.Label();
            this.txtMainInput3 = new System.Windows.Forms.TextBox();
            this.lblMainInput3 = new System.Windows.Forms.Label();
            this.btnMainCalculate = new System.Windows.Forms.Button();
            this.lblOperator = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1240, 577);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.lblOperator);
            this.tabMain.Controls.Add(this.btnMainCalculate);
            this.tabMain.Controls.Add(this.lblMainInput3);
            this.tabMain.Controls.Add(this.txtMainInput3);
            this.tabMain.Controls.Add(this.lblMainInput2);
            this.tabMain.Controls.Add(this.lblMainInput1);
            this.tabMain.Controls.Add(this.cboMainOperator);
            this.tabMain.Controls.Add(this.txtMainInput2);
            this.tabMain.Controls.Add(this.txtMainInput1);
            this.tabMain.Controls.Add(this.txtMainDisplay);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1232, 551);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1232, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtMainDisplay
            // 
            this.txtMainDisplay.Location = new System.Drawing.Point(6, 6);
            this.txtMainDisplay.Name = "txtMainDisplay";
            this.txtMainDisplay.Size = new System.Drawing.Size(1220, 500);
            this.txtMainDisplay.TabIndex = 0;
            this.txtMainDisplay.Text = "";
            // 
            // txtMainInput1
            // 
            this.txtMainInput1.Location = new System.Drawing.Point(6, 525);
            this.txtMainInput1.Name = "txtMainInput1";
            this.txtMainInput1.Size = new System.Drawing.Size(320, 20);
            this.txtMainInput1.TabIndex = 1;
            // 
            // txtMainInput2
            // 
            this.txtMainInput2.Location = new System.Drawing.Point(332, 525);
            this.txtMainInput2.Name = "txtMainInput2";
            this.txtMainInput2.Size = new System.Drawing.Size(320, 20);
            this.txtMainInput2.TabIndex = 2;
            // 
            // cboMainOperator
            // 
            this.cboMainOperator.FormattingEnabled = true;
            this.cboMainOperator.Items.AddRange(new object[] {
            "Addition",
            "Subtraction",
            "Multiplication",
            "Division"});
            this.cboMainOperator.Location = new System.Drawing.Point(984, 525);
            this.cboMainOperator.Name = "cboMainOperator";
            this.cboMainOperator.Size = new System.Drawing.Size(121, 21);
            this.cboMainOperator.TabIndex = 3;
            this.cboMainOperator.Text = "Addition";
            // 
            // lblMainInput1
            // 
            this.lblMainInput1.AutoSize = true;
            this.lblMainInput1.Location = new System.Drawing.Point(6, 509);
            this.lblMainInput1.Name = "lblMainInput1";
            this.lblMainInput1.Size = new System.Drawing.Size(47, 13);
            this.lblMainInput1.TabIndex = 4;
            this.lblMainInput1.Text = "lblInput1";
            // 
            // lblMainInput2
            // 
            this.lblMainInput2.AutoSize = true;
            this.lblMainInput2.Location = new System.Drawing.Point(329, 509);
            this.lblMainInput2.Name = "lblMainInput2";
            this.lblMainInput2.Size = new System.Drawing.Size(47, 13);
            this.lblMainInput2.TabIndex = 5;
            this.lblMainInput2.Text = "lblInput2";
            // 
            // txtMainInput3
            // 
            this.txtMainInput3.Location = new System.Drawing.Point(658, 525);
            this.txtMainInput3.Name = "txtMainInput3";
            this.txtMainInput3.Size = new System.Drawing.Size(320, 20);
            this.txtMainInput3.TabIndex = 6;
            // 
            // lblMainInput3
            // 
            this.lblMainInput3.AutoSize = true;
            this.lblMainInput3.Location = new System.Drawing.Point(655, 509);
            this.lblMainInput3.Name = "lblMainInput3";
            this.lblMainInput3.Size = new System.Drawing.Size(47, 13);
            this.lblMainInput3.TabIndex = 7;
            this.lblMainInput3.Text = "lblInput3";
            // 
            // btnMainCalculate
            // 
            this.btnMainCalculate.Location = new System.Drawing.Point(1111, 525);
            this.btnMainCalculate.Name = "btnMainCalculate";
            this.btnMainCalculate.Size = new System.Drawing.Size(115, 20);
            this.btnMainCalculate.TabIndex = 8;
            this.btnMainCalculate.Text = "Calculate";
            this.btnMainCalculate.UseVisualStyleBackColor = true;
            this.btnMainCalculate.Click += new System.EventHandler(this.btnMainCalculate_Click);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(981, 509);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(58, 13);
            this.lblOperator.TabIndex = 9;
            this.lblOperator.Text = "lblOperator";
            // 
            // Demonstration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 601);
            this.Controls.Add(this.tabControl);
            this.Name = "Demonstration";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Button btnMainCalculate;
        private System.Windows.Forms.Label lblMainInput3;
        private System.Windows.Forms.TextBox txtMainInput3;
        private System.Windows.Forms.Label lblMainInput2;
        private System.Windows.Forms.Label lblMainInput1;
        private System.Windows.Forms.ComboBox cboMainOperator;
        private System.Windows.Forms.TextBox txtMainInput2;
        private System.Windows.Forms.TextBox txtMainInput1;
        private System.Windows.Forms.RichTextBox txtMainDisplay;
        private System.Windows.Forms.TabPage tabPage2;

    }
}

