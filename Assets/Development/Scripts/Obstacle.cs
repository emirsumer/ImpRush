using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        MainCharacterController colliderController = other.gameObject.GetComponent<MainCharacterController>();

        if (colliderController != null)
        {
            colliderController.OnHitObstacle();
        }
    }
  
}
