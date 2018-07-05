using NUnit.Framework;
using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Tests.ViewModels.MainPageViewModelTests
{
    public class WhenInitialize : MainPageViewModelTestBase
    {
        [Test]
        public void AllCommandsAreCreated()
        {
            ViewModel.Initialize();

            Assert.That(ViewModel.GoExamineCommand, Is.Not.Null);
            Assert.That(ViewModel.GoTrainingCommand, Is.Not.Null);
            Assert.That(ViewModel.LoginCommand, Is.Not.Null);
            Assert.That(ViewModel.RegisterCommand, Is.Not.Null);
            Assert.That(ViewModel.ShowInfoCommand, Is.Not.Null);
        }

        [Test]
        public void CurrentUserFullNameTakesFromApp()
        {
            var userFullName = "Тестер Тест Тестович";
            App.CurrentUser = new Student
                              {
                                  Id = 1,
                                  FullName = userFullName
                              };

            ViewModel.Initialize();

            Assert.That(ViewModel.CurrentUserName, Is.EqualTo(userFullName));
        }

        [Test]
        public void LoginInfoIsUpdated()
        {
            App.IsAuthorized = true;

            ViewModel.Initialize();

            Assert.That(ViewModel.IsAuthorized, Is.True);
        }
    }
}