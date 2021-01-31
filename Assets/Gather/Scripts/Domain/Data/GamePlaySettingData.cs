using System;

namespace Gather.Scripts.Domain.Data
{
    [Serializable]
    public class GamePlaySettingData
    {
        public int CorrectCount { get; }
        public int CorrectInterval { get; }

        public GamePlaySettingData(int correctCount,  int correctInterval)
        {
            CorrectCount = correctCount;
            CorrectInterval = correctInterval;
        }
    }
}
