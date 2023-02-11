using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] public GameObject target = default;
    [SerializeField] private float speed = 10f;
    private Vector3 targetPosition = default;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.transform.position;
        transform.LookAt(targetPosition);
    }

    // FixedUpdate is called at fixed intervals independent of framerate
    void FixedUpdate()
    {
        transform.RotateAround(targetPosition, new Vector3(0.0f,1.0f,0.0f), speed);
    }
}
