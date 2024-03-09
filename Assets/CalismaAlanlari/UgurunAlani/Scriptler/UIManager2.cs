
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public Toggle toggle1;
    
    public Toggle toggle2;
    
    private AudioSource audioSource;
    [SerializeField]
    
    AudioClip music,gamePlaySound;
     private static UIManager2 instance;
    void Awake()
    {
        // Singleton pattern to ensure only one instance exists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start() {
         audioSource = GetComponent<AudioSource>();
        toggle1.onValueChanged.AddListener(delegate { ToggleValueChanged(toggle1); });
        toggle2.onValueChanged.AddListener(delegate { ToggleValueChanged(toggle2); });
    }
     void ToggleValueChanged(Toggle change)
    {
        if (change == toggle1)
        {
            if (toggle1.isOn)
                PlayClip(music);
            else
                StopClip(music);
        }
         if (change == toggle2)
        {
            if (toggle2.isOn)
                PlayClip(gamePlaySound);
            else
                StopClip(gamePlaySound);
        }
    }

    void PlayClip(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    void StopClip(AudioClip clip)
    {
        if (audioSource.clip == clip)
        {
            audioSource.Stop();
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("AnaSahne");
    }
    public void QuitGame()
    {
         Application.Quit();
    }
}
