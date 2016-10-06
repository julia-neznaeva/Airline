
    using System;

    namespace PresenterLevel
    {
        public class FindFlightEventArgs : EventArgs
        {
            public string FlightNumber { get; set; }
            public string City { get; set; }
            public DateTime DateTime { get; set; }
        }
    }
