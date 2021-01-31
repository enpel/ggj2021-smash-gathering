using System.Collections.Generic;
using Gather.Scripts.Domain.Data;

namespace Gather.Scripts.Unity
{
    public class StageScoreManager
    {
        private List<StagePlayerScoreData> _playerDatas = new List<StagePlayerScoreData>();

        public void AddPlayer(PlayerData playerData)
        {
            _playerDatas.Add(new StagePlayerScoreData(playerData));
        }

        public void RemovePlayer(PlayerData playerData)
        {
            var removeIndex = _playerDatas.FindIndex(x => x.PlayerData.ID == playerData.ID);
            _playerDatas.RemoveAt(removeIndex);
        }
        
        
        
    }
}