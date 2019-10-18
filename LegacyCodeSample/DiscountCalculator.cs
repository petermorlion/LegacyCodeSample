using System;

namespace LegacyCodeSample
{
    public class DiscountCalculator
    {
        public double CalculateDiscount(Customer customer)
        {
            if (customer.IsGoldMember)
            {
                if (DateTime.UtcNow.Year - customer.Birthdate.Year > 40)
                {
                    if (customer.IsEmployee())
                    {
                        return 20;
                    }

                    return 30;
                }

                if (customer.IsEmployee())
                {
                    return 15;
                }
            }

            if (IsBirthday(customer))
            {
                return 40;
            }

            return 0;
        }

        private bool IsBirthday(Customer customer)
        {
            return customer.Birthdate.Month == DateTime.UtcNow.Month && customer.Birthdate.Day == DateTime.UtcNow.Day;
        }
    }
}
