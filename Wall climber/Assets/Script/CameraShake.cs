using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public IEnumerator Shake(float duration, float force)
    {
        Vector3 originalPositon = this.transform.localPosition;
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * force;
            float y = Random.Range(-1f, 1f) * force;

            transform.localPosition = new Vector3(x, y, originalPositon.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        this.transform.localPosition = originalPositon;
    }
}
