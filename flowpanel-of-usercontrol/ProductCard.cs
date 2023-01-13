using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flowpanel_of_usercontrol
{
    public partial class ProductCard : UserControl
    {
        int _id = 0;
        public ProductCard()
        {
            InitializeComponent();
            Padding = new Padding(0);
            Margin = new Padding(2);
            pictureBox.Padding = new Padding(8);
            labelExp.Click += (sender, e) => MessageBox.Show($"{this}");
            Name = $"userControl{_id++}";  // No space, start with lowercase
        }
        public string Description
        {
            get => labelDescription.Text;
            set
            {
                if (!Equals(labelDescription.Text, value))
                {
                    labelDescription.Text = value;
                    var imagePath = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Images",
                        $"{Description}.png"
                    );
                    // Set the "Copy to Output Directory" property of all image files.
                    if (File.Exists(imagePath))
                    {
                        pictureBox.Image = Image.FromFile(imagePath);
                    }
                }
            }
        }
        public string Category
        {
            get => labelCategory.Text;
            set => labelCategory.Text = value;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Width = getWidth();
            // Respond to width changes of owner container.
            Parent.SizeChanged += (sender, e) => Width = getWidth();
        }
        int VSBW { get; } = SystemInformation.VerticalScrollBarWidth;
        private int getWidth() =>
            Parent.Width -
                Parent.Padding.Left -
                Parent.Padding.Right -
                Margin.Left -
                Margin.Right -
                VSBW;
        public override string ToString() =>
            $"{Category}{Environment.NewLine}{Description}";
    }
}
