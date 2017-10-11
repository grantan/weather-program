using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicWeatherProgram
{
    public class WeatherService
    {
		public IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData)
		{
			var	cityAveragedData = inputData
									.GroupBy(g => new { City = g.City, State = g.State })
									.Select(cd => 
										new CityAveragedWeatherData
										{
											City = cd.Key.City,
											State = cd.Key.State,
											AverageHighTemp = cd.Average(h => h.HighTemp),
											AverageLowTemp = cd.Average(l => l.LowTemp)
										});

			return cityAveragedData;
			
		}
	}
}
