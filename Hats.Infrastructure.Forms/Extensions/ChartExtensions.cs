using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hats.Infrastructure.Forms.Extensions
{
    public static class ChartExtensions
    {
        public static void HighlightDataPointOnHit(this Chart chart, Form form)
        {
            chart.MouseMove += Chart_MouseMove;
            @this = form;
        }

        private static void Chart_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var chart = (Chart)sender;

            for (int i = 0; i < chart.Series.Count; i++)
            {
                foreach (DataPoint point in chart.Series[i].Points)
                {
                    point.BackSecondaryColor = Color.Black;
                    point.BackHatchStyle = ChartHatchStyle.None;
                    point.BorderWidth = 1;
                }
            }

            // Call HitTest
            HitTestResult result = chart.HitTest(e.X, e.Y);

            // If the mouse if over a data point
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                @this.Cursor = Cursors.Hand;

                // Find selected data point
                DataPoint point = chart.Series[result.Series.Name].Points[result.PointIndex];

                // Change the appearance of the data point
                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.Percent50;
                point.BorderWidth = 2;
            }
            else
            {
                // Set default cursor
                @this.Cursor = Cursors.Default;
            }
        }

        private static Form @this;
    }
}
