using System;
using BerlinClock.App.Extensions;
using BerlinClock.App.Shared;

namespace BerlinClock.App.Converters
{
    public class MinutesConverter : BaseConverter, IConvert
    {
        private const int MinLimit = 0;
        private const int MaxLimit = 60;

        #region rows init

        private readonly string[] _topRow = { ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription() };

        private readonly string[] _bottomRow = { ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription() };

        #endregion

        public string Convert(int minutes)
        {
            Validate(minutes);
            int topRowColoredBlocks = minutes / Constants.MinutesDivider;
            var bottomRowYellowBlocksCount = minutes - topRowColoredBlocks * Constants.MinutesDivider;
            UpdateTopRow(_topRow, topRowColoredBlocks);
            UpdateRow(_bottomRow, bottomRowYellowBlocksCount, ColorsEnum.Yellow.GetDescription());
            return PrepareResponse();
        }

        protected override void Validate(int minutes)
        {
            if (minutes < MinLimit)
            {
                throw new ArgumentException("Minutes must be equal or greater then " + MinLimit);
            }

            if (minutes >= MaxLimit)
            {
                throw new ArgumentException("Minutes must be less then " + MaxLimit);
            }
        }

        protected override string PrepareResponse()
        {
            return string.Join("", _topRow) + Environment.NewLine + string.Join("", _bottomRow);
        }

        private void UpdateTopRow(string[] arr, int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                arr[i] = GetColorForTopRow(i);
            }
        }

        private string GetColorForTopRow(int iteration)
        {
            return iteration != 0 && iteration % 3 == 2 ? ColorsEnum.Red.GetDescription() : ColorsEnum.Yellow.GetDescription();
        }
    }
}
