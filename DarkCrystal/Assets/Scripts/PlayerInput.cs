using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxXRotation;
    [SerializeField] private float maxZRotation;

    private float currentXRotation;
    private float currentZRotation;

    private void Update()
    {
        CalculateXRotation();
        CalculateZRotation();
    }

    private void CalculateXRotation()
    {
        float rotation = -Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        print(Mathf.Abs(transform.localEulerAngles.x + rotation));
        if (Mathf.Abs(transform.localEulerAngles.x + rotation) <= maxXRotation)
        {
            //currentXRotation += rotation;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + rotation, 0, transform.localEulerAngles.z);
        }
    }

    private void CalculateZRotation()
    {
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        if (Mathf.Abs(currentZRotation + rotation) <= maxXRotation)
        {
            currentZRotation += rotation;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, currentZRotation);
        }
    }
}
