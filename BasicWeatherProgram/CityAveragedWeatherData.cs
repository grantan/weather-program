using System;
using System.Collections.Generic;
using System.Text;

namespace BasicWeatherProgram
{
    public class CityAveragedWeatherData
    {
		public string State { get; set; }
		public string City { get; set; }
		public decimal AverageHighTemp { get; set; }
		public decimal AverageLowTemp { get; set; }
	}
}
