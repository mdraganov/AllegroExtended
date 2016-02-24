namespace AllegroExtended.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using AllegroExtended.Data.Models;
    using AllegroExtended.Services.Data;
    using AllegroExtended.Web.Infrastructure.Mapping;
    using AllegroExtended.Web.ViewModels.Home;
    using Areas.Administration.Controllers;
    using Areas.Administration.ViewModels;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Moq;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class UserControllerTests
    {
        private AutoMapperConfig autoMapperConfig;
        private List<ApplicationUser> users;

        [SetUp]
        public void Init()
        {
            this.autoMapperConfig = new AutoMapperConfig();
            this.autoMapperConfig.Execute(typeof(UserController).Assembly);
            this.users = new List<ApplicationUser>();
            this.users.Add(new ApplicationUser()
            {
                UserName = "test",
                Email = "a@a.com",
                Group = new Group() { Name = "Test Group" }
            });
            this.users.Add(new ApplicationUser()
            {
                UserName = "test2",
                Email = "b@b.com",
                Group = new Group() { Name = "Test Group 2" }
            });
            this.users.Add(new ApplicationUser()
            {
                UserName = "test3",
                Email = "c@c.com",
                Group = new Group() { Name = "Test Group 3" }
            });
        }

        [Test]
        public void AllShouldWorkCorrectly()
        {
            var usersServiceMock = new Mock<IUserService>();
            usersServiceMock.Setup(x => x.GetAll()).Returns(this.users.AsQueryable());

            var controller = new UserController(new Mock<IAccountRequestService>().Object, usersServiceMock.Object, new Mock<IGroupService>().Object);
            controller.WithCallTo(x => x.All())
                .ShouldRenderView("All")
                .WithModel<List<UserListViewModel>>(
                    viewModel =>
                        {
                            Assert.AreEqual(this.users[0].UserName, viewModel[0].UserName);
                            Assert.AreEqual(this.users.Count, viewModel.Count);
                        }).AndNoModelErrors();
        }

        [Test]
        public void CreateShouldWorkCorrectly()
        {
            var testModel = new UserViewModel()
            {
                UserName = "test",
                Email = "a@a.com",
                Password = "pass",
                Group = 1
            };

            var testGroup = new Group() { Name = "Test Group" };

            var groupsServiceMock = new Mock<IGroupService>();
            groupsServiceMock.Setup(x => x.GetById(It.Is<int>(y => y == 1))).Returns(testGroup);

            var usersServiceMock = new Mock<IUserService>();
            usersServiceMock
                .Setup(x => x.Add(It.Is<ApplicationUser>(u => u.Group.Name == testGroup.Name), It.Is<string>(p => p == testModel.Password)))
                .Verifiable();

            var controller = new UserController(new Mock<IAccountRequestService>().Object, usersServiceMock.Object, groupsServiceMock.Object);
            controller.WithCallTo(x => x.Create(testModel, 42))
                .ShouldRedirectTo(url: "/administration/request/all");

            usersServiceMock
                .Verify(x => x.Add(It.Is<ApplicationUser>(u => u.Group.Name == testGroup.Name), It.Is<string>(p => p == testModel.Password)), Times.Once);
        }

        [Test]
        public void DeleteShouldWorkCorrectly()
        {
            var testId = "testId";
            var usersServiceMock = new Mock<IUserService>();
            usersServiceMock.Setup(x => x.Delete(It.Is<string>(s => s == testId))).Verifiable();

            var controller = new UserController(new Mock<IAccountRequestService>().Object, usersServiceMock.Object, new Mock<IGroupService>().Object);
            controller.WithCallTo(x => x.Delete(testId))
                .ShouldRedirectTo("/administration/user/all");

            usersServiceMock.Verify(x => x.Delete(It.Is<string>(s => s == testId)), Times.Once);
        }
    }
}
