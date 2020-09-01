using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveTheCat
{
    public class LaneRunner : Player
    {
        [SerializeField]
        private float laneWidth;
        [SerializeField]
        private int laneCount;

        [SerializeField]
        public int lane   // property
        {
            get;   // get method
            private set; // set method
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerMask.NameToLayer("Traps") == other.gameObject.layer)
            {
                Debug.Log("You dead.");
            }

            if (LayerMask.NameToLayer("Obstacles") == other.gameObject.layer)
            {
                if (other.GetComponent<ArrowObstacle>())
                {
                    ChangeLane(other.GetComponent<ArrowObstacle>());
                }
            }
        }

        public void ChangeLane(ArrowObstacle arrow)
        {
            disableCollider(1);
            if(arrow.arrowType == ArrowObstacle.ArrowType.LeftMost)
            {
                lane = 0;
            } else if (arrow.arrowType == ArrowObstacle.ArrowType.Left)
            {
                lane = Mathf.Max(0, lane - 1);
            }
            else if (arrow.arrowType == ArrowObstacle.ArrowType.RightMost)
            {
                lane = laneCount - 1;
            }
            else if (arrow.arrowType == ArrowObstacle.ArrowType.Right)
            {
                lane = Mathf.Min(lane + 1, laneCount - 1);
            }

            Vector3 newPos = new Vector3(0, 0, -lane * laneWidth);
            iTween.MoveTo(this.gameObject, iTween.Hash("position", newPos, "islocal", true));

            Debug.Log("moved to lane " + lane);
        }
    }
}