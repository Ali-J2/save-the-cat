using Dreamteck.Forever;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class ArrowObstacle : MonoBehaviour
    {
        public enum ArrowType { Left, Right, LeftMost, RightMost };
        public ArrowType arrowType;
    }
}
