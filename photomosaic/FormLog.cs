using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photomosaic
{
    public partial class FormLog : Form
    {
        public RichTextBox box = new RichTextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Courier New", 10)
        };
        public FormLog()
        {
            InitializeComponent();
        }
        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public void Log(string line, bool error)
        {
            if (error)
                AppendText(box, "\r\n" + line, Color.Red);
            else
                AppendText(box, "\r\n" + line, Color.Black);
        }
    }
}