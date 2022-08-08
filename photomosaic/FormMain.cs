using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photomosaic
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            textBox_x.Text = "1.0";
            textBox_y.Text = "1.0";
            textBox_newx.Text = "1.0";
            textBox_newy.Text = "1.0";
            textBox_xmult.Text = "1.0";
            textBox_ymult.Text = "1.0";
            textBox_xtile.Text = "1.0";
            textBox_ytile.Text = "1.0";
            textBox_xtilemult.Text = "1.0";
            textBox_ytilemult.Text = "1.0";
            textBox_newxtile.Text = "1.0";
            textBox_newytile.Text = "1.0";
            textBox_xfinal.Text = "1.0";
            textBox_yfinal.Text = "1.0";
            radioButton_rgbEuclidean.Checked = true;
            radioButton_mostSimilar.Checked = true;
            comboBox_split.SelectedIndex = 0;
            numericUpDown_processors.Minimum = 1;
            numericUpDown_processors.Maximum = Environment.ProcessorCount;
        }
        private void srcChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox_inputImage.Text))
            {
                int width, height;
                using (Stream stream = File.OpenRead(textBox_inputImage.Text))
                {
                    using (Image img = Image.FromStream(stream, false, false))
                    {
                        width = img.Width;
                        height = img.Height;
                        label_input_dimensions.Text = (width + " x " + height);
                        textBox_x.Text = width.ToString();
                        textBox_y.Text = height.ToString();
                    }
                }
                pictureBox_img.Image = new Bitmap(
                    FormMainCode.ConvertToBitmap(textBox_inputImage.Text),
                    new Size(
                        Math.Max(width, 200),
                        Math.Max(height, 200)));
                textBox_xmult_TextChanged(sender, e);
                textBox_ymult_TextChanged(sender, e);
                textBox_tilexmult_TextChanged(sender, e);
                textBox_tileymult_TextChanged(sender, e);
                if (pictureBox_dir != null)
                    button_generate.Enabled = true;
            }
        }
        private void dirChanged(object sender, EventArgs e)
        {
            //pull images
            List<Bitmap> dirBitmaps = new List<Bitmap>();
            Bitmap tempBitmapFindScale;
            String[] filters = { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            String[] dirFiles = FormMainCode.GetFilesFrom(textBox_inputTiles.Text, filters, false);
            if (dirFiles.Length > 0)
            {
                bool loaded = false;
                int max = 256;
                tempBitmapFindScale = new Bitmap(FormMainCode.ConvertToBitmap(dirFiles[0]));
                int gridW = (int)Math.Sqrt(max);
                float scale = Math.Min((float)gridW / tempBitmapFindScale.Width, (float)gridW / tempBitmapFindScale.Height);
                for (int i = 0; i < dirFiles.Length; i++)
                {
                    if (i == 0)
                        dirBitmaps.Add(FormMainCode.ConvertToBitmap(dirFiles[i], scale));
                    else if (dirBitmaps[0].Width == dirBitmaps[0].Width && dirBitmaps[0].Height == dirBitmaps[0].Height)
                    {
                        if (i < max)
                            dirBitmaps.Add(FormMainCode.ConvertToBitmap(dirFiles[i], scale));
                    }
                    else
                    {
                        MessageBox.Show("Error! Input tiles do not all have the same dimensions!");
                        break;
                    }
                    if (i == dirFiles.Length - 1)
                        loaded = true;
                }

                if (loaded)
                {
                    //create collage
                    int width = Convert.ToInt32(Math.Round(Math.Ceiling(Math.Sqrt(dirBitmaps.Count))));
                    int tileWidth = dirBitmaps[0].Width;
                    int tileHeight = dirBitmaps[0].Height;
                    int finalWidth = width * tileWidth;
                    int finalHeight = width * tileHeight;

                    double widthScale = 0, heightScale = 0;
                    if (finalWidth != 0)
                        widthScale = (double)pictureBox_dir.Width / finalWidth;
                    if (finalHeight != 0)
                        heightScale = (double)pictureBox_dir.Width / finalHeight;

                    double scalingFactor = Math.Min(widthScale, heightScale);

                    int counter = 0;
                    Bitmap outputBitmap = new Bitmap(pictureBox_dir.Width, pictureBox_dir.Width);
                    Rectangle inputRect = new Rectangle(0, 0, tileWidth, tileHeight);
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < width; y++)
                        {
                            counter++;
                            if (counter < dirBitmaps.Count)
                            {
                                Rectangle outputRect = new Rectangle(
                                    (int)(x * tileWidth * scalingFactor),
                                    (int)(y * tileHeight * scalingFactor),
                                    (int)(tileWidth * scalingFactor),
                                    (int)(tileHeight * scalingFactor));
                                using (Graphics grD = Graphics.FromImage(outputBitmap))
                                {
                                    grD.DrawImage(dirBitmaps[counter], outputRect, inputRect, GraphicsUnit.Pixel);
                                }
                            }
                        }
                    }
                    //save bitmap
                    outputBitmap.Save("_tiles.png", ImageFormat.Png);
                    //set picturebox
                    pictureBox_dir.Image = null;
                    label_input_tiles_dimensions.Text = (tileWidth + " x " + tileHeight + " (" + dirFiles.Length + ")");
                    double tileScale = ((double)pictureBox_dir.Width / (width * tileWidth));    //based on window size
                    pictureBox_dir.Image = new Bitmap(outputBitmap,
                                                    new Size(
                                                        Convert.ToInt32(Math.Ceiling(outputBitmap.Width * tileScale)),
                                                        Convert.ToInt32(Math.Ceiling(outputBitmap.Height * tileScale))));
                    outputBitmap.Dispose();

                    //update
                    textBox_xtile.Text = tempBitmapFindScale.Width.ToString();
                    textBox_ytile.Text = tempBitmapFindScale.Height.ToString();
                    textBox_xmult_TextChanged(sender, e);
                    textBox_ymult_TextChanged(sender, e);
                    textBox_tilexmult_TextChanged(sender, e);
                    textBox_tileymult_TextChanged(sender, e);
                    if (pictureBox_img != null)
                        button_generate.Enabled = true;
                    dirBitmaps.Clear();
                }
                else
                {
                    pictureBox_dir.Image = null;
                    label_input_tiles_dimensions.Text = "0 x 0 (0)";
                    dirBitmaps.Clear();
                }
            }
        }
        private async void button_generate_Click(object sender, EventArgs e)
        {
            //start logging
            //Form FormLog = new FormLog();
            //FormLog.ShowDialog();

            int tileAccuracy = (int)numericUpDown_tileAccuracy.Value;

            string downloadPath = "";
            Thread t_downloadPath = new Thread((ThreadStart)(() => {
                if (!checkBox_preview.Checked)
                {
                    downloadPath = FormImage.SaveBitmaps(null, null, -1, "new");
                }
            }));
            t_downloadPath.SetApartmentState(ApartmentState.STA);
            t_downloadPath.Start();
            t_downloadPath.Join();

            /*
            string webviewerPath = "";
            Thread t_webviewerPath = new Thread((ThreadStart)(() => {
                if (checkBox_webViewer.Checked)
                {
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    DialogResult result = folderBrowserDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        webviewerPath = folderBrowserDialog1.SelectedPath;
                    }
                }
            }));
            t_webviewerPath.SetApartmentState(ApartmentState.STA);
            t_webviewerPath.Start();
            t_webviewerPath.Join();
            //DEBUG
            webviewerPath = @"C:\Users\jbax1\Pictures\1234";
            //
            */

            if (!(checkBox_preview.Checked == false && downloadPath == ""))
            {
                int processors = Convert.ToInt32(numericUpDown_processors.Value);

                int algorithm;
                if (radioButton_rgbEuclidean.Checked)
                    algorithm = 0;
                else if (radioButton_cie76.Checked)
                    algorithm = 1;
                else if (radioButton_cie94.Checked)
                    algorithm = 2;
                else if (radioButton_cie00.Checked)
                    algorithm = 3;
                else
                    algorithm = 0;

                int matchingRule;
                if (radioButton_mostSimilar.Checked)
                    matchingRule = 0;
                else if (radioButton_someVariance.Checked)
                    matchingRule = 1;
                else
                    matchingRule = 0;

                int variance = Decimal.ToInt32(numericUpDown_variance.Value);

                int split;
                if (comboBox_split.SelectedIndex > 0)
                {
                    split = comboBox_split.SelectedIndex + 1;
                }
                else
                {
                    split = 0;
                }

                //progress counter

                //xyscale, xytilescale
                double xscale = double.Parse(textBox_xmult.Text, System.Globalization.CultureInfo.InvariantCulture);
                double yscale = double.Parse(textBox_ymult.Text, System.Globalization.CultureInfo.InvariantCulture);
                float xtilescale = float.Parse(textBox_xtilemult.Text, System.Globalization.CultureInfo.InvariantCulture);
                float ytilescale = float.Parse(textBox_ytilemult.Text, System.Globalization.CultureInfo.InvariantCulture);

                //CHECKS
                //max object size is 2,147,483,648
                double area = double.Parse(textBox_xfinal.Text) * double.Parse(textBox_xfinal.Text);
                int temp_split = 1;
                if (split > 0)
                    temp_split = split;
                /*
                double limit = 2000000000;
                if (area / temp_split > limit)
                {
                    string message = "Final image area is too large! ("
                        + area.ToString() + " / " + temp_split.ToString() + " > " + limit.ToString()
                        + "). Please either reduce the final dimensions or split the image into smaller parts.";
                    MessageBox.Show(message, "ERROR - Output Too Large");
                }
                */
                //ALL GOOD
                //else
                {
                    //start timer
                    System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

                    Bitmap[] bitmaps = await Task.Run(() =>
                    FormMainCode.Generate(
                        textBox_inputImage.Text,
                        textBox_inputTiles.Text,
                        algorithm,
                        matchingRule,
                        variance,
                        split,
                        xscale,
                        yscale,
                        xtilescale,
                        ytilescale,
                        processors,
                        tileAccuracy,
                        downloadPath
                        ));

                    //end timer
                    sw.Stop();

                    //if we recieved bitmaps (preview on), show them
                    if (bitmaps != null)
                    {
                        string parameters = "algorithm=" + algorithm.ToString() + "," +
                                            "matchingRule=" + matchingRule.ToString() + "," +
                                            "variance=" + variance.ToString() + "," +
                                            "split=" + split.ToString() + "," +
                                            "xyscale=" + xscale.ToString() + "x" + yscale.ToString() + "," +
                                            "xytilescale=" + xtilescale.ToString() + "x" + ytilescale.ToString() + "," +
                                            "processors=" + processors.ToString() + "," +
                                            "tileAccuracy=" + tileAccuracy.ToString();
                        Form FormImage = new FormImage(bitmaps, parameters);
                        FormImage.Show();
                    }

                    //reset bar
                    progressBar.Value = 0;
                    label_progress.Text = (
                                        "Done!   " + sw.Elapsed.TotalSeconds.ToString("N2") + " Sec / " +
                                        ((float)sw.Elapsed.TotalSeconds / 60).ToString("N2") + " Min"
                                        );

                    //clear memory
                    FormMainCode.Dir.averageColorsRectangles = null;
                    for (int i = 0; i < FormMainCode.Dir.bitmaps.Length; i++)
                    {
                        FormMainCode.Dir.bitmaps[i].Dispose();
                    }
                    for (int i = 0; i < FormMainCode.Dir.bitmapParts.Length; i++)
                    {
                        for (int ii = 0; ii < FormMainCode.Dir.bitmapParts[i].Length; ii++)
                        {
                            FormMainCode.Dir.bitmapParts[i][ii].Dispose();
                        }
                    }
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                }
            }
        }
        private void button_demo_Click(object sender, EventArgs e)
        {
            textBox_inputImage.Text = System.IO.Directory.GetCurrentDirectory() + "\\demo\\demo.png";
            textBox_inputTiles.Text = System.IO.Directory.GetCurrentDirectory() + "\\demo\\tiles";
            textBox_xmult.Text = "0.5";
            textBox_ymult.Text = "0.5";
            srcChanged(sender, e);
            dirChanged(sender, e);
        }
        private void button_chooseInputImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Title = "Open image file",
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png",
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_inputImage.Text = openFileDialog1.FileName;
            }

            srcChanged(sender, e);
        }
        private void button_chooseInputTiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_inputTiles.Text = folderBrowserDialog1.SelectedPath;
            }

            dirChanged(sender, e);
        }
        private void textBox_xmult_TextChanged(object sender, EventArgs e)
        {
            double i = 0;
            if (double.TryParse(textBox_xmult.Text, out i))
            {
                double dx           = double.Parse(textBox_x.Text);
                double dxmult       = double.Parse(textBox_xmult.Text);
                double dxnew        = dx * dxmult;
                textBox_newx.Text   = dxnew.ToString();
            }
            if (i < 0.01)
            {
                textBox_xmult.Text = "0.01";
            }
            if (i > 100)
            {
                textBox_xmult.Text = "100.00";
            }
            calculateDimensions();
        }
        private void textBox_ymult_TextChanged(object sender, EventArgs e)
        {
            double i = 0;
            if (double.TryParse(textBox_ymult.Text, out i))
            {
                double dy           = double.Parse(textBox_y.Text);
                double dymult       = double.Parse(textBox_ymult.Text);
                double dynew        = dy * dymult;
                textBox_newy.Text   = dynew.ToString();
            }
            if (i < 0.01)
            {
                textBox_ymult.Text = "0.01";
            }
            if (i > 100)
            {
                textBox_ymult.Text = "100.00";
            }
            calculateDimensions();
        }
        private void textBox_tilexmult_TextChanged(object sender, EventArgs e)
        {
            double i = 0;
            if (double.TryParse(textBox_xtilemult.Text, out i))
            {
                double dx               = double.Parse(textBox_xtile.Text);
                double dxmult           = double.Parse(textBox_xtilemult.Text);
                double dxnew            = dx * dxmult;
                textBox_newxtile.Text   = dxnew.ToString();
            }
            if (i < 0.01)
            {
                textBox_xtilemult.Text = "0.01";
            }
            if (i > 100)
            {
                textBox_xtilemult.Text = "100.00";
            }
            calculateDimensions();
        }
        private void textBox_tileymult_TextChanged(object sender, EventArgs e)
        {
            double i = 0;
            if (double.TryParse(textBox_ytilemult.Text, out i))
            {
                double dy = double.Parse(textBox_ytile.Text);
                double dymult = double.Parse(textBox_ytilemult.Text);
                double dynew = dy * dymult;
                textBox_newytile.Text = dynew.ToString();
            }
            if (i < 0.01)
            {
                textBox_ytilemult.Text = "0.01";
            }
            if (i > 100)
            {
                textBox_ytilemult.Text = "100.00";
            }
            calculateDimensions();
        }
        private void calculateDimensions()
        {
            try
            {
                //get x
                double dx = 0, dxtile = 0, dxnew = 0;
                if (double.TryParse(textBox_newx.Text, out double dx_out)
                    && double.TryParse(textBox_newxtile.Text, out double dxtile_out))
                {
                    dx = dx_out;
                    dxtile = dxtile_out;
                }

                //get y
                double dy = 0, dytile = 0, dynew = 0;
                if (double.TryParse(textBox_newy.Text, out double newy_out)
                    && double.TryParse(textBox_newytile.Text, out double newytile_out))
                {
                    dy = newy_out;
                    dytile = newytile_out;
                }

                //change
                dxnew = dx * dxtile;
                dynew = dy * dytile;
                textBox_xfinal.Text = dxnew.ToString();
                textBox_yfinal.Text = dynew.ToString();
                //rectangle?
                int gcd = FormMainCode.GCD((int)dxtile, (int)dytile);
                double comparex = (int)dxtile / gcd;
                double comparey = (int)dytile / gcd;
                int dxtilenew = (int)(dxnew / dxtile * comparex);
                int dytilenew = (int)(dynew / dytile * comparey);
                textBox_xfinaltiles.Text = dxtilenew.ToString();
                textBox_yfinaltiles.Text = dytilenew.ToString();

                //memory needed
                const double divider = 200000;
                double memx, memy, memory = 0;
                if (double.TryParse(textBox_xfinal.Text, out memx)
                    && double.TryParse(textBox_xfinal.Text, out memy))
                {
                    memory = Math.Round(memx * memy /divider);
                }
                label_memory.Text = "Memory Needed: ~" + memory.ToString() + "mb";
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Divide by zero in calculateDimensions()\n" + e.ToString());
            }
        }
        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }
    } 
}