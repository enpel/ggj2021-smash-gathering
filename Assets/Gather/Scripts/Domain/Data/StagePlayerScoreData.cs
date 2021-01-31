namespace Gather.Scripts.Domain.Data
{
    public class StagePlayerScoreData
    {
        public PlayerData PlayerData { get; }
        public int Score { get; private set; }

        public StagePlayerScoreData(PlayerData playerData)
        {
            PlayerData = playerData;
        }

        public void SetScore(int score)
        {
            Score = score;
        }

        public void Add(int addScore)
        {
            Score += addScore;
        }
    }
}
