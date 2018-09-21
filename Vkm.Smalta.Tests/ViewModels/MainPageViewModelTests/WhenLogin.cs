using NUnit.Framework;
using Vkm.Smalta.Domain;

namespace Vkm.Smalta.Tests.ViewModels.MainPageViewModelTests
{
    public class WhenLogin : MainPageViewModelTestBase
    {
        [Test]
        public void LoginDialogIsShown()
        {
            ViewModel.LoginCommand.Execute(null);

            Assert.That(DialogFactory.IsLoginDialogShown, Is.True);
        }

        [Test]
        [Ignore("Bad test")]
        public void IfUserIsLogInThenAppIsKnowsAboutIt()
        {
            ViewModel.LoginCommand.Execute(null);
            
            Assert.That(App.IsAuthorized, Is.True);
        }

        [Test]
        public void LoginUnfoUpdated()
        {
            var userFullName = "Тестер Тест Тестович";
            App.CurrentUser = new Student
                              {
                                  Id = 1,
                                  FullName = userFullName
                              };

            ViewModel.LoginCommand.Execute(null);

            Assert.That(ViewModel.CurrentUserName, Is.EqualTo(userFullName));
        }
    }
}