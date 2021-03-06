﻿namespace AllegroExtended.Web.Controllers.Tests
{
    using Moq;

    using AllegroExtended.Data.Models;
    using AllegroExtended.Services.Data;
    using AllegroExtended.Web.Infrastructure.Mapping;
    using AllegroExtended.Web.ViewModels.Home;

    using NUnit.Framework;

    using Areas.Administration.Controllers;
    using TestStack.FluentMVCTesting;
    using Areas.Administration.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class RequestControllerTests
    {
        private AutoMapperConfig autoMapperConfig;
        private List<AccountRequest> requests;

        [SetUp]
        public void Init()
        {
            this.autoMapperConfig = new AutoMapperConfig();
            this.autoMapperConfig.Execute(typeof(RequestController).Assembly);
            this.requests = new List<AccountRequest>();
            this.requests.Add(new AccountRequest()
            {
                UserName = "test",
                Email = "a@a.com",
                Group = new Group() { Name = "Test Group" }
            });
            this.requests.Add(new AccountRequest()
            {
                UserName = "test2",
                Email = "b@b.com",
                Group = new Group() { Name = "Test Group 2" }
            });
            this.requests.Add(new AccountRequest()
            {
                IsRead = true,
                UserName = "test3",
                Email = "c@c.com",
                Group = new Group() { Name = "Test Group 3" }
            });
        }

        [Test]
        public void AllShouldWorkCorrectly()
        {
            var requestServiceMock = new Mock<IAccountRequestService>();
            requestServiceMock.Setup(x => x.GetAll()).Returns(this.requests.AsQueryable());
            requestServiceMock.Setup(x => x.GetAllUnread()).Returns(this.requests.AsQueryable());

            var controller = new RequestController(requestServiceMock.Object);
            controller.WithCallTo(x => x.All())
                .ShouldRenderView("All")
                .WithModel<List<AccountRequestListViewModel>>(
                    viewModel =>
                        {
                            Assert.AreEqual(this.requests[0].UserName, viewModel[0].UserName);
                            Assert.AreEqual(this.requests.Count, viewModel.Count);
                        }).AndNoModelErrors();
        }

        [Test]
        public void AllUnreadShouldWorkCorrectly()
        {
            var requestServiceMock = new Mock<IAccountRequestService>();
            requestServiceMock.Setup(x => x.GetAll()).Returns(this.requests.AsQueryable());
            requestServiceMock.Setup(x => x.GetAllUnread()).Returns(this.requests.AsQueryable().Where(x => !x.IsRead));

            var controller = new RequestController(requestServiceMock.Object);
            controller.WithCallTo(x => x.AllUnread())
                .ShouldRenderView("AllUnread")
                .WithModel<List<AccountRequestListViewModel>>(
                    viewModel =>
                    {
                        Assert.AreEqual(this.requests[0].UserName, viewModel[0].UserName);
                        Assert.AreEqual(2, viewModel.Count);
                    }).AndNoModelErrors();
        }

        [Test]
        public void DetailsShouldWorkCorrectly()
        {
            var testId = 1;

            var requestServiceMock = new Mock<IAccountRequestService>();
            requestServiceMock.Setup(x => x.GetById(It.Is<int>(i => i == testId))).Returns(this.requests[0]);

            var controller = new RequestController(requestServiceMock.Object);
            controller.WithCallTo(x => x.Details(testId))
                .ShouldRenderView("Details")
                .WithModel<AccountRequestDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(this.requests[0].UserName, viewModel.UserName);
                    }).AndNoModelErrors();
        }
    }
}
