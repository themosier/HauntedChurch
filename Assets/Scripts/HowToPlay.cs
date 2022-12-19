using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI BackButton;

    [SerializeField]
    TextMeshProUGUI NextButton;

    private List<GameObject> pages = new List<GameObject>();
    private int curr = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //pages = new List<TextMeshProUGUI>();
        GameObject[] children = GameObject.FindGameObjectsWithTag("Page");

        for (int i = 0; i < children.Length; i++)
        {
            pages.Add(GameObject.Find("Instructions" + (i+1)));
            pages[i].SetActive(false);
        }

        pages[0].SetActive(true);
        

        BackButton.enabled = false;
        NextButton.enabled = true;
    }

    public void NextClick()
    {
        curr++;
        if (curr == pages.Count - 1)
        {
            NextButton.enabled = false;
        }
        if (curr > 0)
        {
            BackButton.enabled = true;
        }

        //pages[curr - 1].GetComponent<TextMeshProUGUI>().enabled = false;
        //pages[curr].GetComponent<TextMeshProUGUI>().enabled = true;

        pages[curr - 1].SetActive(false);
        pages[curr].SetActive(true);
    }

    public void BackClick()
    {
        curr--;
        if (curr <= 0)
        {
            BackButton.enabled = false;
        }
        if (curr < pages.Count - 1)
        {
            NextButton.enabled = true;
        }

        //pages[curr + 1].GetComponent<TextMeshProUGUI>().enabled = false;
        //pages[curr].GetComponent<TextMeshProUGUI>().enabled = true;

        pages[curr + 1].SetActive(false);
        pages[curr].SetActive(true);
    }
}
