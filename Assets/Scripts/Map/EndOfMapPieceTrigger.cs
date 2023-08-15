using Player;
using UnityEngine;

namespace Map
{
    public class EndOfMapPieceTrigger : MonoBehaviour
    {
        private static EndlessMap _endlessMap;
        private PlayerScore _playerScore;

        private void Awake()
        {
            _endlessMap = FindObjectOfType<EndlessMap>();
            _playerScore = FindObjectOfType<PlayerScore>();
        }

        private void OnTriggerExit(Collider other)
        {
            _endlessMap.ContinueMap();
            _playerScore.Increase();
        }
    }
}
