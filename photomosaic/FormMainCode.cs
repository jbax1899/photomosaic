using Hjg.Pngcs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace photomosaic
{
    public class FormMainCode
    {
        static class Global
        {
            public static string src, dir;
            public static int algorithm, matchingRule, variance, split, processors, tileAccuracy;
            public static double xscale, yscale;
            public static float xtilescale, ytilescale;
            public static double[,][] tempDistances;
        }
        public struct rgbColor
        {
            public byte r, g, b;
            public rgbColor(byte rIn, byte gIn, byte bIn)
            {
                r = rIn;
                g = gIn;
                b = bIn;
            }
            public rgbColor(Color colorIn)
            {
                r = colorIn.R;
                g = colorIn.G;
                b = colorIn.B;
            }
            public byte[] Get()
            {
                return new byte[] { r, g, b };
            }
            public Color GetColor()
            {
                return Color.FromArgb(r, g, b);
            }
        }
        static class Src
        {
            public static Bitmap bitmap_, bitmap;
            //public static Color[,] bitmapColors;
            public static rgbColor[][] bitmapColors;
        }
        public static class Dir
        {
            public static String[] dirFiles;
            public static Bitmap[] bitmaps;
            public static Bitmap[][] bitmapParts;
            public static double[][][] averageColorsRectangles;

        }
        public static Bitmap[] Generate(
            string src, string dir,
            int algorithm, int matchingRule, int variance, int split,
            double xscale, double yscale, float xtilescale, float ytilescale,
            int processors,
            int tileAccuracy,
            string downloadPath = ""
            )
        {

            //set Globals
            Global.src = src;
            Global.dir = dir;
            Global.algorithm = algorithm;
            Global.matchingRule = matchingRule;
            Global.variance = variance;
            Global.split = split;
            Global.xscale = xscale;
            Global.yscale = yscale;
            Global.xtilescale = xtilescale;
            Global.ytilescale = ytilescale;
            Global.processors = processors;
            Global.tileAccuracy = tileAccuracy;

            //load src
            int w, h;
            try
            {
                Src.bitmap_ = ConvertToBitmap(src);
                Src.bitmap = new Bitmap(Src.bitmap_,
                    new System.Drawing.Size(
                        Convert.ToInt32(Src.bitmap_.Width * xscale),
                        Convert.ToInt32(Src.bitmap_.Height * yscale)
                        ));
                w = Src.bitmap.Width;
                h = Src.bitmap.Height;

                //get colors from src
                Src.bitmapColors = new rgbColor[w][];
                for (int x = 0; x < w; x++)
                {
                    Src.bitmapColors[x] = new rgbColor[h];
                    for (int y = 0; y < h; y++)
                    {
                        if (matchingRule == 0)
                        {
                            Src.bitmapColors[x][y] = new rgbColor(Src.bitmap.GetPixel(x, y));
                        }
                        else
                        {
                            Src.bitmapColors[x][y] = new rgbColor(Color.FromArgb(
                                (int)Math.Truncate((decimal)Src.bitmap.GetPixel(x, y).R / Global.variance),
                                (int)Math.Truncate((decimal)Src.bitmap.GetPixel(x, y).G / Global.variance),
                                (int)Math.Truncate((decimal)Src.bitmap.GetPixel(x, y).B / Global.variance)
                                ));
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.ToString());
                return new Bitmap[0];
            }

            //load dir
            int gcd = 1, tilex, tiley;
            String[] filters = { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            Dir.dirFiles = GetFilesFrom(dir, filters, false);
            Dir.bitmaps = new Bitmap[Dir.dirFiles.Length];
            Dir.bitmaps[0] = ConvertToBitmap(Dir.dirFiles[0], xtilescale, ytilescale);
            Dir.bitmapParts = new Bitmap[Dir.bitmaps.Length][];
            tilex = Dir.bitmaps[0].Width;
            tiley = Dir.bitmaps[0].Height;
            gcd = GCD(tilex, tiley);
            Dir.averageColorsRectangles = new double[Dir.bitmapParts.Length][][];
            //
            //MULTITHREAD START
            //
            List<Thread> dir_threads = new List<Thread>();
            for (int i = 0; i < processors; i++)
            {
                int from    = i * (Dir.dirFiles.Length / processors);
                int to      = from + (Dir.dirFiles.Length / processors);
                if (i == processors - 1)
                    to = Dir.dirFiles.Length;
                dir_threads.Add(new Thread(() =>
                {
                    LoadDir(from, to, tilex, tiley, gcd);
                }));
                dir_threads[i].Start();
            }
            //wait for threads to finish
            foreach (var thread in dir_threads)
            {
                thread.Join();
            }
            //
            //MULTITHREAD END
            //
            
            //Build grid
            int comparex = tilex / gcd;
            int comparey = tiley / gcd;
            int gridw, gridh;

            if (w % comparex == 0) //if tiles do not fit cleanly, cut off extra
                gridw = w / comparex;
            else
                gridw = (w / comparex) - comparex;

            if (h % comparey == 0)
                gridh = h / comparey;
            else
                gridh = (h / comparey) - comparey;

            //get rgb or labs of src
            try
            {
                Global.tempDistances = new double[gridw * comparex, gridh * comparey][];
            }
            catch (ArithmeticException e)
            {
                MessageBox.Show(e.ToString());
            }
            for (int x = 0; x < gridw * comparex; x++)
            {
                for (int y = 0; y < gridh * comparey; y++)
                {
                    if (Global.algorithm == 0)
                    {
                        Global.tempDistances[x, y] = new double[] {
                            Src.bitmapColors[x][y].r,
                            Src.bitmapColors[x][y].g,
                            Src.bitmapColors[x][y].b
                        };
                    }
                    else
                    {
                        Global.tempDistances[x, y] = rgb2lab(new int[] {
                            Src.bitmapColors[x][y].r,
                            Src.bitmapColors[x][y].g,
                            Src.bitmapColors[x][y].b
                        });
                    }
                }
            }

            //
            //Multithread start
            //
            //compare colors
            //
            List<int[,]> grids = new List<int[,]>();
            int gridPart = gridw / processors;
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < processors; i++)
            {
                grids.Add(new int[gridPart, gridh]);
                int _i = i;
                int _startx = i * gridPart;
                int _endx = (i + 1) * gridPart;
                int _gridh = gridh;
                int _comparex = comparex;
                int _comparey = comparey;
                int _algorithm = algorithm;
                double[][][] _averageColorsRectangles = Dir.averageColorsRectangles;
                int _bitmapsCount = Dir.bitmaps.Length;
                double[,][] _tempDistances = Global.tempDistances;
                int _processors = processors;
                threads.Add(new Thread(() =>
                {
                    grids[_i] = ComputeGrid(_startx, _endx, _gridh, _comparex, _comparey, _algorithm, _averageColorsRectangles, _bitmapsCount, _tempDistances,  _processors);
                }));
                threads[i].Start();
            }
            
            //wait for threads to finish
            foreach (var thread in threads)
            {
                thread.Join();
            }

            //merge grid parts
            int[,] dirGrid = new int[gridw, gridh];
            for (int i = 0; i < processors; i++)
            {
                for (int x = 0; x < gridPart; x++)
                {
                    for (int y = 0; y < gridh; y++)
                    {
                        dirGrid[x + (gridPart * i), y] = grids[i][x, y];
                    }
                }
            }
            //
            //Multithread end
            //

            //store tile counts
            List<int[]> tileCounts = new List<int[]>();
            for (int i = 0; i < Dir.bitmaps.Length; i++)
            {
                tileCounts.Add(new int[1]);
            }
            foreach (var num in dirGrid)
            {
                tileCounts[num][0]++;
            }
            using (StreamWriter outputFile = new StreamWriter("tileCounts.csv"))
            {
                //write to file
                for (int i = 0; i < tileCounts.Count; i++)
                {
                    outputFile.WriteLine(i.ToString() + "," + tileCounts[i][0].ToString());
                }
            }
            tileCounts.Clear();

            //
            //Write images to file
            //
            if (split == 0)
            {
                int tileW = Dir.bitmaps[0].Width;
                int tileH = Dir.bitmaps[0].Height;
                int outW = dirGrid.GetLength(0);
                int outH = dirGrid.GetLength(1);
                Bitmap[] outputBitmaps = new Bitmap[1];
                outputBitmaps[0] = new Bitmap(outW * tileW, outH * tileH);
                Rectangle rectCopyTo = new Rectangle(0, 0, tileW, tileH);
                for (int x = 0; x < outW; x++)
                {
                    for (int y = 0; y < outH; y++)
                    {
                        Rectangle rectCopyFrom = new Rectangle(x * tileW, y * tileH, tileW, tileH);
                        using (Graphics grD = Graphics.FromImage(outputBitmaps[0]))
                        {
                            grD.DrawImage(Dir.bitmaps[dirGrid[x, y]], rectCopyFrom, rectCopyTo, GraphicsUnit.Pixel);
                        }
                    }
                }

                if (downloadPath != "")
                {
                    FormImage.SaveBitmaps(outputBitmaps, null, -1, downloadPath);
                    MessageBox.Show("Images saved!");
                    return null;
                }
                else
                    return outputBitmaps;
            }
            else
            {
                int tileW = Dir.bitmaps[0].Width;
                int tileH = Dir.bitmaps[0].Height;
                int outW = dirGrid.GetLength(0) / split;
                int outH = dirGrid.GetLength(1) / split;

                Bitmap[] outputBitmaps = new Bitmap[split * split];

                int counter = 0;
                for (int partY = 0; partY < split; partY++)
                {
                    for (int partX = 0; partX < split; partX++)
                    {
                        Bitmap outputBitmap = new Bitmap(outW * tileW, outH * tileH);
                        Rectangle inputRect = new Rectangle(0, 0, tileW, tileH);
                        for (int x = (partX * outW); x < (outW + (partX * outW)); x++)
                        {
                            for (int y = (partY * outH); y < (outH + (partY * outH)); y++)
                            {
                                Rectangle outputRect = new Rectangle(
                                    (x - (partX * outW)) * tileW,
                                    (y - (partY * outH)) * tileH,
                                    tileW,
                                    tileH);
                                using (Graphics grD = Graphics.FromImage(outputBitmap))
                                {
                                    grD.DrawImage(Dir.bitmaps[dirGrid[x, y]], outputRect, inputRect, GraphicsUnit.Pixel);
                                }
                            }
                        }
                        if (downloadPath == "") 
                        {
                            outputBitmaps[counter] = outputBitmap;
                        }
                        else
                        {
                            FormImage.SaveBitmaps(null, outputBitmap, counter, downloadPath);
                        }
                        counter++;
                        outputBitmap.Dispose();
                    }
                }

                MessageBox.Show("Images saved!");
                if (downloadPath == "")
                    return outputBitmaps;
                else
                {
                    foreach (Bitmap bitmap in outputBitmaps)
                        bitmap.Dispose();
                    return null;
                }
            }
        }
        public static Bitmap ConvertToBitmap(string fileName, float xscale = 1, float yscale = 1)
        {
            //https://stackoverflow.com/questions/24383256/how-can-i-convert-a-jpg-file-into-a-bitmap-using-c
            Bitmap bitmap = null;
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
                    {
                        Image image = Image.FromStream(bmpStream);
                        bitmap = new Bitmap(image, new Size(Convert.ToInt32(image.Width * xscale), Convert.ToInt32(image.Height * yscale)));
                        bmpStream.Close();
                        bmpStream.Dispose();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error - " + ex);
            }
            return bitmap;
        }
        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            //https://stackoverflow.com/a/18321162
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                try
                {
                    filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
                }
                catch (DirectoryNotFoundException e)
                {
                    MessageBox.Show("Directory not found!\n" + e.ToString());
                    break;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.ToString());
                    break;
                }
            }
            return filesFound.ToArray();
        }
        public static double[] averageColor(Bitmap bi)
        {
            double sumA = 0, sumB = 0, sumC = 0, count = 0;
            int skip = Global.tileAccuracy;

            //If skip == 0 iterate through one pixel
            //If skip > 0 and within bounds of the bitmap, iterate += skip
            //If skip > 0 and would step outside of the bitmap, iterate += the pixels within bounds
            for (int x = 0; x < bi.Width; x += Math.Max(1, Math.Min(skip, bi.Width - (x + skip))))
            {
                for (int y = 0; y < bi.Height; y += Math.Max(1, Math.Min(skip, bi.Height - (y + skip))))
                {
                    count++;
                    Color pixel = bi.GetPixel(x, y);
                    double[] tempAvg;
                    if (Global.matchingRule == 1)
                    {
                        if (Global.algorithm == 0)
                        {
                            tempAvg = new double[]
                            {
                                (double)Math.Truncate((decimal)pixel.R / Global.variance),
                                (double)Math.Truncate((decimal)pixel.G / Global.variance),
                                (double)Math.Truncate((decimal)pixel.B / Global.variance)
                            };
                        }
                        else
                        {
                            tempAvg = rgb2lab(new int[]
                            {
                                (int)Math.Truncate((decimal)pixel.R / Global.variance),
                                (int)Math.Truncate((decimal)pixel.G / Global.variance),
                                (int)Math.Truncate((decimal)pixel.B / Global.variance)
                            });
                        }
                    }
                    else
                    {
                        if (Global.algorithm == 0)
                            tempAvg = new double[] { pixel.R, pixel.G, pixel.B };
                        else
                            tempAvg = rgb2lab(new int[] { pixel.R, pixel.G, pixel.B });
                    }
                    sumA += tempAvg[0];
                    sumB += tempAvg[1];
                    sumC += tempAvg[2];
                }
            }
            return new double[] { sumA / count, sumB / count, sumC / count };
        }
        public static double[] rgb2lab(int[] rgb)
        {
            //http://www.brucelindbloom.com/index.html?Math.html

            double r = (double)rgb[0] / 255,
                   g = (double)rgb[1] / 255,
                   b = (double)rgb[2] / 255,
                   k = (double)24389 / 27,
                   e = (double)216 / 24389,
                   x, y, z,
                   l_, a_, b_;

            //RGB -> XYZ
            r = (r > 0.04045) ? Math.Pow((r + 0.055) / 1.055, 2.4) : r / 12.92;
            g = (g > 0.04045) ? Math.Pow((g + 0.055) / 1.055, 2.4) : g / 12.92;
            b = (b > 0.04045) ? Math.Pow((b + 0.055) / 1.055, 2.4) : b / 12.92;

            r *= 100;
            g *= 100;
            b *= 100;

            x = r * 0.4124 + g * 0.3576 + b * 0.1805;
            y = r * 0.2126 + g * 0.7152 + b * 0.0722;
            z = r * 0.0193 + g * 0.1192 + b * 0.9505;
            //old
            //x = (r * 0.4124 + g * 0.3576 + b * 0.1805) / 0.95047;
            //y = (r * 0.2126 + g * 0.7152 + b * 0.0722) / 1.00000;
            //z = (r * 0.0193 + g * 0.1192 + b * 0.9505) / 1.08883;

            //XYZ -> LAB
            x = x / 100;
            y = y / 100;
            z = z / 100;

            x = (x > e) ? Math.Pow(x, (double)1 / 3) : (k * x + 16) / 116;
            y = (y > e) ? Math.Pow(y, (double)1 / 3) : (k * y + 16) / 116;
            z = (z > e) ? Math.Pow(z, (double)1 / 3) : (k * z + 16) / 116;

            l_ = (116 * y) - 16;
            a_ = 500 * (x - y);
            b_ = 200 * (y - z);
            double[] output = { l_, a_, b_ };

            return output;
        }
        public static double rgbDistance(double[] rgb0, double[] rgb1)
        {
            //regular euclidean distance
            double distance = Math.Sqrt(
                                    (rgb1[0] - rgb0[0]) * (rgb1[0] - rgb0[0]) +
                                    (rgb1[1] - rgb0[1]) * (rgb1[1] - rgb0[1]) +
                                    (rgb1[2] - rgb0[2]) * (rgb1[2] - rgb0[2]));
            return distance;
        }
        public static double deltaE_cie76(double[] labA, double[] labB)
        {
            return Math.Sqrt(
                        (labA[0] - labB[0]) * (labA[0] - labB[0]) + 
                        (labA[1] - labB[1]) * (labA[1] - labB[1]) + 
                        (labA[2] - labB[2]) * (labA[2] - labB[2]));
        }
        public static double deltaE_cie94(double[] labA, double[] labB)
        {
            double deltaL = labA[0] - labB[0];
            double deltaA = labA[1] - labB[1];
            double deltaB = labA[2] - labB[2];
            double c1 = Math.Sqrt(labA[1] * labA[1] + labA[2] * labA[2]);
            double c2 = Math.Sqrt(labB[1] * labB[1] + labB[2] * labB[2]);
            double deltaC = c1 - c2;
            double deltaH = ((deltaA * deltaA) + (deltaB * deltaB) - (deltaC * deltaC));
            deltaH = deltaH < 0 ? 0 : Math.Sqrt(deltaH);
            double deltaLKlsl = deltaL / (1.0);
            double deltaCkcsc = deltaC / (1.0 + 0.045 * c1);
            double deltaHkhsh = deltaH / (1.0 + 0.015 * c1);
            double i = (deltaLKlsl * deltaLKlsl) + (deltaCkcsc * deltaCkcsc) + (deltaHkhsh * deltaHkhsh);
            return i < 0 ? 0 : Math.Sqrt(i);
        }
        public static double deltaE_cie00(double[] labA, double[] labB)
        {
            //https://www.easyrgb.com/en/math.php
            double CIE_L_1 = labA[0];
            double CIE_A_1 = labA[1];
            double CIE_b_1 = labA[2];          
            double CIE_L_2 = labB[0];
            double CIE_A_2 = labB[1];
            double CIE_b_2 = labB[2];

            //L*ab->L*CH
            //double var_H = Math.Atan2(CIE_b_1, CIE_A_1);  //Quadrant by signs
            //if (var_H > 0) var_H = (var_H / Math.PI) * 180;
            //else var_H = 360 - (Math.Abs(var_H) / Math.PI) * 180;
            //double WHT_L = CIE_L_1;
            //double WHT_C = Math.Sqrt(Math.Pow(CIE_A_1, 2) + Math.Pow(CIE_b_1, 2));
            //double WHT_H = var_H;
            double WHT_L = 100;
            double WHT_C = 100;
            double WHT_H = 100;

            double xC1 = Math.Sqrt(CIE_A_1 * CIE_A_1 + CIE_b_1 * CIE_b_1);
            double xC2 = Math.Sqrt(CIE_A_2 * CIE_A_2 + CIE_b_2 * CIE_b_2);
            double xCX = (xC1 + xC2) / 2;
            double xGX = 0.5 * (1 - Math.Sqrt((Math.Pow(xCX, 7)) / ((Math.Pow(xCX, 7)) + (25 ^ 7))));
            double xNN = (1 + xGX) * CIE_A_1;
            xC1 = Math.Sqrt(xNN * xNN + CIE_b_1 * CIE_b_1);
            double xH1 = CieLab2Hue(xNN, CIE_b_1);
            xNN = (1 + xGX) * CIE_A_2;
            xC2 = Math.Sqrt(xNN * xNN + CIE_b_2 * CIE_b_2);
            double xH2 = CieLab2Hue(xNN, CIE_b_2);
            double xDL = CIE_L_2 - CIE_L_1;
            double xDC = xC2 - xC1;
            double xDH;
            if ((xC1 * xC2) == 0)
            {
                xDH = 0;
            }
            else
            {
                xNN = Math.Round(xH2 - xH1, 12);
                if (Math.Abs(xNN) <= 180)
                {
                    xDH = xH2 - xH1;
                }
                else
                {
                    if (xNN > 180) xDH = xH2 - xH1 - 360;
                    else xDH = xH2 - xH1 + 360;
                }
            }

            xDH = 2 * Math.Sqrt(xC1 * xC2) * Math.Sin((xDH / 2) * (Math.PI / 180));
            double xLX = (CIE_L_1 + CIE_L_2) / 2;
            double xCY = (xC1 + xC2) / 2;
            double xHX;
            if ((xC1 * xC2) == 0)
            {
                xHX = xH1 + xH2;
            }
            else
            {
                xNN = Math.Abs(Math.Round(xH1 - xH2, 12));
                if (xNN > 180)
                {
                    if ((xH2 + xH1) < 360) xHX = xH1 + xH2 + 360;
                    else xHX = xH1 + xH2 - 360;
                }
                else
                {
                    xHX = xH1 + xH2;
                }
                xHX /= 2;
            }
            double xTX = 1 - 0.17 * Math.Cos((xHX - 30) * (Math.PI / 180)) + 0.24
                                  * Math.Cos((2 * xHX) * (Math.PI / 180)) + 0.32
                                  * Math.Cos((3 * xHX + 6) * (Math.PI / 180)) - 0.20
                                  * Math.Cos((4 * xHX - 63) * (Math.PI / 180));
            double xPH = 30 * Math.Exp(-((xHX - 275) / 25) * ((xHX - 275) / 25));
            double xRC = 2 * Math.Sqrt(Math.Pow(xCY, 7) / (Math.Pow(xCY, 7) + (Math.Pow(25, 7))));
            double xSL = 1 + ((0.015 * ((xLX - 50) * (xLX - 50))) / Math.Sqrt(20 + ((xLX - 50) * (xLX - 50))));

            double xSC = 1 + 0.045 * xCY;
            double xSH = 1 + 0.015 * xCY * xTX;
            double xRT = -Math.Sin((2 * xPH) * (Math.PI / 180)) * xRC;
            xDL = xDL / (WHT_L * xSL);
            xDC = xDC / (WHT_C * xSC);
            xDH = xDH / (WHT_H * xSH);
            double e = Math.Sqrt(Math.Pow(xDL, 2) + Math.Pow(xDC, 2) + Math.Pow(xDH, 2) + xRT * xDC * xDH);
            
            return e;
        }
        private static double CieLab2Hue(double var_a, double var_b)
        {
           //Function returns CIE-H° value
           double var_bias = 0;
           if (var_a >= 0 && var_b == 0) return 0;
           else if (var_a < 0 && var_b == 0) return 180;
           else if (var_a == 0 && var_b > 0) return 90;
           else if (var_a == 0 && var_b < 0) return 270;
           else if (var_a > 0 && var_b > 0) var_bias = 0;
           else if (var_a < 0) var_bias = 180;
           else if (var_a > 0 && var_b < 0) var_bias = 360;
           return (Math.Atan(var_b / var_a) * (180 / Math.PI)) + var_bias;
        }
        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
        public static int[,] ComputeGrid(int startx, int endx, int gridh, int comparex, int comparey, int algorithm, double[][][] averageColorsRectangles, int bitmapsCount, double[,][] tempDistancesIn, int processors)
        {
            //grid that will be populated with the color equivalent tiles
            int gridw = endx - startx;
            int[,] dirGrid = new int[gridw, gridh];
            //loop through each tile part X of src...
            for (int x = startx; x < endx; x++)
            {
                //report
                if (processors == 1)
                {
                    int prog;
                    try { prog = Convert.ToInt32((double)x * gridh / (gridw * gridh) * 100); }
                    catch (DivideByZeroException) { prog = 0; }
                } 

                //loop through each tile part Y of src...
                for (int y = 0; y < gridh; y++)
                {
                    double[,][] tempDistances = new double[comparex, comparey][];
                    double[] closestVals = new double[comparex * comparey];
                    int counter = -1;
                    for (int ix = 0; ix < comparex; ix++)
                    {
                        for (int iy = 0; iy < comparey; iy++)
                        {
                            counter++;
                            tempDistances[ix, iy] = new double[bitmapsCount]; //...find the lab distances between bitmappart[x] and srctile[x]
                            //loop through dir tiles..
                            for (int ib = 0; ib < bitmapsCount; ib++)
                            {
                                if (algorithm == 0) //how similar is this pixel's color to tile[im]?
                                    tempDistances[ix, iy][ib] = rgbDistance(averageColorsRectangles[ib][counter], tempDistancesIn[(x * comparex) + ix, (y * comparey) + iy]);
                                else if (algorithm == 1)
                                    tempDistances[ix, iy][ib] = deltaE_cie76(averageColorsRectangles[ib][counter], tempDistancesIn[(x * comparex) + ix, (y * comparey) + iy]);
                                else if (algorithm == 2)
                                    tempDistances[ix, iy][ib] = deltaE_cie94(averageColorsRectangles[ib][counter], tempDistancesIn[(x * comparex) + ix, (y * comparey) + iy]);
                                else //if (algorithm == 3)
                                    tempDistances[ix, iy][ib] = deltaE_cie00(averageColorsRectangles[ib][counter], tempDistancesIn[(x * comparex) + ix, (y * comparey) + iy]);
                            }
                            double closestVal = -1;
                            int closestValID = 0;
                            for (int ib = 0; ib < bitmapsCount; ib++)
                            {
                                if (tempDistances[ix, iy][ib] < closestVal | closestVal == -1)
                                {
                                    closestVal = tempDistances[ix, iy][ib];
                                    closestValID = ib;
                                }
                            }
                            closestVals[counter] = closestValID;
                        }
                    }

                    //find mode of our list of closest tiles vs. pixels - that is the tile we will use
                    var groups = closestVals.GroupBy(v => v);
                    int maxCount = groups.Max(g => g.Count());
                    double mode = groups.First(g => g.Count() == maxCount).Key;
                    dirGrid[x - startx, y] = (int)mode;
                }
            }
            return dirGrid;
        }
        public static void LoadDir(int from, int to, int tilex, int tiley, int gcd)
        {
            int length = (tilex / gcd) * (tiley / gcd);
            for (int file = from; file < to; file++)
            {
                Dir.bitmaps[file] = ConvertToBitmap(Dir.dirFiles[file], Global.xtilescale, Global.ytilescale);
                Dir.bitmapParts[file] = new Bitmap[tilex / gcd * tiley / gcd];
                int count = 0;
                for (int ix = 0; ix < (tilex / gcd); ix++)         //splitx,
                {
                    for (int iy = 0; iy < (tiley / gcd); iy++)      //splity,
                    {
                        Bitmap bm = new Bitmap(gcd, gcd);
                        using (Graphics gr = Graphics.FromImage(bm))
                        {
                            //public Rectangle (int x, int y, int width, int height);
                            Rectangle dest_rect = new Rectangle(0, 0, gcd, gcd);
                            Rectangle source_rect = new Rectangle(ix * gcd, iy * gcd, gcd, gcd);
                            //Draws the specified portion of the specified Image at the specified location and with the specified size.
                            gr.DrawImage(Dir.bitmaps[file], dest_rect, source_rect, GraphicsUnit.Pixel);
                            gr.Dispose();
                        }
                        Dir.bitmapParts[file][count] = bm;
                        count++;
                    }
                }
                //get average colors from dir
                Dir.averageColorsRectangles[file] = new double[length][];
                for (int i = 0; i < Dir.averageColorsRectangles[file].Length; i++)
                {
                    Dir.averageColorsRectangles[file][i] = averageColor(Dir.bitmapParts[file][i]);
                    Dir.bitmapParts[file][i].Dispose();
                }
            }
        }
    }
}