using _8_Bit_Twist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _8_Bit_TwistTests
{
    public class ApplicationUserTests
    {
        [Fact]
        public void CanGetFirstName()
        {
            ApplicationUser user = new ApplicationUser() { FirstName = "Andy" };

            Assert.Equal("Andy", user.FirstName);
        }

        [Fact]
        public void CanSetFirstName()
        {
            ApplicationUser user = new ApplicationUser() { FirstName = "Andy" };

            user.FirstName = "Ben";

            Assert.Equal("Ben", user.FirstName);
        }

        [Fact]
        public void CanGetLastName()
        {
            ApplicationUser user = new ApplicationUser() { LastName = "Roska" };

            Assert.Equal("Roska", user.LastName);
        }

        [Fact]
        public void CanSetLastName()
        {
            ApplicationUser user = new ApplicationUser() { LastName = "Roska" };

            user.LastName = "Taylor";

            Assert.Equal("Taylor", user.LastName);
        }

        [Fact]
        public void CanGetComputer()
        {
            ApplicationUser user = new ApplicationUser() { Computer = false };

            Assert.False(user.Computer);
        }

        [Fact]
        public void CanSetComputer()
        {
            ApplicationUser user = new ApplicationUser() { Computer = false };

            user.Computer = true;

            Assert.True(user.Computer);
        }
    }
}
