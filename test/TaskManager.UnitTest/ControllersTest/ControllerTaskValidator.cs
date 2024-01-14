using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManager.Core.Consts;
using TaskManager.Core.Interfaces.Repositories;
using TaskManager.Core.Services;
using TaskManager.Web.Controllers;
using TaskManager.Web.Middlewares.Mappings;
using TaskManager.Web.Models;

namespace TaskManager.UnitTest.ControllersTest
{
    public class ControllerTaskValidator
    {
        [Fact]
        public void Get_Index_Return_All_Tasks()
        {
            // Arrange
            var repository = GetRepositoryMock();
            var taskService = new TaskService(repository.Object);
            var mapper = GetMapper();
            var controller = new TaskController(taskService, mapper);

            // Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<TaskViewModel>>(viewResult.Model);
            Assert.Equal(3, model.Count);
        }

        [Fact]
        public void Post_Create_Return_RedirectToAction_Index()
        {
            // Arrange
            var repository = GetRepositoryMock();
            var taskService = new TaskService(repository.Object);
            var mapper = GetMapper();
            var controller = new TaskController(taskService, mapper);

            // Act
            var task = new Core.Entities.Task
            {
                Id = 4,
                Description = "Task 4",
                Priority = 4,
                Status = Status.InProgress
            };
            var model = mapper.Map<TaskViewModel>(task);
            var result = controller.Create(model);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Get_Edit_Return_Task()
        {
            // Arrange
            var repository = GetRepositoryMock();
            var taskService = new TaskService(repository.Object);
            var mapper = GetMapper();
            var controller = new TaskController(taskService, mapper);

            // Act
            var result = controller.Edit(1);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<TaskViewModel>(viewResult.Model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public void Put_Edit_Return_Json()
        {
            // Arrange
            var repository = GetRepositoryMock();
            var taskService = new TaskService(repository.Object);
            var mapper = GetMapper();
            var controller = new TaskController(taskService, mapper);

            // Act
            var task = new Core.Entities.Task
            {
                Id = 1,
                Description = "Task 1",
                Priority = 1,
                Status = Status.InProgress
            };
            var model = mapper.Map<TaskViewModel>(task);
            var result = controller.Edit(model);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var url = Assert.IsType<string>(jsonResult.Value);
            Assert.Equal("/Task/Index", url);
        }

        [Fact]
        public void Delete_Delete_Return_Json()
        {
            // Arrange
            var repository = GetRepositoryMock();
            var taskService = new TaskService(repository.Object);
            var mapper = GetMapper();
            var controller = new TaskController(taskService, mapper);

            // Act
            var result = controller.Delete(1);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var url = Assert.IsType<string>(jsonResult.Value);
            Assert.Equal("/Task/Index", url);
        }

        #region private methods

        private static Mock<IRepository<Core.Entities.Task>> GetRepositoryMock()
        {
            var repository = new Mock<IRepository<Core.Entities.Task>>();
            repository.Setup(x => x.Add(It.IsAny<Core.Entities.Task>()));
            repository.Setup(x => x.Update(It.IsAny<Core.Entities.Task>()));
            repository.Setup(x => x.Delete(It.IsAny<Core.Entities.Task>()));
            repository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Core.Entities.Task
            {
                Id = 1,
                Description = "Task 1",
                Priority = 1,
                Status = Status.InProgress
            });
            repository.Setup(x => x.GetAll()).Returns(new List<Core.Entities.Task>
            {
                new() {
                    Id = 1,
                    Description = "Task 1",
                    Priority = 1,
                    Status = Status.InProgress
                },
                new() {
                    Id = 2,
                    Description = "Task 2",
                    Priority = 2,
                    Status = Status.InProgress
                },
                new() {
                    Id = 3,
                    Description = "Task 3",
                    Priority = 3,
                    Status = Status.InProgress
                }
            }.AsQueryable());
            return repository;
        }

        private static Mapper GetMapper()
        {
            var profile = new MapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return new Mapper(configuration);
        }

        #endregion
    }
}
