using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : NewMonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude, float frequency)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-0.001f, 0.001f) * magnitude;
            float y = Random.Range(-0.001f, 0.001f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            magnitude *= 0.4f; 

            yield return new WaitForSeconds(1f / frequency);
        }

        transform.localPosition = originalPos;
    }
}
