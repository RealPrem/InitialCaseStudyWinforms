using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitialCaseStudyWinforms
{
    public partial class Form1 : Form
    {
        public TSP TravellingSalesMan = new TSP(5);
        public Form1()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            panel1.BackColor = Color.LightBlue;
            Graphics G = e.Graphics;

            //G.FillRectangle(new SolidBrush(Color.LightPink), 0, 0, 100, 100);
            
            /*
            foreach(City C in TravellingSalesMan.AllCities)
            {
                G.FillEllipse(new SolidBrush(Color.Red), C.X - 5, C.Y - 5, 10, 10);
                G.DrawString(C.Name, new Font("Arial", 12), new SolidBrush(Color.Black), C.X + 5, C.Y + 5);
            }
            var BestPath = TravellingSalesMan.Paths[0];

            for (int i = 0; i < TravellingSalesMan.NumOfCities - 1; i += 1)
            {
                int X1 = BestPath.Cities[i].X;
                int Y1 = BestPath.Cities[i].Y;

                int X2 = BestPath.Cities[i + 1].X;
                int Y2 = BestPath.Cities[i + 1].Y;

                //CornflowerBlue
                G.DrawLine(new Pen(Color.LightPink, 3), X1, Y1, X2, Y2 );
                
            }
            string CityPath = "PATH: ";
            string TotalDistance = "DISTANCE: " + BestPath.Distance.ToString();

            for (int i = 0; i < TravellingSalesMan.NumOfCities; i += 1)
            {
                CityPath += BestPath.Cities[i].Name;
            }
            PathLabel.Text = CityPath;
            DistanceLabel.Text = TotalDistance;
            */
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.Red;
        }
    }
}
