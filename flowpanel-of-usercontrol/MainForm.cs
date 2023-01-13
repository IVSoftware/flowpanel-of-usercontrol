namespace flowpanel_of_usercontrol
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        int _count = 0;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            flowLayoutPanel.Padding = new Padding(0);
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Carpet",
                Description = "Caserta Stone Beige",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8,
            });
            flowLayoutPanel.Controls.Add(new ProductCard
            {
                Name = $"userControl{_count++}",  // No space, start with lowercase
                Category = "Hardwood",
                Margin = new Padding(4, 4, 4, 0),
                Width = flowLayoutPanel.Width - 8,
            });
        }
    }
}