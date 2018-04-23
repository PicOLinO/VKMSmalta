using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Domain;
using VKMSmalta.Network;
using VKMSmalta.Services;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class RegisterDialogViewModel : LoginDialogViewModel
    {
        public SecureString ConfirmPassword => PasswordSupplier.GetConfirmPassword();

        public RegisterDialogViewModel(IPasswordSupplier passwordSupplier) : base(passwordSupplier)
        {
            Initialize();
        }

        private void Initialize()
        {
            Task.Run(LoadTeamsWithStudentsWithoutLogins).Wait();
        }

        private async Task LoadTeamsWithStudentsWithoutLogins()
        {
            var teamWithStudentsWithoutLogins = await NetworkService.Instance.GetTeamsAndStudentsWithoutLogin();
            Teams = new ObservableCollection<Team>();

            foreach (var team in teamWithStudentsWithoutLogins)
            {
                var newTeam = new Team { Id = team.Id, Number = team.Number };
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

        public Team SelectedTeam
        {
            get { return GetProperty(() => SelectedTeam); }
            set { SetProperty(() => SelectedTeam, value, OnSelectedTeamChanged); }
        }

        private void OnSelectedTeamChanged()
        {
            Students = new ObservableCollection<Student>(SelectedTeam.Students);
        }

        public ObservableCollection<Team> Teams
        {
            get { return GetProperty(() => Teams); }
            set { SetProperty(() => Teams, value); }
        }

        public Student SelectedStudent
        {
            get { return GetProperty(() => SelectedStudent); }
            set { SetProperty(() => SelectedStudent, value); }
        }

        public ObservableCollection<Student> Students
        {
            get { return GetProperty(() => Students); }
            set { SetProperty(() => Students, value); }
        }

        protected override async Task OnClickCore()
        {
            var password = Password.ConvertToUnsecureString();
            var confirmPassword = ConfirmPassword.ConvertToUnsecureString();

            if (password != confirmPassword)
            {
                DialogFactory.ShowWarningMessage("Пароли должны совпадать");
                return;
            }

            var registerData = new RegisterDataDto
                                {
                                    Credential = new NetworkCredential(Login, Password),
                                    StudentId = SelectedStudent.Id
            };

            var success = await NetworkService.Instance.Register(registerData);

            if (success)
            {
                CloseCommand.Execute(null);
            }
            else
            {
                throw new Exception("Ошибка на сервере");
            }
        }
    }
}