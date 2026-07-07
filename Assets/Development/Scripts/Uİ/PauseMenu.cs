using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private RectTransform pausePanelRect;
    [SerializeField] private float topPosY;
    [SerializeField] private float midPosY;
    [SerializeField] private float duration;

    [SerializeField] private GameObject buttonsPanel;
    [SerializeField] private GameObject settingsPanel;

    private AudioManager _audioManager;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        buttonsPanel.SetActive(true);
        settingsPanel.SetActive(false);


        PausePanelIntro();
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("S_MainMenu");
        Time.timeScale = 1;
    }

    public async void Resume()
    {
        await PausePanelOut();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        buttonsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        buttonsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }


    public void ClickButton()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonSound();
        }
    }

    public void ClickPauseButton()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPauseButtonSound();
        }
    }

    public void ExitGame()
    {
        Application.Quit();

    }

    private void PausePanelIntro()
    {
        pausePanelRect.DOAnchorPosY(midPosY, duration).SetUpdate(true);
    }

    private async Task PausePanelOut()
    {
        await pausePanelRect.DOAnchorPosY(topPosY, duration).SetUpdate(true).AsyncWaitForCompletion();

    }
}
