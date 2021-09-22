using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;
    public AudioSource clickSource;
    public AudioClip click;
    
    private int indexScene;
    

    public void Awake()
    {
        audioSource.clip = music;
        audioSource.Play();
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickSource.clip = click;
            clickSource.Play();
        }
    }

    public void LoadPlay()
    {
        Time.timeScale = 1;
        indexScene = 1;
        SceneManager.LoadScene(indexScene);
    }
}
