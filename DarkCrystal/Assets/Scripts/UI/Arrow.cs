using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour, UIEvaluable
{
    [Range(0.7f, 0.9f)] [SerializeField]
    private float screenBoundOffset;

    private Image image;

    Vector3 ScreenCentre => new Vector3(Screen.width, Screen.height, 0) / 2;
    Vector3 ScreenBounds => ScreenCentre * screenBoundOffset;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void EvaluatePosition(Plaine target)
    {
        Vector3 screenPosition = target.PositionOnScreen - ScreenCentre;
        if (screenPosition.z < 0)
        {
            screenPosition *= -1;
        }

        float rotation = Mathf.Atan2(screenPosition.y, screenPosition.x);
        transform.localEulerAngles = new Vector3(0, 0, rotation * Mathf.Rad2Deg);
        float slope = Mathf.Tan(rotation);


        screenPosition = new Vector3(ScreenBounds.x, ScreenBounds.x * slope, 0) * (screenPosition.x > 0 ? 1:-1);

        if (screenPosition.y > ScreenBounds.y)
        {
            screenPosition = new Vector3(ScreenBounds.y / slope, ScreenBounds.y, 0);
        }
        else if (screenPosition.y < -ScreenBounds.y)
        {
            screenPosition = new Vector3(-ScreenBounds.y / slope, -ScreenBounds.y, 0);
        }

        transform.position = screenPosition + ScreenCentre;
    }

}
