using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectReward : MonoBehaviour {

    int[] fixedRewards = { 100, 200, 300 };

	// Use this for initialization
	void Start () {
        // Setup button listeners
        GameObject buttons = GameObject.Find("CardHolder");

        foreach (Button button in buttons.GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(SelectedCard);
        }	
	}

    void SelectedCard() {
        // Randomize coins reward 
        System.Random random = new System.Random();
        int index = random.Next(3);

        PlayerPrefs.SetInt("reward", fixedRewards[index]);
        SceneManager.LoadScene("SurveyReward");
    }
}
