using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurveyList : MonoBehaviour {

    // String array of all decks aka surveys
    string[] surveyList = { "Neuroticism", "Openness", "Conscientious", 
        "Agreeableness", "Extraversion" };

    // Pointer to track current deck viewed
    int current = 0; 

    // Use this for initialization
    void Start()
    {
        // Sets the default deck to neuroticism (index 0)
        // Does by default anyway, so this is not necessary
        // Could be needed when no longer hardcoded
        Image survey = GameObject.Find("Deck").GetComponent<Image>();
        Text surveyText = GameObject.Find("DeckText").GetComponent<Text>();

        Sprite defSprite = Resources.Load<Sprite>("Cards/Neuroticism");
        string newText = "This deck tests your neuroticism";

        survey.sprite = defSprite;
        surveyText.text = newText;
    }

    // On left, if index is 0, go to last deck in list
    public void Left() {
        if ((current - 1) < 0) {
            current = surveyList.Length-1;    
        } else {
            current -= 1;   
        }

        UpdateUI();
    }

    // On right, if index exceeds deck length, go to first deck in list
    public void Right() {
        if ((current + 1) > surveyList.Length-1) {
            current = 0;
        } else {
            current += 1;
        }

        UpdateUI();
    }

    // Updates image and text
    public void UpdateUI() {
        Image survey = GameObject.Find("Deck").GetComponent<Image>();
        Text surveyText = GameObject.Find("DeckText").GetComponent<Text>();

        Sprite defSprite = Resources.Load<Sprite>("Cards/" + surveyList[current]);
        string newText = "This deck tests your " + surveyList[current].ToLower();

        survey.sprite = defSprite;
        surveyText.text = newText;
    }

    // Goes to game play round
    public void SelectedSurvey() {
        PlayerPrefs.SetInt("survey", current);
        SceneManager.LoadScene("Survey");
    }
}
