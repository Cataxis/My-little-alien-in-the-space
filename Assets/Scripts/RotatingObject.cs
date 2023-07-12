using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    float rotationSpeed;
    [SerializeField] float min;
    [SerializeField] float max;

    void Start()
    {
        rotationSpeed = Random.Range(min, max);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
