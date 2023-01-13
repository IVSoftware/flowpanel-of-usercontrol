For something light-duty, it's pretty easy to use a flow layout panel to show a bound table in a scrollable list. A quick proof-of-concept is shown below [[clone](https://github.com/IVSoftware/flowpanel-of-usercontrol.git)]. 

*For production use or with huge tables there are at least three big companies producing sophisticated custom WinForms components of this nature that have free trial licenses. IMO one "might" want to weight the benefits vs the cost.*

[![screenshot][1]][1]

    class CustomFlowLayoutTable : FlowLayoutPanel
    {
        public CustomFlowLayoutTable()
        {
            Padding = new Padding(0);
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
***
**ProductCard**

    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
            Margin = new Padding(4, 4, 4, 0);
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
            Parent.SizeChanged += (sender, e) =>
            {
                Width = getWidth();
            };
        }
        int VSBW { get; } = SystemInformation.VerticalScrollBarWidth;
        private int getWidth() => Parent.Width - 8 - VSBW;
    }

***
**Main Form**

    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        int _count = 0;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var VSBW = SystemInformation.VerticalScrollBarWidth;
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


  [1]: https://i.stack.imgur.com/PAeUJ.png