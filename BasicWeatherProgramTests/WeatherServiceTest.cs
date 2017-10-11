using BasicWeatherProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicWeatherProgramTests
{
	[TestClass]
	public class WeatherServiceTest
	{
		List<WeatherData> weatherList;

		[TestInitialize]
		public void Setup()
		{
			weatherList = new List<WeatherData>();

			WeatherData data1 = new WeatherData
			{
				State = "Colorado",
				City = "Denver",
				Date = Convert.ToDateTime("10/10/2017"),
				HighTemp = 40.0m,
				LowTemp = 30.0m
			};

			WeatherData data2 = new WeatherData
			{
				State = "Colorado",
				City = "Denver",
				Date = Convert.ToDateTime("10/11/2017"),
				HighTemp = 50.0m,
				LowTemp = 40.0m
			};

			WeatherData data3 = new WeatherData
			{
				State = "California",
				City = "San Francisco",
				Date = Convert.ToDateTime("10/10/2017"),
				HighTemp = 80.0m,
				LowTemp = 50.0m
			};

			WeatherData data4 = new WeatherData
			{
				State = "California",
				City = "San Francisco",
				Date = Convert.ToDateTime("10/11/2017"),
				HighTemp = 70.0m,
				LowTemp = 60.0m
			};

			weatherList.Add(data1);
			weatherList.Add(data2);
			weatherList.Add(data3);
			weatherList.Add(data4);
		}

		[TestCleanup]
		public void TearDown()
		{
			weatherList = null;
		}

		[TestMethod]
		public void TestAverageHighOneCity()
		{
			WeatherService service = new WeatherService();
			IEnumerable<CityAveragedWeatherData> averagedData = service.AggregateWeatherData(weatherList.ToArray());

			var denverWeather = averagedData
									.Where(c => c.City == "Denver")
									.Where(s => s.State == "Colorado")
									.FirstOrDefault();

			Assert.IsTrue(denverWeather.AverageHighTemp == 45.0m);
		}

		[TestMethod]
		public void TestAverageLowTwoCities()
		{
			WeatherService service = new WeatherService();
			IEnumerable<CityAveragedWeatherData> averagedData = service.AggregateWeatherData(weatherList.ToArray());

			var denverWeather = averagedData
									.Where(c => c.City == "Denver")
									.Where(s => s.State == "Colorado")
									.FirstOrDefault();

			var sfWeather = averagedData
									.Where(c => c.City == "San Francisco")
									.Where(s => s.State == "California")
									.FirstOrDefault();

			Assert.IsTrue(denverWeather.AverageLowTemp == 35.0m && sfWeather.AverageLowTemp == 55.0m);
		}
	}
}