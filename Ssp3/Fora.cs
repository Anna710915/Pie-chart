using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ssp3
{
    public class Fora : System.Windows.Forms.Form

    {
        private System.Windows.Forms.Button button1;

        /// <summary>

        /// Required designer variable.

        /// </summary>

        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Button button2;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private short show = 0; //значение show=0 запрещает рисование

        public Fora()

        {

            //

            // Required for Windows Form Designer support

            //

            InitializeComponent();

            //

            // TODO: Add any constructor code after InitializeComponent call

            //

        }

        /// <summary>

        /// Clean up any resources being used.

        /// </summary>

        protected override void Dispose(bool disposing)

        {

            if (disposing)

            {

                if (components != null)

                {

                    components.Dispose();

                }

            }

            base.Dispose(disposing);

        }

        /// <summary>

        /// Required method for Designer support - do not modify

        /// the contents of this method with the code editor.

        /// </summary>



        private void InitializeComponent() //стандартная программа инициализации                                            

        //формы позволяет вставить свои собственные команды

        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(112, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Painting";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cls";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(382, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "[red] Angle (%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 4;
            // 
            // Fora
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(564, 481);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Fora";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Fora_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.showgraph);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>

        /// The main entry point for the application.

        /// </summary>

       

        private void showgraph(object sender, System.Windows.Forms.PaintEventArgs e)

        {
            try
            {
                if (show == 1)
                {  //рисование, когда show=1
                    int value = int.Parse(textBox1.Text);

                    if (value < 0 || value > 360)
                    {
                        throw new Exception();
                    }

                    int other = 100 - value;
                    int[] myPiePercent = { value , other};

                    //Take Colors To Display Pie In That Colors Of Taken Five Values.
                    Color[] myPieColors = { Color.Red, Color.Black};

                    using (Graphics myPieGraphic = this.CreateGraphics())
                    {
                        //Give Location Which Will Display Chart At That Location.
                        Point myPieLocation = new Point(10, 10);

                        //Set Here Size Of The Chartâ€¦
                        Size myPieSize = new Size(150, 150);

                        //Call Function Which Will Draw Pie of Values.
                        DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);
                    }
                    show = 0;
                    label2.Text = "[black] Other " + other.ToString();
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Invalid value!");
            }
           

        }
        public void DrawPieChart(int[] myPiePerecents, Color[] myPieColors, Graphics myPieGraphic, Point
myPieLocation, Size myPieSize)
        {
            //Check if sections add up to 100.
            int sum = 0;
            foreach (int percent_loopVariable in myPiePerecents)
            {
                sum += percent_loopVariable;
            }

            if (sum != 100)
            {
                MessageBox.Show("Sum Do Not Add Up To 100.");
            }

            //Check Here Number Of Values & Colors Are Same Or Not.They Must Be Same.
            if (myPiePerecents.Length != myPieColors.Length)
            {
                MessageBox.Show("There Must Be The Same Number Of Percents And Colors.");
            }

            int PiePercentTotal = 0;
            for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
            {
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {

                    //Here it Will Convert Each Value Into 360, So Total Into 360 & Then It Will Draw A Full Pie Chart.
                    myPieGraphic.FillPie(brush, new Rectangle(new Point(10, 10), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
                }

                PiePercentTotal += myPiePerecents[PiePercents];
            }
            return;
        }

        private void button1_Click(object sender, System.EventArgs e)

        {

            show = 1;

            this.Invalidate(); //активизируем событие OnPaint

        }

        private void button2_Click(object sender, System.EventArgs e)

        {

            show = 0;


            this.Invalidate();
            label2.Text = "";
            textBox1.Text = "";

        }

        private void Fora_Load(object sender, EventArgs e)
        {

        }
    }
}
