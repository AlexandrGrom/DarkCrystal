using UnityEngine;

public class Plaine : MonoBehaviour
{
    private new Camera camera;
    private void Awake()
    {
        camera = Camera.main;
    }
    public bool IsVisible
    {
        get
        {
            Vector3 targetPositionOnScreen = PositionOnScreen;

            bool isTargetVisible =
                targetPositionOnScreen.z > 0 &&
                targetPositionOnScreen.x > 0 &&
                targetPositionOnScreen.x < Screen.width &&
                targetPositionOnScreen.y > 0 &&
                targetPositionOnScreen.y < Screen.height;

            return isTargetVisible;
        }
    }

    public Vector3 PositionOnScreen => camera.WorldToScreenPoint(transform.position);

}
