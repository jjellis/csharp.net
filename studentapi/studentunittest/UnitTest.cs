using System;
using Xunit;
using studentapi.Controllers;
using studentapi.Models;
using studentapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace studentunittest
{
    public class UnitTest
    {
        [Fact]
        public void Post_ShouldReturnBadRequestIfBirttDateIsInFuture()
        {
            
           Student student = new Student()
           {
              
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2999, 1, 1), // in the future
                Email = "test@test.com",
                Phone = "555-555-5555"
            };
            var result = TryPost(student);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void Post_ShouldReturnBadRequestIfBirttDateIsToOld()
        {
            
            Student student = new Student()
            {

                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1940, 1, 1), // too old
                Email = "test@test.com",
                Phone = "555-555-5555"
            };
            var result = TryPost(student);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        public IActionResult TryPost(Student student)
        {
            StudentsController controller = new StudentsController(new StudentService());
            var result = controller.Post(student);
            return result;
        }
    }
}
