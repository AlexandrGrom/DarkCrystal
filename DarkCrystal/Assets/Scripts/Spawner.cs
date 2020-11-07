using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Plaine plainPrefab;
    [SerializeField] private Indicator indicatorPrefab;

    private Canvas UICanvas;


    private void Awake()
    {
        UICanvas = GetComponentInChildren<Canvas>();
        CreatePlain();
    }

    void CreatePlain()
    {
        Plaine plain = Instantiate(plainPrefab,transform);
        Indicator indicator = Instantiate(indicatorPrefab,UICanvas.transform);
        indicator.Initialize(plain);
    }
}
