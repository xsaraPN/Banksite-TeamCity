﻿using System.Web.Mvc;
using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
    [TestFixture]
    public class LoanApplicationControllerTests
    {
        [Test]
        public void ShouldRenderDefaultView()
        {
            var fakerepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakerepository.Object, fakeLoanApplicationScorer.Object);

            sut.WithCallTo(x => x.Apply()).ShouldRenderDefaultView();
        }

        [Test]
        public void ShouldRedirectToAcceptedViewOnSuccessfulApplication()
        {
            var fakerepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakerepository.Object, fakeLoanApplicationScorer.Object);

            var acceptedApplication = new LoanApplication
            {
                IsAccepted = true
            };

            sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Accepted);
        }

        [Test]
        public void ShouldRedirectToDeclinedViewOnUnsuccessfulApplication()
        {
            var fakerepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakerepository.Object, fakeLoanApplicationScorer.Object);

            var declinedApplication = new LoanApplication
            {
                IsAccepted = false
            };


            sut.WithCallTo(x => x.Apply(declinedApplication))
               .ShouldRedirectTo<int>(x => x.Declined);
        }
    }
}
