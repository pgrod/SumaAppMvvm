namespace SumaAppMvvm
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private Button CounterBtn;

        public MainPage()
        {
            InitializeComponent();
            CounterBtn = new Button
            {
                Text = "Click me"
            };
            CounterBtn.Clicked += OnCounterClicked;
            Content = new StackLayout
            {
                Children = { CounterBtn }
            };
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}


