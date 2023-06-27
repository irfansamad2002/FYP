using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    AudioSource audioSrc;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioOneShot(int index, float volume)
    {
        audioSrc.PlayOneShot(audioClips[index],volume);
    }
}
