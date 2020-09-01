using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapButton : MonoBehaviour
    {
        public TrapStatus trapStatus;
        public GameObject[] trapObjects;
        bool pressedBefore;

        private void Start()
        {
            if (gameObject.GetComponent<Renderer>())
            {
                trapStatus.OnButtonPressed += ChangeButtonColor;
            }
        }

        private void ChangeButtonColor(object sender, EventArgs e)
        {
            if (!pressedBefore)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
        private void OnMouseDown()
        {
            if (trapStatus.IsInteractive())
            {
                trapStatus.TurnOffInteractivity();
                for (int i = 0; i < trapObjects.Length; i++)
                {
                    trapObjects[i].GetComponent<ITrap>().DisableTrap();
                }

                if (!pressedBefore)
                {
                    pressedBefore = true;
                    if (gameObject.GetComponent<Renderer>())
                    {
                        AnimateButtonPush();
                    }
                    trapStatus.FireOnButtonPressed();
                }
            }
        }

        void AnimateButtonPush()
        {
            Vector3 pos = this.transform.localPosition + (-0.7f * this.transform.right);
            iTween.MoveFrom(this.gameObject, iTween.Hash("position", pos, "speed", 1, "islocal", true));
        }

        private void OnDestroy()
        {
            if (gameObject.GetComponent<Renderer>() && trapStatus != null)
            {
                trapStatus.OnButtonPressed -= ChangeButtonColor;
            }
        }
    }
}