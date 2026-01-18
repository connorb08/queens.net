using Queens.Enums;
using Queens.Interfaces.Core.Variables;

namespace Queens.Extensions;

internal static partial class LoggerExtensions
{

    private static class Events
    {
        public const int AnalyzeGroup = 50;

        public const int RemoveCell = 99;
        public const int PlaceQueen = 100;
    }

    extension<T>(ILogger<T> logger)
    {
        internal void AnalyzeGroup(ICellGroup cellGroup)
        {
            string colorName = string.IsNullOrEmpty(cellGroup.ColorName) ? "" : $"({cellGroup.ColorName})";
            LogMessages.AnalyzeGroup(logger, cellGroup.Grouping.Name, cellGroup.Id, colorName);
        }
        internal void PlaceQueen(int cellId, string reason) => LogMessages.PlaceQueen(logger, cellId, reason);
        internal void PlaceCross(int cellId, string reason) => LogMessages.RemoveCell(logger, cellId, reason);
    }

    private static partial class LogMessages
    {

        [LoggerMessage(
            Level = LogLevel.Debug,
            EventId = Events.AnalyzeGroup,
            EventName = nameof(AnalyzeGroup),
            Message = "Analyzing {GroupName}({GroupId}){ColorName}"
        )]
        public static partial void AnalyzeGroup(ILogger logger, string groupName, int groupId, string colorName);

        [LoggerMessage(
            Level = LogLevel.Debug,
            EventId = Events.PlaceQueen,
            EventName = nameof(PlaceQueen),
            Message = "Placing Queen in cell {CellId}: {Reason}"
        )]
        public static partial void PlaceQueen(ILogger logger, int cellId, string reason);

        [LoggerMessage(
            Level = LogLevel.Debug,
            EventId = Events.RemoveCell,
            EventName = nameof(RemoveCell),
            Message = "Removing Cell({CellId}): {Reason}"
        )]
        public static partial void RemoveCell(ILogger logger, int cellId, string reason);
    }
}
