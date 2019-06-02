using System;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace mdsharpe.DateOnly.UnitTests
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
        public void CanCreateDate_UsingAutofixture() {
            // Act
            var date = new Fixture().Create<Date>();

            // Assert
            Assert.True(date.Day > 0 || date.Month > 0 || date.Year > 0);
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

        [Fact]
        public void Date_EqualsOperator() {
            // Arrange
            var dt = new Fixture().Create<DateTime>();
            
            var d1 = new Date(dt.Year, dt.Month, dt.Day);
            var d2 = new Date(dt.Year, dt.Month, dt.Day);

            // Act
            var result = d1 == d2;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Date_Equals_ReturnsTrueForEqualDates() {
            // Arrange
            var dt = new Fixture().Create<DateTime>();
            
            var d1 = new Date(dt.Year, dt.Month, dt.Day);
            var d2 = new Date(dt.Year, dt.Month, dt.Day);

            // Act
            var result = d1.Equals(d2);

            // Assert
            result.Should().BeTrue();
        }
    }
}
 