using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrations.Cb.Business;
using Integrations.Cb.Contracts.Interfaces.Business;
using Integrations.Cb.Contracts.Interfaces.Business.Models;
using Integrations.Cb.Contracts.Interfaces.DataAccess;
using Integrations.Cb.Contracts.Models.Business;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Integrations.Cb.UnitTests.Business
{
    [TestClass]
    public class CruiseBookingTest
    {
       [TestMethod]
       public async Task TestGetCruiseBookingHeaderDetailsAsync()
        {
           Mock<ILogger<CruiseBooking>> mockLogger = new Mock<ILogger<CruiseBooking>>();
            Mock<ICoreDatabaseDataAccess> coreDataAccessMock = new Mock<ICoreDatabaseDataAccess>();
            CruiseBooking earnRewards = new CruiseBooking(
              coreDataAccessMock.Object
              , mockLogger.Object);
            string ownerId = "1054148";
            ICruiseBookingHeader cruiseBookingHeader = new CruiseBookingHeader()
            {
                OrignalTswTransactionId=null,
                TswTransactionId=1,
                TransactionDate=DateTime.Now,
                OwnerId=ownerId,
               OwnerNumber= ownerId,
               SailDate= DateTime.Now,
               DollarsUsed=20,
               Comment="comment",
               ConfirmationNo="T1223"

            };
            IEnumerable<ICruiseBookingHeader> cruiseBookingHeaders = new List<ICruiseBookingHeader>()
            {
                new CruiseBookingHeader()
                {
                OrignalTswTransactionId=null,
                TswTransactionId=1,
                TransactionDate=DateTime.Now,
                OwnerId=ownerId,
               OwnerNumber= ownerId,
               SailDate= DateTime.Now,
               DollarsUsed=20,
               Comment="comment",
               ConfirmationNo="T1223",
               Flag=true
                }
            };
            coreDataAccessMock.Setup(x => x.GetCruiseBookingHeaderDetailsAsync(ownerId)).Returns(Task.FromResult(cruiseBookingHeaders));
            var response=await earnRewards.GetCruiseBookingHeaderDetailsAsync(ownerId);
            Assert.AreEqual(response.First().OwnerId,ownerId);
        }
       [TestMethod]
       public async Task TestGetCruiseLinesAsync()
        {
            Mock<ILogger<CruiseBooking>> mockLogger = new Mock<ILogger<CruiseBooking>>();
            Mock<ICoreDatabaseDataAccess> coreDataAccessMock = new Mock<ICoreDatabaseDataAccess>();
            CruiseBooking cruiseBooking = new CruiseBooking(
              coreDataAccessMock.Object
              , mockLogger.Object); var cruiseLinesId = 1;
            var cruiseLinesName = "CruiseLinesName1";
            IEnumerable<ICruiseLines> cruiseLines = new List<CruiseLines>()
            {
                new CruiseLines()
                {
                    CruiseLinesId = cruiseLinesId,
                    CruiseLinesName = cruiseLinesName
                }
            };
            coreDataAccessMock.Setup(x => x.GetCruiseLinesAsync())
                    .Returns(Task.FromResult(cruiseLines));
            var response = await cruiseBooking.GetCruiseLinesAsync();
            Assert.AreEqual(response.First().CruiseLinesId, cruiseLinesId);
            Assert.AreEqual(response.First().CruiseLinesName, cruiseLinesName);
        }
       [TestMethod]
       public async Task TestGetTourNamesAsync()
        {
            Mock<ILogger<CruiseBooking>> mockLogger = new Mock<ILogger<CruiseBooking>>();
            Mock<ICoreDatabaseDataAccess> coreDataAccessMock = new Mock<ICoreDatabaseDataAccess>();
            CruiseBooking cruiseBooking = new CruiseBooking(
              coreDataAccessMock.Object
              , mockLogger.Object); 
            var id = 1;
            var tourName = "TourName";
            var tourType = "FamilyTrip";
            IEnumerable<ITourNames> tourNames = new List<TourNames>()
            {
                new TourNames()
                {
                    Id = id,
                    TourName = tourName,
                    TourType = tourType
                }
            };
            coreDataAccessMock.Setup(x => x.GetTourNamesAsync())
                    .Returns(Task.FromResult(tourNames));
            var response = await cruiseBooking.GetTourNamesAsync();
            Assert.AreEqual(response.First().Id, id);
            Assert.AreEqual(response.First().TourName, tourName);
            Assert.AreEqual(response.First().TourType, tourType);
        }
    }
}
