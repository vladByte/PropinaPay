namespace PropinaPay;

public partial class MainPage : ContentPage
{
    int count = 0;
    int numPersons = 1;
    int tip = 0;
    decimal bill = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void TxtBill_OnCompleted(object? sender, EventArgs e)
    {
        bill = decimal.Parse(TxtBill.Text);
        CalculateTotal();
    }

    /// <summary>
    /// Calculates the total bill including tip and splits it among the number of persons.
    /// </summary>
    private void CalculateTotal()
    {
        if (tip != 0)
        {
            // Total tip amount.
            decimal tipAmount = (bill * tip) / 100;
            lblTip.Text = tipAmount.ToString("C");
            
            // Total bill amount including tip.
            decimal totalBillAmount = bill + tipAmount;
            LblTotal.Text = $"{totalBillAmount:C}";
            
            // Total amount by person.
            decimal totalByPerson = totalBillAmount / numPersons;
            LblTipByPerson.Text = $"{totalByPerson:C}";
        }
        else
        {
            decimal totalPerPerson = bill / numPersons;
        }
    }

    /// <summary>
    /// Called when the number of persons slider value changes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void SldTip__OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    /// <summary>
    /// Selects the tip percentage when a button is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_OnClicked(object? sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var tipText = btn.Text.Replace("%", "");
            var percentage = int.Parse(tipText);
            sldTip.Value = percentage;
            lblTip.Text = $"Tip: {tipText}%";
            CalculateTotal();
        }
    }

    /// <summary>
    /// Results when the minus button is clicked to decrease the number of persons.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnMinus_OnClicked(object? sender, EventArgs e)
    {
        if (numPersons > 1)
        {
            numPersons--;
            lblSplit.Text = $"Number of Persons: {numPersons}";
            CalculateTotal();
        }
        else
        {
            DisplayAlert("Invalid Operation", "Number of persons cannot be less than 1.", "OK");
        }
    }

    /// <summary>
    /// Sumar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnPlus_OnClicked(object? sender, EventArgs e)
    {
        numPersons++;
        lblSplit.Text = $"Number of Persons: {numPersons}";
        CalculateTotal();
    }
}