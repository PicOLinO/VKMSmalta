#region Usings

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Network;
using Vkm.ComplexSim.Services;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public class RegisterDialogViewModel : LoginDialogViewModel
    {
        public RegisterDialogViewModel(IDialogFactory dialogFactory, IPasswordSupplier passwordSupplier) : base(dialogFactory, passwordSupplier)
        {
        }

        public Student SelectedStudent
        {
            get { return GetProperty(() => SelectedStudent); }
            set { SetProperty(() => SelectedStudent, value); }
        }

        public Team SelectedTeam
        {
            get { return GetProperty(() => SelectedTeam); }
            set { SetProperty(() => SelectedTeam, value, OnSelectedTeamChanged); }
        }

        public ObservableCollection<Student> Students
        {
            get { return GetProperty(() => Students); }
            set { SetProperty(() => Students, value); }
        }

        public ObservableCollection<Team> Teams
        {
            get { return GetProperty(() => Teams); }
            set { SetProperty(() => Teams, value); }
        }

        private SecureString ConfirmPassword => PasswordSupplier.GetConfirmPassword();
        private INetworkService NetworkService => GetService<INetworkService>();

        public async Task LoadTeamsWithStudentsWithoutLogins()
        {
            var teamWithStudentsWithoutLogins = await NetworkService.GetTeamsAndStudentsWithoutLogin();
            Teams = new ObservableCollection<Team>();

            foreach (var team in teamWithStudentsWithoutLogins)
            {
                var newTeam = new Team {Id = team.Id, Number = team.Number};
                var students = team.Students.Select(student => new Student
                                                               {
                                                                   Id = student.Id,
                                                                   FullName = $"{student.LastName} {student.FirstName} {student.MiddleName}"
                                                               })
                                   .ToList();
                newTeam.Students = students;
                Teams.Add(newTeam);
            }

            SelectedTeam = Teams.FirstOrDefault();
            SelectedStudent = SelectedTeam?.Students.FirstOrDefault();
        }

        private async Task<bool> RegisterUser()
        {
            var password = Password.ConvertToUnsecureString();
            var confirmPassword = ConfirmPassword.ConvertToUnsecureString();

            if (password != confirmPassword)
            {
                var dialogFactory = GetService<IDialogFactory>();
                dialogFactory.ShowWarningMessage("Пароли должны совпадать");
                return false;
            }

            var registerData = new RegisterDataDto
                               {
                                   Credential = new NetworkCredential(Login, Password),
                                   StudentId = SelectedStudent.Id
                               };

            var success = await NetworkService.Register(registerData);

            if (success)
            {
                return true;
            }

            throw new Exception("Ошибка на сервере");
        }

        private void OnSelectedTeamChanged()
        {
            Students = new ObservableCollection<Student>(SelectedTeam.Students);
            SelectedStudent = Students.FirstOrDefault();
        }

        protected override async Task OnClickOk()
        {
            try
            {
                var success = await RegisterUser();
                if (success)
                {
                    CloseCommand.Execute(true);
                }
            }
            catch (Exception e)
            {
                DialogFactory.ShowErrorMessage(e);
            }
        }
    }
}