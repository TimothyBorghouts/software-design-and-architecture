using software_design_and_architecture_3_colleges;

namespace software_design_and_architecture.tests
{
    public class CalculatePrice
    {
        private Order CreateOrderWithMovieTickets(bool isStudent, DateTime screeningDateTime, bool isPremium)
        {
            Order order = new Order(1, isStudent);
            Movie movie = new Movie("Timothy de draak");
            MovieScreening movieScreening = new MovieScreening(movie, screeningDateTime, 10);
            MovieTicket movieTicket1 = new MovieTicket(2, 5, isPremium, movieScreening);
            MovieTicket movieTicket2 = new MovieTicket(2, 5, isPremium, movieScreening);
            order.AddSeatReservation(movieTicket1);
            order.AddSeatReservation(movieTicket2);
            return order;
        }

        //Order has no movie tickets should return an error.
        [Fact]
        public void NoMovieTicketsInOrder()
        {
            //Arrange
            Order order = new Order(1, true);

            //Act
            var exception = Assert.Throws<InvalidOperationException>(() => order.CalculatePrice());

            //Assert
            Assert.Equal("No movie tickets available. Cannot calculate total price.", exception.Message);
        }

        // 2 tickets and 2e ticket is free because of student order 1 x 10 = 10,-
        [Fact]
        public void StudentSecondTicketFree()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(true, DateTime.Now, false);

            //Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(10, result);
        }

        // 2 tickets and 2e ticket is free because it is it is a monday 1 x 10 = 10,-
        [Fact]
        public void MidWeekSecondTicketFree()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 5), false);

            //Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(10, result);
        }

        // 2 tickets and 2e ticket is free because it is it is a tuesdays 1 x 10 = 10,-
        [Fact]
        public void MidWeekSecondTicketFreeTuesday()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 6), false);
            //Act
            var result = order.CalculatePrice();
            // Assert
            Assert.Equal(10, result);
        }

        // 2 tickets and 2e ticket is free because it is it is a wednesday 1 x 10 = 10,-
        [Fact]
        public void MidWeekSecondTicketFreeWednesday()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 7), false);
            //Act
            var result = order.CalculatePrice();
            // Assert
            Assert.Equal(10, result);
        }

        // 2 tickets and 2e ticket is free because it is it is a thursday 1 x 10 = 10,-
        [Fact]
        public void MidWeekSecondTicketFreeThursday()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 8), false);
            //Act
            var result = order.CalculatePrice();
            // Assert
            Assert.Equal(10, result);
        }

        //2 Tickets with no premium, no 2e ticket free, no discounts. 2 x 10 = 20,-
        [Fact]
        public void NoDiscountOrFreeTickets()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 4), false);

            //Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(20, result);
        }

        // 6 tickets with 10% group discount 6 x 10 = 60 x 0.9 = 54,-
        [Fact]
        public void GroupDiscount()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 4), false);
            Movie movie = new Movie("Timothy de draak"); 
            DateTime screeningDateTime = new DateTime(2024, 2, 4);
            MovieScreening movieScreening = new MovieScreening(movie, screeningDateTime, 10);

            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));

            //Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(54, result);
        }

        // 6 tickets with 10% group discount and 2e ticket free 6 x 10 = 60 - 3 x 10 = 30 x 0.9 = 27,-
        [Fact]
        public void GroupDiscountAndSecondTicketFree()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 5), false);
            Movie movie = new Movie("Timothy de draak");
            DateTime screeningDateTime = new DateTime(2024, 2, 5);
            MovieScreening movieScreening = new MovieScreening(movie, screeningDateTime, 10);

            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));

            //Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(27, result);
        }

        // 5 tickets will not give 10% discount
        [Fact]
        public void NoGroupDiscount()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 4), false);
            Movie movie = new Movie("Timothy de draak");
            DateTime screeningDateTime = new DateTime(2024, 2, 4);
            MovieScreening movieScreening = new MovieScreening(movie, screeningDateTime, 10);

            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            order.AddSeatReservation(new MovieTicket(2, 5, false, movieScreening));
            //Act
            var result = order.CalculatePrice();
            // Assert
            Assert.Equal(50, result);
        }

        // 2 premium tickets without discounts or free tickets 13 x 2 = 26,-
        [Fact]
        public void PremiumTicketFee()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 4), true);

            //Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(26, result);
        }

        // 2 premium tickets with 2e ticket free 13,-
        [Fact]
        public void PremiumTicketFeeSecondTicketFree()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(false, new DateTime(2024, 2, 5), true);
            //Act
            var result = order.CalculatePrice();
            // Assert
            Assert.Equal(13, result);
        }

        // 2 premium student tickets with 2e ticket free 12,-
        [Fact]
        public void PremiumStudentTicketFeeSecondTicketFree()
        {
            //Arrange
            Order order = CreateOrderWithMovieTickets(true, new DateTime(2024, 2, 5), true);
            //Act
            var result = order.CalculatePrice();
            // Assert
            Assert.Equal(12, result);
        }
    }
}
