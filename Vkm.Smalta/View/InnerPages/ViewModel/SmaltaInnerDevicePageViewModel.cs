#region Usings

using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;

#endregion

namespace Vkm.Smalta.View.InnerPages.ViewModel
{
    public class SmaltaInnerDevicePageViewModel : MainInnerDevicePageViewModel
    {
        public SmaltaInnerDevicePageViewModel(Enum pageKey, string background, Algorithm currentAlgorithm) : base(pageKey, background, currentAlgorithm)
        {
            InitializeElements();
        }

        protected sealed override void InitializeElements()
        {
            switch (PageKey)
            {
                case SmaltaInnerRegionPage.LO01P:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   //Тумблеры в середине
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_1channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(299, 409).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_2channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(343, 409).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_3channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(386, 409).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_4channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(429, 409).Thumbler().Please(),

                                   //Подсветка в середине
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_1channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(309, 540).LightBox("ПРИЕМНИК\nI КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_2channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(353, 540).LightBox("ПРИЕМНИК\nII КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_3channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(396, 540).LightBox("ПРИЕМНИК\nIII КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_4channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(441, 541).LightBox("ПРИЕМНИК\nIV КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_antenna_leftside").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(483, 540).LightBox("АНТЕННА\nЛЕВЫЙ БОРТ").Please(),

                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_1channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(309, 628).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_2channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(353, 628).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_3channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(396, 628).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_4channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(441, 627).LightBox("ПЕРЕДАТЧИК\nI КАНАЛ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_antenna_rightside").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(484, 627).LightBox("АНТЕННА\nПРАВЫЙ БОРТ").Please(),

                                   GiveMe.Element().On(PageKey).WithName("lo01p_defect_1channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(311, 715).LightBox("НЕИСПРАВНОСТЬ\nI КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_defect_2channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(354, 715).LightBox("НЕИСПРАВНОСТЬ\nII КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_defect_3channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(396, 714).LightBox("НЕИСПРАВНОСТЬ\nIII КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_defect_4channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(441, 714).LightBox("НЕИСПРАВНОСТЬ\nIV КАНАЛ").WithBackgroundColor(Colors.Orange).Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_1cooler").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(484, 714).LightBox("ВЕНТИЛЯТОР I").Please(),

                                   GiveMe.Element().On(PageKey).WithName("lo01p_glow_on").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(310, 802).LightBox("НАКАЛ\nВКЛЮЧЕН").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_simulator").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(353, 802).LightBox("ИМИТАТОР").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_modulation").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(441, 801).LightBox("МОДУЛЯЦИЯ").Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_2cooler").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(484, 801).LightBox("ВЕНТИЛЯТОР II").Please(),

                                   //Тумблеры снизу
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_simulator").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(582, 385).Thumbler()
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_simulator")
                                                                     .WithDependencyValue(0, 0)
                                                                     .WithDependencyValue(1, 1)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_antenna_leftside").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(584, 662).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_antenna_rightside").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(586, 752).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(656, 753).Thumbler().Please(),

                                   //Кнопки снизу
                                   GiveMe.Element().On(PageKey).WithName("lo01p_button_reciever_glow_on").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(581, 463).BigButton()
                                         .WithDependencySecureElement("lo01p_button_reciever_glow_off")
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_glow_on")
                                                                     .WithDependencyValue(1, 1)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01r_lamp_heating")
                                                                     .WithDependencyValue(1, 1)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01r_lamp_heating")
                                                                     .WithDependencyValue(1, 0)
                                                                     .WithDelay(5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_1channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_2channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_3channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_4channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                     .WithDependencyValue(1, 1)
                                                                     .WithDelay(10)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_button_reciever_glow_off").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(655, 462).BigButton()
                                         .WithDependencySecureElement("lo01p_button_reciever_glow_on")
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_glow_on")
                                                                     .WithDependencyValue(1, 0)
                                                                     .WithDelay(8)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_1channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_2channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_3channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_reciever_4channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_button_transmitter_on").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(580, 554).BigButton()
                                         .WithDependencySecureElement("lo01p_button_transmitter_off")
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_1channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_2channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_3channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_4channel")
                                                                     .WithDependencyValue(1, 1)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_button_transmitter_off").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(655, 554).BigButton()
                                         .WithDependencySecureElement("lo01p_button_transmitter_on")
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_1channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_2channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_3channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_4channel")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_button_control").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(656, 371).BigButton().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_button_eject").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(655, 645).BigButton().Please(),

                                   //Тумблеры справа сверху
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_power").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(68, 1178).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_cold").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(67, 1226).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_autosarpp").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(69, 1278).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_aircontrol").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(70, 1329).Thumbler().Please(),

                                   //Тумблеры справа снизу
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_cooler").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(636, 1170).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light_maintance").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(637, 1217).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light_advanced").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(635, 1262).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_thumbler_light_table").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(636, 1308).Thumbler().Please(),

