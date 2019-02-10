using System;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace DateOnly.UnitTests
{
    public class DateTests
    {
        [Fact]
        public void CanCreateDate_WithParameterlessConstructor()
        {
            // Act
            new Date();
        }

        [Fact]
        public void CanCreateDate_WithYYYYMMDDConstructor()
        {
            // Arrange
            var dt = new Fixture().Create<DateTime>();

            // Act
            new Date(dt.Year, dt.Month, dt.Day);
        }

        [Fact]
        public void Date_RetainsYearMonthDay()
        {
            // Arrange
            var dt = new Fixture().Create<DateTime>();

            // Act
            var sut = new Date(dt.Year, dt.Month, dt.Day);
            
            // Assert
            sut.Year.Should().Be(dt.Year);
            sut.Month.Should().Be(dt.Month);
            sut.Day.Should().Be(dt.Day);
        }
    }
}
