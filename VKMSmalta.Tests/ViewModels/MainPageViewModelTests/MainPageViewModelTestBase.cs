#region Usings

using NUnit.Framework;
using VKMSmalta.Domain;
using VKMSmalta.ViewModel;

#endregion

namespace VKMSmalta.Tests.ViewModels.MainPageViewModelTests
{
    public class MainPageViewModelTestBase : TestBase
    {
        protected override void Setup()
        {
            base.Setup();
            ViewModel = new MainPageViewModel();
        }

        protected MainPageViewModel ViewModel;

        [Test]
        public void AllCommandsAreCreated()
        {
            var vm = new MainPageViewModel();

            Assert.That(vm.GoExamineCommand, Is.Not.Null);
            Assert.That(vm.GoTrainingCommand, Is.Not.Null);
            Assert.That(vm.LoginCommand, Is.Not.Null);
            Assert.That(vm.RegisterCommand, Is.Not.Null);
            Assert.That(vm.ShowInfoCommand, Is.Not.Null);
        }

        [Test]
        public void WhenUserIsAuthorizedAndHaveCurrentUserThenViewModelKnowsAboutIt()
        {
            var userFullName = "Тестер Тест Тестович";
            App.CurrentUser = new Student
                              {
                                  Id = 1,
                                  FullName = userFullName
                              };

            var vm = new MainPageViewModel();

            Assert.That(vm.CurrentUserName, Is.EqualTo(userFullName));
        }

        [Test]
        public void WhenUserIsAuthorizedThenViewModelKnowsAboutIt()
        {
            App.IsAuthorized = true;

            var vm = new MainPageViewModel();

            Assert.That(vm.IsAuthorized, Is.True);
        }
    }
}