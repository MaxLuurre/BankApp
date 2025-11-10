namespace BankApp
{
    internal class Loan
    {
        public enum LoanStatus
        {
            Active,
            PaidOff,
            Defaulted,
            Closed,
        }

        public decimal PrincipalAmount { get; private set; }
        public decimal OutstandingAmount { get; private set; }
        public float InterestRatePercent { get; private set; }
        public int TermYears { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public LoanStatus Status { get; private set; }

        // NY konstruktor: sätter räntan + förfallodatum automatiskt
        public Loan(decimal principalAmount, int termYears, DateTime startDate)
        {
            if (principalAmount <= 0) throw new ArgumentException("Belopp måste vara positivt.", nameof(principalAmount));
            if (!LoanPricing.IsSupportedTerm(termYears)) throw new ArgumentException("Löptid måste vara 1, 2 eller 3 år.", nameof(termYears));

            PrincipalAmount = principalAmount;
            OutstandingAmount = principalAmount;
            TermYears = termYears;
            InterestRatePercent = LoanPricing.GetRateForYears(termYears);
            StartDate = startDate;
            DueDate = startDate.AddYears(termYears);
            Status = LoanStatus.Active;
        }

        // Behåll gärna denna om du fortfarande vill kunna skapa "fria" lån
        public Loan(decimal principalamount, float interestratepercent, DateTime startdate, DateTime duedate)
        {
            if (principalamount <= 0) throw new ArgumentException("Principal must be positiv.", nameof(principalamount));
            if (interestratepercent < 0) throw new ArgumentException("Interestrate cannot be negative", nameof(interestratepercent));
            if (duedate <= startdate) throw new ArgumentException("Due date must be after Start date", nameof(duedate));

            PrincipalAmount = principalamount;
            OutstandingAmount = principalamount;
            InterestRatePercent = interestratepercent;
            StartDate = startdate;
            DueDate = duedate;
            Status = LoanStatus.Active;
            TermYears = Math.Max(1, (int)Math.Round((duedate - startdate).TotalDays / 365.0)); // enkel uppskattning
        }

        public void ApplyInterest()
        {
            if (Status != LoanStatus.Active) return;
            decimal interest = OutstandingAmount * ((decimal)InterestRatePercent / 100m);
            OutstandingAmount += interest;
        }

        public void MakePayment(decimal amount)
        {
            if (Status != LoanStatus.Active) return;
            if (amount <= 0) return;

            OutstandingAmount -= amount;
            if (OutstandingAmount <= 0)
            {
                OutstandingAmount = 0;
                Status = LoanStatus.PaidOff;
            }
        }

        public void CheckDue(DateTime currentDate)
        {
            // BUGFIX: var "<" — ska vara ">" för att defaulta EFTER förfallodatum
            if (Status == LoanStatus.Active && currentDate > DueDate && OutstandingAmount > 0)
                Status = LoanStatus.Defaulted;
        }

        public void CloseLoan() => Status = LoanStatus.Closed;

        public override string ToString()
        {
            return $"Outstanding {OutstandingAmount}, Rate {InterestRatePercent:0.##}%, Term {TermYears}y, Due {DueDate:d}, Status {Status}";
        }
        internal static class LoanPricing
        {
            // Justera procentsatserna efter behov
            private static readonly Dictionary<int, float> _ratesByYears = new()
            {
                { 1, 5.00f },
                { 2, 6.25f },
                { 3, 7.50f }
            };

            public static float GetRateForYears(int years)
            {
                if (!_ratesByYears.TryGetValue(years, out var rate))
                    throw new ArgumentException("Ogiltig löptid. Tillåtna är 1, 2 eller 3 år.", nameof(years));
                return rate;
            }

            public static bool IsSupportedTerm(int years) => _ratesByYears.ContainsKey(years);
        }
    }
}
