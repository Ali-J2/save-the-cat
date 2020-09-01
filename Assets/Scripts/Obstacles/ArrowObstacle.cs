using UnityEngine;

namespace SaveTheCat
{
    public class ArrowObstacle : MonoBehaviour
    {
        public enum ArrowType { Left, Right, LeftMost, RightMost };
        public ArrowType arrowType;
    }
}
