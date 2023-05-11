using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;
using System.Net.Http;

namespace graphics_package
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        void DrawTableForLine(List<string> points,string title, int x1, int y1, int x2, int y2)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            Console.WriteLine(string.Join(", ", points));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.Title = "Save HTML File";
            DateTime now = DateTime.Now;
            string dateTimeString = now.ToString("yyyyMMdd-HHmmss");
            saveFileDialog.FileName = $"DrawLineFor{title}-{dateTimeString}.html";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {

                string filePath = saveFileDialog.FileName;
                htmlBuilder.AppendLine("<html><head><style>");

                htmlBuilder.AppendLine("table {overflow: hidden;;width: 1500px;border-radius: 1em;border-collapse: collapse;}");
                htmlBuilder.AppendLine("th, td {border-bottom: 2px solid white;background: #ddd;padding: 1em;text-align: start;}");
                htmlBuilder.AppendLine("h1 {text-align: center;}");
                htmlBuilder.AppendLine("</style></head><body>");

                htmlBuilder.AppendLine($"<h1>{title} Algorithm fromStartPoint: {x1}, {y1} and EndPoint: {x2}, {y2}</h1>");
                htmlBuilder.AppendLine("<table>");
                htmlBuilder.AppendLine("<tr><th>Step</th><th>X</th><th>Y</th></tr>");

                for (int i = 1; i < points.Count; i++)
                {
                    htmlBuilder.AppendLine($"<tr><td>{i}</td><td>{points[i].Split(',')[0]}</td><td>{points[i].Split(',')[1]}</td></tr>");
                }

                htmlBuilder.AppendLine("</table>");
                htmlBuilder.AppendLine("</body></html>");

                // Write the HTML page to a file
                File.WriteAllText(filePath, htmlBuilder.ToString());
            }
        }

        void DrawTableBresenhamLine(List<string> points, string title, int x1, int y1, int x2, int y2)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            Console.WriteLine(string.Join(", ", points));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.Title = "Save HTML File";
            DateTime now = DateTime.Now;
            string dateTimeString = now.ToString("yyyyMMdd-HHmmss");
            saveFileDialog.FileName = $"DrawLineFor{title}-{dateTimeString}.html";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {

                string filePath = saveFileDialog.FileName;
                htmlBuilder.AppendLine("<html><head><style>");

                htmlBuilder.AppendLine("table {overflow: hidden;;width: 1500px;border-radius: 1em;border-collapse: collapse;}");
                htmlBuilder.AppendLine("th, td {border-bottom: 2px solid white;background: #ddd;padding: 1em;text-align: start;}");
                htmlBuilder.AppendLine("h1 {text-align: center;}");
                htmlBuilder.AppendLine("</style></head><body>");

                htmlBuilder.AppendLine($"<h1>{title} Algorithm fromStartPoint: {x1}, {y1} and EndPoint: {x2}, {y2}</h1>");
                htmlBuilder.AppendLine("<table>");
                htmlBuilder.AppendLine("<tr><th>Step</th><th>X<sub>k+1</sub></th><th>Y<sub>k+1</sub></th><th>P</th></tr>");

                for (int i = 1; i < points.Count; i++)
                {
                    htmlBuilder.AppendLine($"<tr><td>{i-1}</td><td>{points[i].Split(',')[0]}</td><td>{points[i].Split(',')[1]}</td><td>{points[i-1].Split(',')[2]}</td></tr>");
                }

                htmlBuilder.AppendLine("</table>");
                htmlBuilder.AppendLine("</body></html>");

                // Write the HTML page to a file
                File.WriteAllText(filePath, htmlBuilder.ToString());
            }
        }

        void DrawTableForCircle(List<string> points, string title, int xCenter, int yCenter, int radius, int p, int doubx, int douby)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            Console.WriteLine(string.Join(", ", points));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.Title = "Save HTML File";
            DateTime now = DateTime.Now;
            string dateTimeString = now.ToString("yyyyMMdd-HHmmss");
            saveFileDialog.FileName = $"DrawCircle-{dateTimeString}.html";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {

                string filePath = saveFileDialog.FileName;
                htmlBuilder.AppendLine("<html><head><style>");
                htmlBuilder.AppendLine("table {overflow: hidden;;width: 1500px;border-radius: 1em;border-collapse: collapse;}");
                htmlBuilder.AppendLine("th, td {border-bottom: 2px solid white;background: #ddd;padding: 1em;text-align: start;}");
                htmlBuilder.AppendLine("h1 {text-align: center;}");
                htmlBuilder.AppendLine("</style></head><body>");
                htmlBuilder.AppendLine($"<h1>{title}: ({xCenter}, {yCenter}) and raduis: ({radius})</h1>");
                htmlBuilder.AppendLine("<table>");
                htmlBuilder.AppendLine("<tr><th>Step</th><th>X<sub>k+1</sub></th><th>Y<sub>k+1</sub></th><th>P</th><th>2X<sub>k+1</sub></th><th>2Y<sub>k+1</sub></th></tr>");

                for (int i = 1; i < points.Count; i++)
                {
                    htmlBuilder.AppendLine($"<tr><td>{(i-1).ToString()}</td><td>{points[i].Split(',')[0]}</td><td>{points[i].Split(',')[1]}</td><td>{points[i-1].Split(',')[2]}</td><td>{points[i].Split(',')[3]}</td><td>{points[i].Split(',')[4]}</td></tr>");
                }

                htmlBuilder.AppendLine("</table>");
                htmlBuilder.AppendLine("</body></html>");

                // Write the HTML page to a file
                File.WriteAllText(filePath, htmlBuilder.ToString());
            }
        }
        void DrawTableForElipse(List<string> points, string title, int xCenter, int yCenter, int Xradius,int Yraduis,int pk)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            Console.WriteLine(string.Join(", ", points));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.Title = "Save HTML File";
            DateTime now = DateTime.Now;
            string dateTimeString = now.ToString("yyyyMMdd-HHmmss");
            saveFileDialog.FileName = $"DrawElipse-{dateTimeString}.html";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {

                string filePath = saveFileDialog.FileName ;
                htmlBuilder.AppendLine("<html><head><style>");

                htmlBuilder.AppendLine("table {overflow: hidden;;width: 1500px;border-radius: 1em;border-collapse: collapse;}");
                htmlBuilder.AppendLine("th, td {border-bottom: 2px solid white;background: #ddd;padding: 1em;text-align: start;}");
                htmlBuilder.AppendLine("h1 {text-align: center;}");
                htmlBuilder.AppendLine("</style></head><body>");
                htmlBuilder.AppendLine($"<h1>{title}: {xCenter}, {yCenter} and Xraduis: {Xradius},Yraduis:{Yraduis}</h1>");
                htmlBuilder.AppendLine("<table>");
                htmlBuilder.AppendLine("<tr><th>Step</th><th>X<sub>k+1</sub></th><th>Y<sub>k+1</sub></th><th>P<sub>1K</sub></th><th>2r<sup>2</sup><sub>y</sub>X<sub>k+1</sub></th><th>2r<sup>2</sup><sub>x</sub>Y<sub>k+1</sub></th></tr>");

                for (int i = 1; i < points.Count; i++)
                {
                    htmlBuilder.AppendLine($"<tr><td>{i-1}</td><td>{points[i].Split(',')[0]}</td><td>{points[i].Split(',')[1]}</td><td>{points[i-1].Split(',')[2]}</td><td>{points[i].Split(',')[3]}</td><td>{points[i].Split(',')[4]}</td></tr>");
                }

                htmlBuilder.AppendLine("</table>");
                htmlBuilder.AppendLine("</body></html>");

                // Write the HTML page to a file
                File.WriteAllText(filePath, htmlBuilder.ToString());
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox4.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox2.Text);
            panel1.Controls.Clear();
            this.Refresh();
           
            lineDDA(x1, y1, x2, y2);
        }
        
        private void drawAxis()
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            for (int i = 0; i < 344; i++)
            {
                g.FillRectangle(aBrush, i, 154, 2, 2);
            }
            for (int j = 0; j < 308; j++)
            {
                g.FillRectangle(aBrush, 172, j, 2, 2);
            }
        }

        private void DrawPlotPoints(float x,float y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            g.FillRectangle(aBrush, 172 + x, 154 - y, 2, 2);

        }


        void lineDDA(int x0, int y0, int xEnd, int yEnd)

        {
            int xInitial = x0, yInitial = y0, xFinal = xEnd, yFinal = yEnd;
            int dx = xFinal - xInitial, dy = yFinal - yInitial, steps, k, xf, yf;
            float xIncrement, yIncrement, x = xInitial, y = yInitial;

            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);
            else steps = Math.Abs(dy);

            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;

            List<string> points = new List<string>();
            points.Add($"{x}, {y}");

            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                xf = (int)x;
                y += yIncrement;
                yf = (int)y;
                points.Add($"{Math.Round(x)}, {Math.Round(y)}");

                try
                {
                    DrawPlotPoints(x, y);

                }
                catch (InvalidOperationException)
                {
                    return;
                }
            }

            DrawTableForLine(points, "DDA Line Algorithm", Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox2.Text));

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox5.Text);
            int y1 = Convert.ToInt32(textBox6.Text);
            int x2 = Convert.ToInt32(textBox7.Text);
            int y2 = Convert.ToInt32(textBox8.Text);
            drawAxis();
            Bresenham_Draw(x1, y1, x2, y2, "Black");
            
        }

        private void swap(ref int x0, ref int y0, ref int xEnd, ref int yEnd)
        {
            int temp1, temp2;
            temp1 = x0;
            x0 = y0;
            y0 = temp1;

            temp2 = xEnd;
            xEnd = yEnd;
            yEnd = temp2;
        }
        private void Bresenham_Draw(int x0, int y0, int xEnd, int yEnd, string Color)
        {
            List<string> points = new List<string>();
            float deltaX, deltaY, p;
            deltaX = (xEnd - x0);
            deltaY = (yEnd - y0);
            var brush = Brushes.Black;
            if (Color == "Black") { brush = Brushes.Black; }

            var g = panel1.CreateGraphics();
            
            float slope = deltaY / deltaX;

            if (deltaX == 0) { slope = 99999; }
            
            
            // First Ocstant
            if (x0 < xEnd && slope >= 0 && slope <= 1)
            {
                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;
                points.Add($"{(x0)}, {(y0)},{p}");
                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (++Y), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(X)}, {(Y)},{p}");
                }
                
            }

            // Second Ocstant
            else if (y0 < yEnd && slope > 1 && slope < 999999)
            {
                swap(ref x0, ref y0, ref xEnd, ref yEnd);
                deltaX = xEnd - x0;
                deltaY = yEnd - y0;
                p = (2 * deltaY) - deltaX;
                points.Add($"{(x0)}, {(y0)},{p}");
                int X = x0, Y = y0;
                
                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (++X), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++Y), center.Y - (++X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(Y)}, {(X)},{p}");
                }
               
            }

            // Third Ocstant
            else if (y0 < yEnd && slope < -1 && slope > -999999)
            {
                swap(ref x0, ref y0, ref xEnd, ref yEnd);
                deltaX = xEnd - x0;
                deltaY = yEnd - y0;
                deltaY = -deltaY;
                p = (2 * deltaY) - deltaX;
                points.Add($"{(x0)}, {(y0)},{p}");
                int X = x0, Y = y0;
                
                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (++X), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--Y), center.Y - (++X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(Y)}, {(X)},{p}");
                }
                
            }

            // Fourth Ocstant
            else if (x0 > xEnd && slope <= 0 && slope >= -1)
            {
                deltaX = -deltaX;
                p = (2 * deltaY) - deltaX;
                points.Add($"{(x0)}, {(y0)},{p}");
                int X = x0, Y = y0;
                
                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (++Y), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(X)}, {(Y)},{p}");
                }
                
            }

            // Fifth Ocstant
            else if (x0 > xEnd && slope > 0 && slope <= 1)
            {
                deltaX = -deltaX; deltaY = -deltaY;
                p = (2 * deltaY) - deltaX;
                points.Add($"{(x0)}, {(y0)},{p}");
                int X = x0, Y = y0;
                
                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (--Y), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(X)}, {(Y)},{p}");
                }
                
            }

            // Sixth Ocstant
            else if (y0 > yEnd && slope > 1 && slope < 999999)
            {
                // Swap x1 and y1 ,,, Swap x2 and y2
                swap(ref x0, ref y0, ref xEnd, ref yEnd);
                
                deltaX = xEnd - x0;
                deltaY = yEnd - y0;
                deltaX = -deltaX; deltaY = -deltaY;
                
                p = (2 * deltaY) - deltaX;
                points.Add($"{(x0)}, {(y0)},{p}");
                int X = x0, Y = y0;
                
                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (--X), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--Y), center.Y - (--X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(Y)}, {(X)},{p}");
                }
                
            }

            // Seventh Ocstant
            else if (y0 > yEnd && slope < -1 && slope < 999999)
            {
                swap(ref x0, ref y0, ref xEnd, ref yEnd);
                
                deltaX = xEnd - x0;
                deltaY = yEnd - y0;
                deltaX = -deltaX;
                
                p = (2 * deltaY) - deltaX;
                points.Add($"{(x0)}, {(y0)},{p}");
                int X = x0, Y = y0;
                
                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (--X), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++Y), center.Y - (--X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(Y)}, {(X)},{p}");
                }
                
            }

            // Eighth Ocstant
            else if (x0 < xEnd && slope <= 0 && slope >= -1)
            {
                deltaY = -deltaY;
                
                p = (2 * deltaY) - deltaX;
                points.Add($"{(x0)}, {(y0)},{p}");
                int X = x0, Y = y0;
                
                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (--Y), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                    points.Add($"{(X)}, {(Y)},{p}");
                }
                
            }
            DrawTableBresenhamLine(points, "BresenhamLine Algorithm", Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
        }
        private void BresenhamLine(int x1, int y1, int x2, int y2, int dx, int dy, int decide)
        {

            List<string> points = new List<string>();
           
            
            int pk = 2 * dy - dx;
   
            for (int i = 0; i <= dx - 1; i++)
            {
                if (x1 < x2) x1++;
                else x1--;

                
                if (pk < 0)
                {
                    if (decide == 0)
                    {
                        BLAPlotPoints(x1, y1);
                        
                        pk = pk + 2 * dy;
                        
                    }
                    else
                    {
                        BLAPlotPoints(y1, x1);
                        
                        pk = pk + 2 * dy;
                        
                    }
                }
                else
                {
                    if (y1 < y2) y1++;
                    else y1--;
                    if (decide == 0)
                    {

                        BLAPlotPoints(x1, y1);
                        

                    }
                    else
                    {
                        BLAPlotPoints(y1, x1);
                        

                    }
                    pk = pk + 2 * dy - 2 * dx;
                }
                points.Add($"{(x1)}, {(y1)},{pk}");


            }
            DrawTableBresenhamLine(points, "BresenhamLine Algorithm", Convert.ToInt32( textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
        }

        private void BLAPlotPoints(int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            g.FillRectangle(aBrush, 172 + x, 154 - y, 2, 2);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics().Clear(Color.ForestGreen);
        }


        public Point center = new Point(172, 154);
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            var g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);


            Point p1 = new Point(center.X + 400, center.Y);
            Point p2 = new Point(center.X - 400, center.Y);
            Point p3 = new Point(center.X, center.Y + 400);
            Point p4 = new Point(center.X, center.Y - 400);

            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox9.Text);
            int y1 = Convert.ToInt32(textBox10.Text);
            int radius = Convert.ToInt32(textBox11.Text);
            panel1.Controls.Clear();
            this.Refresh();
           
            circleMidpoint(x1, y1, radius);

        }



       
        void circleMidpoint(int xCenter, int yCenter, int radius)
        {
            int x = 0;
            int y = radius;
            int p = 1 - radius;
            List<string> points = new List<string>();
            circlePlotPoints(xCenter, yCenter, x, y);
            
            if (xCenter == 0 && yCenter == 0)
                points.Add($"{x+1}, {y},{p},{2 * x},{2 * y}");
            else
                points.Add($"{(x+1) + xCenter}, {y + yCenter},{p},{2 * x},{2 * y}");

            while (x < y)
            {

                x++;
                if (p < 0)
                {
                    p += 2 * x + 1;
                    if(xCenter==0 && yCenter==0)
                        points.Add($"{x}, {y},{p},{2 * x},{2 * y}");
                    else
                        points.Add($"{x+xCenter}, {y+yCenter},{p},{2 * x},{2 * y}");
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                    if (xCenter == 0 && yCenter == 0)
                        points.Add($"{x}, {y},{p},{2 * x},{2 * y}");
                    else
                        points.Add($"{x + xCenter}, {y + yCenter},{p},{2 * x},{2 * y}");
                }

                circlePlotPoints(xCenter, yCenter, x, y);
                
            }
            DrawTableForCircle(points, "Circle MidPoint Algorithm from Xcenter and yCenter", xCenter, yCenter, radius,p,2*x,2*y);
        }
        void circlePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 175 + (xCenter + x), 150 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 175 + (xCenter - x), 150 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 175 + (xCenter + x), 150 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 175 + (xCenter - x), 150 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 175 + (xCenter + y), 150 - (yCenter + x), 2, 2);
            g.FillRectangle(aBrush, 175 + (xCenter - y), 150 - (yCenter + x), 2, 2);
            g.FillRectangle(aBrush, 175 + (xCenter + y), 150 - (yCenter - x), 2, 2);
            g.FillRectangle(aBrush, 175 + (xCenter - y), 150 - (yCenter - x), 2, 2);
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int xradius = Convert.ToInt32(textBox14.Text);
            int yradius = Convert.ToInt32(textBox15.Text);
            panel1.Controls.Clear();
            this.Refresh();
            
            ellipseMidpoint(x1, y1, xradius, yradius);
        }

        
        void ellipseMidpoint(int xCenter, int yCenter, int Rx, int Ry)
        {
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;

            List<string> points = new List<string>();
            ellipsePlotPoints(xCenter, yCenter, x, y);
            p = Convert.ToInt32(Ry2 - (Rx2 * Ry) + (0.25 * Rx2));
            points.Add($"({x + xCenter}, {y + yCenter},{p},{px},{py}");
           

            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                    p += Ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }
                points.Add($"{(x + xCenter)}, {(y + yCenter)},{p},{px},{py}");
                ellipsePlotPoints(xCenter, yCenter, x, y);
                
            }
            /* second region */
            
            p = Convert.ToInt32(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);
            //points.Add($"{(x + xCenter)}, {(y + yCenter)},{p},{px},{py}"); add the value -23
            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                    p += Rx2 - py;
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                points.Add($"{(x + xCenter)}, {(y + yCenter)},{p},{px},{py}");
                ellipsePlotPoints(xCenter, yCenter, x, y);
                

            }
            
            DrawTableForElipse(points, "Elipse MidPoint Algorithm from Xcenter and yCenter", Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox13.Text), Convert.ToInt32(textBox14.Text), Convert.ToInt32(textBox15.Text),p);
        }
        void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter - y), 2, 2);
        }


        private void button15_Click(object sender, EventArgs e)
        {
            Form2 transforamtion=new Form2();
            transforamtion.Show();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
     
    }
}


