using UnityEngine;
using UnityEngine.Serialization;

namespace Map
{
    public class EndlessMap : MonoBehaviour
    {
        [SerializeField][FormerlySerializedAs("Map Pieces")] 
        private GameObject[] mapPieces;

        private int _currentIndex = 0;
        private Vector3 _lastPosition = Vector3.zero;

        private void Awake()
        {
            _lastPosition = mapPieces[^1].transform.position;
        }

        public void ContinueMap()
        {
            var newPosition = _lastPosition + new Vector3(0, 0, 9);
        
            mapPieces[_currentIndex].transform.position = newPosition;
            _lastPosition = newPosition;

            _currentIndex = (_currentIndex + 1) % mapPieces.Length;
        }
    }
}
