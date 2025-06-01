using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShapeDrawer
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();

        private enum ShapeType { Rectangle, Triangle, Circle }

        private class Shape
        {
            public ShapeType Type { get; set; }
            public Rectangle Bounds { get; set; }
        }

        private List<Shape> shapes = new List<Shape>();

        private System.Windows.Forms.Timer timerRectangle;
        private System.Windows.Forms.Timer timerTriangle;
        private System.Windows.Forms.Timer timerCircle;

        public Form1()
        {
            InitializeComponent();


            btnRectangle.Click += (s, e) => timerRectangle.Start();
            btnTriangle.Click += (s, e) => timerTriangle.Start();
            btnCircle.Click += (s, e) => timerCircle.Start();

            this.Controls.Add(btnRectangle);
            this.Controls.Add(btnTriangle);
            this.Controls.Add(btnCircle);

            timerRectangle = new System.Windows.Forms.Timer { Interval = 3000 };
            timerTriangle = new System.Windows.Forms.Timer { Interval = 2000 };
            timerCircle = new System.Windows.Forms.Timer { Interval = 4000 };

            timerRectangle.Tick += (s, e) => AddShape(ShapeType.Rectangle);
            timerTriangle.Tick += (s, e) => AddShape(ShapeType.Triangle);
            timerCircle.Tick += (s, e) => AddShape(ShapeType.Circle);

            this.DoubleBuffered = true;
            this.ClientSize = new Size(600, 400);
        }

        private void AddShape(ShapeType type)
        {
            int w = rand.Next(40, 100);
            int h = rand.Next(40, 100);
            int x = rand.Next(0, this.ClientSize.Width - w);
            int y = rand.Next(50, this.ClientSize.Height - h);

            shapes.Add(new Shape
            {
                Type = type,
                Bounds = new Rectangle(x, y, w, h)
            });

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var shape in shapes)
            {
                switch (shape.Type)
                {
                    case ShapeType.Rectangle:
                        e.Graphics.FillRectangle(Brushes.Green, shape.Bounds);
                        break;
                    case ShapeType.Circle:
                        e.Graphics.FillEllipse(Brushes.Blue, shape.Bounds);
                        break;
                    case ShapeType.Triangle:
                        var p1 = new Point(shape.Bounds.X + shape.Bounds.Width / 2, shape.Bounds.Y);
                        var p2 = new Point(shape.Bounds.X, shape.Bounds.Bottom);
                        var p3 = new Point(shape.Bounds.Right, shape.Bounds.Bottom);
                        e.Graphics.FillPolygon(Brushes.Blue, new[] { p1, p2, p3 });
                        break;
                }
            }
        }
    }
}
