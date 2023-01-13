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
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Caserta Stone Beige",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Caserta Sky Grey",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Ageless Beauty Clay",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Lush II Tundra",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Lush II Frosty Glade",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Hardwood",
                Description = "Bolivian Rosewood",
            });
        }
    }
    class CustomFlowLayoutTable : FlowLayoutPanel
    {
        public CustomFlowLayoutTable()
        {
            AutoScroll = true;
            Products.ListChanged += (sender, e) =>
            {
                switch (e.ListChangedType)
                {
                    case ListChangedType.ItemAdded:
                        Controls.Add(Products[e.NewIndex]);
                        break;
                    default:
                        break;
                }
            };
        }
        public BindingList<ProductCard> Products = new BindingList<ProductCard>();
    }
}