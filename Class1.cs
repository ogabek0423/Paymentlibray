namespace PaymentLibrary
{
    public class LoanCalculator
    {
        public static decimal CalculateMonthlyPayment(
            decimal principal,
            double annualInterestRate,
            int termInYears,
            decimal additionalFee = 0)
        {
            if (principal <= 0)
                throw new ArgumentException("Asosiy qarz musbat bolishi kerak");
            if (annualInterestRate < 0)
                throw new ArgumentException("Foiz stavkasi manfiy bolmasligi kerak");
            if (termInYears <= 0)
                throw new ArgumentException("Muddat musbat bolishi kerak");
            if (additionalFee < 0)
                throw new ArgumentException("Qoshimcha komissiya manfiy bo‘lmasligi kerak");

            double monthlyRate = annualInterestRate / 100 / 12;
            int totalMonths = termInYears * 12;

            decimal basePayment = principal * (decimal)(monthlyRate * Math.Pow(1 + monthlyRate, totalMonths)) /
                                  (decimal)(Math.Pow(1 + monthlyRate, totalMonths) - 1);

            return Math.Round(basePayment + additionalFee, 2);
        }
    }
}
