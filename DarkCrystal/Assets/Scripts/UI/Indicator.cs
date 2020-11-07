using UnityEngine;

public class Indicator : MonoBehaviour
{
    private Arrow indicator;
    private DistanceText distance;
    private Plaine plaine;

    private UIEvaluable behaviour;


    public void Initialize(Plaine plaine)
    {
        indicator = GetComponentInChildren<Arrow>();
        distance = GetComponentInChildren<DistanceText>();
        this.plaine = plaine;
    }

    private void Update()
    {
        if (plaine.IsVisible)
        {
            TargetInCamera();
        }
        else
        {
            TargetOutOfCamera();
        }

        behaviour.EvaluatePosition(plaine);
    }

    private void TargetOutOfCamera()
    {
        indicator.gameObject.SetActive(true);
        distance.gameObject.SetActive(false);
        behaviour = indicator;
    }
    
    private void TargetInCamera()
    {
        indicator.gameObject.SetActive(false);
        distance.gameObject.SetActive(true);
        behaviour = distance;

    }




}
