using System;

namespace photomosaic
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_generate = new System.Windows.Forms.Button();
            this.button_demo = new System.Windows.Forms.Button();
            this.label_input_tiles_dimensions = new System.Windows.Forms.Label();
            this.radioButton_cie76 = new System.Windows.Forms.RadioButton();
            this.radioButton_cie94 = new System.Windows.Forms.RadioButton();
            this.groupBox_cie = new System.Windows.Forms.GroupBox();
            this.radioButton_rgbEuclidean = new System.Windows.Forms.RadioButton();
            this.radioButton_cie00 = new System.Windows.Forms.RadioButton();
            this.groupBox_scale = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_yfinaltiles = new System.Windows.Forms.TextBox();
            this.textBox_xfinaltiles = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_newytile = new System.Windows.Forms.TextBox();
            this.textBox_newxtile = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_ytilemult = new System.Windows.Forms.TextBox();
            this.textBox_xtilemult = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_yfinal = new System.Windows.Forms.TextBox();
            this.textBox_xfinal = new System.Windows.Forms.TextBox();
            this.textBox_ytile = new System.Windows.Forms.TextBox();
            this.textBox_xtile = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ymult = new System.Windows.Forms.TextBox();
            this.textBox_xmult = new System.Windows.Forms.TextBox();
            this.textBox_newy = new System.Windows.Forms.TextBox();
            this.textBox_newx = new System.Windows.Forms.TextBox();
            this.groupBox_src = new System.Windows.Forms.GroupBox();
            this.label_input_dimensions = new System.Windows.Forms.Label();
            this.pictureBox_img = new System.Windows.Forms.PictureBox();
            this.button_chooseInputImage = new System.Windows.Forms.Button();
            this.textBox_inputImage = new System.Windows.Forms.TextBox();
            this.groupBox_tiles = new System.Windows.Forms.GroupBox();
            this.pictureBox_dir = new System.Windows.Forms.PictureBox();
            this.button_chooseInputTiles = new System.Windows.Forms.Button();
            this.textBox_inputTiles = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_variance = new System.Windows.Forms.NumericUpDown();
            this.radioButton_someVariance = new System.Windows.Forms.RadioButton();
            this.radioButton_mostSimilar = new System.Windows.Forms.RadioButton();
            this.toolTip_cie76 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_cie94 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_colorMatchingAlgorithm = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_demo = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_variance = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDown_tileAccuracy = new System.Windows.Forms.NumericUpDown();
            this.comboBox_split = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            this.groupBox_processing = new System.Windows.Forms.GroupBox();
            this.checkBox_preview = new System.Windows.Forms.CheckBox();
            this.label_cores = new System.Windows.Forms.Label();
            this.numericUpDown_processors = new System.Windows.Forms.NumericUpDown();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label_memory = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox_overlay = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.numericUpDown_transparency = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_cie.SuspendLayout();
            this.groupBox_scale.SuspendLayout();
            this.groupBox_src.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).BeginInit();
            this.groupBox_tiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dir)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_variance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tileAccuracy)).BeginInit();
            this.groupBox_processing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_processors)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox_overlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_transparency)).BeginInit();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.Enabled = false;
            this.helpProvider1.SetHelpString(this.button_generate, "Generates a mosaic from the input image and tiles");
            this.button_generate.Location = new System.Drawing.Point(956, 615);
            this.button_generate.Name = "button_generate";
            this.helpProvider1.SetShowHelp(this.button_generate, true);
            this.button_generate.Size = new System.Drawing.Size(70, 26);
            this.button_generate.TabIndex = 16;
            this.button_generate.Text = "Generate";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // button_demo
            // 
            this.helpProvider1.SetHelpString(this.button_demo, "Fills in sample input image and tiles");
            this.button_demo.Location = new System.Drawing.Point(880, 614);
            this.button_demo.Name = "button_demo";
            this.helpProvider1.SetShowHelp(this.button_demo, true);
            this.button_demo.Size = new System.Drawing.Size(70, 26);
            this.button_demo.TabIndex = 15;
            this.button_demo.Text = "Demo";
            this.toolTip_demo.SetToolTip(this.button_demo, "Supplies a sample image and tiles");
            this.button_demo.UseVisualStyleBackColor = true;
            this.button_demo.Click += new System.EventHandler(this.button_demo_Click);
            // 
            // label_input_tiles_dimensions
            // 
            this.label_input_tiles_dimensions.AutoSize = true;
            this.label_input_tiles_dimensions.Location = new System.Drawing.Point(20, 195);
            this.label_input_tiles_dimensions.Name = "label_input_tiles_dimensions";
            this.label_input_tiles_dimensions.Size = new System.Drawing.Size(10, 13);
            this.label_input_tiles_dimensions.TabIndex = 19;
            this.label_input_tiles_dimensions.Text = "-";
            // 
            // radioButton_cie76
            // 
            this.radioButton_cie76.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.radioButton_cie76, "");
            this.helpProvider1.SetHelpString(this.radioButton_cie76, "Fast but less accurate");
            this.radioButton_cie76.Location = new System.Drawing.Point(7, 45);
            this.radioButton_cie76.Name = "radioButton_cie76";
            this.helpProvider1.SetShowHelp(this.radioButton_cie76, true);
            this.radioButton_cie76.Size = new System.Drawing.Size(75, 17);
            this.radioButton_cie76.TabIndex = 7;
            this.radioButton_cie76.TabStop = true;
            this.radioButton_cie76.Text = "Lab CIE76";
            this.radioButton_cie76.UseVisualStyleBackColor = true;
            // 
            // radioButton_cie94
            // 
            this.radioButton_cie94.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.radioButton_cie94, "");
            this.helpProvider1.SetHelpString(this.radioButton_cie94, "Slow but more accurate");
            this.radioButton_cie94.Location = new System.Drawing.Point(6, 68);
            this.radioButton_cie94.Name = "radioButton_cie94";
            this.helpProvider1.SetShowHelp(this.radioButton_cie94, true);
            this.radioButton_cie94.Size = new System.Drawing.Size(75, 17);
            this.radioButton_cie94.TabIndex = 8;
            this.radioButton_cie94.TabStop = true;
            this.radioButton_cie94.Text = "Lab CIE94";
            this.toolTip_cie94.SetToolTip(this.radioButton_cie94, "Slower, but more accurate");
            this.radioButton_cie94.UseVisualStyleBackColor = true;
            // 
            // groupBox_cie
            // 
            this.groupBox_cie.Controls.Add(this.radioButton_rgbEuclidean);
            this.groupBox_cie.Controls.Add(this.radioButton_cie00);
            this.groupBox_cie.Controls.Add(this.radioButton_cie76);
            this.groupBox_cie.Controls.Add(this.radioButton_cie94);
            this.helpProvider1.SetHelpKeyword(this.groupBox_cie, "");
            this.helpProvider1.SetHelpString(this.groupBox_cie, "The algorithm used when comparing the input image and tile colors");
            this.groupBox_cie.Location = new System.Drawing.Point(346, 19);
            this.groupBox_cie.Name = "groupBox_cie";
            this.helpProvider1.SetShowHelp(this.groupBox_cie, true);
            this.groupBox_cie.Size = new System.Drawing.Size(194, 117);
            this.groupBox_cie.TabIndex = 23;
            this.groupBox_cie.TabStop = false;
            this.groupBox_cie.Text = "Color Matching Algorithm";
            // 
            // radioButton_rgbEuclidean
            // 
            this.radioButton_rgbEuclidean.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.radioButton_rgbEuclidean, "");
            this.helpProvider1.SetHelpString(this.radioButton_rgbEuclidean, "Fastest but inaccurate");
            this.radioButton_rgbEuclidean.Location = new System.Drawing.Point(7, 23);
            this.radioButton_rgbEuclidean.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_rgbEuclidean.Name = "radioButton_rgbEuclidean";
            this.helpProvider1.SetShowHelp(this.radioButton_rgbEuclidean, true);
            this.radioButton_rgbEuclidean.Size = new System.Drawing.Size(98, 17);
            this.radioButton_rgbEuclidean.TabIndex = 6;
            this.radioButton_rgbEuclidean.TabStop = true;
            this.radioButton_rgbEuclidean.Text = "RGB Euclidean";
            this.radioButton_rgbEuclidean.UseVisualStyleBackColor = true;
            // 
            // radioButton_cie00
            // 
            this.radioButton_cie00.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.radioButton_cie00, "");
            this.helpProvider1.SetHelpString(this.radioButton_cie00, "Slowest but most accurate");
            this.radioButton_cie00.Location = new System.Drawing.Point(7, 92);
            this.radioButton_cie00.Name = "radioButton_cie00";
            this.helpProvider1.SetShowHelp(this.radioButton_cie00, true);
            this.radioButton_cie00.Size = new System.Drawing.Size(75, 17);
            this.radioButton_cie00.TabIndex = 9;
            this.radioButton_cie00.TabStop = true;
            this.radioButton_cie00.Text = "Lab CIE00";
            this.radioButton_cie00.UseVisualStyleBackColor = true;
            // 
            // groupBox_scale
            // 
            this.groupBox_scale.Controls.Add(this.label30);
            this.groupBox_scale.Controls.Add(this.label23);
            this.groupBox_scale.Controls.Add(this.label29);
            this.groupBox_scale.Controls.Add(this.label28);
            this.groupBox_scale.Controls.Add(this.label27);
            this.groupBox_scale.Controls.Add(this.label26);
            this.groupBox_scale.Controls.Add(this.label25);
            this.groupBox_scale.Controls.Add(this.label24);
            this.groupBox_scale.Controls.Add(this.label17);
            this.groupBox_scale.Controls.Add(this.label10);
            this.groupBox_scale.Controls.Add(this.label9);
            this.groupBox_scale.Controls.Add(this.label8);
            this.groupBox_scale.Controls.Add(this.label1);
            this.groupBox_scale.Controls.Add(this.label22);
            this.groupBox_scale.Controls.Add(this.label21);
            this.groupBox_scale.Controls.Add(this.label20);
            this.groupBox_scale.Controls.Add(this.label19);
            this.groupBox_scale.Controls.Add(this.label18);
            this.groupBox_scale.Controls.Add(this.textBox_yfinaltiles);
            this.groupBox_scale.Controls.Add(this.textBox_xfinaltiles);
            this.groupBox_scale.Controls.Add(this.label16);
            this.groupBox_scale.Controls.Add(this.textBox_newytile);
            this.groupBox_scale.Controls.Add(this.textBox_newxtile);
            this.groupBox_scale.Controls.Add(this.label14);
            this.groupBox_scale.Controls.Add(this.label15);
            this.groupBox_scale.Controls.Add(this.textBox_ytilemult);
            this.groupBox_scale.Controls.Add(this.textBox_xtilemult);
            this.groupBox_scale.Controls.Add(this.label13);
            this.groupBox_scale.Controls.Add(this.label12);
            this.groupBox_scale.Controls.Add(this.label11);
            this.groupBox_scale.Controls.Add(this.label7);
            this.groupBox_scale.Controls.Add(this.label6);
            this.groupBox_scale.Controls.Add(this.textBox_yfinal);
            this.groupBox_scale.Controls.Add(this.textBox_xfinal);
            this.groupBox_scale.Controls.Add(this.textBox_ytile);
            this.groupBox_scale.Controls.Add(this.textBox_xtile);
            this.groupBox_scale.Controls.Add(this.textBox_y);
            this.groupBox_scale.Controls.Add(this.textBox_x);
            this.groupBox_scale.Controls.Add(this.label2);
            this.groupBox_scale.Controls.Add(this.textBox_ymult);
            this.groupBox_scale.Controls.Add(this.textBox_xmult);
            this.groupBox_scale.Controls.Add(this.textBox_newy);
            this.groupBox_scale.Controls.Add(this.textBox_newx);
            this.groupBox_scale.Location = new System.Drawing.Point(12, 19);
            this.groupBox_scale.Name = "groupBox_scale";
            this.groupBox_scale.Size = new System.Drawing.Size(328, 305);
            this.groupBox_scale.TabIndex = 24;
            this.groupBox_scale.TabStop = false;
            this.groupBox_scale.Text = "Scale Output";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(210, 180);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(14, 13);
            this.label30.TabIndex = 48;
            this.label30.Text = "X";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(210, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(14, 13);
            this.label23.TabIndex = 47;
            this.label23.Text = "X";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(296, 251);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(25, 13);
            this.label29.TabIndex = 46;
            this.label29.Text = "tiles";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(209, 225);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(14, 13);
            this.label28.TabIndex = 45;
            this.label28.Text = "X";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(210, 79);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 13);
            this.label27.TabIndex = 44;
            this.label27.Text = "X";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(210, 128);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(14, 13);
            this.label26.TabIndex = 43;
            this.label26.Text = "X";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(185, 225);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(18, 13);
            this.label25.TabIndex = 42;
            this.label25.Text = "px";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(185, 180);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(18, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "px";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(186, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "px";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "px";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "tiles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "px";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(297, 225);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(18, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "px";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(297, 180);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 13);
            this.label21.TabIndex = 33;
            this.label21.Text = "px";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(297, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 13);
            this.label20.TabIndex = 32;
            this.label20.Text = "px";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(297, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "px";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(297, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "px";
            // 
            // textBox_yfinaltiles
            // 
            this.textBox_yfinaltiles.Location = new System.Drawing.Point(229, 248);
            this.textBox_yfinaltiles.Name = "textBox_yfinaltiles";
            this.textBox_yfinaltiles.ReadOnly = true;
            this.textBox_yfinaltiles.Size = new System.Drawing.Size(61, 20);
            this.textBox_yfinaltiles.TabIndex = 29;
            this.textBox_yfinaltiles.TabStop = false;
            // 
            // textBox_xfinaltiles
            // 
            this.textBox_xfinaltiles.Location = new System.Drawing.Point(118, 248);
            this.textBox_xfinaltiles.Name = "textBox_xfinaltiles";
            this.textBox_xfinaltiles.ReadOnly = true;
            this.textBox_xfinaltiles.Size = new System.Drawing.Size(61, 20);
            this.textBox_xfinaltiles.TabIndex = 28;
            this.textBox_xfinaltiles.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "New Size";
            // 
            // textBox_newytile
            // 
            this.textBox_newytile.Location = new System.Drawing.Point(229, 177);
            this.textBox_newytile.Name = "textBox_newytile";
            this.textBox_newytile.ReadOnly = true;
            this.textBox_newytile.Size = new System.Drawing.Size(61, 20);
            this.textBox_newytile.TabIndex = 25;
            this.textBox_newytile.TabStop = false;
            // 
            // textBox_newxtile
            // 
            this.textBox_newxtile.Location = new System.Drawing.Point(118, 177);
            this.textBox_newxtile.Name = "textBox_newxtile";
            this.textBox_newxtile.ReadOnly = true;
            this.textBox_newxtile.Size = new System.Drawing.Size(61, 20);
            this.textBox_newxtile.TabIndex = 24;
            this.textBox_newxtile.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Size Multiplier";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(210, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "X";
            // 
            // textBox_ytilemult
            // 
            this.textBox_ytilemult.Location = new System.Drawing.Point(229, 151);
            this.textBox_ytilemult.Name = "textBox_ytilemult";
            this.textBox_ytilemult.Size = new System.Drawing.Size(61, 20);
            this.textBox_ytilemult.TabIndex = 5;
            this.textBox_ytilemult.TextChanged += new System.EventHandler(this.textBox_tileymult_TextChanged);
            // 
            // textBox_xtilemult
            // 
            this.textBox_xtilemult.Location = new System.Drawing.Point(118, 151);
            this.textBox_xtilemult.Name = "textBox_xtilemult";
            this.textBox_xtilemult.Size = new System.Drawing.Size(61, 20);
            this.textBox_xtilemult.TabIndex = 4;
            this.textBox_xtilemult.TextChanged += new System.EventHandler(this.textBox_tilexmult_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Output Dimensions";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Tiles Size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "New Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Size Multiplier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Image Size";
            // 
            // textBox_yfinal
            // 
            this.textBox_yfinal.Location = new System.Drawing.Point(229, 222);
            this.textBox_yfinal.Name = "textBox_yfinal";
            this.textBox_yfinal.ReadOnly = true;
            this.textBox_yfinal.Size = new System.Drawing.Size(61, 20);
            this.textBox_yfinal.TabIndex = 13;
            this.textBox_yfinal.TabStop = false;
            // 
            // textBox_xfinal
            // 
            this.textBox_xfinal.Location = new System.Drawing.Point(118, 222);
            this.textBox_xfinal.Name = "textBox_xfinal";
            this.textBox_xfinal.ReadOnly = true;
            this.textBox_xfinal.Size = new System.Drawing.Size(61, 20);
            this.textBox_xfinal.TabIndex = 12;
            this.textBox_xfinal.TabStop = false;
            // 
            // textBox_ytile
            // 
            this.textBox_ytile.Location = new System.Drawing.Point(230, 125);
            this.textBox_ytile.Name = "textBox_ytile";
            this.textBox_ytile.ReadOnly = true;
            this.textBox_ytile.Size = new System.Drawing.Size(61, 20);
            this.textBox_ytile.TabIndex = 10;
            this.textBox_ytile.TabStop = false;
            // 
            // textBox_xtile
            // 
            this.textBox_xtile.Location = new System.Drawing.Point(119, 125);
            this.textBox_xtile.Name = "textBox_xtile";
            this.textBox_xtile.ReadOnly = true;
            this.textBox_xtile.Size = new System.Drawing.Size(61, 20);
            this.textBox_xtile.TabIndex = 9;
            this.textBox_xtile.TabStop = false;
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(230, 24);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.ReadOnly = true;
            this.textBox_y.Size = new System.Drawing.Size(61, 20);
            this.textBox_y.TabIndex = 7;
            this.textBox_y.TabStop = false;
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(119, 24);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.ReadOnly = true;
            this.textBox_x.Size = new System.Drawing.Size(61, 20);
            this.textBox_x.TabIndex = 6;
            this.textBox_x.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            // 
            // textBox_ymult
            // 
            this.textBox_ymult.Location = new System.Drawing.Point(230, 50);
            this.textBox_ymult.Name = "textBox_ymult";
            this.textBox_ymult.Size = new System.Drawing.Size(61, 20);
            this.textBox_ymult.TabIndex = 3;
            this.textBox_ymult.TextChanged += new System.EventHandler(this.textBox_ymult_TextChanged);
            // 
            // textBox_xmult
            // 
            this.textBox_xmult.Location = new System.Drawing.Point(119, 50);
            this.textBox_xmult.Name = "textBox_xmult";
            this.textBox_xmult.Size = new System.Drawing.Size(61, 20);
            this.textBox_xmult.TabIndex = 2;
            this.textBox_xmult.TextChanged += new System.EventHandler(this.textBox_xmult_TextChanged);
            // 
            // textBox_newy
            // 
            this.textBox_newy.Location = new System.Drawing.Point(230, 76);
            this.textBox_newy.Name = "textBox_newy";
            this.textBox_newy.ReadOnly = true;
            this.textBox_newy.Size = new System.Drawing.Size(61, 20);
            this.textBox_newy.TabIndex = 1;
            this.textBox_newy.TabStop = false;
            // 
            // textBox_newx
            // 
            this.textBox_newx.Location = new System.Drawing.Point(119, 76);
            this.textBox_newx.Name = "textBox_newx";
            this.textBox_newx.ReadOnly = true;
            this.textBox_newx.Size = new System.Drawing.Size(61, 20);
            this.textBox_newx.TabIndex = 0;
            this.textBox_newx.TabStop = false;
            // 
            // groupBox_src
            // 
            this.groupBox_src.Controls.Add(this.label_input_dimensions);
            this.groupBox_src.Controls.Add(this.pictureBox_img);
            this.groupBox_src.Controls.Add(this.button_chooseInputImage);
            this.groupBox_src.Controls.Add(this.textBox_inputImage);
            this.groupBox_src.Location = new System.Drawing.Point(6, 19);
            this.groupBox_src.Name = "groupBox_src";
            this.groupBox_src.Size = new System.Drawing.Size(215, 250);
            this.groupBox_src.TabIndex = 25;
            this.groupBox_src.TabStop = false;
            this.groupBox_src.Text = "Input Image";
            // 
            // label_input_dimensions
            // 
            this.label_input_dimensions.AutoSize = true;
            this.label_input_dimensions.Location = new System.Drawing.Point(16, 195);
            this.label_input_dimensions.Name = "label_input_dimensions";
            this.label_input_dimensions.Size = new System.Drawing.Size(10, 13);
            this.label_input_dimensions.TabIndex = 23;
            this.label_input_dimensions.Text = "-";
            // 
            // pictureBox_img
            // 
            this.pictureBox_img.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox_img.Location = new System.Drawing.Point(6, 18);
            this.pictureBox_img.Name = "pictureBox_img";
            this.pictureBox_img.Size = new System.Drawing.Size(200, 200);
            this.pictureBox_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_img.TabIndex = 22;
            this.pictureBox_img.TabStop = false;
            // 
            // button_chooseInputImage
            // 
            this.button_chooseInputImage.Location = new System.Drawing.Point(181, 224);
            this.button_chooseInputImage.Name = "button_chooseInputImage";
            this.button_chooseInputImage.Size = new System.Drawing.Size(25, 20);
            this.button_chooseInputImage.TabIndex = 21;
            this.button_chooseInputImage.Text = "...";
            this.button_chooseInputImage.UseVisualStyleBackColor = true;
            this.button_chooseInputImage.Click += new System.EventHandler(this.button_chooseInputImage_Click);
            // 
            // textBox_inputImage
            // 
            this.textBox_inputImage.Location = new System.Drawing.Point(6, 224);
            this.textBox_inputImage.Name = "textBox_inputImage";
            this.textBox_inputImage.Size = new System.Drawing.Size(177, 20);
            this.textBox_inputImage.TabIndex = 0;
            // 
            // groupBox_tiles
            // 
            this.groupBox_tiles.Controls.Add(this.label_input_tiles_dimensions);
            this.groupBox_tiles.Controls.Add(this.pictureBox_dir);
            this.groupBox_tiles.Controls.Add(this.button_chooseInputTiles);
            this.groupBox_tiles.Controls.Add(this.textBox_inputTiles);
            this.groupBox_tiles.Location = new System.Drawing.Point(236, 19);
            this.groupBox_tiles.Name = "groupBox_tiles";
            this.groupBox_tiles.Size = new System.Drawing.Size(215, 250);
            this.groupBox_tiles.TabIndex = 26;
            this.groupBox_tiles.TabStop = false;
            this.groupBox_tiles.Text = "Input Tiles";
            // 
            // pictureBox_dir
            // 
            this.pictureBox_dir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox_dir.Location = new System.Drawing.Point(10, 18);
            this.pictureBox_dir.Name = "pictureBox_dir";
            this.pictureBox_dir.Size = new System.Drawing.Size(200, 200);
            this.pictureBox_dir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_dir.TabIndex = 14;
            this.pictureBox_dir.TabStop = false;
            // 
            // button_chooseInputTiles
            // 
            this.button_chooseInputTiles.Location = new System.Drawing.Point(187, 224);
            this.button_chooseInputTiles.Name = "button_chooseInputTiles";
            this.button_chooseInputTiles.Size = new System.Drawing.Size(25, 20);
            this.button_chooseInputTiles.TabIndex = 13;
            this.button_chooseInputTiles.Text = "...";
            this.button_chooseInputTiles.UseVisualStyleBackColor = true;
            this.button_chooseInputTiles.Click += new System.EventHandler(this.button_chooseInputTiles_Click);
            // 
            // textBox_inputTiles
            // 
            this.textBox_inputTiles.Location = new System.Drawing.Point(10, 224);
            this.textBox_inputTiles.Name = "textBox_inputTiles";
            this.textBox_inputTiles.Size = new System.Drawing.Size(179, 20);
            this.textBox_inputTiles.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown_variance);
            this.groupBox1.Controls.Add(this.radioButton_someVariance);
            this.groupBox1.Controls.Add(this.radioButton_mostSimilar);
            this.groupBox1.Location = new System.Drawing.Point(346, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 69);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matching Rule";
            // 
            // numericUpDown_variance
            // 
            this.numericUpDown_variance.Location = new System.Drawing.Point(141, 44);
            this.numericUpDown_variance.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown_variance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_variance.Name = "numericUpDown_variance";
            this.numericUpDown_variance.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_variance.TabIndex = 12;
            this.toolTip_variance.SetToolTip(this.numericUpDown_variance, "Instead of using the most similar tile, use the x-most similar tile");
            this.numericUpDown_variance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radioButton_someVariance
            // 
            this.radioButton_someVariance.AutoSize = true;
            this.helpProvider1.SetHelpString(this.radioButton_someVariance, "Find the x-most similar tile per pixel analyzed");
            this.radioButton_someVariance.Location = new System.Drawing.Point(7, 44);
            this.radioButton_someVariance.Name = "radioButton_someVariance";
            this.helpProvider1.SetShowHelp(this.radioButton_someVariance, true);
            this.radioButton_someVariance.Size = new System.Drawing.Size(67, 17);
            this.radioButton_someVariance.TabIndex = 11;
            this.radioButton_someVariance.TabStop = true;
            this.radioButton_someVariance.Text = "Variance";
            this.radioButton_someVariance.UseVisualStyleBackColor = true;
            // 
            // radioButton_mostSimilar
            // 
            this.radioButton_mostSimilar.AutoSize = true;
            this.helpProvider1.SetHelpString(this.radioButton_mostSimilar, "Find the closest matching tile per pixel analyzed");
            this.radioButton_mostSimilar.Location = new System.Drawing.Point(7, 20);
            this.radioButton_mostSimilar.Name = "radioButton_mostSimilar";
            this.helpProvider1.SetShowHelp(this.radioButton_mostSimilar, true);
            this.radioButton_mostSimilar.Size = new System.Drawing.Size(81, 17);
            this.radioButton_mostSimilar.TabIndex = 10;
            this.radioButton_mostSimilar.TabStop = true;
            this.radioButton_mostSimilar.Text = "Most Similar";
            this.radioButton_mostSimilar.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_tileAccuracy
            // 
            this.numericUpDown_tileAccuracy.Location = new System.Drawing.Point(254, 19);
            this.numericUpDown_tileAccuracy.Name = "numericUpDown_tileAccuracy";
            this.numericUpDown_tileAccuracy.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown_tileAccuracy.TabIndex = 13;
            this.toolTip_variance.SetToolTip(this.numericUpDown_tileAccuracy, "Instead of using the most similar tile, use the x-most similar tile");
            // 
            // comboBox_split
            // 
            this.comboBox_split.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.comboBox_split, "Splits the output image into X smaller images");
            this.comboBox_split.Items.AddRange(new object[] {
            "Do not split",
            "Split into (4) images",
            "Split into (9) images",
            "Split into (16) images",
            "Split into (25) images",
            "Split into (36) images",
            "Split into (49) images",
            "Split into (64) images",
            "Split into (81) images",
            "Split into (100) images",
            "Split into (121) images",
            "Split into (144) images",
            "Split into (169) images",
            "Split into (196) images",
            "Split into (225) images",
            "Split into (256) images",
            "Split into (289) images",
            "Split into (324) images",
            "Split into (361) images",
            "Split into (400) images",
            "Split into (441) images",
            "Split into (484) images",
            "Split into (529) images",
            "Split into (576) images",
            "Split into (625) images",
            "Split into (676) images",
            "Split into (729) images",
            "Split into (784) images",
            "Split into (841) images",
            "Split into (900) images"});
            this.comboBox_split.Location = new System.Drawing.Point(6, 46);
            this.comboBox_split.Name = "comboBox_split";
            this.helpProvider1.SetShowHelp(this.comboBox_split, true);
            this.comboBox_split.Size = new System.Drawing.Size(141, 21);
            this.comboBox_split.TabIndex = 14;
            // 
            // progressBar
            // 
            this.helpProvider1.SetHelpString(this.progressBar, "Progress bar");
            this.progressBar.Location = new System.Drawing.Point(12, 615);
            this.progressBar.Name = "progressBar";
            this.helpProvider1.SetShowHelp(this.progressBar, true);
            this.progressBar.Size = new System.Drawing.Size(862, 25);
            this.progressBar.TabIndex = 30;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(14, 337);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(10, 13);
            this.label_progress.TabIndex = 31;
            this.label_progress.Text = ".";
            // 
            // groupBox_processing
            // 
            this.groupBox_processing.Controls.Add(this.checkBox_preview);
            this.groupBox_processing.Controls.Add(this.comboBox_split);
            this.groupBox_processing.Controls.Add(this.label_cores);
            this.groupBox_processing.Controls.Add(this.numericUpDown_processors);
            this.groupBox_processing.Location = new System.Drawing.Point(346, 222);
            this.groupBox_processing.Name = "groupBox_processing";
            this.groupBox_processing.Size = new System.Drawing.Size(194, 102);
            this.groupBox_processing.TabIndex = 32;
            this.groupBox_processing.TabStop = false;
            this.groupBox_processing.Text = "Processing";
            // 
            // checkBox_preview
            // 
            this.checkBox_preview.AutoSize = true;
            this.checkBox_preview.Checked = true;
            this.checkBox_preview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_preview.Location = new System.Drawing.Point(7, 73);
            this.checkBox_preview.Name = "checkBox_preview";
            this.checkBox_preview.Size = new System.Drawing.Size(107, 17);
            this.checkBox_preview.TabIndex = 35;
            this.checkBox_preview.Text = "Preview Image(s)";
            this.checkBox_preview.UseVisualStyleBackColor = true;
            // 
            // label_cores
            // 
            this.label_cores.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label_cores, "Amount of cores to use for calculation");
            this.label_cores.Location = new System.Drawing.Point(6, 22);
            this.label_cores.Name = "label_cores";
            this.helpProvider1.SetShowHelp(this.label_cores, true);
            this.label_cores.Size = new System.Drawing.Size(91, 13);
            this.label_cores.TabIndex = 1;
            this.label_cores.Text = "Virtual Processors";
            // 
            // numericUpDown_processors
            // 
            this.helpProvider1.SetHelpString(this.numericUpDown_processors, "Amount of cores to use for calculation");
            this.numericUpDown_processors.Location = new System.Drawing.Point(100, 20);
            this.numericUpDown_processors.Name = "numericUpDown_processors";
            this.helpProvider1.SetShowHelp(this.numericUpDown_processors, true);
            this.numericUpDown_processors.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_processors.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.numericUpDown_tileAccuracy);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.helpProvider1.SetHelpKeyword(this.groupBox2, "");
            this.helpProvider1.SetHelpString(this.groupBox2, "The algorithm used when comparing the input image and tile colors");
            this.groupBox2.Location = new System.Drawing.Point(12, 330);
            this.groupBox2.Name = "groupBox2";
            this.helpProvider1.SetShowHelp(this.groupBox2, true);
            this.groupBox2.Size = new System.Drawing.Size(328, 50);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiles";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 21);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(241, 13);
            this.label31.TabIndex = 49;
            this.label31.Text = "Tile Average Color - For Each Pixel Skip [X] Pixels";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.helpProvider1.SetHelpKeyword(this.radioButton2, "");
            this.helpProvider1.SetHelpString(this.radioButton2, "Slowest but most accurate");
            this.radioButton2.Location = new System.Drawing.Point(7, 92);
            this.radioButton2.Name = "radioButton2";
            this.helpProvider1.SetShowHelp(this.radioButton2, true);
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Lab CIE00";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label_memory
            // 
            this.label_memory.AutoSize = true;
            this.label_memory.ForeColor = System.Drawing.Color.Red;
            this.label_memory.Location = new System.Drawing.Point(19, 311);
            this.label_memory.Name = "label_memory";
            this.label_memory.Size = new System.Drawing.Size(10, 13);
            this.label_memory.TabIndex = 33;
            this.label_memory.Text = ".";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.userManualToolStripMenuItem.Text = "User manual";
            this.userManualToolStripMenuItem.Click += new System.EventHandler(this.userManualToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox_src);
            this.groupBox3.Controls.Add(this.groupBox_tiles);
            this.groupBox3.Location = new System.Drawing.Point(12, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 278);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Images";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox_overlay);
            this.groupBox4.Controls.Add(this.groupBox_scale);
            this.groupBox4.Controls.Add(this.groupBox_cie);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.label_memory);
            this.groupBox4.Controls.Add(this.label_progress);
            this.groupBox4.Controls.Add(this.groupBox_processing);
            this.groupBox4.Location = new System.Drawing.Point(480, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(546, 581);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // groupBox_overlay
            // 
            this.groupBox_overlay.Controls.Add(this.label3);
            this.groupBox_overlay.Controls.Add(this.numericUpDown_transparency);
            this.groupBox_overlay.Controls.Add(this.radioButton1);
            this.groupBox_overlay.Location = new System.Drawing.Point(346, 330);
            this.groupBox_overlay.Name = "groupBox_overlay";
            this.groupBox_overlay.Size = new System.Drawing.Size(194, 83);
            this.groupBox_overlay.TabIndex = 34;
            this.groupBox_overlay.TabStop = false;
            this.groupBox_overlay.Text = "Overlay";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(154, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Overlay tiles on input image";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_transparency
            // 
            this.numericUpDown_transparency.Location = new System.Drawing.Point(137, 51);
            this.numericUpDown_transparency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_transparency.Name = "numericUpDown_transparency";
            this.numericUpDown_transparency.ReadOnly = true;
            this.numericUpDown_transparency.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown_transparency.TabIndex = 1;
            this.numericUpDown_transparency.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tile Transparency %";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 652);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button_demo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Photomosaic";
            this.groupBox_cie.ResumeLayout(false);
            this.groupBox_cie.PerformLayout();
            this.groupBox_scale.ResumeLayout(false);
            this.groupBox_scale.PerformLayout();
            this.groupBox_src.ResumeLayout(false);
            this.groupBox_src.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).EndInit();
            this.groupBox_tiles.ResumeLayout(false);
            this.groupBox_tiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dir)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_variance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tileAccuracy)).EndInit();
            this.groupBox_processing.ResumeLayout(false);
            this.groupBox_processing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_processors)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox_overlay.ResumeLayout(false);
            this.groupBox_overlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_transparency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.Button button_demo;
        private System.Windows.Forms.Label label_input_tiles_dimensions;
        private System.Windows.Forms.RadioButton radioButton_cie76;
        private System.Windows.Forms.RadioButton radioButton_cie94;
        private System.Windows.Forms.GroupBox groupBox_cie;
        private System.Windows.Forms.GroupBox groupBox_scale;
        private System.Windows.Forms.GroupBox groupBox_src;
        private System.Windows.Forms.Label label_input_dimensions;
        private System.Windows.Forms.PictureBox pictureBox_img;
        private System.Windows.Forms.Button button_chooseInputImage;
        private System.Windows.Forms.TextBox textBox_inputImage;
        private System.Windows.Forms.GroupBox groupBox_tiles;
        private System.Windows.Forms.PictureBox pictureBox_dir;
        private System.Windows.Forms.Button button_chooseInputTiles;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_newytile;
        private System.Windows.Forms.TextBox textBox_newxtile;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_ytilemult;
        private System.Windows.Forms.TextBox textBox_xtilemult;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_yfinal;
        private System.Windows.Forms.TextBox textBox_xfinal;
        private System.Windows.Forms.TextBox textBox_ytile;
        private System.Windows.Forms.TextBox textBox_xtile;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ymult;
        private System.Windows.Forms.TextBox textBox_xmult;
        private System.Windows.Forms.TextBox textBox_newy;
        private System.Windows.Forms.TextBox textBox_newx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_someVariance;
        private System.Windows.Forms.RadioButton radioButton_mostSimilar;
        private System.Windows.Forms.ToolTip toolTip_cie76;
        private System.Windows.Forms.ToolTip toolTip_cie94;
        private System.Windows.Forms.ToolTip toolTip_colorMatchingAlgorithm;
        private System.Windows.Forms.ToolTip toolTip_demo;
        private System.Windows.Forms.NumericUpDown numericUpDown_variance;
        private System.Windows.Forms.ToolTip toolTip_variance;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.ComboBox comboBox_split;
        public System.Windows.Forms.TextBox textBox_inputTiles;
        private System.Windows.Forms.RadioButton radioButton_cie00;
        private System.Windows.Forms.RadioButton radioButton_rgbEuclidean;
        private System.Windows.Forms.GroupBox groupBox_processing;
        private System.Windows.Forms.Label label_cores;
        private System.Windows.Forms.NumericUpDown numericUpDown_processors;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_yfinaltiles;
        private System.Windows.Forms.TextBox textBox_xfinaltiles;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label_memory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_preview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown_tileAccuracy;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label31;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox_overlay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_transparency;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

