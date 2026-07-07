using System.Collections;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Transform fullGroundTransform;

    private bool _isTriggerable = true;

    private void OnTriggerEnter(Collider other)
    {
        MainCharacterController character = other.GetComponent<MainCharacterController>();
        if (_isTriggerable)
        {
            _isTriggerable = false;
            if (character != null)
            {
                StartCoroutine(SpawnCoroutine());
            }
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        GroundPiece[] allGroundPieces = fullGroundTransform.GetComponentsInChildren<GroundPiece>();
        yield return new WaitForSeconds(15);

        Vector3 desiredPosition = fullGroundTransform.position + new Vector3(0, 0, 400);
        fullGroundTransform.position = desiredPosition;

        _isTriggerable = true;

        foreach(var currentPiece in allGroundPieces)
        {
            currentPiece.ClearItems();
            currentPiece.SpawnPosition();
        }
    }

}
