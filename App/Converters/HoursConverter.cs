using System;
using BerlinClock.App.Extensions;
using BerlinClock.App.Shared;

namespace BerlinClock.App.Converters
{
    public class HoursConverter : BaseConverter, IConvert
    {
        private const int MinLimit = 0;
        private const int MaxLimit = 24;

        #region rows init

        private readonly string[] _topRow = { ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription() };

        private readonly string[] _bottomRow = { ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription(),
                                            ColorsEnum.Off.GetDescription() };

        #endregion

        public string Convert(int hours)
        {
            Validate(hours);
            int topRowRedBlocksCount = hours / Constants.HoursDivider;
            var bottomRowRedBlocksCount = hours - topRowRedBlocksCount * Constants.HoursDivider;
            UpdateRow(_topRow, topRowRedBlocksCount, ColorsEnum.Red.GetDescription());
            UpdateRow(_bottomRow, bottomRowRedBlocksCount, ColorsEnum.Red.GetDescription());
            return PrepareResponse();
        }

        protected override void Validate(int hours)
        {
            if (hours < MinLimit)
            {
                throw new ArgumentException("Hours must be equal or greater then " + MinLimit);
            }

            if (hours > MaxLimit)
            {
                throw new ArgumentException("Hours must be equal or less then " + MaxLimit);
            }
        }

        protected override string PrepareResponse()
        {
            return string.Join("", _topRow) + Environment.NewLine + string.Join("", _bottomRow);
        }
    }
}
