using System;

namespace DataTablesCustomSearchFiltersPagingDemo.Utilities
{
    public static class SqlHelpers
    {
        public static bool IsValidSqlDate(DateTime date)
        {
            var greaterThanMinValue = date >= new DateTime(1753, 1, 1, 0, 0, 0);
            var lessThanMaxValue = date <= new DateTime(9999, 12, 31, 11, 59, 59);

            return greaterThanMinValue && lessThanMaxValue;
        }
    }
}