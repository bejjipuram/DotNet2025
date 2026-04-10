using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class DelegateRetryUtility
    {
        private static int tries = 0;
        public static void Main(string[] args)
        {
            int result = ExecuteWithRetry(() =>
            {
                tries++;
                if (tries <= 2)
                {
                    throw new InvalidOperationException("Temporary fialure");

                }
                return 999;
            }, maxAttempts: 3);
            Console.WriteLine(result);
        }
        public static T ExecuteWithRetry<T>(Func<T> work, int maxAttempts)
        {
            if (work == null)
            {
                throw new ArgumentNullException(nameof(work));
            }
            if (maxAttempts <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxAttempts), "maxAttempts must be greater than zero.");
            }
            Exception? lastException = null;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    return work();
                }
                catch (Exception ex)
                {
                    if (attempt == maxAttempts)
                        throw;
                }
            }
            throw lastException;
        }
    }
}
