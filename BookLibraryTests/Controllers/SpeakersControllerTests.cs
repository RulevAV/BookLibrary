using BookLibrary.Controllers;
using BookLibrary.Domain.Repositories.Abstract;
using BookLibraryTests.MockData;
using FluentAssertions;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookLibraryTests.Controllers
{
    public class SpeakersControllerTests
    {
        [Fact]
        public async Task GetAllSpeakers_()
        {
            //Arrange
            var data = new Mock<ISpeaker>();
            data.Setup(_ => _.getAll()).Returns(SpeakersMockData.getAll());
            var controller = new speakersController(data.Object);

            //Act
            var result = controller.GetAllSpeakers();

            //Assert
            result.Should().HaveCount(SpeakersMockData.getAll().Count);
        }
    }
}
