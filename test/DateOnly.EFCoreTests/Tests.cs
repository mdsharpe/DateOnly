using System;
using AutoFixture;
using mdsharpe.DateOnly.EFCoreTests.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace mdsharpe.DateOnly.EFCoreTests
{
    public class Tests
    {
        [Fact]
        public void CanUseDateWithEf()
        {
            var date = new Fixture().Create<Date>();

            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

                int id;

            using (var context = new TestDbContext(options))
            {
                var testEntity = new TestEntity {
                    TheDate = date
                };

                context.TestEntities.Add(testEntity);

                context.SaveChanges();

                id = testEntity.Id;
            }

            using (var context = new TestDbContext(options))
            {
                var testEntity = context.TestEntities.Find(id);

                Assert.Equal(date, testEntity.TheDate);
            }
        }
    }
}
