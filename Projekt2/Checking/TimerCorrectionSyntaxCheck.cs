using System;

namespace Projekt2
{
    public class TimerCorrectionSyntaxCheck
    {
        public static bool IsTimerSyntaxCorrectOrWhereIsWrong(string timer)
        {
            string[] parsedTime = timer.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool includeSeconds = parsedTime.Length == 6;

            for (int i = 0; i < parsedTime.Length; i++)
            {
                string token = parsedTime[i];
                if (token == "*")
                    continue;

                int value;
                if (token.StartsWith("*/"))
                {
                    string step = token.Substring(2);
                    if (!int.TryParse(step, out value))
                        return (false);
                }
                else
                {
                    if (!int.TryParse(token, out value))
                        return (false);
                }

                (int maximumNumberThatCanBeSet, int minimumNumberThatCanBeSet, string nameOfTimeWeChecked) = SetMinMaxPossibleTime(i, includeSeconds);

                if (value < minimumNumberThatCanBeSet || value > maximumNumberThatCanBeSet)
                    return (false);
            }

            return (true);
        }

        private static (int max, int min, string whatTime) SetMinMaxPossibleTime(int positionInTiming, bool includeSeconds)
        {
            if (includeSeconds)
            {
                switch (positionInTiming)
                {
                    case 0: return (59, 0, "Second");
                    case 1: return (59, 0, "Minute");
                    case 2: return (23, 0, "Hour");
                    case 3: return (31, 1, "Day of Month");
                    case 4: return (12, 1, "Month");
                    case 5: return (6, 0, "Day of Week");
                    default:
                        return (0, -1, "");
                }
            }
            else
            {
                switch (positionInTiming)
                {
                    case 0: return (59, 0, "Minute");
                    case 1: return (23, 0, "Hour");
                    case 2: return (31, 1, "Day of Month");
                    case 3: return (12, 1, "Month");
                    case 4: return (6, 0, "Day of Week");
                    default:
                        return (0, -1, "");
                }
            }
        }
    }
}