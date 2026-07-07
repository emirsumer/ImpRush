using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    private float targetZValue = 0;

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
           Instantiate(spawnPrefab,new Vector3(0,0,targetZValue),Quaternion.identity);
            targetZValue += 50;
        }
    }
}
