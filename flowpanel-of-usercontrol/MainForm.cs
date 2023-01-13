using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace flowpanel_of_usercontrol
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Category = "Carpet",
                Description = "Caserta Stone Beige",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Category = "Carpet",
                Description = "Caserta Sky Grey",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Category = "Carpet",
                Description = "Ageless Beauty Clay",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Category = "Carpet",
                Description = "Lush II Tundra",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Category = "Carpet",
                Description = "Lush II Frosty Glade",
            });
            flowLayoutPanel.Products.Add(new ProductCard
            {
                Category = "Hardwood",
                Description = "Bolivian Rosewood",
            });

            #region G L Y P H S
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "search-refresh-exchange-plus.ttf");
            privateFontCollection.AddFontFile(path);
            var fontFamily = privateFontCollection.Families[0];
            Glyphs = new Font(fontFamily, 12F);
            labelSearch.Font = Glyphs;
            labelSearch.Text = "\uE800";
            textBoxSearch.TextChanged += (sender, e) => flowLayoutPanel.Search(textBoxSearch.Text);
            #endregion G L Y P H S
        }

        PrivateFontCollection privateFontCollection = new PrivateFontCollection();
        private Font Glyphs;
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

        internal void Search(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                foreach (var product in Products)
                {
                    product.Visible = true;
                }
            }
            else
            {
                foreach (var product in Products)
                {
                    product.Visible = 
                        product.Description.Contains(
                            text, 
                            StringComparison.OrdinalIgnoreCase);
                }
            }
        }
    }
}