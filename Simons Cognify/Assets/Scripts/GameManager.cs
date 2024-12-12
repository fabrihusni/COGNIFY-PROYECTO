using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<int> playerTaskList = new List<int>();
    private List<int> playerSequenceList = new List<int>();
    public List<AudioClip> buttonSoundList = new List<AudioClip>();
    public List<List<Color32>> buttoncolors = new List<List<Color32>>();
    public List<Button> ClickeableButtons;
    public AudioClip LoseSound;
    public AudioSource audioSource;
    public CanvasGroup Buttons;
    public GameObject StartButton;
    
    public void AddToPlayerSequenceList(int buttonId)
    {
        playerSequenceList.Add(buttonId); 
        for(int i=0 ; i<playerSequenceList.Count; i++)
        {
            if (playerTaskList[i] == playerSequenceList[i])
            {
                continue;
            }
            else
            {
                StartCoroutine(PlayerLost());
                return;
            }
        }
        if (playerSequenceList.Count == playerTaskList.Count)
        {
            StartCoroutine(StartNextRound());
        }
    }
    public void StartGame()
    {
        StartCoroutine(StartNextRound());
        StartButton.SetActive(false);
    }

    public IEnumerator PlayerLost()
    {
        audioSource.PlayOneShot(LoseSound);
        playerSequenceList.Clear();
        playerTaskList.Clear();
        yield return new WaitForSeconds(1f);
        StartButton.SetActive(true);
    }

    public IEnumerator LuzPrendida(int buttonId)
    {
        yield return new WaitForSeconds(.5f);
        ClickeableButtons[buttonId].GetComponent<Image>().color = buttoncolors[buttonId][0];
        yield return new WaitForSeconds (.5f);
        ClickeableButtons[buttonId].GetComponent<Image>().color = buttoncolors[buttonId][1];
    }

    public IEnumerator StartNextRound()
    {
        playerSequenceList.Clear();
        Buttons.interactable = false;
        yield return new WaitForSeconds(1f);
        playerTaskList.Add(Random.Range(0,4));
        foreach(int index in playerTaskList)
        {
        yield return StartCoroutine(LuzPrendida(index));
        }
        Buttons.interactable = true;
        yield return null;

    }
    
    public void Awake()
    {
        buttoncolors.Add(new List<Color32>{new Color32(255, 100, 100, 255), new Color32(255, 0, 0, 255)});
        buttoncolors.Add(new List<Color32>{new Color32(248, 255, 95, 255) , new Color32(255, 255, 0, 255)});
        buttoncolors.Add(new List<Color32>{new Color32(7, 166, 0, 255), new Color32(44, 255, 35, 255)});
        buttoncolors.Add(new List<Color32>{new Color32(0, 43, 156, 255), new Color32(31, 93, 255, 255)});
        for(int i = 0; i<4; i++)
        {
            ClickeableButtons[i].GetComponent<Image>().color = buttoncolors[i][1];
        }
    }

    

}