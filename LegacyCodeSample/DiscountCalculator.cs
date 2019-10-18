using System;

namespace LegacyCodeSample
{
    public class DiscountCalculator
    {
        public double CalculateDiscount(Customer customer)
        {
            if (!customer.IsGoldMember && customer.Birthdate.Month == DateTime.UtcNow.Month && customer.Birthdate.Day == DateTime.UtcNow.Day)
            {
                return 40;
            }

            if (customer.IsGoldMember)
            {
                if (DateTime.UtcNow.Year - customer.Birthdate.Year > 40)
                {
                    return 30;
                }

                if (customer.IsEmployee())
                {
                    if (DateTime.UtcNow.Year - customer.Birthdate.Year > 40)
                    {
                        return 20;
                    }
                    else
                    {
                        return 15;
                    }
                }

                if (customer.Birthdate.Month == DateTime.UtcNow.Month && customer.Birthdate.Day == DateTime.UtcNow.Day)
                {
                    return 40;
                }
            }

            return 0;
        }
    }
}
