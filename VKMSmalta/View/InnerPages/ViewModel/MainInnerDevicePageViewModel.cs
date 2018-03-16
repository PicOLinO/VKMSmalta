using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.DSL;
using VKMSmalta.View.DSL.Other;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class MainInnerDevicePageViewModel : InnerPageViewModelBase
    {
        private readonly HistoryService historyService;
        private readonly Algorithm currentAlgorithm;

        public MainInnerDevicePageViewModel(HistoryService historyService, InnerRegionPage pageKey, string background, Algorithm currentAlgorithm) : base(pageKey, background)
        {
            this.historyService = historyService;
            this.currentAlgorithm = currentAlgorithm;
            InitializeElements();  //TODO: ВЫШЕ!
        }

        private void InitializeElements()
        {
            if (PageKey == InnerRegionPage.L001P)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           //Тумблеры в середине
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(280,341).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(323,340).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(367,341).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(90).At(411,341).Thumbler(historyService).Please(),

                           //Подсветка в середине
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(309,540).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(353,540).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396,540).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441,541).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_antenna_leftside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(483,540).LightBox().Please(),

                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(309,628).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(353,628).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396,628).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441,627).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_antenna_rightside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(484,627).LightBox().Please(),

                           GiveMe.Element().On(PageKey).WithName("l001p_defect_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(311,715).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_defect_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(354,715).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_defect_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396,714).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_defect_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441,714).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_1cooler").WithValueFrom(currentAlgorithm.StartStateOfElements).At(484,714).LightBox().Please(),

                           GiveMe.Element().On(PageKey).WithName("l001p_glow_on").WithValueFrom(currentAlgorithm.StartStateOfElements).At(310,802).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_simulator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(353,802).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_modulation").WithValueFrom(currentAlgorithm.StartStateOfElements).At(441,801).LightBox().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_2cooler").WithValueFrom(currentAlgorithm.StartStateOfElements).At(484,801).LightBox().Please(),

                           //Тумблеры снизу
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_simulator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(582,385).Thumbler(historyService)
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_simulator")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .Please())
                                 .Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_antenna_leftside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(584,662).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_antenna_rightside").WithValueFrom(currentAlgorithm.StartStateOfElements).At(586,752).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_light").WithValueFrom(currentAlgorithm.StartStateOfElements).At(656,753).Thumbler(historyService).Please(),

                           //Кнопки снизу
                           GiveMe.Element().On(PageKey).WithName("l001p_button_reciever_glow_on").WithValueFrom(currentAlgorithm.StartStateOfElements).At(581,463).BigButton(historyService)
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_glow_on")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001r_lamp_heating")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001r_lamp_heating")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.ToZeroTwoCount)
                                                             .WithDelay(5)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_1channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_2channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_3channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_4channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_1channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_2channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_3channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_reciever_4channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .WithDelay(10)
                                                             .Please())
                                 .Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_button_reciever_glow_off").WithValueFrom(currentAlgorithm.StartStateOfElements).At(655,462).BigButton(historyService)
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_glow_on")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.ReverseTwoCount)
                                                             .Please())
                                 .Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_button_transmitter_on").WithValueFrom(currentAlgorithm.StartStateOfElements).At(580,554).BigButton(historyService)
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_1channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_2channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_3channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_4channel")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.EqualsTwoCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_1channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.ToFiveOneCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_2channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.ToFiveOneCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_3channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.ToFiveOneCount)
                                                             .Please())
                                 .WithDependencyAction(GiveMe.DependencyAction()
                                                             .WithDependencyElementName("l001p_transmitter_4channel_arrow")
                                                             .WithDefaultDependencyValues(DependencyActionsDefaultValues.ToFiveOneCount)
                                                             .Please())
                                 .Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_button_transmitter_off").WithValueFrom(currentAlgorithm.StartStateOfElements).At(655,554).BigButton(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_button_control").WithValueFrom(currentAlgorithm.StartStateOfElements).At(656,371).BigButton(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_button_eject").WithValueFrom(currentAlgorithm.StartStateOfElements).At(655,645).BigButton(historyService).Please(),
                           
                           //Тумблеры справа сверху
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_power").WithValueFrom(currentAlgorithm.StartStateOfElements).At(68,1178).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_cold").WithValueFrom(currentAlgorithm.StartStateOfElements).At(67,1226).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_autosarpp").WithValueFrom(currentAlgorithm.StartStateOfElements).At(69,1278).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_aircontrol").WithValueFrom(currentAlgorithm.StartStateOfElements).At(70,1329).Thumbler(historyService).Please(),
                           
                           //Тумблеры справа снизу
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_cooler").WithValueFrom(currentAlgorithm.StartStateOfElements).At(636,1170).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_light_maintance").WithValueFrom(currentAlgorithm.StartStateOfElements).At(637,1217).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_light_advanced").WithValueFrom(currentAlgorithm.StartStateOfElements).At(635,1262).Thumbler(historyService).Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_thumbler_light_table").WithValueFrom(currentAlgorithm.StartStateOfElements).At(636,1308).Thumbler(historyService).Please(),

                           //Стрелки слева
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_1channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(96,127).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_2channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(288,127).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_3channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(478,128).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_reciever_4channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(665,128).LittleArrow().Please(),

                           //Стрелки справа
                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_1channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(103,1004).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_2channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(294,1004).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_3channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(479,1003).LittleArrow().Please(),
                           GiveMe.Element().On(PageKey).WithName("l001p_transmitter_4channel_arrow").WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(35).At(667,999).LittleArrow().Please(),
                       };
            }

            if (PageKey == InnerRegionPage.L001R)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                           {
                               //Тумблеры приемника-передатчика
                               GiveMe.Element().On(PageKey).WithName("l001r_reciever_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(400,104).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_reciever_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(400,168).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_reciever_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(398,236).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_reciever_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(395,303).Thumbler(historyService).Please(),

                               GiveMe.Element().On(PageKey).WithName("l001r_transmitter_1channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(394,366).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_transmitter_2channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(396,435).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_transmitter_3channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(394,507).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_transmitter_4channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(393,576).Thumbler(historyService).Please(),

                               //Лампочки в середине устройства
                               GiveMe.Element().On(PageKey).WithName("l001r_lamp_network_27v").WithValueFrom(currentAlgorithm.StartStateOfElements).At(109,829).Lamp().Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_lamp_equal").WithValueFrom(currentAlgorithm.StartStateOfElements).At(258,786).Lamp().Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_lamp_+10v").WithValueFrom(currentAlgorithm.StartStateOfElements).At(257,878).Lamp().Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_lamp_heating").WithValueFrom(currentAlgorithm.StartStateOfElements).At(575,836).Lamp().Please(),

                               //Контролы управления в середине устройства
                               GiveMe.Element().On(PageKey).WithName("l001r_antenna_equal").At(309,788).WithValueFrom(currentAlgorithm.StartStateOfElements).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001r_modulation").At(430,806).WithValueFrom(currentAlgorithm.StartStateOfElements).WithStartupRotation(30).RotateWheel(historyService)
                                     .WithMaxValue(5).WithRotationStepDegrees(30).Please(),
                               
                           };
            }

            if (PageKey == InnerRegionPage.L001I_L001K)
            {
                Elements = new ObservableCollection<ElementViewModelBase>
                           {
                               //L001I
                               GiveMe.Element().On(PageKey).WithName("l001i_thumbler_1generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(301,369).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001i_thumbler_2generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(302,523).Thumbler(historyService)
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_reciever_1channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.AddedFiveTwoCount)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_reciever_2channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.AddedFiveTwoCount)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_reciever_3channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.AddedFiveTwoCount)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_reciever_4channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.AddedFiveTwoCount)
                                                                 .Please())
                                     //////////////////////////////////////////////////////////////////////
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_transmitter_1channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.RemoveTwoTwoCount)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_transmitter_2channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.RemoveTwoTwoCount)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_transmitter_3channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.RemoveTwoTwoCount)
                                                                 .Please())
                                     .WithDependencyAction(GiveMe.DependencyAction()
                                                                 .TypeOf(DependencyType.Add)
                                                                 .WithDependencyElementName("l001p_transmitter_4channel_arrow")
                                                                 .WithDefaultDependencyValues(DependencyActionsDefaultValues.RemoveTwoTwoCount)
                                                                 .Please())
                                     .Please(),
                               GiveMe.Element().On(PageKey).WithName("l001i_thumbler_3generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(443,364).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001i_thumbler_4generator").WithValueFrom(currentAlgorithm.StartStateOfElements).At(439,524).Thumbler(historyService).Please(),

                               //L001K
                               GiveMe.Element().On(PageKey).WithName("l001k_modulation_13channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(262,1140).Thumbler(historyService).Please(),
                               GiveMe.Element().On(PageKey).WithName("l001k_modulation_24channel").WithValueFrom(currentAlgorithm.StartStateOfElements).At(264,1237).Thumbler(historyService).Please(),
                           };
            }
        }
    }
}