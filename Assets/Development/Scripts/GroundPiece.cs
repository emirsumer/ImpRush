using UnityEngine;

public class GroundPiece : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject goldPrefab;
    [SerializeField] private GameObject obstaclePrefab;

    private GameObject spawnedItems;
    private int _randomIndex;

    private void Start()
    {
        SpawnPosition();
    }

    public void SpawnPosition()
    {
        _randomIndex = Random.Range(0, positions.Length);
        SpawnItem();
    }

    private void SpawnItem()
    {
        int randomItemIndex = UnityEngine.Random.Range(0, 10);
        if (randomItemIndex < 1)
        {
            return;
        }
        else if (randomItemIndex >= 1 && randomItemIndex < 5)
        {
            //Vector3 goldPosition = positions[_randomIndex].position +  new Vector3(0,0,0);
            Vector3 goldPosition = positions[_randomIndex].position;
            GameObject gold = Instantiate(goldPrefab,goldPosition,Quaternion.identity);
            spawnedItems = gold;
        }
        else if(randomItemIndex >= 5)
        {
            Vector3 obstaclePosition = positions[_randomIndex].position + new Vector3(-0.5f, 0, 0);
            GameObject obstacle = Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
            spawnedItems = obstacle;
        }
    }

    public void ClearItems()
    {
        if (spawnedItems != null)
        {
            Destroy(spawnedItems);
        }
    }
}
