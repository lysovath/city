using UnityEngine;

public class CarCameraFollow : MonoBehaviour
{
    public Transform carTarget;

    public float distance = 6.0f;
    public float height = 2.0f;
    bool isBehind = true; // Will make the camera be able to switch between front and back with shift

    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    void LateUpdate()
    {
        if (!carTarget) return;

        float wantedRotationAngle = carTarget.eulerAngles.y;
        float wantedHeight = carTarget.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = carTarget.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(carTarget);
    }
}