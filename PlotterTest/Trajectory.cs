using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlotterTest
{
    public class Trajectory
    {
        ArrayList xList, yList, zList;
        double xCurrent = 0;
        double yCurrent = 0;
        double zCurrent = 0;
        double feedRate = 100;
        public Trajectory()
        {

        }
        public void addZOnly(double z)
        {
            zCurrent = z;
        }
        public void addXYOnly(double x, double y)
        {
            double length = Math.Sqrt((x - xCurrent) * (x - xCurrent) + (y - yCurrent) * (y - yCurrent));
            int interval = (int)(length / feedRate);
            double xIncrement = (x - xCurrent) / interval;
            double yIncrement = (y - yCurrent) / interval;

            for (int i = 0; i<interval; i++) {
                xList.Add(xCurrent + i * xIncrement);
                yList.Add(yCurrent + i * yIncrement);
            }
            xCurrent = x;
            yCurrent = y;

        }

        public void addLine(double x, double y, double z)
        {
            if(zCurrent == z)
            {
                double length = Math.Sqrt((x - xCurrent) * (x - xCurrent) + (y - yCurrent) * (y - yCurrent));
                int interval = (int)(length / feedRate);
                double xIncrement = (x - xCurrent) / interval;
                double yIncrement = (y - yCurrent) / interval;

                for (int i = 0; i < interval; i++)
                {
                    xList.Add(xCurrent + i * xIncrement);
                    yList.Add(yCurrent + i * yIncrement);
                }
                xCurrent = x;
                yCurrent = y;
            }
        }
        public void addArcCC(double x, double y, double z, double i, double j)
        {

        }

        public void addArcCCC(double x, double y, double z, double i, double j)
        {

        }

    }
}
