using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    [SerializeField] private float rotationX = 0f;
    [SerializeField] private float rotationY = 0f;
    [SerializeField] private float rotationZ = 0f;
    [SerializeField] private float intensity = 0f;
    [SerializeField] private float minLengthIndicators = 0f;
    [SerializeField] private float maxLengthIndicators = 0f;
    [SerializeField] private Indicator engagementIndicator = default;
    [SerializeField] private Indicator excitementIndicator = default;
    [SerializeField] private Indicator stressIndicator = default;
    [SerializeField] private Indicator relaxationIndicator = default;
    [SerializeField] private Indicator interestIndicator = default;
    [SerializeField] private Indicator focusIndicator = default;

    // Start is called before the first frame update
    void Start()
    {
        var indicators = GetComponentsInChildren<Indicator>();

        foreach (var indicator in indicators) {
            indicator.SetMinLength(minLengthIndicators);
            indicator.SetMaxLength(maxLengthIndicators);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /**
        * Go through all your current values to figure out the max and min, then pass that through.
        * This ensures that all bars scale evenly
        **/
        var maxIntensity = 5f;
        var minIntensity = -2f;

        SetIntensityValues(engagementIndicator, intensity, maxIntensity, minIntensity);
        SetIntensityValues(excitementIndicator, intensity, maxIntensity, minIntensity);
        SetIntensityValues(stressIndicator, intensity, maxIntensity, minIntensity);
        SetIntensityValues(relaxationIndicator, intensity, maxIntensity, minIntensity);
        SetIntensityValues(interestIndicator, intensity, maxIntensity, minIntensity);
        SetIntensityValues(focusIndicator, intensity, maxIntensity, minIntensity);
    }

    private void FixedUpdate() {
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ));
    }

    private void SetIntensityValues(Indicator indicator, float intensity, float maxIntensity, float minIntensity) {
        indicator.SetIntensity(intensity);
        indicator.SetMaxIntensityAllIndicators(maxIntensity);
        indicator.SetMinIntensityAllIndicators(minIntensity);
    }
}
