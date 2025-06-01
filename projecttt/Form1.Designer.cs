namespace projecttt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timerTriangle = new System.Windows.Forms.Timer(components);
            timerCircle = new System.Windows.Forms.Timer(components);
            timerRectangle = new System.Windows.Forms.Timer(components);
            btnRectangle = new Button();
            btnCircle = new Button();
            btnTriangle = new Button();
            SuspendLayout();
            // 
            // timerRectangle
            // 
            timerRectangle.Tick += timer3_Tick;
            // 
            // btnRectangle
            // 
            btnRectangle.Location = new Point(612, 253);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(75, 23);
            btnRectangle.TabIndex = 0;
            btnRectangle.Text = "Rectangle";
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnCircle
            // 
            btnCircle.Location = new Point(281, 253);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(75, 23);
            btnCircle.TabIndex = 1;
            btnCircle.Text = "Circle";
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnTriangle
            // 
            btnTriangle.Location = new Point(29, 253);
            btnTriangle.Name = "btnTriangle";
            btnTriangle.Size = new Size(75, 23);
            btnTriangle.TabIndex = 2;
            btnTriangle.Text = "Triangle";
            btnTriangle.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTriangle);
            Controls.Add(btnCircle);
            Controls.Add(btnRectangle);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timerTriangle;
        private System.Windows.Forms.Timer timerCircle;
        private System.Windows.Forms.Timer timerRectangle;
        private Button btnRectangle;
        private Button btnCircle;
        private Button btnTriangle;
    }
}
