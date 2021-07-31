using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automator
{
    class DateTimeGenerator
    {
        private readonly Random _random;
        private DateTime _min;
        private DateTime _max;
        private long _range;

        public DateTimeGenerator(string min = null, string max = null)
        {
            _random = new Random();
            _min = string.IsNullOrWhiteSpace(min)
                ? DateTime.MinValue
                : DateTime.Parse(min);
            _max = string.IsNullOrWhiteSpace(max)
                ? DateTime.Now
                : DateTime.Parse(max);
            _range = (_max - _min).Ticks;
        }

        public DateTime GetDateTime()
        {
            return _min.AddTicks((long)(_random.NextDouble() * _range));
        }

        public string GetDateTimeString(string format = "yyyy-MM-dd hh:mm:ss")
        {
            return GetDateTime().ToString(format);
        }

        public string GetDateTimeSafeString()
        {
            return GetDateTime().ToString("yyyy-MM-dd_hh-mm-ss");
        }
    }
}
