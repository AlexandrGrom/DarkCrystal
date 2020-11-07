using TMPro;
using UnityEngine;

public class DistanceText : MonoBehaviour, UIEvaluable
{
    private TextMeshProUGUI text;

    public void EvaluatePosition(Plaine target)
    {
        transform.position = target.PositionOnScreen;
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

}
