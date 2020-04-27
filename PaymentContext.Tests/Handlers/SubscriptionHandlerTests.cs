using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShoulReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Address = "hello@balta.io2";
            command.Barcode = "123456789";
            command.BoletoNumber = "123654898";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.Email = "batman@dc.com";
            command.Street = "asd";
            command.Number = "asd";
            command.Neighborhood = "asd";
            command.City = "asd";
            command.State = "asd";
            command.Country = "asd";
            command.ZipCode = "asd";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }

    }
}