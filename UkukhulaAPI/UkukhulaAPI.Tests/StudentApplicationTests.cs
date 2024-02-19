
// using Moq;
// using Microsoft.AspNetCore.Mvc;
// using UkukhulaAPI.Controllers;
// using UkukhulaAPI.Controllers.Request;
// using UkukhulaAPI.Data.Services;
// using UkukhulaAPI.Data.Models.View;
// using AutoMapper;

// namespace UkukhulaAPI.Tests.Controllers
// {
//     public class StudentApplicationControllerTests
//     {
//         [Fact]
//         public void InsertStudentApplication_ValidRequest_ReturnsOkResult()
//         {

//             var mockService = new Mock<ApplicationService>();
//             var controller = new StudentApplicationsController(mockService.Object,new Mock<IMapper>().Object);

//             var user = new StudentRegistrationVm
//             {
//                 FirstName = "Mxolisi",
//                 LastName = "Sibaya",
//                 Idnumber = "1234567890123",
//                 averageMark = 80,
//                 CourseOfStudy = "Computer Science",
//                 race = 1,
//                 HODId = 123,
//                 ApplicationMotivation = "Motivation text",
//                 BursaryAmount = 5000
//             };


//             var contact = new ContactVm
//             {
//                 ContactNumber = "1234567890",
//                 Email = "Mxo@example.com"
//             };

//             var request = new AddStudentApplicationRequest { User = user, Contact = contact };


//             var result = controller.insertStudentApplication(request);


//             Assert.IsType<OkResult>(result);
//         }

//         [Fact]
//         public void InsertStudentApplication_NullRequest_ReturnsBadRequest()
//         {
//             // Arrange
//             var mockService = new Mock<ApplicationService>();
//             var controller = new StudentApplicationsController(mockService.Object,new Mock<IMapper>().Object);

//             // Act
//             var result = controller.insertStudentApplication(null);

//             // Assert
//             Assert.IsType<BadRequestResult>(result);
//         }

//     }
// }
