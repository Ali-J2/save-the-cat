using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheCat
{

    public class RandomizePropRotations : MonoBehaviour
    {

        [SerializeField]
        private float maxRotationX = 20, maxDip = 1;

        // Start is called before the first frame update
        void OnEnable()
        {
            Vector3 rotation = new Vector3(Random.Range(-maxRotationX, maxRotationX), Random.Range(0, 360), 0);
            transform.localRotation = Quaternion.Euler(rotation);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - Random.Range(0.2f, maxDip), transform.localPosition.z);
        }
    }
}