using UnityEngine;

public class AtmosphereControl : MonoBehaviour
{
    [SerializeField, Range(0.0f, 0.05f)] private float fogDensity = 0.01f;
    [SerializeField] private Color fogDamageColor = Color.red;
    [SerializeField] private Color fogInitialColor = Color.red;

    private void Update()
    {
        fogDensity += 0.000005f;
        // if (fogDensity > 0.03f) fogDensity = 0.028f;
        if (fogDensity > 0.03f) fogDensity = 0.035f;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fogColor = Color.Lerp(fogInitialColor, fogDamageColor, fogDensity * 10);
    }

    public void ModifyDensity(float density)
    {
        fogDensity = density;
    }
}