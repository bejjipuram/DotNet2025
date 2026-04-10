using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_45_M1Practice
{
    public class ThresholdChangedEventArgs<T> : EventArgs
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
        public string Message { get; set; } = "";
    }
    public class ThresholdMonitor<T> where T: IComparable<T>
    {
        private readonly T thresholds;
        private T current;
        public ThresholdMonitor(T threshold,T initial)
        {
            thresholds = threshold;
            current = initial;
        }
        public event EventHandler<ThresholdChangedEventArgs<T>>? ThresholdCrossed;
        public void Update(T newValue)
        {
            bool wasBelow = current.CompareTo(thresholds) < 0;
            bool isNowAtOrAbove = newValue.CompareTo(thresholds) >= 0;
            if (wasBelow && isNowAtOrAbove)
            {
                ThresholdCrossed?.Invoke(this, new ThresholdChangedEventArgs<T>
                {
                    OldValue = current,
                    NewValue = newValue,
                    Message = $"Threshold crossed at value {newValue}"
                });
            }
            current = newValue;
        }
    }
    public class GenericEventWithDelegate
    {
        public static void Main(string[] args)
        {
            var Monitor = new ThresholdMonitor<int>(threshold: 100, initial: 90);
            Monitor.ThresholdCrossed += (sender, e) =>
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Old={e.OldValue}, New={e.NewValue}");
            };
            Monitor.Update(95);
            Monitor.Update(101);
        }
    }
}
