using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ShapeDrawerWithThreadsAndTimers
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

        private System.Windows.Forms.Timer rectangleTimer;
        private System.Windows.Forms.Timer triangleTimer;
        private System.Windows.Forms.Timer circleTimer;

        private bool rectangleThreadStarted = false;
        private bool triangleThreadStarted = false;
        private bool circleThreadStarted = false;

        public Form1()
        {

            this.DoubleBuffered = true;
            this.ClientSize = new Size(600, 400);

            Button btnRectangle = new Button() { Text = "Правоъгълник", Location = new Point(10, 10) };
            Button btnTriangle = new Button() { Text = "Триъгълник", Location = new Point(130, 10) };
            Button btnCircle = new Button() { Text = "Кръг", Location = new Point(250, 10) };

            btnRectangle.Click += BtnRectangle_Click;
            btnTriangle.Click += BtnTriangle_Click;
            btnCircle.Click += BtnCircle_Click;

            this.Controls.Add(btnRectangle);
            this.Controls.Add(btnTriangle);
            this.Controls.Add(btnCircle);
        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            if (!rectangleThreadStarted)
            {
                rectangleThreadStarted = true;
                new Thread(() =>
                {
                    rectangleTimer = new System.Windows.Forms.Timer();
                    rectangleTimer.Interval = 3000;
                    rectangleTimer.Tick += (s, ev) => AddShape(ShapeType.Rectangle);
                    this.Invoke((MethodInvoker)(() => rectangleTimer.Start()));
                })
                { IsBackground = true }.Start();
            }
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            if (!triangleThreadStarted)
            {
                triangleThreadStarted = true;
                new Thread(() =>
                {
                    triangleTimer = new System.Windows.Forms.Timer();
                    triangleTimer.Interval = 2000;
                    triangleTimer.Tick += (s, ev) => AddShape(ShapeType.Triangle);
                    this.Invoke((MethodInvoker)(() => triangleTimer.Start()));
                })
                { IsBackground = true }.Start();
            }
        }

        private void BtnCircle_Click(object sender, EventArgs e)
        {
            if (!circleThreadStarted)
            {
                circleThreadStarted = true;
                new Thread(() =>
                {
                    circleTimer = new System.Windows.Forms.Timer();
                    circleTimer.Interval = 4000;
                    circleTimer.Tick += (s, ev) => AddShape(ShapeType.Circle);
                    this.Invoke((MethodInvoker)(() => circleTimer.Start()));
                })
                { IsBackground = true }.Start();
            }
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
