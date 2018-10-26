using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeSurvey : MonoBehaviour {

    string[] surveyList = { "Neuroticism", "Openness", "Conscientious",
        "Agreeableness", "Extraversion" };

    string newNumber;
    string COUNTER = "questionNumber";
    string PREVIOUS = "previousButton"; // use to track for UI
    
	// Use this for initialization
    void Start () {
        // For updating qns number
        int num = PlayerPrefs.GetInt(COUNTER);
        Debug.Log(num);
        if (num == 0) {
            // If first init
            newNumber = "1";
            PlayerPrefs.SetInt(COUNTER, 1);
        } else if (num > 3) {
            // Set back questionNumber to 0
            PlayerPrefs.SetInt(COUNTER, 0);
            // End
            SceneManager.LoadScene("SurveyEnd");
        } else {
            newNumber = num.ToString();
        }

        int i = PlayerPrefs.GetInt("survey");
        string survey = surveyList[i];

        Image surveyType = GameObject.Find("Card").GetComponent<Image>();
        Text qnsNumber = GameObject.Find("Number").GetComponent<Text>();
        Text qns = GameObject.Find("Question").GetComponent<Text>();

        Sprite defSprite = Resources.Load<Sprite>("QnsCards/" + survey);
        string newQuestion = "This is a default question. Rate 1 for not " +
            "default and 5 for very default";

        surveyType.sprite = defSprite;
        qnsNumber.text = newNumber;
        qns.text = newQuestion;

        // Disable the button until user selects a rating
        Button nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        nextButton.interactable = false;

        // Setup button listeners
        GameObject buttons = GameObject.Find("ButtonHolder");

        foreach (Button button in buttons.GetComponentsInChildren<Button>()) {
            button.onClick.AddListener(delegate { SelectedRating(button); }); 
        }
    }

    void SelectedRating(Button button) {
        // Unhighlight previous selected button sprite
        string previous = PlayerPrefs.GetString(PREVIOUS, "NONE");

        if (!previous.Equals("NONE")) {
            Image prevOptionButton = GameObject.Find(previous).GetComponent<Image>();
            Sprite unselect = Resources.Load<Sprite>("OptionButton");
            prevOptionButton.sprite = unselect;
        }

        // Do something with rating selected
        string rating = button.GetComponentInChildren<Text>().text;
        Debug.Log("selected: " + rating);

        // Update selected button sprite
        Image optionButton = button.GetComponent<Image>();
        Sprite optionSelected = Resources.Load<Sprite>("OptionSelectButton");
        optionButton.sprite = optionSelected;

        PlayerPrefs.SetString(PREVIOUS, button.name);

        // Enable next button
        Button nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        nextButton.interactable = true;
    }

    public void NextQuestion() {
        // Increment qns number
        int currentNumber = PlayerPrefs.GetInt(COUNTER);
        PlayerPrefs.SetInt(COUNTER, currentNumber + 1);

        // Reload scene to next question, should pass all needed params
        SceneManager.LoadScene("Survey");
    }
}
