using System.Collections.Generic;
using Gather.Scripts.Domain.Data;
using Ludiq.OdinSerializer.Utilities;
using UnityEngine;

namespace Gather.Scripts.Unity.Stage
{
    public class DebugPlayerScoreView : MonoBehaviour
    {
        private ScoreManager _scoreManager;
        public void Setup(ScoreManager scoreManager)
        {
            _scoreManager = scoreManager;
        }

        private void OnGUI()
        {
            var index = 0;
            _scoreManager.PlayerScoreTable.ForEach(x =>
            {
                string text = x.Key + ": " + x.Value;
                GUI.TextField(new Rect(10, 10 + index * 20, 100, 20), text);
                index++;
            });
        }
    }
}
