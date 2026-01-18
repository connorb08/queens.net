namespace Queens.Extensions;

internal static partial class LoggerExtensions
{
    extension<T>(ILogger<T> logger)
    {
        internal void PlaceQueen(int cellId, string reason) => LogMessages.PlaceQueen(logger, cellId, reason);
        internal void PlaceCross(int cellId, string reason) => LogMessages.PlaceCross(logger, cellId, reason);
    }

    private static partial class LogMessages
    {
        [LoggerMessage(Level = LogLevel.Debug, Message = "Placing Queen in cell {CellId}: {Reason}")]
        public static partial void PlaceQueen(ILogger logger, int cellId, string reason);

        [LoggerMessage(Level = LogLevel.Debug, Message = "Placing Cross in Cell ({CellId}): {Reason}")]
        public static partial void PlaceCross(ILogger logger, int cellId, string reason);
    }
}
