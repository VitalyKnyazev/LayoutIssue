using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace LayoutIssue
{
	[DesignTimeVisible(false)]
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();

			var random = new Random();

			var items = Enumerable.Repeat(1, 1000).Select(i =>
			{
				var income = Math.Round(random.NextDouble() * 10000, 2);
				var expenses = Math.Round(random.NextDouble() * -10000, 2);

				return new DataItem
				{
					Date = DateTime.Now.ToShortTimeString(),
					Income = income.ToString(CultureInfo.InvariantCulture),
					Expenses = expenses.ToString(CultureInfo.InvariantCulture),
					Net = (income - expenses).ToString(CultureInfo.InvariantCulture)
				};
			}).ToArray();

			listView.ItemsSource = items;
		}
	}

	public sealed class DataItem
	{
		public string Date { get; set; }
		public string Income { get; set; }
		public string Expenses { get; set; }
		public string Net { get; set; }
	}
}