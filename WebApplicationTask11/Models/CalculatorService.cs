namespace CalculatorApp.Models
{
    public class CalculatorService
{
    public double Add(double num1, double num2) => num1 + num2;
    public double Subtract(double num1, double num2) => num1 - num2;
    public double Multiply(double num1, double num2) => num1 * num2;
    public double Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Деление на ноль недопустимо.");
        }
        return num1 / num2;
    }
}
}