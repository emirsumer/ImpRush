using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private GameObject goldObject;
    [SerializeField] private GameObject[] healthBars;
    [SerializeField] private GameObject infoText;

    private int _totalGold;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    public void UpdateGold(int totalGold)
    {
        _totalGold++;
        goldText.text = _totalGold.ToString();
    }

    public void UpdateHealth(int health)
    {
        if (health >= 0 && health < healthBars.Length)
        {
            healthBars[health].SetActive(false);
        }
    }

    public void HandleCharacterDeath()
    {
        goldText.gameObject.SetActive(false);
        goldObject.SetActive(false);
    }

    public void StartGame()
    {
        infoText.SetActive(false);
    }
}
