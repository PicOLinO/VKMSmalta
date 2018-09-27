#region Usings

using System;

#endregion

namespace Vkm.Smalta.Domain
{
    public class ExamineResultProperties
    {
        /// <summary>
        /// Процент наличия эталонных действий в действиях пользователя
        /// </summary>
        public double PercentageOfEthalonActionsInUserActions { get; set; }

        /// <summary>
        /// Процент правильного порядка выполнения действий пользователя
        /// </summary>
        public double PercentageOfEthalonActionsRightOrderInUserActions { get; set; }

        /// <summary>
        /// Количество ошибочных действий пользователя
        /// </summary>
        public int WrongActionsCount { get; set; }

        public int GetValue()
        {
            var value = PercentageOfEthalonActionsInUserActions * PercentageOfEthalonActionsRightOrderInUserActions * 5 - WrongActionsCount;

            if (value < 0)
            {
                value = 0;
            }

            return (int) Math.Round(value);
        }
    }
}