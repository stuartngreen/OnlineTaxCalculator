using OnlineTaxCalculator.Domain.Models;
using System;
using Xunit;

namespace OnlineTaxCalculator.Test
{
    public class PaySlipTests
    {
        [Fact]
        public void GetPaye_GivenNoEmployeeAge_ThrowsException()
        {
            // Arrange
            var employee = new Employee();

            var paySlip = new PaySlip(employee);

            // Assert
            Assert.Throws<System.ArgumentException>(() => paySlip.GetPaye());
        }

        [Fact]
        public void GetPaye_GivenNoGrossSalary_ThrowsException()
        {
            // Arrange
            var employee = new Employee
            {
                Age = 30
            };

            var paySlip = new PaySlip(employee);

            // Assert
            Assert.Throws<System.ArgumentException>(() => paySlip.GetPaye());
        }

        [Fact]
        public void GetPaye_GivenGrossSalaryAndDeductionsAndYear2019_ReturnsCorrectValue()
        {
            // Arrange
            var employee = new Employee
            {
                Age = 30
            };

            var paySlip = new PaySlip(employee);
            var taxYear = 2019;
            var expected = 9156.21m;

            paySlip.GrossSalary = 40000m;
            paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Pension",
                Taxable = false,
                Value = 2500m
            });
            paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Vitality",
                Taxable = true,
                Value = 250m
            });
            paySlip.DeductionItems.Add(new Deduction
            {
                Name = "Parking",
                Taxable = true,
                Value = 150m
            });

            // Act
            var paye = paySlip.GetPaye(taxYear);

            // Assert
            Assert.Equal(expected, Math.Round(paye, 2));
        }

    }
}
