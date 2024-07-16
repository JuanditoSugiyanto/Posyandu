using Posyandu.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginOrtu
{
    public partial class DetaiAnak : System.Web.UI.Page
    {
        private Dictionary<int, double> medianHeightFemale = new Dictionary<int, double>
        {
            { 0, 49.1 }, { 1, 53.7 }, { 2, 57.1 }, { 3, 59.8 }, { 4, 62.1 }, { 5, 64.0 }, { 6, 65.7 }, { 7, 67.3 },
            { 8, 68.7 }, { 9, 70.1 }, { 10, 71.5 }, { 11, 72.8 }, { 12, 74.0 }, { 13, 75.2 }, { 14, 76.4 }, { 15, 77.5 },
            { 16, 78.6 }, { 17, 79.7 }, { 18, 80.7 }, { 19, 81.7 }, { 20, 82.7 }, { 21, 83.7 }, { 22, 84.6 }, { 23, 85.5 },
            { 24, 86.4 }, { 25, 86.6 }, { 26, 87.4 }, { 27, 88.3 }, { 28, 89.1 }, { 29, 89.9 }, { 30, 90.7 }, { 31, 91.4 },
            { 32, 92.2 }, { 33, 92.9 }, { 34, 93.6 }, { 35, 94.4 }, { 36, 95.1 }, { 37, 95.7 }, { 38, 96.4 }, { 39, 97.1 },
            { 40, 97.7 }, { 41, 98.4 }, { 42, 99.0 }, { 43, 99.7 }, { 44, 100.3 }, { 45, 100.9 }, { 46, 101.5 }, { 47, 102.1 },
            { 48, 102.7 }, { 49, 103.3 }, { 50, 103.9 }, { 51, 104.5 }, { 52, 105.0 }, { 53, 105.6 }, { 54, 106.2 }, { 55, 106.7 },
            { 56, 107.3 }, { 57, 107.8 }, { 58, 108.4 }, { 59, 108.9 }, { 60, 109.4 }
        };
        private Dictionary<int, double> heightSDMinus2 = new Dictionary<int, double>
        {
            { 0, 45.4 }, { 1, 49.8 }, { 2, 53.0 }, { 3, 55.6 }, { 4, 57.8 }, { 5, 59.6 }, { 6, 61.2 }, { 7, 62.7 },
            { 8, 64.0 }, { 9, 65.3 }, { 10, 66.5 }, { 11, 67.7 }, { 12, 68.9 }, { 13, 70.0 }, { 14, 71.0 }, { 15, 72.0 },
            { 16, 73.0 }, { 17, 74.0 }, { 18, 74.9 }, { 19, 75.8 }, { 20, 76.7 }, { 21, 77.5 }, { 22, 78.4 }, { 23, 79.2 },
            { 24, 80.0 }, { 25, 80.0 }, { 26, 80.8 }, { 27, 81.5 }, { 28, 82.2 }, { 29, 82.9 }, { 30, 83.6 }, { 31, 84.3 },
            { 32, 84.9 }, { 33, 85.6 }, { 34, 86.2 }, { 35, 86.8 }, { 36, 87.4 }, { 37, 88.0 }, { 38, 88.6 }, { 39, 89.2 },
            { 40, 89.8 }, { 41, 90.4 }, { 42, 90.9 }, { 43, 91.5 }, { 44, 92.0 }, { 45, 92.5 }, { 46, 93.1 }, { 47, 93.6 },
            { 48, 94.1 }, { 49, 94.6 }, { 50, 95.1 }, { 51, 95.6 }, { 52, 96.1 }, { 53, 96.6 }, { 54, 97.1 }, { 55, 97.6 },
            { 56, 98.1 }, { 57, 98.5 }, { 58, 99.0 }, { 59, 99.5 }, { 60, 99.9 }
        };
        private Dictionary<int, double> heightSDPlus2 = new Dictionary<int, double>
        {
            { 0, 52.9 }, { 1, 57.6 }, { 2, 61.1 }, { 3, 64.0 }, { 4, 66.4 }, { 5, 68.5 }, { 6, 70.3 }, { 7, 71.9 },
            { 8, 73.5 }, { 9, 75.0 }, { 10, 76.4 }, { 11, 77.8 }, { 12, 79.2 }, { 13, 80.5 }, { 14, 81.7 }, { 15, 83.0 },
            { 16, 84.2 }, { 17, 85.4 }, { 18, 86.5 }, { 19, 87.6 }, { 20, 88.7 }, { 21, 89.8 }, { 22, 90.8 }, { 23, 91.9 },
            { 24, 92.9 }, { 25, 93.1 }, { 26, 94.1 }, { 27, 95.0 }, { 28, 96.0 }, { 29, 96.9 }, { 30, 97.7 }, { 31, 98.6 },
            { 32, 99.4 }, { 33, 100.3 }, { 34, 101.1 }, { 35, 101.9 }, { 36, 102.7 }, { 37, 103.4 }, { 38, 104.2 }, { 39, 105.0 },
            { 40, 105.7 }, { 41, 106.4 }, { 42, 107.2 }, { 43, 107.9 }, { 44, 108.6 }, { 45, 109.3 }, { 46, 110.0 }, { 47, 110.7 },
            { 48, 111.3 }, { 49, 112.0 }, { 50, 112.7 }, { 51, 113.3 }, { 52, 114.0 }, { 53, 114.6 }, { 54, 115.2 }, { 55, 115.9 },
            { 56, 116.5 }, { 57, 117.1 }, { 58, 117.7 }, { 59, 118.3 }, { 60, 118.9 }
        };
        private Dictionary<int, double> heightSDPlus3 = new Dictionary<int, double>
        {
            { 0, 54.7 }, { 1, 59.5 }, { 2, 63.2 }, { 3, 66.1 }, { 4, 68.6 }, { 5, 70.7 }, { 6, 72.5 }, { 7, 74.2 },
            { 8, 75.8 }, { 9, 77.4 }, { 10, 78.9 }, { 11, 80.3 }, { 12, 81.7 }, { 13, 83.1 }, { 14, 84.4 }, { 15, 85.7 },
            { 16, 87.0 }, { 17, 88.2 }, { 18, 89.4 }, { 19, 90.6 }, { 20, 91.7 }, { 21, 92.9 }, { 22, 94.0 }, { 23, 95.0 },
            { 24, 96.1 }, { 25, 96.4 }, { 26, 97.4 }, { 27, 98.4 }, { 28, 99.4 }, { 29, 100.3 }, { 30, 101.3 }, { 31, 102.2 },
            { 32, 103.1 }, { 33, 103.9 }, { 34, 104.8 }, { 35, 105.6 }, { 36, 106.5 }, { 37, 107.3 }, { 38, 108.1 }, { 39, 108.9 },
            { 40, 109.7 }, { 41, 110.5 }, { 42, 111.2 }, { 43, 112.0 }, { 44, 112.7 }, { 45, 113.5 }, { 46, 114.2 }, { 47, 114.9 },
            { 48, 115.7 }, { 49, 116.4 }, { 50, 117.1 }, { 51, 117.7 }, { 52, 118.4 }, { 53, 119.1 }, { 54, 119.8 }, { 55, 120.4 },
            { 56, 121.1 }, { 57, 121.8 }, { 58, 122.4 }, { 59, 123.1 }, { 60, 123.7 }
        };

        private Dictionary<int, double> heightSDMinus3 = new Dictionary<int, double>
        {
            { 0, 43.6 }, { 1, 47.8 }, { 2, 51.0 }, { 3, 53.5 }, { 4, 55.6 }, { 5, 57.4 }, { 6, 58.9 }, { 7, 60.3 },
            { 8, 61.7 }, { 9, 62.9 }, { 10, 64.1 }, { 11, 65.2 }, { 12, 66.3 }, { 13, 67.3 }, { 14, 68.3 }, { 15, 69.3 },
            { 16, 70.2 }, { 17, 71.1 }, { 18, 72.0 }, { 19, 72.8 }, { 20, 73.7 }, { 21, 74.5 }, { 22, 75.2 }, { 23, 76.0 },
            { 24, 76.7 }, { 25, 76.8 }, { 26, 77.5 }, { 27, 78.1 }, { 28, 78.8 }, { 29, 79.5 }, { 30, 80.1 }, { 31, 80.7 },
            { 32, 81.3 }, { 33, 81.9 }, { 34, 82.5 }, { 35, 83.1 }, { 36, 83.6 }, { 37, 84.2 }, { 38, 84.7 }, { 39, 85.3 },
            { 40, 85.8 }, { 41, 86.3 }, { 42, 86.8 }, { 43, 87.4 }, { 44, 87.9 }, { 45, 88.4 }, { 46, 88.9 }, { 47, 89.3 },
            { 48, 89.8 }, { 49, 90.3 }, { 50, 90.7 }, { 51, 91.2 }, { 52, 91.7 }, { 53, 92.1 }, { 54, 92.6 }, { 55, 93.0 },
            { 56, 93.4 }, { 57, 93.9 }, { 58, 94.3 }, { 59, 94.7 }, { 60, 95.2 }
        };



        //==============================================================================================================================================//


        private Dictionary<int, double> medianHeightMale = new Dictionary<int, double>
        {
            { 0, 49.9 }, { 1, 54.7 }, { 2, 58.4 }, { 3, 61.4 }, { 4, 63.9 },
            { 5, 65.9 }, { 6, 67.6 }, { 7, 69.2 }, { 8, 70.6 }, { 9, 72.0 },
            { 10, 73.3 }, { 11, 74.5 }, { 12, 75.7 }, { 13, 76.9 }, { 14, 78.0 },
            { 15, 79.1 }, { 16, 80.2 }, { 17, 81.2 }, { 18, 82.3 }, { 19, 83.2 },
            { 20, 84.2 }, { 21, 85.1 }, { 22, 86.0 }, { 23, 86.9 }, { 24, 87.8 },
            { 25, 88.0 }, { 26, 88.8 }, { 27, 89.6 }, { 28, 90.4 }, { 29, 91.2 },
            { 30, 91.9 }, { 31, 92.7 }, { 32, 93.4 }, { 33, 94.1 }, { 34, 94.8 },
            { 35, 95.4 }, { 36, 96.1 }, { 37, 96.7 }, { 38, 97.4 }, { 39, 98.0 },
            { 40, 98.6 }, { 41, 99.2 }, { 42, 99.9 }, { 43, 100.4 }, { 44, 101.0 },
            { 45, 101.6 }, { 46, 102.2 }, { 47, 102.8 }, { 48, 103.3 }, { 49, 103.9 },
            { 50, 104.4 }, { 51, 105.0 }, { 52, 105.6 }, { 53, 106.1 }, { 54, 106.7 },
            { 55, 107.2 }, { 56, 107.8 }, { 57, 108.3 }, { 58, 108.9 }, { 59, 109.4 },
            { 60, 110.0 }
        };
        private Dictionary<int, double> minus2SDHeightMale = new Dictionary<int, double>
        {
            { 0, 46.1 }, { 1, 50.8 }, { 2, 54.4 }, { 3, 57.3 }, { 4, 59.7 },
            { 5, 61.7 }, { 6, 63.3 }, { 7, 64.8 }, { 8, 66.2 }, { 9, 67.5 },
            { 10, 68.7 }, { 11, 69.9 }, { 12, 71.0 }, { 13, 72.1 }, { 14, 73.1 },
            { 15, 74.1 }, { 16, 75.0 }, { 17, 76.0 }, { 18, 76.9 }, { 19, 77.7 },
            { 20, 78.6 }, { 21, 79.4 }, { 22, 80.2 }, { 23, 81.0 }, { 24, 81.7 },
            { 25, 81.7 }, { 26, 82.5 }, { 27, 83.1 }, { 28, 83.8 }, { 29, 84.5 },
            { 30, 85.1 }, { 31, 85.7 }, { 32, 86.4 }, { 33, 86.9 }, { 34, 87.5 },
            { 35, 88.1 }, { 36, 88.7 }, { 37, 89.2 }, { 38, 89.8 }, { 39, 90.3 },
            { 40, 90.9 }, { 41, 91.4 }, { 42, 91.9 }, { 43, 92.4 }, { 44, 93.0 },
            { 45, 93.5 }, { 46, 94.0 }, { 47, 94.4 }, { 48, 94.9 }, { 49, 95.4 },
            { 50, 95.9 }, { 51, 96.4 }, { 52, 96.9 }, { 53, 97.4 }, { 54, 97.8 },
            { 55, 98.3 }, { 56, 98.8 }, { 57, 99.3 }, { 58, 99.7 }, { 59, 100.2 },
            { 60, 100.7 }
        };
        private Dictionary<int, double> plus2SDHeightMale = new Dictionary<int, double>
        {
            { 0, 53.7 }, { 1, 58.6 }, { 2, 62.4 }, { 3, 65.5 }, { 4, 68.0 },
            { 5, 70.1 }, { 6, 71.9 }, { 7, 73.5 }, { 8, 75.0 }, { 9, 76.5 },
            { 10, 77.9 }, { 11, 79.2 }, { 12, 80.5 }, { 13, 81.8 }, { 14, 83.0 },
            { 15, 84.2 }, { 16, 85.4 }, { 17, 86.5 }, { 18, 87.7 }, { 19, 88.8 },
            { 20, 89.8 }, { 21, 90.9 }, { 22, 91.9 }, { 23, 92.9 }, { 24, 93.9 },
            { 25, 94.2 }, { 26, 95.2 }, { 27, 96.1 }, { 28, 97.0 }, { 29, 97.9 },
            { 30, 98.7 }, { 31, 99.6 }, { 32, 100.4 }, { 33, 101.2 }, { 34, 102.0 },
            { 35, 102.7 }, { 36, 103.5 }, { 37, 104.2 }, { 38, 105.0 }, { 39, 105.7 },
            { 40, 106.4 }, { 41, 107.1 }, { 42, 107.8 }, { 43, 108.5 }, { 44, 109.1 },
            { 45, 109.8 }, { 46, 110.4 }, { 47, 111.1 }, { 48, 111.7 }, { 49, 112.4 },
            { 50, 113.0 }, { 51, 113.6 }, { 52, 114.2 }, { 53, 114.9 }, { 54, 115.5 },
            { 55, 116.1 }, { 56, 116.7 }, { 57, 117.4 }, { 58, 118.0 }, { 59, 118.6 },
            { 60, 119.2 }
        };
        private Dictionary<int, double> minus3SDHeightMale = new Dictionary<int, double>
        {
            { 0, 44.2 }, { 1, 48.9 }, { 2, 52.4 }, { 3, 55.3 }, { 4, 57.6 },
            { 5, 59.6 }, { 6, 61.2 }, { 7, 62.7 }, { 8, 64.0 }, { 9, 65.2 },
            { 10, 66.4 }, { 11, 67.6 }, { 12, 68.6 }, { 13, 69.6 }, { 14, 70.6 },
            { 15, 71.6 }, { 16, 72.5 }, { 17, 73.3 }, { 18, 74.2 }, { 19, 75.0 },
            { 20, 75.8 }, { 21, 76.5 }, { 22, 77.2 }, { 23, 78.0 }, { 24, 78.7 },
            { 25, 78.6 }, { 26, 79.3 }, { 27, 79.9 }, { 28, 80.5 }, { 29, 81.1 },
            { 30, 81.7 }, { 31, 82.3 }, { 32, 82.8 }, { 33, 83.4 }, { 34, 83.9 },
            { 35, 84.4 }, { 36, 85.0 }, { 37, 85.5 }, { 38, 86.0 }, { 39, 86.5 },
            { 40, 87.0 }, { 41, 87.5 }, { 42, 88.0 }, { 43, 88.4 }, { 44, 88.9 },
            { 45, 89.4 }, { 46, 89.8 }, { 47, 90.3 }, { 48, 90.7 }, { 49, 91.2 },
            { 50, 91.6 }, { 51, 92.1 }, { 52, 92.5 }, { 53, 93.0 }, { 54, 93.4 },
            { 55, 93.9 }, { 56, 94.3 }, { 57, 94.7 }, { 58, 95.2 }, { 59, 95.6 },
            { 60, 96.1 }
        };
        private Dictionary<int, double> plus3SDHeightMale = new Dictionary<int, double>
        {
            { 0, 55.6 }, { 1, 60.6 }, { 2, 64.4 }, { 3, 67.6 }, { 4, 70.1 },
            { 5, 72.2 }, { 6, 74.0 }, { 7, 75.7 }, { 8, 77.2 }, { 9, 78.7 },
            { 10, 80.1 }, { 11, 81.5 }, { 12, 82.9 }, { 13, 84.2 }, { 14, 85.5 },
            { 15, 86.7 }, { 16, 88.0 }, { 17, 89.2 }, { 18, 90.4 }, { 19, 91.5 },
            { 20, 92.6 }, { 21, 93.8 }, { 22, 94.9 }, { 23, 95.9 }, { 24, 97.0 },
            { 25, 97.3 }, { 26, 98.3 }, { 27, 99.3 }, { 28, 100.3 }, { 29, 101.2 },
            { 30, 102.1 }, { 31, 103.0 }, { 32, 103.9 }, { 33, 104.8 }, { 34, 105.6 },
            { 35, 106.4 }, { 36, 107.2 }, { 37, 108.0 }, { 38, 108.8 }, { 39, 109.5 },
            { 40, 110.3 }, { 41, 111.0 }, { 42, 111.7 }, { 43, 112.5 }, { 44, 113.2 },
            { 45, 113.9 }, { 46, 114.6 }, { 47, 115.2 }, { 48, 115.9 }, { 49, 116.6 },
            { 50, 117.3 }, { 51, 117.9 }, { 52, 118.6 }, { 53, 119.2 }, { 54, 119.9 },
            { 55, 120.6 }, { 56, 121.2 }, { 57, 121.9 }, { 58, 122.6 }, { 59, 123.2 },
            { 60, 123.9 }
        };




        protected void Page_Load(object sender, EventArgs e)
        {

            string nik = Request.QueryString["NIK"];
            if (string.IsNullOrEmpty(nik))
            {
                // Handle the case where NIK is not provided
                Response.Redirect("WebForm1Ortu.aspx");
                return;
            }

            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                var anak = (from b in db.balitas
                            where b.NIK == nik
                            select b).FirstOrDefault();

                if (anak == null)
                {
                    // Handle the case where the child is not found
                    Response.Redirect("WebForm1Ortu.aspx");
                    return;
                }
                LabelNama.Text = anak.namaAnak;
                LblOrtu.Text = anak.namaOrangtua;

                growthUtility utility = new growthUtility();
                string jenisKelamin = anak.jenisKelamin;
                double? zScore = utility.CalculateZScoreAndClassification(anak.umur, Convert.ToDouble(anak.tinggiBadan), jenisKelamin).zScore;

                if (zScore.HasValue)
                {
                    ZScore.Text = $"Z-score: {zScore.Value:F2}";
                }
                else
                {
                    ZScore.Text = "Z-score: Not available";
                }

                if(anak.jenisKelamin == "perempuan")
                {
                    Series series1 = Chart1.Series.FindByName("Series1");
                    Chart1.Series["Series1"].Points.Clear();


                    foreach (var entry in medianHeightFemale.OrderBy(x => x.Key))
                    {
                        series1.Points.AddXY(entry.Key, entry.Value);

                    }
                    series1.Points.Last().Label = medianHeightFemale.Last().Value.ToString("median");
                    series1.ChartType = SeriesChartType.Line;
                    series1.LegendText = "Median Height";


                    Series series2 = Chart1.Series.FindByName("Series2");

                    series2 = new Series("Series2");
                    series2.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series2);

                    series2.Points.Clear();


                    foreach (var entry in heightSDMinus2.OrderBy(x => x.Key))
                    {
                        series2.Points.AddXY(entry.Key, entry.Value);
                    }
                    series2.Points.Last().Label = heightSDMinus2.Last().Value.ToString("-2 SD");
                    series2.ChartType = SeriesChartType.Line; // Display only data points
                    series2.Color = Color.Red;
                    series2.LegendText = "-2SD Height";

                    Series series3 = Chart1.Series.FindByName("Series3");
                    series3 = new Series("Series3");
                    series3.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series3);

                    series3.Points.Clear();

                    foreach (var entry in heightSDPlus2.OrderBy(x => x.Key))
                    {
                        series3.Points.AddXY(entry.Key, entry.Value);
                    }
                    series3.Points.Last().Label = heightSDPlus2.Last().Value.ToString("2 SD");
                    series3.ChartType = SeriesChartType.Line; // Display only data points
                    series3.Color = Color.Red;
                    series3.LegendText = "+2SD Height";


                    Series series4 = Chart1.Series.FindByName("Series4");
                    series4 = new Series("Series4");
                    series4.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series4);

                    series4.Points.Clear();

                    foreach (var entry in heightSDPlus3.OrderBy(x => x.Key))
                    {
                        series4.Points.AddXY(entry.Key, entry.Value);
                    }
                    series4.Points.Last().Label = heightSDPlus3.Last().Value.ToString("3 SD");
                    series4.ChartType = SeriesChartType.Line;
                    series4.Color = Color.Black;
                    series4.LegendText = "+3SD Height";

                    Series series5 = Chart1.Series.FindByName("Series5");
                    series5 = new Series("Series5");
                    series5.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series5);
                    series5.Points.Clear();
                    foreach (var entry in heightSDMinus3.OrderBy(x => x.Key))
                    {
                        series5.Points.AddXY(entry.Key, entry.Value);
                    }

                    series5.Points.Last().Label = heightSDMinus3.Last().Value.ToString("3 SD");
                    series5.ChartType = SeriesChartType.Line;
                    series5.Color = Color.Black;
                    series5.LegendText = "+3SD Height";
                }
                else
                {
                    Series series1 = Chart1.Series.FindByName("Series1");
                    Chart1.Series["Series1"].Points.Clear();


                    foreach (var entry in medianHeightMale.OrderBy(x => x.Key))
                    {
                        series1.Points.AddXY(entry.Key, entry.Value);

                    }
                    series1.Points.Last().Label = medianHeightMale.Last().Value.ToString("median");
                    series1.ChartType = SeriesChartType.Line;
                    series1.LegendText = "Median Height";


                    Series series2 = Chart1.Series.FindByName("Series2");

                    series2 = new Series("Series2");
                    series2.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series2);

                    series2.Points.Clear();


                    foreach (var entry in minus2SDHeightMale.OrderBy(x => x.Key))
                    {
                        series2.Points.AddXY(entry.Key, entry.Value);
                    }
                    series2.Points.Last().Label = minus2SDHeightMale.Last().Value.ToString("-2 SD");
                    series2.ChartType = SeriesChartType.Line; // Display only data points
                    series2.Color = Color.Red;
                    series2.LegendText = "-2SD Height";

                    Series series3 = Chart1.Series.FindByName("Series3");
                    series3 = new Series("Series3");
                    series3.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series3);

                    series3.Points.Clear();

                    foreach (var entry in plus2SDHeightMale.OrderBy(x => x.Key))
                    {
                        series3.Points.AddXY(entry.Key, entry.Value);
                    }
                    series3.Points.Last().Label = plus2SDHeightMale.Last().Value.ToString("2 SD");
                    series3.ChartType = SeriesChartType.Line; // Display only data points
                    series3.Color = Color.Red;
                    series3.LegendText = "+2SD Height";


                    Series series4 = Chart1.Series.FindByName("Series4");
                    series4 = new Series("Series4");
                    series4.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series4);

                    series4.Points.Clear();

                    foreach (var entry in plus3SDHeightMale.OrderBy(x => x.Key))
                    {
                        series4.Points.AddXY(entry.Key, entry.Value);
                    }
                    series4.Points.Last().Label = plus3SDHeightMale.Last().Value.ToString("3 SD");
                    series4.ChartType = SeriesChartType.Line;
                    series4.Color = Color.Black;
                    series4.LegendText = "+3SD Height";

                    Series series5 = Chart1.Series.FindByName("Series5");
                    series5 = new Series("Series5");
                    series5.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series5);
                    series5.Points.Clear();
                    foreach (var entry in minus3SDHeightMale.OrderBy(x => x.Key))
                    {
                        series5.Points.AddXY(entry.Key, entry.Value);
                    }

                    series5.Points.Last().Label = minus3SDHeightMale.Last().Value.ToString("3 SD");
                    series5.ChartType = SeriesChartType.Line;
                    series5.Color = Color.Black;
                    series5.LegendText = "+3SD Height";
                }

                

                
                Series seriesChild = new Series("ChildData");
                seriesChild.ChartType = SeriesChartType.Point;
                seriesChild.MarkerStyle = MarkerStyle.Circle;
                seriesChild.MarkerColor = Color.Blue;
                seriesChild.MarkerSize = 10;
                Chart1.Series.Add(seriesChild);

                // Add child data point
                seriesChild.Points.AddXY(anak.umur, Convert.ToDouble(anak.tinggiBadan));
                seriesChild.Points[0].Label = $"{anak.namaAnak}'s Height"; // Optional label for the data point
            }
        }


    }
}