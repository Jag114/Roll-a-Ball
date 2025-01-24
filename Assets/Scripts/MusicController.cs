using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance = null;
    private static int nr = 0;
    public string name;
    public AudioSource audioSource = null;

    public static MusicController Instance
    {
        get{
            return instance;
        }
    }

    private void Awake()
    {
        print("My name is " + name);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (audioSource == null)
            {
                audioSource = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
            }
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}