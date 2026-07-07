using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator canvasAnimator;
    [SerializeField] private GameObject mainMenuObject;


    public void PlayGame()
    {
        canvasAnimator.SetTrigger("StartGame");
        mainMenuObject.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("S_GameScene");
    }

    public void StartGame()
    {
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