                                   //Стрелки слева
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_1channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(96, 127).LittleArrow().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_2channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(288, 127).LittleArrow().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_3channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(478, 128).LittleArrow().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_reciever_4channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(665, 128).LittleArrow().Please(),

                                   //Стрелки справа
                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_1channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(103, 1004).LittleArrow().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_2channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(294, 1004).LittleArrow().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_3channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(479, 1003).LittleArrow().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01p_transmitter_4channel_arrow").WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(667, 999).LittleArrow().Please()
                               };
                    break;
                case SmaltaInnerRegionPage.LO01R:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   //Тумблеры приемника-передатчика
                                   GiveMe.Element().On(PageKey).WithName("lo01r_reciever_1channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(400, 104).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_reciever_2channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(400, 168).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_reciever_3channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(398, 236).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_reciever_4channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(395, 303).Thumbler().Please(),

                                   GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_1channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(394, 366).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_2channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(396, 435).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_3channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(394, 507).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_transmitter_4channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(393, 576).Thumbler().Please(),

                                   //Лампочки в середине устройства
                                   GiveMe.Element().On(PageKey).WithName("lo01r_lamp_network_27v").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(109, 829).Lamp().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_lamp_equal").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(258, 786).Lamp().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_lamp_+10v").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(257, 878).Lamp().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_lamp_heating").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(575, 836).Lamp().Please(),

                                   //Контролы управления в середине устройства
                                   GiveMe.Element().On(PageKey).WithName("lo01r_antenna_equal").At(309, 788).WithValueFrom(CurrentAlgorithm.StartStateOfElements).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01r_modulation").At(430, 806).WithValueFrom(CurrentAlgorithm.StartStateOfElements).WithStartupRotation(30).RotateStepWheel()
                                         .WithMaxValue(5).WithRotationStepDegrees(30).Please()
                               };
                    break;
                case SmaltaInnerRegionPage.LO01I_LO01K:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   //lo01I
                                   GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_1generator").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(301, 369).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_2generator").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(302, 523).Thumbler()
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         //////////////////////////////////////////////////////////////////////
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_3generator").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(443, 364).Thumbler()
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         //////////////////////////////////////////////////////////////////////
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01i_thumbler_4generator").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(439, 524).Thumbler()
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_1channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_2channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_3channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_reciever_4channel_arrow")
                                                                     .WithDependencyValue(0, -5)
                                                                     .WithDependencyValue(1, 5)
                                                                     .Please())
                                         //////////////////////////////////////////////////////////////////////
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_1channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_2channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_3channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .TypeOf(DependencyType.Add)
                                                                     .WithDependencyElementName("lo01p_transmitter_4channel_arrow")
                                                                     .WithDependencyValue(0, 2)
                                                                     .WithDependencyValue(1, -2)
                                                                     .Please())
                                         .Please(),

                                   //lo01K
                                   GiveMe.Element().On(PageKey).WithName("lo01k_modulation_13channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(262, 1140).Thumbler().Please(),
                                   GiveMe.Element().On(PageKey).WithName("lo01k_modulation_24channel").WithValueFrom(CurrentAlgorithm.StartStateOfElements).At(264, 1237).Thumbler().Please()
                               };
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}