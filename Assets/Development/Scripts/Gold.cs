using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject goldParticlePrefab;
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up,rotationSpeed * Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        MainCharacterController character = other.GetComponent<MainCharacterController>();
        if(character != null )
        {
            AudioManager.Instance.PlayGoldSound();

            GameObject goldParticle = Instantiate(goldParticlePrefab,transform.position,transform.rotation);
            goldParticle.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            
            _uiManager.UpdateGold(1);
            
            Destroy(gameObject);
        }
    }
}
