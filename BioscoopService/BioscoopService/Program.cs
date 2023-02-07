// See https://aka.ms/new-console-template for more information
using BioscoopService;

Console.WriteLine("Hello, World!");

Movie movie = new Movie("DonkeyKong");

MovieScreening screening = new MovieScreening(movie,DateTime.Now,5);

MovieTicket ticketEen = new MovieTicket(screening,true,2,2);
MovieTicket ticketTwee = new MovieTicket(screening, true, 2, 3);
MovieTicket ticketDrie = new MovieTicket(screening, true, 2, 4);
MovieTicket ticketVier = new MovieTicket(screening, true, 2, 5);
MovieTicket ticketVijf = new MovieTicket(screening, true, 2, 6);
MovieTicket ticketZes = new MovieTicket(screening, true, 2, 7);

Order order = new Order(1,false);

order.addSeatReservation(ticketEen);
order.addSeatReservation(ticketTwee);
order.addSeatReservation(ticketDrie);
order.addSeatReservation(ticketVier);
order.addSeatReservation(ticketVijf);
order.addSeatReservation(ticketZes);

Console.WriteLine(order.calculatePrice());

order.Export(TicketExportFormat.PLAINTEXT);

Console.WriteLine((int)DateTime.Now.AddDays(5).DayOfWeek);


