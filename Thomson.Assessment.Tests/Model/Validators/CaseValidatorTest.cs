using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Thomson.Assessment.Model.Validators;
using FluentValidation;
using Thomson.Assessment.Model;

namespace Thomson.Assessment.Tests.Model.Validators
{
    [TestClass]
    public class CaseValidatorTest
    {
        [TestMethod]
        public void WhenPassingEmptyCaseNumber_ShouldFailValidation()
        {
            //arrange
            var myCase = new Case{Number=""};
            var target = new CaseValidator();

            //act
            var result = target.Validate(myCase);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void WhenPassingMoreThan25CharCaseNumber_ShouldFailValidation()
        {
            //arrange
            var myCase = new Case{Number= new string('1',26)};
            var target = new CaseValidator();

            //act
            var result = target.Validate(myCase, opt => opt.Number);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void WhenPassingInvalidFormatCaseNumber_ShouldFailValidation()
        {
            //arrange
            var myCase = new Case{Number="1234567-12.1234.112.12.34"};
            var target = new CaseValidator();

            //act
            var result = target.Validate(myCase, opt => opt.Number);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void WhenPassingCorrectCaseNumber_ShouldPassValidation()
        {
            //arrange
            var myCase = new Case{Number="1234567-12.1234.1.12.1234"};
            var target = new CaseValidator();

            //act
            var result = target.Validate(myCase, opt => opt.Number);

            //assert
            result.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void WhenPassingEmptyCourtName_ShouldFailValidation()
        {
            //arrange
            var myCase = new Case{CourtName=""};
            var target = new CaseValidator();

            //act
            var result = target.Validate(myCase, opt => opt.CourtName);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void WhenPassingMoreThan1000CharLengthCourtName_ShouldFailValidation()
        {
            //arrange
            var myCase = new Case{CourtName=new string ('1',1001)};
            var target = new CaseValidator();

            //act
            var result = target.Validate(myCase, opt => opt.CourtName);

            //assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void WhenPassingCorrectCourtName_ShouldPassValidation()
        {
            //arrange
            var myCase = new Case{CourtName="Supreme Federal Court"};
            var target = new CaseValidator();

            //act
            var result = target.Validate(myCase, opt => opt.CourtName);

            //assert
            result.IsValid.Should().BeTrue();
        }

        //TODO

    }
}