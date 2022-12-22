using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource soundSource;

    [SerializeField]
    AudioClip startingMusic;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

        musicSource = gameObject.AddComponent<AudioSource>();
        soundSource = gameObject.AddComponent<AudioSource>();

        PlayMusic(startingMusic);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    public void PlayPage(AudioClip clip)
    {
        musicSource.Pause();
        StartCoroutine(PlayPageCoroutine(clip));
        //musicSource.Play();
    }

    IEnumerator PlayPageCoroutine(AudioClip clip)
    {
        musicSource.Pause();
        soundSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        //musicSource.Play();
    }
}
