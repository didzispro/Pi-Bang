using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private float shakeTimer;
    private float shakePower;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakePower;

            shakeTimer -= Time.deltaTime;
            shakePower *= 0.9f;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }

    public void Shake(float duration, float power)
    {
        shakeTimer = duration;
        shakePower = power;
    }
}
