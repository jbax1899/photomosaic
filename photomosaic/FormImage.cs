using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace photomosaic
{
    public partial class FormImage : Form
    {
        static class Images
        {
            public static Bitmap[] bitmaps;
            public static PictureBox[] pictureboxes;
            public static int tileW, tileH, gridLength;
            public static double scale = 1;
            public static bool saved = false;
            public static void UpdatePictureboxes(Form form, GroupBox groupBox)
            {
                scale = Math.Min((double)form.Width / groupBox.Width, (double)form.Height / groupBox.Height);
                groupBox.Width = (int)Math.Round(Images.scale * groupBox.Width);
                groupBox.Height = (int)Math.Round(Images.scale * groupBox.Height);
                tileW = (int)Math.Round((double)groupBox.Width / gridLength);
                tileH = (int)Math.Round((double)groupBox.Height / gridLength);
                int counterX = 0, counterY = 0;
                for (int i = 0; i < bitmaps.Length; i++)
                {
                    pictureboxes[i].Size = new Size(tileW, tileH);
                    pictureboxes[i].Location = new Point(tileW * counterX, tileH * counterY);
                    //picturebox snaking logic
                    if (counterX + 1 == Math.Sqrt(bitmaps.Length))
                    {
                        counterX = 0;
                        counterY++;
                    }
                    else
                    {
                        counterX++;
                    }
                }
            }
        }
        public FormImage(Bitmap[] inputBitmaps, string parameters)
        {
            //Initialize
            InitializeComponent();

            if (inputBitmaps == null)
            {
                this.Close();
            }

            Images.bitmaps = inputBitmaps;
            Images.gridLength = (int)Math.Sqrt(inputBitmaps.Length);
            this.Text +=    " (" + Images.bitmaps[0].Width.ToString() + "x" + Images.bitmaps[0].Height.ToString() +
                            ")(x" + Images.bitmaps.Length + ")" +
                            parameters;

            //create as many pictureboxes as we need
            Images.pictureboxes = new PictureBox[inputBitmaps.Length];
            for (int i = 0; i < inputBitmaps.Length; i++)
            {
                Images.pictureboxes[i] = new PictureBox
                {
                    Name = "pictureBox" + i.ToString(),
                    Image = inputBitmaps[i],
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle
                };
                groupBox1.Controls.Add(FormImage.Images.pictureboxes[i]);
            }
            //re-draw screen
            groupBox1.Width = (int)Math.Round((double)Images.bitmaps[0].Width / Images.gridLength);
            groupBox1.Height = (int)Math.Round((double)Images.bitmaps[0].Height / Images.gridLength);
            this.Width = 800;
            this.Height = 600;
            Images.UpdatePictureboxes(this, groupBox1);
        }
        private void toolStripButton_save_Click(object sender, EventArgs e)
        {
            if (Images.bitmaps != null)
            {
                SaveBitmaps(Images.bitmaps);
                Images.saved = true;
            }
        }
        private void FormImage_ResizeEnd(Object sender, EventArgs e)
        {
            Images.UpdatePictureboxes(this, groupBox1);
        }
        private void FormImage_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Images.saved == false)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("You have not saved your image(s). Close anyway?", "Image Mosaic",
                   MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file... 
                }
            }
            //clear bitmap from memory
            if (Images.bitmaps != null)
            {
                foreach (var bitmap in Images.bitmaps)
                {
                    bitmap.Dispose();
                }
            }
        }
        public static string SaveBitmaps(Bitmap[] bitmaps = null, Bitmap bitmap = null, int counter = -1, string path = "", long quality = 90)
        {
            //bitmap[] in:          save dialogue
            //null, "new" in:       get path and return
            //bitmap[], path in:    save bitmaps to path
            //bitmap, path in:      save bitmap to path

            string outputPath = "";
            System.Drawing.Imaging.ImageFormat imgform = System.Drawing.Imaging.ImageFormat.Jpeg;   //default

            if (bitmap != null)
                bitmaps = new Bitmap[] { bitmap };

            if (path == "" || path == "new")
            {
                //if no path is given, open save dialogue to get one
                //if "new" is given, open save dialgue to get a path to return
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png|Tiff Image|*.tiff";
                saveFileDialog1.Title = "Save an Image File(s)";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // If the file name is not an empty string open it for saving
                    if (saveFileDialog1.FileName != "")
                    {
                        System.IO.FileStream fs =
                            (System.IO.FileStream)saveFileDialog1.OpenFile();
                        switch (saveFileDialog1.FilterIndex)
                        {
                            case 1:
                                imgform = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case 2:
                                imgform = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case 3:
                                imgform = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                            case 4:
                                imgform = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            case 5:
                                imgform = System.Drawing.Imaging.ImageFormat.Tiff;
                                break;
                            default:
                                break;
                        }
                        outputPath = fs.Name;
                        fs.Close();
                        File.Delete(outputPath);
                    }
                }
            }
            else
            {
                outputPath = path;
            }
            if (path == "new")
            {
                //return filepath
                return outputPath;
            }
            else
            {
                //array of bitmaps
                string pathNew;
                if (counter == -1)
                {
                    for (int i = 0; i < bitmaps.Length; i++)
                    {
                        //add counter between filename and extension
                        if (bitmaps.Length == 1)
                            pathNew = outputPath.Remove(outputPath.Length - imgform.ToString().Length) + "." + imgform.ToString().ToLower();
                        else
                            pathNew = outputPath.Remove(outputPath.Length - imgform.ToString().Length) + "_" + i.ToString() + "." + imgform.ToString().ToLower();
                        SaveImage(bitmaps[i], pathNew, imgform, quality);
                    }
                }
                //single bitmap+counter (instead of array)
                else
                {
                    pathNew = outputPath.Remove(outputPath.Length - imgform.ToString().Length) + "_" + counter.ToString() + "." + imgform.ToString().ToLower();
                    SaveImage(bitmaps[0], pathNew, imgform, quality);
                }
                
                //we don't need to return a filepath
                return null;
            }
        }
        public static void SaveImage(Bitmap Image, string path, System.Drawing.Imaging.ImageFormat imgform, long quality = 100)
        {
            if (imgform == System.Drawing.Imaging.ImageFormat.Jpeg)
            {
                //From: https://stackoverflow.com/a/39493346
                using (EncoderParameters encoderParameters = new EncoderParameters(1))
                using (EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, quality))
                {
                    ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                    encoderParameters.Param[0] = encoderParameter;
                    Image.Save(path, codecInfo, encoderParameters);
                }
            }
            else if (imgform == System.Drawing.Imaging.ImageFormat.Tiff)
            {
                //From: https://stackoverflow.com/a/39493346
                using (EncoderParameters encoderParameters = new EncoderParameters(1))
                using (EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, (long)EncoderValue.CompressionLZW))
                {
                    ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Tiff.Guid);
                    encoderParameters.Param[0] = encoderParameter;
                    Image.Save(path, codecInfo, encoderParameters);
                }
            }
            else
            {
                Image.Save(path, imgform);
            }
        }
    }
}