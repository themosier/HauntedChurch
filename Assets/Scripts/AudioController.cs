using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance { get; private set; }

    public AudioSource musicSource { get; private set; }
    public AudioSource soundSource { get; private set; }
    public AudioClip startingMusic { get; private set; }
    public AudioClip winMusic { get; private set; }


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

        musicSource.volume = .5f;
        soundSource.volume = .2f;

        startingMusic = GameObject.Find("StartingMusic").GetComponent<AudioSource>().clip;
        winMusic = GameObject.Find("WinMusic").GetComponent<AudioSource>().clip;

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
        soundSource.clip = clip;
        soundSource.Play();
        yield return new WaitForSeconds(clip.length);
        //musicSource.Play();
    }
}
