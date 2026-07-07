using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameMusicSource;
    [SerializeField] private AudioSource goldSfx;
    [SerializeField] private AudioSource obstacleSfx;
    [SerializeField] private AudioSource deathSfx;
    [SerializeField] private AudioSource mainMenuSource;
    [SerializeField] private AudioSource startButtonSfx;
    [SerializeField] private AudioSource buttonSfx;
    [SerializeField] private AudioSource pauseButtonSfx;
    [SerializeField] private AudioSource stepRightFootSfx;
    [SerializeField] private AudioSource stepLeftFootSfx;
    [SerializeField] private AudioSource jumpSfx;


    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMainMenuMusic();
    }

    private void PlayMainMenuMusic()
    {
        if (gameMusicSource.isPlaying)
        {
            gameMusicSource.Stop();
        }

        mainMenuSource.loop = true;
        mainMenuSource.Play();
    }

    public void PlayGameMusic()
    {
        if (mainMenuSource.isPlaying) mainMenuSource.Stop();

        gameMusicSource.loop = true;
        gameMusicSource.Play();
    }


    public void PlayGoldSound()
    {
        goldSfx.PlayOneShot(goldSfx.clip);
    }

    public void PlayObstacleSound()
    {
        obstacleSfx.Play();
    }

    public void PlayDeathSound()
    {
        deathSfx.Play();
    }
    public void PlayStartButtonSound()
    {
        startButtonSfx.Play();
    }

    public void PlayButtonSound()
    {
        buttonSfx.Play();
    }

    public void PlayPauseButtonSound()
    {
        pauseButtonSfx.Play();
    }

    public void PlayStepRightFootSound()
    {
        stepRightFootSfx.Play();
    }

    public void PlayStepLeftFootSound()
    {
        stepLeftFootSfx.Play();
    }
    public void PlayJumpSound()
    {
        jumpSfx.Play();
    }
}
