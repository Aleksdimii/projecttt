using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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

        public Form1()
        {
            InitializeComponent();

            // Бутоните
            Button btnRectangle = new Button() { Text = "Правоъгълник", Location = new Point(10, 10) };
            Button btnTriangle = new Button() { Text = "Триъгълник", Location = new Point(130, 10) };
            Button btnCircle = new Button() { Text = "Кръг", Location = new Point(250, 10) };

            btnRectangle.Click += (s, e) => StartShapeThread(ShapeType.Rectangle, 3000);
            btnTriangle.Click += (s, e) => StartShapeThread(ShapeType.Triangle, 2000);
            btnCircle.Click += (s, e) => StartShapeThread(ShapeType.Circle, 4000);

            this.Controls.Add(btnRectangle);
            this.Controls.Add(btnTriangle);
            this.Controls.Add(btnCircle);

            this.DoubleBuffered = true;
            this.ClientSize = new Size(600, 400);
        }

        private void StartShapeThread(ShapeType type, int delayMs)
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(delayMs);

                Rectangle bounds = GenerateRandomRectangle();

                Shape newShape = new Shape { Type = type, Bounds = bounds };

                this.Invoke((MethodInvoker)(() =>
                {
                    shapes.Add(newShape);
                    this.Invalidate();
                }));
            });

            thread.IsBackground = true;
            thread.Start();
        }

        private Rectangle GenerateRandomRectangle()
        {
            int w = rand.Next(40, 100);
            int h = rand.Next(40, 100);
            int x = rand.Next(0, this.ClientSize.Width - w);
            int y = rand.Next(50, this.ClientSize.Height - h);
            return new Rectangle(x, y, w, h);
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
