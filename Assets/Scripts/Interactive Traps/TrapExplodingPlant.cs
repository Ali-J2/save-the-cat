using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{
    public class TrapExplodingPlant : MonoBehaviour, ITrap
    {
        [SerializeField]
        private GameObject plant;
        [SerializeField]
        private ParticleSystem ExplosionEffect;
        [SerializeField]
        private Material RedOrbMat;
        [SerializeField]
        private TrapStatus trapStatus;

        // Start is called before the first frame update
        void Start()
        {
            trapStatus.OnButtonPressed += ChangePlantColor;
        }

        public void DisableTrap()
        {
            trapStatus.OnButtonPressed -= ChangePlantColor;
            ExplosionEffect.Play();
            plant.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
        }

        public void ChangePlantColor(object sender, EventArgs e)
        {
            plant.GetComponent<Renderer>().material = RedOrbMat;
        }

        private void OnTriggerEnter(Collider other)
        {
            DisableTrap();
        }

        public void AdjustSpeed()
        {
            throw new NotImplementedException();
        }
    }
}