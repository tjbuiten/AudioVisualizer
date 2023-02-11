using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private Color color = Color.magenta;
    private float maxLength = 0f;
    private float minLength = 0f;
    private Vector3 baseLength = Vector3.zero;
    private float minIntensityAllIndicators = 0f;
    private float maxIntensityAllIndicators = 0f;
    private float currentIntensity = 0f;
    private Vector3 positionIncreaseForScaling = Vector3.zero;
    private Vector3 basePosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        var meshRenderer = GetComponentsInChildren<MeshRenderer>();

        foreach (var mesh in meshRenderer) {
            mesh.material.SetColor("_Color", color);
        }

        baseLength = transform.localScale * minLength;
        basePosition = transform.localPosition;
        positionIncreaseForScaling = GetPositionIncreaseForScalingBasedOnRotation(transform.rotation);
    }

    // FixedUpdate is called at fixed intervals independent of framerate
    void FixedUpdate()
    {
        var newLength = (maxLength == 0 || maxIntensityAllIndicators - minIntensityAllIndicators == 0 )
            ? minLength
            : minLength + (maxLength / (maxIntensityAllIndicators - minIntensityAllIndicators)) * currentIntensity;

        transform.localScale = new Vector3(
            positionIncreaseForScaling.x == 0 ? 1 : newLength,
            positionIncreaseForScaling.y == 0 ? 1 : newLength,
            positionIncreaseForScaling.z == 0 ? 1 : newLength
        );
         
        transform.localPosition = basePosition + positionIncreaseForScaling * newLength;
    }

    public void SetIntensity(float currentIntensity) {
        this.currentIntensity = currentIntensity;
    }

    public void SetMaxIntensityAllIndicators(float maxIntensityAllIndicators) {
        this.maxIntensityAllIndicators = maxIntensityAllIndicators;
    }

    public void SetMinIntensityAllIndicators(float minIntensityAllIndicators) {
        this.minIntensityAllIndicators = minIntensityAllIndicators;
    }

    public void SetMinLength(float minLength) {
        this.minLength = minLength;
    }

    public void SetMaxLength(float maxLength) {
        this.maxLength = maxLength;
    }

    // Only 6 axis are implemented currently, anything else will break
    private Vector3 GetPositionIncreaseForScalingBasedOnRotation(Quaternion rotation) {
        switch (rotation.z) {
            case (90):
                return new Vector3(-0.5f, 0, 0);
            case (-90):
                return new Vector3(0.5f, 0, 0);
            case (180):
                return new Vector3(0, 0.5f, 0);
        }

        switch (rotation.x) {
            case (-90):
                return new Vector3(0, 0, 0.5f);
            case (90):
                return new Vector3(0, 0, -0.5f);
        }
        
        return new Vector3(0, -0.5f, 0);
    }
}
