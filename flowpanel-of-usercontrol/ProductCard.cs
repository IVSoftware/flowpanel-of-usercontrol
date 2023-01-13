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
        public ProductCard()
        {
            InitializeComponent();
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
                    if(File.Exists(imagePath))
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
    }
}
