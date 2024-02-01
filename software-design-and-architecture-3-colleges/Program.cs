
using software_design_and_architecture_3_colleges;

//----------------------------------------------------------------------------------------------------------------------

Order order1 = new Order(1, true);
Movie movie1 = new Movie("Matthijs de dinosaurus");
MovieScreening movieScreening1 = new MovieScreening(movie1, DateTime.Now, 10);

// ticket 1: 10,- + 2,- = 12,-
// ticket 2: 0, want 2e ticket
// ticket 3: 10,-
// total: 22,-
MovieTicket movieTicket1 = new MovieTicket(3, 11, true, movieScreening1);
MovieTicket movieTicket2 = new MovieTicket(3, 12, false, movieScreening1);
MovieTicket movieTicket3 = new MovieTicket(3, 13, false, movieScreening1);
Console.WriteLine(movieTicket1.ToString());
Console.WriteLine(movieTicket2.ToString());
Console.WriteLine(movieTicket3.ToString());

order1.AddSeatReservation(movieTicket1);
order1.AddSeatReservation(movieTicket2);
order1.AddSeatReservation(movieTicket3);

Console.WriteLine(order1.CalculatePrice());

//----------------------------------------------------------------------------------------------------------------------

Order order2 = new Order(2, false);
Movie movie2 = new Movie("Timothy de draak");
MovieScreening movieScreening2 = new MovieScreening(movie2, DateTime.Now.AddDays(0), 10);

//Niet ma/di/wo/do + Niet student
// 100  + 9 (premium 3x) x 0.9 (groepskorting) = 98.1

//ma/di/wo/do + niet student
// 100 : 2 (want ma/di/wo/do) + 6 (premium 3x - 1x(ma/di/do/wo)) x 0.9 (groepskorting) = 50.4
MovieTicket movieTicket4 = new MovieTicket(7, 11, true, movieScreening2);
MovieTicket movieTicket5 = new MovieTicket(7, 12, false, movieScreening2);
MovieTicket movieTicket6 = new MovieTicket(7, 13, false, movieScreening2);
MovieTicket movieTicket7 = new MovieTicket(4, 11, true, movieScreening2);
MovieTicket movieTicket8 = new MovieTicket(4, 12, false, movieScreening2);
MovieTicket movieTicket9 = new MovieTicket(4, 13, false, movieScreening2);
MovieTicket movieTicket10 = new MovieTicket(5, 1, true, movieScreening2);
MovieTicket movieTicket11 = new MovieTicket(5, 2, false, movieScreening2);
MovieTicket movieTicket12 = new MovieTicket(6, 5, false, movieScreening2);
MovieTicket movieTicket13 = new MovieTicket(6, 5, false, movieScreening2);

order2.AddSeatReservation(movieTicket4);
order2.AddSeatReservation(movieTicket5);
order2.AddSeatReservation(movieTicket6);
order2.AddSeatReservation(movieTicket7);
order2.AddSeatReservation(movieTicket8);
order2.AddSeatReservation(movieTicket9);
order2.AddSeatReservation(movieTicket10);
order2.AddSeatReservation(movieTicket11);
order2.AddSeatReservation(movieTicket12);
order2.AddSeatReservation(movieTicket13);

Console.WriteLine(order2.CalculatePrice());

//----------------------------------------------------------------------------------------------------------------------

order1.Export(TicketExportFormat.PLAINTEXT);
order1.Export(TicketExportFormat.JSON);