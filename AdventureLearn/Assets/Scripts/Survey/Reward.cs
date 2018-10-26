using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reward : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text reward = GameObject.Find("Reward").GetComponent<Text>();
        reward.text = PlayerPrefs.GetInt("reward").ToString();
	}
}
