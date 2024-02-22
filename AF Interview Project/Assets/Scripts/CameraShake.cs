using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class CameraShake : MonoBehaviour
    {
        public float shakeDuration = 0.5f;
        public float shakeMagnitude = 0.1f;

        public void StartShake()
        {
            StartCoroutine(Shake());
        }

        IEnumerator Shake()
        {
            Vector3 originalPosition = transform.localPosition;

            float elapsed = 0.0f;

            while (elapsed < shakeDuration)
            {
                float x = originalPosition.x + Random.Range(-1f, 1f) * shakeMagnitude;
                float y = originalPosition.y + Random.Range(-1f, 1f) * shakeMagnitude;

                transform.localPosition = new Vector3(x, y, originalPosition.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPosition;
        }
    }
}
