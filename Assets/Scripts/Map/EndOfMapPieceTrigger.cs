using UnityEngine;

namespace Map
{
    public class EndOfMapPieceTrigger : MonoBehaviour
    {
        private static EndlessMap _endlessMap;

        private void Awake()
        {
            _endlessMap = FindObjectOfType<EndlessMap>();
        }

        private void OnTriggerExit(Collider other)
        {
            _endlessMap.ContinueMap();
        }
    }
}
