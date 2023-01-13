using System.ComponentModel;
using System.Windows.Forms;

namespace flowpanel_of_usercontrol
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        int _count = 0;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var VSBW = SystemInformation.VerticalScrollBarWidth;
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Caserta Stone Beige",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8 - VSBW,
            });
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Caserta Sky Grey",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8 - VSBW,
            });
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Ageless Beauty Clay",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8 - VSBW,
            });
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Lush II Tundra",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8 - VSBW,
            });
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Lush II Frosty Glade",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8 - VSBW,
            });
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Hardwood",
                Description = "Bolivian Rosewood",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8 - VSBW,
            });
        }
    }
    class CustomFlowLayoutTable : FlowLayoutPanel
    {
        public CustomFlowLayoutTable()
        {
            Padding = new Padding(0);
            AutoScroll = true;
            Products.AddingNew += (sender, e) =>
            {
            };
        }
        BindingList<ProductCard> Products = new BindingList<ProductCard>();
    }
}