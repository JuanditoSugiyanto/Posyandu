using Posyandu.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Posyandu.AfterLoginKader
{
    public partial class ControlAnak : System.Web.UI.Page
    {


        private Dictionary<int, double> minus3SDWeightMaleMale = new Dictionary<int, double>
        {
            { 0, 2.1 }, { 1, 2.9 }, { 2, 3.8 }, { 3, 4.4 }, { 4, 4.9 },
            { 5, 5.3 }, { 6, 5.7 }, { 7, 5.9 }, { 8, 6.2 }, { 9, 6.4 },
            { 10, 6.6 }, { 11, 6.8 }, { 12, 6.9 }, { 13, 7.1 }, { 14, 7.2 },
            { 15, 7.4 }, { 16, 7.5 }, { 17, 7.7 }, { 18, 7.8 }, { 19, 8.0 },
            { 20, 8.1 }, { 21, 8.2 }, { 22, 8.4 }, { 23, 8.5 }, { 24, 8.6 },
            { 25, 8.8 }, { 26, 8.9 }, { 27, 9.0 }, { 28, 9.1 }, { 29, 9.2 },
            { 30, 9.4 }, { 31, 9.5 }, { 32, 9.6 }, { 33, 9.7 }, { 34, 9.8 },
            { 35, 9.9 }, { 36, 10.0 }, { 37, 10.1 }, { 38, 10.2 }, { 39, 10.3 },
            { 40, 10.4 }, { 41, 10.5 }, { 42, 10.6 }, { 43, 10.7 }, { 44, 10.8 },
            { 45, 10.9 }, { 46, 11.0 }, { 47, 11.1 }, { 48, 11.2 }, { 49, 11.3 },
            { 50, 11.4 }, { 51, 11.5 }, { 52, 11.6 }, { 53, 11.7 }, { 54, 11.8 },
            { 55, 11.9 }, { 56, 12.0 }, { 57, 12.1 }, { 58, 12.2 }, { 59, 12.3 },
            { 60, 12.4 }
        };

        private Dictionary<int, double> minus2SDWeightMale = new Dictionary<int, double>
        {
            { 0, 2.5 }, { 1, 3.4 }, { 2, 4.3 }, { 3, 5.0 }, { 4, 5.6 },
            { 5, 6.0 }, { 6, 6.4 }, { 7, 6.7 }, { 8, 6.9 }, { 9, 7.1 },
            { 10, 7.4 }, { 11, 7.6 }, { 12, 7.7 }, { 13, 7.9 }, { 14, 8.1 },
            { 15, 8.3 }, { 16, 8.4 }, { 17, 8.6 }, { 18, 8.8 }, { 19, 8.9 },
            { 20, 9.1 }, { 21, 9.2 }, { 22, 9.4 }, { 23, 9.5 }, { 24, 9.7 },
            { 25, 9.8 }, { 26, 10.0 }, { 27, 10.1 }, { 28, 10.2 }, { 29, 10.4 },
            { 30, 10.5 }, { 31, 10.7 }, { 32, 10.8 }, { 33, 10.9 }, { 34, 11.0 },
            { 35, 11.2 }, { 36, 11.3 }, { 37, 11.4 }, { 38, 11.5 }, { 39, 11.6 },
            { 40, 11.8 }, { 41, 11.9 }, { 42, 12.0 }, { 43, 12.1 }, { 44, 12.2 },
            { 45, 12.4 }, { 46, 12.5 }, { 47, 12.6 }, { 48, 12.7 }, { 49, 12.8 },
            { 50, 12.9 }, { 51, 13.1 }, { 52, 13.2 }, { 53, 13.3 }, { 54, 13.4 },
            { 55, 13.5 }, { 56, 13.6 }, { 57, 13.7 }, { 58, 13.8 }, { 59, 14.0 },
            { 60, 14.1 }
        };
        private Dictionary<int, double> minus1SDWeightMale = new Dictionary<int, double>
        {
            { 0, 2.9 }, { 1, 3.9 }, { 2, 4.9 }, { 3, 5.7 }, { 4, 6.2 },
            { 5, 6.7 }, { 6, 7.1 }, { 7, 7.4 }, { 8, 7.7 }, { 9, 8.0 },
            { 10, 8.2 }, { 11, 8.4 }, { 12, 8.6 }, { 13, 8.8 }, { 14, 9.0 },
            { 15, 9.2 }, { 16, 9.4 }, { 17, 9.6 }, { 18, 9.8 }, { 19, 10.0 },
            { 20, 10.1 }, { 21, 10.3 }, { 22, 10.5 }, { 23, 10.7 }, { 24, 10.8 },
            { 25, 11.0 }, { 26, 11.2 }, { 27, 11.3 }, { 28, 11.5 }, { 29, 11.7 },
            { 30, 11.8 }, { 31, 12.0 }, { 32, 12.1 }, { 33, 12.3 }, { 34, 12.4 },
            { 35, 12.6 }, { 36, 12.7 }, { 37, 12.9 }, { 38, 13.0 }, { 39, 13.1 },
            { 40, 13.3 }, { 41, 13.4 }, { 42, 13.6 }, { 43, 13.7 }, { 44, 13.8 },
            { 45, 14.0 }, { 46, 14.1 }, { 47, 14.3 }, { 48, 14.4 }, { 49, 14.5 },
            { 50, 14.7 }, { 51, 14.8 }, { 52, 15.0 }, { 53, 15.1 }, { 54, 15.2 },
            { 55, 15.4 }, { 56, 15.5 }, { 57, 15.6 }, { 58, 15.8 }, { 59, 15.9 },
            { 60, 16.0 }
        };

        private Dictionary<int, double> medianWeightMale = new Dictionary<int, double>
        {
            { 0, 3.3 }, { 1, 4.5 }, { 2, 5.6 }, { 3, 6.4 }, { 4, 7.0 },
            { 5, 7.5 }, { 6, 7.9 }, { 7, 8.3 }, { 8, 8.6 }, { 9, 8.9 },
            { 10, 9.2 }, { 11, 9.4 }, { 12, 9.6 }, { 13, 9.9 }, { 14, 10.1 },
            { 15, 10.3 }, { 16, 10.5 }, { 17, 10.7 }, { 18, 10.9 }, { 19, 11.1 },
            { 20, 11.3 }, { 21, 11.5 }, { 22, 11.8 }, { 23, 12.0 }, { 24, 12.2 },
            { 25, 12.4 }, { 26, 12.5 }, { 27, 12.7 }, { 28, 12.9 }, { 29, 13.1 },
            { 30, 13.3 }, { 31, 13.5 }, { 32, 13.7 }, { 33, 13.8 }, { 34, 14.0 },
            { 35, 14.2 }, { 36, 14.3 }, { 37, 14.5 }, { 38, 14.7 }, { 39, 14.8 },
            { 40, 15.0 }, { 41, 15.2 }, { 42, 15.3 }, { 43, 15.5 }, { 44, 15.7 },
            { 45, 15.8 }, { 46, 16.0 }, { 47, 16.2 }, { 48, 16.3 }, { 49, 16.5 },
            { 50, 16.7 }, { 51, 16.8 }, { 52, 17.0 }, { 53, 17.2 }, { 54, 17.3 },
            { 55, 17.5 }, { 56, 17.7 }, { 57, 17.8 }, { 58, 18.0 }, { 59, 18.2 },
            { 60, 18.3 }
        };

        private Dictionary<int, double> plus1SDWeightMale = new Dictionary<int, double>
        {
            { 0, 3.9 }, { 1, 5.1 }, { 2, 6.3 }, { 3, 7.2 }, { 4, 7.8 },
            { 5, 8.4 }, { 6, 8.8 }, { 7, 9.2 }, { 8, 9.6 }, { 9, 9.9 },
            { 10, 10.2 }, { 11, 10.5 }, { 12, 10.8 }, { 13, 11.0 }, { 14, 11.3 },
            { 15, 11.5 }, { 16, 11.7 }, { 17, 12.0 }, { 18, 12.2 }, { 19, 12.5 },
            { 20, 12.7 }, { 21, 12.9 }, { 22, 13.2 }, { 23, 13.4 }, { 24, 13.6 },
            { 25, 13.9 }, { 26, 14.1 }, { 27, 14.3 }, { 28, 14.5 }, { 29, 14.8 },
            { 30, 15.0 }, { 31, 15.2 }, { 32, 15.4 }, { 33, 15.6 }, { 34, 15.8 },
            { 35, 16.0 }, { 36, 16.2 }, { 37, 16.4 }, { 38, 16.6 }, { 39, 16.8 },
            { 40, 17.0 }, { 41, 17.2 }, { 42, 17.4 }, { 43, 17.6 }, { 44, 17.8 },
            { 45, 18.0 }, { 46, 18.2 }, { 47, 18.4 }, { 48, 18.6 }, { 49, 18.8 },
            { 50, 19.0 }, { 51, 19.2 }, { 52, 19.4 }, { 53, 19.6 }, { 54, 19.8 },
            { 55, 20.0 }, { 56, 20.2 }, { 57, 20.4 }, { 58, 20.6 }, { 59, 20.8 },
            { 60, 21.0 }
        };

        private Dictionary<int, double> plus2SDWeightMale = new Dictionary<int, double>
        {
            { 0, 4.4 }, { 1, 5.8 }, { 2, 7.1 }, { 3, 8.0 }, { 4, 8.7 },
            { 5, 9.3 }, { 6, 9.8 }, { 7, 10.3 }, { 8, 10.7 }, { 9, 11.0 },
            { 10, 11.4 }, { 11, 11.7 }, { 12, 12.0 }, { 13, 12.3 }, { 14, 12.6 },
            { 15, 12.8 }, { 16, 13.1 }, { 17, 13.4 }, { 18, 13.7 }, { 19, 13.9 },
            { 20, 14.2 }, { 21, 14.5 }, { 22, 14.7 }, { 23, 15.0 }, { 24, 15.3 },
            { 25, 15.5 }, { 26, 15.8 }, { 27, 16.1 }, { 28, 16.3 }, { 29, 16.6 },
            { 30, 16.9 }, { 31, 17.1 }, { 32, 17.4 }, { 33, 17.6 }, { 34, 17.8 },
            { 35, 18.1 }, { 36, 18.3 }, { 37, 18.6 }, { 38, 18.8 }, { 39, 19.0 },
            { 40, 19.3 }, { 41, 19.5 }, { 42, 19.7 }, { 43, 20.0 }, { 44, 20.2 },
            { 45, 20.5 }, { 46, 20.7 }, { 47, 20.9 }, { 48, 21.2 }, { 49, 21.4 },
            { 50, 21.7 }, { 51, 21.9 }, { 52, 22.2 }, { 53, 22.4 }, { 54, 22.7 },
            { 55, 22.9 }, { 56, 23.2 }, { 57, 23.4 }, { 58, 23.7 }, { 59, 23.9 },
            { 60, 24.2 }
        };

        private Dictionary<int, double> plus3SDWeightMale = new Dictionary<int, double>
        {
            { 0, 5.0 }, { 1, 6.6 }, { 2, 8.0 }, { 3, 9.0 }, { 4, 9.7 },
            { 5, 10.4 }, { 6, 10.9 }, { 7, 11.4 }, { 8, 11.9 }, { 9, 12.3 },
            { 10, 12.7 }, { 11, 13.0 }, { 12, 13.3 }, { 13, 13.7 }, { 14, 14.0 },
            { 15, 14.3 }, { 16, 14.6 }, { 17, 14.9 }, { 18, 15.3 }, { 19, 15.6 },
            { 20, 15.9 }, { 21, 16.2 }, { 22, 16.5 }, { 23, 16.8 }, { 24, 17.1 },
            { 25, 17.5 }, { 26, 17.8 }, { 27, 18.1 }, { 28, 18.4 }, { 29, 18.7 },
            { 30, 19.0 }, { 31, 19.3 }, { 32, 19.6 }, { 33, 19.9 }, { 34, 20.2 },
            { 35, 20.4 }, { 36, 20.7 }, { 37, 21.0 }, { 38, 21.3 }, { 39, 21.6 },
            { 40, 21.9 }, { 41, 22.1 }, { 42, 22.4 }, { 43, 22.7 }, { 44, 23.0 },
            { 45, 23.3 }, { 46, 23.6 }, { 47, 23.9 }, { 48, 24.2 }, { 49, 24.5 },
            { 50, 24.8 }, { 51, 25.1 }, { 52, 25.4 }, { 53, 25.7 }, { 54, 26.0 },
            { 55, 26.3 }, { 56, 26.6 }, { 57, 26.9 }, { 58, 27.2 }, { 59, 27.6 },
            { 60, 27.9 }
        };

        //===============Female==============================//

        private Dictionary<int, double> minus3SDWeightFemale = new Dictionary<int, double>
        {
            { 0, 2.0 }, { 1, 2.7 }, { 2, 3.4 }, { 3, 4.0 }, { 4, 4.4 },
            { 5, 4.8 }, { 6, 5.1 }, { 7, 5.3 }, { 8, 5.6 }, { 9, 5.8 },
            { 10, 5.9 }, { 11, 6.1 }, { 12, 6.3 }, { 13, 6.4 }, { 14, 6.6 },
            { 15, 6.7 }, { 16, 6.9 }, { 17, 7.0 }, { 18, 7.2 }, { 19, 7.3 },
            { 20, 7.5 }, { 21, 7.6 }, { 22, 7.8 }, { 23, 7.9 }, { 24, 8.1 },
            { 25, 8.2 }, { 26, 8.4 }, { 27, 8.5 }, { 28, 8.6 }, { 29, 8.8 },
            { 30, 8.9 }, { 31, 9.0 }, { 32, 9.1 }, { 33, 9.3 }, { 34, 9.4 },
            { 35, 9.5 }, { 36, 9.6 }, { 37, 9.7 }, { 38, 9.8 }, { 39, 9.9 },
            { 40, 10.1 }, { 41, 10.2 }, { 42, 10.3 }, { 43, 10.4 }, { 44, 10.5 },
            { 45, 10.6 }, { 46, 10.7 }, { 47, 10.8 }, { 48, 10.9 }, { 49, 11.0 },
            { 50, 11.1 }, { 51, 11.2 }, { 52, 11.3 }, { 53, 11.4 }, { 54, 11.5 },
            { 55, 11.6 }, { 56, 11.7 }, { 57, 11.8 }, { 58, 11.9 }, { 59, 12.0 },
            { 60, 12.1 }
        };


        private Dictionary<int, double> minus2SDWeightFemale = new Dictionary<int, double>
        {
            { 0, 2.4 }, { 1, 3.2 }, { 2, 3.9 }, { 3, 4.5 }, { 4, 5.0 },
            { 5, 5.4 }, { 6, 5.7 }, { 7, 6.0 }, { 8, 6.3 }, { 9, 6.5 },
            { 10, 6.7 }, { 11, 6.9 }, { 12, 7.0 }, { 13, 7.2 }, { 14, 7.4 },
            { 15, 7.6 }, { 16, 7.7 }, { 17, 7.9 }, { 18, 8.1 }, { 19, 8.2 },
            { 20, 8.4 }, { 21, 8.6 }, { 22, 8.7 }, { 23, 8.9 }, { 24, 9.0 },
            { 25, 9.2 }, { 26, 9.4 }, { 27, 9.5 }, { 28, 9.7 }, { 29, 9.8 },
            { 30, 10.0 }, { 31, 10.1 }, { 32, 10.3 }, { 33, 10.4 }, { 34, 10.5 },
            { 35, 10.7 }, { 36, 10.8 }, { 37, 10.9 }, { 38, 11.1 }, { 39, 11.2 },
            { 40, 11.3 }, { 41, 11.5 }, { 42, 11.6 }, { 43, 11.7 }, { 44, 11.8 },
            { 45, 12.0 }, { 46, 12.1 }, { 47, 12.2 }, { 48, 12.3 }, { 49, 12.4 },
            { 50, 12.6 }, { 51, 12.7 }, { 52, 12.8 }, { 53, 12.9 }, { 54, 13.0 },
            { 55, 13.2 }, { 56, 13.3 }, { 57, 13.4 }, { 58, 13.5 }, { 59, 13.6 },
            { 60, 13.7 }
        };

        private Dictionary<int, double> minus1SDWeightFemale = new Dictionary<int, double>
        {
            { 0, 2.8 }, { 1, 3.6 }, { 2, 4.5 }, { 3, 5.2 }, { 4, 5.7 },
            { 5, 6.1 }, { 6, 6.5 }, { 7, 6.8 }, { 8, 7.0 }, { 9, 7.3 },
            { 10, 7.5 }, { 11, 7.7 }, { 12, 7.9 }, { 13, 8.1 }, { 14, 8.3 },
            { 15, 8.5 }, { 16, 8.7 }, { 17, 8.9 }, { 18, 9.1 }, { 19, 9.2 },
            { 20, 9.4 }, { 21, 9.6 }, { 22, 9.8 }, { 23, 10.0 }, { 24, 10.2 },
            { 25, 10.3 }, { 26, 10.5 }, { 27, 10.7 }, { 28, 10.9 }, { 29, 11.1 },
            { 30, 11.2 }, { 31, 11.4 }, { 32, 11.6 }, { 33, 11.7 }, { 34, 11.9 },
            { 35, 12.0 }, { 36, 12.2 }, { 37, 12.4 }, { 38, 12.5 }, { 39, 12.7 },
            { 40, 12.8 }, { 41, 13.0 }, { 42, 13.1 }, { 43, 13.3 }, { 44, 13.4 },
            { 45, 13.6 }, { 46, 13.7 }, { 47, 13.9 }, { 48, 14.0 }, { 49, 14.2 },
            { 50, 14.3 }, { 51, 14.5 }, { 52, 14.6 }, { 53, 14.8 }, { 54, 14.9 },
            { 55, 15.1 }, { 56, 15.2 }, { 57, 15.3 }, { 58, 15.5 }, { 59, 15.6 },
            { 60, 15.8 }
        };

        private Dictionary<int, double> medianWeightFemale = new Dictionary<int, double>
        {
            { 0, 3.2 }, { 1, 4.2 }, { 2, 5.1 }, { 3, 5.8 }, { 4, 6.4 },
            { 5, 6.9 }, { 6, 7.3 }, { 7, 7.6 }, { 8, 7.9 }, { 9, 8.2 },
            { 10, 8.5 }, { 11, 8.7 }, { 12, 8.9 }, { 13, 9.2 }, { 14, 9.4 },
            { 15, 9.6 }, { 16, 9.8 }, { 17, 10.0 }, { 18, 10.2 }, { 19, 10.4 },
            { 20, 10.6 }, { 21, 10.9 }, { 22, 11.1 }, { 23, 11.3 }, { 24, 11.5 },
            { 25, 11.7 }, { 26, 11.9 }, { 27, 12.1 }, { 28, 12.3 }, { 29, 12.5 },
            { 30, 12.7 }, { 31, 12.9 }, { 32, 13.1 }, { 33, 13.3 }, { 34, 13.5 },
            { 35, 13.7 }, { 36, 13.9 }, { 37, 14.0 }, { 38, 14.2 }, { 39, 14.4 },
            { 40, 14.6 }, { 41, 14.8 }, { 42, 15.0 }, { 43, 15.2 }, { 44, 15.3 },
            { 45, 15.5 }, { 46, 15.7 }, { 47, 15.9 }, { 48, 16.1 }, { 49, 16.3 },
            { 50, 16.4 }, { 51, 16.6 }, { 52, 16.8 }, { 53, 17.0 }, { 54, 17.2 },
            { 55, 17.3 }, { 56, 17.5 }, { 57, 17.7 }, { 58, 17.9 }, { 59, 18.0 },
            { 60, 18.2 }
        };

        private Dictionary<int, double> plus1SDWeightFemale = new Dictionary<int, double>
        {
            { 0, 3.7 }, { 1, 4.8 }, { 2, 5.8 }, { 3, 6.6 }, { 4, 7.3 },
            { 5, 7.8 }, { 6, 8.2 }, { 7, 8.6 }, { 8, 9.0 }, { 9, 9.3 },
            { 10, 9.6 }, { 11, 9.9 }, { 12, 10.1 }, { 13, 10.4 }, { 14, 10.6 },
            { 15, 10.9 }, { 16, 11.1 }, { 17, 11.4 }, { 18, 11.6 }, { 19, 11.8 },
            { 20, 12.1 }, { 21, 12.3 }, { 22, 12.5 }, { 23, 12.8 }, { 24, 13.0 },
            { 25, 13.3 }, { 26, 13.5 }, { 27, 13.7 }, { 28, 14.0 }, { 29, 14.2 },
            { 30, 14.4 }, { 31, 14.7 }, { 32, 14.9 }, { 33, 15.1 }, { 34, 15.4 },
            { 35, 15.6 }, { 36, 15.8 }, { 37, 16.0 }, { 38, 16.3 }, { 39, 16.5 },
            { 40, 16.7 }, { 41, 16.9 }, { 42, 17.2 }, { 43, 17.4 }, { 44, 17.6 },
            { 45, 17.8 }, { 46, 18.1 }, { 47, 18.3 }, { 48, 18.5 }, { 49, 18.8 },
            { 50, 19.0 }, { 51, 19.2 }, { 52, 19.4 }, { 53, 19.7 }, { 54, 19.9 },
            { 55, 20.1 }, { 56, 20.3 }, { 57, 20.6 }, { 58, 20.8 }, { 59, 21.0 },
            { 60, 21.2 }
        };


        private Dictionary<int, double> plus2SDWeightFemale = new Dictionary<int, double>
        {
            { 0, 4.2 }, { 1, 5.5 }, { 2, 6.6 }, { 3, 7.5 }, { 4, 8.2 },
            { 5, 8.8 }, { 6, 9.3 }, { 7, 9.8 }, { 8, 10.2 }, { 9, 10.5 },
            { 10, 10.9 }, { 11, 11.2 }, { 12, 11.5 }, { 13, 11.8 }, { 14, 12.1 },
            { 15, 12.4 }, { 16, 12.6 }, { 17, 12.9 }, { 18, 13.2 }, { 19, 13.5 },
            { 20, 13.7 }, { 21, 14.0 }, { 22, 14.3 }, { 23, 14.6 }, { 24, 14.8 },
            { 25, 15.1 }, { 26, 15.4 }, { 27, 15.7 }, { 28, 16.0 }, { 29, 16.2 },
            { 30, 16.5 }, { 31, 16.8 }, { 32, 17.1 }, { 33, 17.3 }, { 34, 17.6 },
            { 35, 17.9 }, { 36, 18.1 }, { 37, 18.4 }, { 38, 18.7 }, { 39, 19.0 },
            { 40, 19.2 }, { 41, 19.5 }, { 42, 19.8 }, { 43, 20.1 }, { 44, 20.4 },
            { 45, 20.7 }, { 46, 20.9 }, { 47, 21.2 }, { 48, 21.5 }, { 49, 21.8 },
            { 50, 22.1 }, { 51, 22.4 }, { 52, 22.6 }, { 53, 22.9 }, { 54, 23.2 },
            { 55, 23.5 }, { 56, 23.8 }, { 57, 24.1 }, { 58, 24.4 }, { 59, 24.6 },
            { 60, 24.9 }
        };

        private Dictionary<int, double> plus3SDWeightFemale = new Dictionary<int, double>
        {
            { 0, 4.8 }, { 1, 6.2 }, { 2, 7.5 }, { 3, 8.5 }, { 4, 9.3 },
            { 5, 10.0 }, { 6, 10.6 }, { 7, 11.1 }, { 8, 11.6 }, { 9, 12.0 },
            { 10, 12.4 }, { 11, 12.8 }, { 12, 13.1 }, { 13, 13.5 }, { 14, 13.8 },
            { 15, 14.1 }, { 16, 14.5 }, { 17, 14.8 }, { 18, 15.1 }, { 19, 15.4 },
            { 20, 15.7 }, { 21, 16.0 }, { 22, 16.4 }, { 23, 16.7 }, { 24, 17.0 },
            { 25, 17.3 }, { 26, 17.7 }, { 27, 18.0 }, { 28, 18.3 }, { 29, 18.7 },
            { 30, 19.0 }, { 31, 19.3 }, { 32, 19.6 }, { 33, 20.0 }, { 34, 20.3 },
            { 35, 20.6 }, { 36, 20.9 }, { 37, 21.3 }, { 38, 21.6 }, { 39, 22.0 },
            { 40, 22.3 }, { 41, 22.7 }, { 42, 23.0 }, { 43, 23.4 }, { 44, 23.7 },
            { 45, 24.1 }, { 46, 24.5 }, { 47, 24.8 }, { 48, 25.2 }, { 49, 25.5 },
            { 50, 25.9 }, { 51, 26.3 }, { 52, 26.6 }, { 53, 27.0 }, { 54, 27.4 },
            { 55, 27.7 }, { 56, 28.1 }, { 57, 28.5 }, { 58, 28.8 }, { 59, 29.2 },
            { 60, 29.5 }
        };



        //=========================================================//
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
                Response.Redirect("WebForm1Kader.aspx");
                return;
            }
            ViewState["NIK"] = nik;
            using (DatabasePsoyanduEntities db = new DatabasePsoyanduEntities())
            {
                var anak = (from b in db.balitas
                            where b.NIK == nik
                            select b).FirstOrDefault();

                if (anak == null)
                {
                    // Handle the case where the child is not found
                    Response.Redirect("WebForm1Kader.aspx");
                    return;
                }
                LabelNama.Text = anak.namaAnak;
                LblOrtu.Text = anak.namaOrangtua;
                LblUmurDB.Text = anak.umur.ToString();
                LblNIK.Text = anak.NIK;
                LblTinggi.Text = anak.tinggiBadan.ToString();
                LblBerat.Text = anak.beratBadan.ToString();
                LblJenisKelamin.Text = anak.jenisKelamin;
                LblAlamat.Text = anak.alamat;
      

                growthUtility utility = new growthUtility();
                string jenisKelamin = anak.jenisKelamin;
                double? zScore = utility.CalculateZScoreAndClassificationWeight(anak.umur, Convert.ToDouble(anak.beratBadan), jenisKelamin).zScore;
                string statusGizi = (anak.tinggiBadan == null || anak.tinggiBadan == 0) ? "" :
                    utility.CalculateZScoreAndClassificationWeight(anak.umur, Convert.ToDouble(anak.beratBadan), anak.jenisKelamin).classification;

                LblStatus.Text = statusGizi;   
                if (zScore.HasValue)
                {
                    ZScore.Text = $"Z-score: {zScore.Value:F2}";
                }
                else
                {
                    ZScore.Text = "Z-score: Not available";
                }

                if (anak.jenisKelamin == "perempuan")
                {
                    Series series1 = Chart1.Series.FindByName("Series1");
                    Chart1.Series["Series1"].Points.Clear();


                    foreach (var entry in medianWeightFemale.OrderBy(x => x.Key))
                    {
                        series1.Points.AddXY(entry.Key, entry.Value);

                    }
                    series1.Points.Last().Label = medianWeightFemale.Last().Value.ToString("median");
                    series1.ChartType = SeriesChartType.Line;
                    series1.LegendText = "Median Height";


                    Series series2 = Chart1.Series.FindByName("Series2");

                    series2 = new Series("Series2");
                    series2.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series2);

                    series2.Points.Clear();


                    foreach (var entry in minus2SDWeightFemale.OrderBy(x => x.Key))
                    {
                        series2.Points.AddXY(entry.Key, entry.Value);
                    }
                    series2.Points.Last().Label = minus2SDWeightFemale.Last().Value.ToString("-2 SD");
                    series2.ChartType = SeriesChartType.Line; // Display only data points
                    series2.Color = Color.Yellow;
                    series2.LegendText = "-2SD Height";

                    Series series3 = Chart1.Series.FindByName("Series3");
                    series3 = new Series("Series3");
                    series3.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series3);

                    series3.Points.Clear();

                    foreach (var entry in plus2SDWeightFemale.OrderBy(x => x.Key))
                    {
                        series3.Points.AddXY(entry.Key, entry.Value);
                    }
                    series3.Points.Last().Label = plus2SDWeightFemale.Last().Value.ToString("2 SD");
                    series3.ChartType = SeriesChartType.Line; // Display only data points
                    series3.Color = Color.Yellow;
                    series3.LegendText = "+2SD Height";


                    Series series4 = Chart1.Series.FindByName("Series4");
                    series4 = new Series("Series4");
                    series4.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series4);

                    series4.Points.Clear();

                    foreach (var entry in plus3SDWeightFemale.OrderBy(x => x.Key))
                    {
                        series4.Points.AddXY(entry.Key, entry.Value);
                    }
                    series4.Points.Last().Label = plus3SDWeightFemale.Last().Value.ToString("3 SD");
                    series4.ChartType = SeriesChartType.Line;
                    series4.Color = Color.Black;
                    series4.LegendText = "+3SD Height";

                    Series series5 = Chart1.Series.FindByName("Series5");
                    series5 = new Series("Series5");
                    series5.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series5);
                    series5.Points.Clear();
                    foreach (var entry in minus3SDWeightFemale.OrderBy(x => x.Key))
                    {
                        series5.Points.AddXY(entry.Key, entry.Value);
                    }

                    series5.Points.Last().Label = minus3SDWeightFemale.Last().Value.ToString("3 SD");
                    series5.ChartType = SeriesChartType.Line;
                    series5.Color = Color.Red;
                    series5.LegendText = "+3SD Height";



                    
                    Series series6 = Chart1.Series.FindByName("Series6");
                    series6 = new Series("Series6");
                    series6.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series6);
                    series6.Points.Clear();
                    foreach (var entry in plus1SDWeightFemale.OrderBy(x => x.Key))
                    {
                        series6.Points.AddXY(entry.Key, entry.Value);
                    }

                    series6.Points.Last().Label = plus1SDWeightFemale.Last().Value.ToString("1 SD");
                    series6.ChartType = SeriesChartType.Line;
                    series6.Color = Color.Green;
                    series6.LegendText = "+1SD Height";



                    Series series7 = Chart1.Series.FindByName("Series7");
                    series7 = new Series("Series7");
                    series7.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series7);
                    series7.Points.Clear();
                    foreach (var entry in minus1SDWeightFemale.OrderBy(x => x.Key))
                    {
                        series7.Points.AddXY(entry.Key, entry.Value);
                    }

                    series7.Points.Last().Label = minus1SDWeightFemale.Last().Value.ToString("-1 SD");
                    series7.ChartType = SeriesChartType.Line;
                    series7.Color = Color.Green;
                    series7.LegendText = "-1SD Height";
                }
                else
                {
                    Series series1 = Chart1.Series.FindByName("Series1");
                    Chart1.Series["Series1"].Points.Clear();


                    foreach (var entry in medianWeightMale.OrderBy(x => x.Key))
                    {
                        series1.Points.AddXY(entry.Key, entry.Value);

                    }
                    series1.Points.Last().Label = medianWeightMale.Last().Value.ToString("median");
                    series1.ChartType = SeriesChartType.Line;
                    series1.LegendText = "Median Height";


                    Series series2 = Chart1.Series.FindByName("Series2");

                    series2 = new Series("Series2");
                    series2.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series2);

                    series2.Points.Clear();


                    foreach (var entry in minus2SDWeightMale.OrderBy(x => x.Key))
                    {
                        series2.Points.AddXY(entry.Key, entry.Value);
                    }
                    series2.Points.Last().Label = minus2SDWeightMale.Last().Value.ToString("-2 SD");
                    series2.ChartType = SeriesChartType.Line; // Display only data points
                    series2.Color = Color.Yellow;
                    series2.LegendText = "-2SD Height";

                    Series series3 = Chart1.Series.FindByName("Series3");
                    series3 = new Series("Series3");
                    series3.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series3);

                    series3.Points.Clear();

                    foreach (var entry in plus2SDWeightMale.OrderBy(x => x.Key))
                    {
                        series3.Points.AddXY(entry.Key, entry.Value);
                    }
                    series3.Points.Last().Label = plus2SDWeightMale.Last().Value.ToString("2 SD");
                    series3.ChartType = SeriesChartType.Line; // Display only data points
                    series3.Color = Color.Yellow;
                    series3.LegendText = "+2SD Height";


                    Series series4 = Chart1.Series.FindByName("Series4");
                    series4 = new Series("Series4");
                    series4.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series4);

                    series4.Points.Clear();

                    foreach (var entry in plus3SDWeightMale.OrderBy(x => x.Key))
                    {
                        series4.Points.AddXY(entry.Key, entry.Value);
                    }
                    series4.Points.Last().Label = plus3SDWeightMale.Last().Value.ToString("3 SD");
                    series4.ChartType = SeriesChartType.Line;
                    series4.Color = Color.Black;
                    series4.LegendText = "+3SD Height";

                    Series series5 = Chart1.Series.FindByName("Series5");
                    series5 = new Series("Series5");
                    series5.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series5);
                    series5.Points.Clear();
                    foreach (var entry in minus3SDWeightMaleMale.OrderBy(x => x.Key))
                    {
                        series5.Points.AddXY(entry.Key, entry.Value);
                    }

                    series5.Points.Last().Label = minus3SDWeightMaleMale.Last().Value.ToString("-3 SD");
                    series5.ChartType = SeriesChartType.Line;
                    series5.Color = Color.Red;
                    series5.LegendText = "-3SD Height";




                    Series series6 = Chart1.Series.FindByName("Series6");
                    series6 = new Series("Series6");
                    series6.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series6);
                    series6.Points.Clear();
                    foreach (var entry in plus1SDWeightMale.OrderBy(x => x.Key))
                    {
                        series6.Points.AddXY(entry.Key, entry.Value);
                    }

                    series6.Points.Last().Label = plus1SDWeightMale.Last().Value.ToString("1 SD");
                    series6.ChartType = SeriesChartType.Line;
                    series6.Color = Color.Green;
                    series6.LegendText = "+1SD Height";



                    Series series7 = Chart1.Series.FindByName("Series7");
                    series7 = new Series("Series7");
                    series7.ChartType = SeriesChartType.Line;
                    Chart1.Series.Add(series7);
                    series7.Points.Clear();
                    foreach (var entry in minus1SDWeightMale.OrderBy(x => x.Key))
                    {
                        series7.Points.AddXY(entry.Key, entry.Value);
                    }

                    series7.Points.Last().Label = minus1SDWeightMale.Last().Value.ToString("-1 SD");
                    series7.ChartType = SeriesChartType.Line;
                    series7.Color = Color.Green;
                    series7.LegendText = "-1SD Height";

                }


                   if(anak.jenisKelamin == "perempuan")
                {
                    Series series1 = Chart2.Series.FindByName("Series1");
                    Chart2.Series["Series1"].Points.Clear();


                    foreach (var entry in medianHeightFemale.OrderBy(x => x.Key))
                    {
                        series1.Points.AddXY(entry.Key, entry.Value);

                    }
                    series1.Points.Last().Label = medianHeightFemale.Last().Value.ToString("median");
                    series1.ChartType = SeriesChartType.Line;
                    series1.LegendText = "Median Height";


                    Series series2 = Chart2.Series.FindByName("Series2");

                    series2 = new Series("Series2");
                    series2.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series2);

                    series2.Points.Clear();


                    foreach (var entry in heightSDMinus2.OrderBy(x => x.Key))
                    {
                        series2.Points.AddXY(entry.Key, entry.Value);
                    }
                    series2.Points.Last().Label = heightSDMinus2.Last().Value.ToString("-2 SD");
                    series2.ChartType = SeriesChartType.Line; // Display only data points
                    series2.Color = Color.Red;
                    series2.LegendText = "-2SD Height";

                    Series series3 = Chart2.Series.FindByName("Series3");
                    series3 = new Series("Series3");
                    series3.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series3);

                    series3.Points.Clear();

                    foreach (var entry in heightSDPlus2.OrderBy(x => x.Key))
                    {
                        series3.Points.AddXY(entry.Key, entry.Value);
                    }
                    series3.Points.Last().Label = heightSDPlus2.Last().Value.ToString("2 SD");
                    series3.ChartType = SeriesChartType.Line; // Display only data points
                    series3.Color = Color.Red;
                    series3.LegendText = "+2SD Height";


                    Series series4 = Chart2.Series.FindByName("Series4");
                    series4 = new Series("Series4");
                    series4.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series4);

                    series4.Points.Clear();

                    foreach (var entry in heightSDPlus3.OrderBy(x => x.Key))
                    {
                        series4.Points.AddXY(entry.Key, entry.Value);
                    }
                    series4.Points.Last().Label = heightSDPlus3.Last().Value.ToString("3 SD");
                    series4.ChartType = SeriesChartType.Line;
                    series4.Color = Color.Black;
                    series4.LegendText = "+3SD Height";

                    Series series5 = Chart2.Series.FindByName("Series5");
                    series5 = new Series("Series5");
                    series5.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series5);
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
                    Series series1 = Chart2.Series.FindByName("Series1");
                    Chart2.Series["Series1"].Points.Clear();


                    foreach (var entry in medianHeightMale.OrderBy(x => x.Key))
                    {
                        series1.Points.AddXY(entry.Key, entry.Value);

                    }
                    series1.Points.Last().Label = medianHeightMale.Last().Value.ToString("median");
                    series1.ChartType = SeriesChartType.Line;
                    series1.LegendText = "Median Height";


                    Series series2 = Chart2.Series.FindByName("Series2");

                    series2 = new Series("Series2");
                    series2.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series2);

                    series2.Points.Clear();


                    foreach (var entry in minus2SDHeightMale.OrderBy(x => x.Key))
                    {
                        series2.Points.AddXY(entry.Key, entry.Value);
                    }
                    series2.Points.Last().Label = minus2SDHeightMale.Last().Value.ToString("-2 SD");
                    series2.ChartType = SeriesChartType.Line; // Display only data points
                    series2.Color = Color.Red;
                    series2.LegendText = "-2SD Height";

                    Series series3 = Chart2.Series.FindByName("Series3");
                    series3 = new Series("Series3");
                    series3.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series3);

                    series3.Points.Clear();

                    foreach (var entry in plus2SDHeightMale.OrderBy(x => x.Key))
                    {
                        series3.Points.AddXY(entry.Key, entry.Value);
                    }
                    series3.Points.Last().Label = plus2SDHeightMale.Last().Value.ToString("2 SD");
                    series3.ChartType = SeriesChartType.Line; // Display only data points
                    series3.Color = Color.Red;
                    series3.LegendText = "+2SD Height";


                    Series series4 = Chart2.Series.FindByName("Series4");
                    series4 = new Series("Series4");
                    series4.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series4);

                    series4.Points.Clear();

                    foreach (var entry in plus3SDHeightMale.OrderBy(x => x.Key))
                    {
                        series4.Points.AddXY(entry.Key, entry.Value);
                    }
                    series4.Points.Last().Label = plus3SDHeightMale.Last().Value.ToString("3 SD");
                    series4.ChartType = SeriesChartType.Line;
                    series4.Color = Color.Black;
                    series4.LegendText = "+3SD Height";

                    Series series5 = Chart2.Series.FindByName("Series5");
                    series5 = new Series("Series5");
                    series5.ChartType = SeriesChartType.Line;
                    Chart2.Series.Add(series5);
                    series5.Points.Clear();
                    foreach (var entry in minus3SDHeightMale.OrderBy(x => x.Key))
                    {
                        series5.Points.AddXY(entry.Key, entry.Value);
                    }

                    series5.Points.Last().Label = minus3SDHeightMale.Last().Value.ToString("-3 SD");
                    series5.ChartType = SeriesChartType.Line;
                    series5.Color = Color.Black;
                    series5.LegendText = "-3SD Height";
                }

                Series seriesChild = new Series("ChildData");
                seriesChild.ChartType = SeriesChartType.Point;
                seriesChild.MarkerStyle = MarkerStyle.Circle;
                seriesChild.MarkerColor = Color.Blue;
                seriesChild.MarkerSize = 5;
                Chart1.Series.Add(seriesChild);

                // Add child data point
                seriesChild.Points.AddXY(anak.umur, Convert.ToDouble(anak.beratBadan));
                seriesChild.Points[0].Label = $"{anak.namaAnak}'s Weight"; // Optional label for the data point

                Series seriesChildBerat = new Series("ChildData");
                seriesChildBerat.ChartType = SeriesChartType.Point;
                seriesChildBerat.MarkerStyle = MarkerStyle.Circle;
                seriesChildBerat.MarkerColor = Color.Blue;
                seriesChildBerat.MarkerSize = 10;
                Chart2.Series.Add(seriesChildBerat);

                // Add child data point
                seriesChildBerat.Points.AddXY(anak.umur, Convert.ToDouble(anak.tinggiBadan));
                seriesChildBerat.Points[0].Label = $"{anak.namaAnak}'s Height"; // Optional label for the data point
            }
        


    }
        }
    }
