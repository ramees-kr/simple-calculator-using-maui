namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = "0";
        private string currentOperator;
        private double firstOperand;
        private double secondOperand;

        public MainPage()
        {
            InitializeComponent();
            resultLabel.Text = currentInput;
        }

        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (currentInput == "0" || currentInput == "Error")
            {
                currentInput = buttonText;
            }
            else
            {
                currentInput += buttonText;
            }

            resultLabel.Text = currentInput;
        }

        private void OperatorButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentOperator = button.Text;
            if (currentInput == "Error")
            {
                currentInput = "0";
            }
            else
            {
                firstOperand = double.Parse(currentInput);
                currentInput = "0";
                resultLabel.Text = currentInput;
            }
            
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            currentInput = "0";
            currentOperator = null;
            firstOperand = 0;
            secondOperand = 0;
            resultLabel.Text = currentInput;
        }

        private void BackspaceButton_Clicked(object sender, EventArgs e)
        {
            if (currentInput.Length > 1)
            {
                currentInput = currentInput.Remove(currentInput.Length - 1);
            }
            else
            {
                currentInput = "0";
            }
            resultLabel.Text = currentInput;
        }

        private void EqualsButton_Clicked(object sender, EventArgs e)
        {
            if (currentOperator != null)
            {
                secondOperand = double.Parse(currentInput);
                try
                {
                    double resultLabelValue = CalculatorProcessor.Process(firstOperand, secondOperand, currentOperator);
                    currentInput = resultLabelValue.ToString();
                    resultLabel.Text = currentInput;
                }
                catch (Exception ex)
                {
                    currentInput = "Error";
                    resultLabel.Text = currentInput;
                    Console.WriteLine($"Error occurred: {ex.Message}");

                    //Clear the operands and operator
                    currentOperator = null;
                    firstOperand = 0;
                    secondOperand = 0;
                }
            }
        }
    }

}
