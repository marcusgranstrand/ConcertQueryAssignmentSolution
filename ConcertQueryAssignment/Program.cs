using System.Text.Json;
using ConcertQueryAssignment;

string concertData = File.ReadAllText("D:\\Programmering\\C#\\C# Course\\ConcertQueryAssignmentSolution\\ConcertQueryAssignment\\concert_data.json");

List<Concert> concerts = JsonSerializer.Deserialize<List<Concert>>(concertData);

DateOrdered();
Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
ReducedVenueOrdered();
Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
Year2024Ordered();
Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
LargestSales();
Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------");
FridayConcerts();

List<Concert> DateOrdered()
{	
    List<Concert> datevalued = concerts
	.OrderBy(concerts => concerts.Date)
	.Where(concerts => concerts.Date >= DateTime.Today)
	.ToList();

	foreach (var item in datevalued)
	{		
		Console.WriteLine($"ID: {item.Id} \tReducedVenue: {item.ReducedVenue} \tDateValue: {item.Date} " +
		$"\tPeformer: {item.Performer, 35} \tBegins At: {item.BeginsAt} \tFullCapacitySales: {item.FullCapacitySales,10}");
	}
	return datevalued;
}

List<Concert> ReducedVenueOrdered()
{
	List<Concert> reducedVenueOrdered = concerts
	.Where(concerts => concerts.ReducedVenue == true)
	.ToList();

	foreach (var item in reducedVenueOrdered)
	{
		Console.WriteLine($"ID: {item.Id} \tReducedVenue: {item.ReducedVenue} \tDateValue: {item.Date} " +
		$"\tPeformer: {item.Performer,35} \tBegins At: {item.BeginsAt} \tFullCapacitySales: {item.FullCapacitySales,10}");
	}
	return reducedVenueOrdered;
}

List<Concert> Year2024Ordered()
{
	List<Concert> year2024Ordered = concerts
	.Where(concerts => concerts.Date.Year == 2024)
	.OrderBy(concerts => concerts.Date)
	.ToList();

	foreach(var item in year2024Ordered)
	{
        Console.WriteLine($"ID: {item.Id} \tReducedVenue: {item.ReducedVenue} \tDateValue: {item.Date} " +
		$"\tPeformer: {item.Performer,35} \tBegins At: {item.BeginsAt} \tFullCapacitySales: {item.FullCapacitySales,10}");
	}
	return year2024Ordered;
}

List<Concert> LargestSales()
{
	List<Concert> concertsCopy = concerts
	.OrderByDescending(concerts => concerts.FullCapacitySales)
	.Take(5)
	.ToList();

	foreach (var item in concertsCopy)
	{
		Console.WriteLine($"ID: {item.Id} \tReducedVenue: {item.ReducedVenue} \tDateValue: {item.Date} " +
		$"\tPeformer: {item.Performer,35} \tBegins At: {item.BeginsAt} \tFullCapacitySales: {item.FullCapacitySales,10}");
	}

	return concertsCopy;
}

List<Concert> FridayConcerts()
{
	List<Concert> fridayConcerts = concerts
	.Where(concerts => concerts.Date.DayOfWeek == DayOfWeek.Friday)
	.ToList();

	foreach (var item in fridayConcerts)
	{
		Console.WriteLine($"ID: {item.Id} \tReducedVenue: {item.ReducedVenue} \tDateValue: {item.Date} " +
		$"\tPeformer: {item.Performer,35} \tBegins At: {item.BeginsAt} \tFullCapacitySales: {item.FullCapacitySales,10}");
	}
	return fridayConcerts;
}

Console.ReadKey();