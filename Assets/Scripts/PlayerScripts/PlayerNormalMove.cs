using Dreamteck.Forever;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using System;

namespace SaveTheCat
{
    public class PlayerNormalMove : Player
    {
        private Animator anim;
        private LaneRunner runner;
        private float startSpeed;
        [SerializeField]
        private float playerSpeedStep; //time in seconds until speed ramps up

        private void Awake()
        {
            GameControl.Instance.playerSpeedStep = playerSpeedStep;
        }

        // Start is called before the first frame update
        void Start()
        {
            runner = this.GetComponent<LaneRunner>();
            anim = this.GetComponent<Animator>();
            startSpeed = runner.followSpeed;
            AdjustPlayerSpeed(this, EventArgs.Empty);
        }

        IEnumerator<float> _animateDirection(bool left)
        {
            if (left)
            {
                anim.SetFloat("Horizontal", -1);
            }
            else
            {
                anim.SetFloat("Horizontal", 1);
            }

            yield return Timing.WaitForSeconds(runner.laneSwitchSpeed);
            anim.SetFloat("Horizontal", 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerMask.NameToLayer("Traps") == other.gameObject.layer)
            {
                //Debug.Log("You dead.");
            }

            if (LayerMask.NameToLayer("Obstacles") == other.gameObject.layer)
            {
                if (other.GetComponent<ArrowObstacle>())
                {
                    MoveViaArrow(other.GetComponent<ArrowObstacle>());
                }
            }
        }

        void MoveViaArrow(ArrowObstacle arrow)
        {
            if (runner)
            {
                if (arrow.arrowType == ArrowObstacle.ArrowType.Left)
                {
                    runner.lane--;
                }
                else if (arrow.arrowType == ArrowObstacle.ArrowType.Right)
                {
                    runner.lane++;
                }
                else if (arrow.arrowType == ArrowObstacle.ArrowType.LeftMost)
                {
                    runner.lane = 1;
                }
                else if (arrow.arrowType == ArrowObstacle.ArrowType.RightMost)
                {
                    runner.lane = 3;
                }
            }
        }

        void AdjustPlayerSpeed(object sender, EventArgs e)
        {
            runner.followSpeed = startSpeed + GameControl.Instance.gameSpeed;
            GameControl.Instance.OnGameSpeedChanged += AdjustPlayerSpeed;
        }
    }
}