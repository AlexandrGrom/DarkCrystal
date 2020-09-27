using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxXRotation;
    [SerializeField] private float maxZRotation;

    private Vector3 newRotation;

    private void Update()
    {
        CalculateRotation();
    }

    private void CalculateRotation()
    {
        float rotationz = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float rotationx = -Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;

        float x = transform.localEulerAngles.x;
        if (IsNextStep(x, rotationx, maxXRotation))
        {
            newRotation.x = x + rotationx;
        }

        float z = transform.localEulerAngles.z;
        if (IsNextStep(z, rotationz, maxZRotation))
        {
            newRotation.z = z + rotationz;
        }

        transform.localEulerAngles = new Vector3(newRotation.x, 0, newRotation.z);
    }
    private float CalculateAngle(float angle)
    {
        if (angle > 180) return angle - 360;
        
        return angle;
    }

    private bool IsNextStep(float angle, float step, float maximum)
    {
        return Mathf.Abs(CalculateAngle(angle) + step) <= maximum;
    }
}
