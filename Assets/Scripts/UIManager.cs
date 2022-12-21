using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    AudioClip bgMusic;

    private void Awake()
    {
        //AudioController.instance.PlayMusic(bgMusic);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(4);
    }

    public void WonGame()
    {
        SceneManager.LoadScene(5);
    }
    public void QuitGame()
    {

    }

    public void ButtonHighlight(TextMeshProUGUI text)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            text.color = new Color32(190, 0, 0, 255);
        }
        else
        {
            text.color = Color.white;
        }
    }

    public void ButtonUnHighlight(TextMeshProUGUI text)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            text.color = Color.white;
        }
        else
        {
            text.color = new Color32(190, 0, 0, 255);
        }
    }
}
