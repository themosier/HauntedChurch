using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityMovementAI;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour // Singleton class holding references to significant static objects
{
    public static GameController game { get; private set; }
    public static PlayerController Player { get; private set; }
    public static EnemyController Enemy { get; private set; }
    public static OrganManager Organ { get; private set; }
    public static GameObject UI { get; private set; }

    public static AudioController Audio { get; private set; }

    public static UIManager uiManager { get; private set; }
    public static Camera MainCamera { get; private set; }

    public static Vector2 maxBounds { get; private set; }
    public static Vector2 minBounds { get; private set; }

    [SerializeField]
    private List<AudioClip> ambientSounds;
    

    private void Awake()
    {
        if (game != null && game != this)
        {
            Destroy(this);
            return;
        }
        game = this;
        Player = game.GetComponentInChildren<PlayerController>();
        Enemy = game.GetComponentInChildren<EnemyController>();
        Organ = GameObject.Find("Organ").GetComponentInChildren<OrganManager>();
        UI = GameObject.Find("UI");
        MainCamera = Camera.main;
        uiManager = game.GetComponentInChildren<UIManager>();
        Audio = GetComponentInChildren<AudioController>();

        //AudioManager.Audio.PlayMusic(bgMusic);

        GameObject walls = GameObject.Find("Walls");
        
        minBounds = walls.GetComponent<Renderer>().bounds.min;
        maxBounds = walls.GetComponent<Renderer>().bounds.max;

        Debug.Log("min: " + minBounds);
        Debug.Log("max: " + maxBounds);

    }

    private void Start()
    {
        StartCoroutine(PlayAmbientSounds());
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            uiManager.WonGame();
        }
#endif
    }


    // Coroutine for ambient sounds
    IEnumerator PlayAmbientSounds()
    {
        yield return new WaitForSeconds(Random.Range(10f, 15f));

        int clipIndex = Random.Range(0, ambientSounds.Count - 1);
        AudioController.instance.PlaySound(ambientSounds[clipIndex]);

        yield return new WaitForSeconds(ambientSounds[clipIndex].length);
        StartCoroutine(PlayAmbientSounds());
    }


    // Trigger for screams
}
