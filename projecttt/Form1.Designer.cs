namespace ShapeDrawer
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnCircle;

        private void InitializeComponent()
        {
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();

            this.btnRectangle.Text = "Правоъгълник";
            this.btnRectangle.Location = new System.Drawing.Point(10, 10);

            this.btnTriangle.Text = "Триъгълник";
            this.btnTriangle.Location = new System.Drawing.Point(120, 10);

            this.btnCircle.Text = "Кръг";
            this.btnCircle.Location = new System.Drawing.Point(230, 10);

            this.Controls.Add(this.btnRectangle);
            this.Controls.Add(this.btnTriangle);
            this.Controls.Add(this.btnCircle);

            this.Text = "Форми";
            this.ClientSize = new System.Drawing.Size(600, 400);
        }
    }
}

