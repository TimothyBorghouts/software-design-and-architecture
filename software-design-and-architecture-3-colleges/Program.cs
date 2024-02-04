
using software_design_and_architecture_3_colleges;


Movie movie = new Movie("Matthijs de dinosaurus");
MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddDays(4), 10);

Console.WriteLine(movie.ToString() + "\n");
Console.WriteLine(movieScreening.ToString() + "\n");

Order order1 = new Order(1, true);
Order order2 = new Order(2, false);

// Order 1

// 12 + 0 + 10 = 22,-

MovieTicket movieTicket1 = new MovieTicket(3, 11, true, movieScreening);
MovieTicket movieTicket2 = new MovieTicket(3, 12, false, movieScreening);
MovieTicket movieTicket3 = new MovieTicket(3, 13, false, movieScreening);

order1.AddSeatReservation(movieTicket1);
order1.AddSeatReservation(movieTicket2);
order1.AddSeatReservation(movieTicket3);

Console.WriteLine("Price order 1: " + order1.CalculatePrice());


// Order 2

// (13 + 0 + 10 + 0 + 10 + 0 + 13 + 0) * 0.9 = 41,4

MovieTicket movieTicket4 = new MovieTicket(7, 11, true, movieScreening);
MovieTicket movieTicket5 = new MovieTicket(7, 12, false, movieScreening);
MovieTicket movieTicket6 = new MovieTicket(7, 13, false, movieScreening);
MovieTicket movieTicket7 = new MovieTicket(4, 11, true, movieScreening);
MovieTicket movieTicket8 = new MovieTicket(4, 12, false, movieScreening);
MovieTicket movieTicket9 = new MovieTicket(4, 13, false, movieScreening);
MovieTicket movieTicket10 = new MovieTicket(5, 1, true, movieScreening);
MovieTicket movieTicket11 = new MovieTicket(5, 2, false, movieScreening);

order2.AddSeatReservation(movieTicket4);
order2.AddSeatReservation(movieTicket5);
order2.AddSeatReservation(movieTicket6);
order2.AddSeatReservation(movieTicket7);
order2.AddSeatReservation(movieTicket8);
order2.AddSeatReservation(movieTicket9);
order2.AddSeatReservation(movieTicket10);
order2.AddSeatReservation(movieTicket11);

Console.WriteLine("Price order 2: " + order2.CalculatePrice());

// Export

order1.Export(TicketExportFormat.PLAINTEXT);
order1.Export(TicketExportFormat.JSON);