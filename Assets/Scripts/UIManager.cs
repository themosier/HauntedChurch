using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
    public void QuitGame()
    {

    }

    public void ButtonHighlight(TextMeshProUGUI text)
    {
        text.color = Color.white;
    }

    public void ButtonUnHighlight(TextMeshProUGUI text)
    {
        text.color = new Color32(190, 0, 0, 255);
    }
}
