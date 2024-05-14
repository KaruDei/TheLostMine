using UnityEngine;

public class TimeOfDayManager : MonoBehaviour
{
    public float dayDuration = 60.0f;
    public Gradient skyboxGradient;
    public Gradient ambientLightGradient;
    public AnimationCurve sunIntensityCurve;
    public Light sun;
    public float timeOfDay = 0.25f;

    private float dayStartTime = 0.25f;
    private float nightStartTime = 0.75f;

    void Update()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1.0f)
        {
            timeOfDay -= 1.0f;
        }

        float sunIntensity = sunIntensityCurve.Evaluate(timeOfDay);

        sun.transform.localRotation = Quaternion.Euler((timeOfDay * 360.0f) - 90.0f, 170.0f, 0.0f);
        sun.intensity = sunIntensity;
    }
}
