using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avatar : MonoBehaviour {

    private string SAVED = "saved";
    private string AVATAR = "avatar";

	// Use this for initialization
	void Start () {
        string savedAvatar = PlayerPrefs.GetString(SAVED, "Default");

        LoadAvatar(savedAvatar);	    

        // Set up button listeners
        GameObject buttons = GameObject.Find("Content");

        foreach (Button button in buttons.GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(delegate { SelectedAvatar(button); });
        }
	}
	
    void SelectedAvatar(Button button) {
        // Unhighlight previous
        string prevAvatar = PlayerPrefs.GetString(AVATAR);

        Image prevButtonImage = GameObject.Find(prevAvatar).GetComponent<Image>();
        prevButtonImage.color = new Color32(255, 255, 255, 255);

        // Highlight selected avatar
        Image buttonImage = button.GetComponent<Image>();
        buttonImage.color = new Color32(187, 187, 187, 255);

        Debug.Log(button.name);
        PlayerPrefs.SetString(AVATAR, button.name);

        LoadAvatar(button.name);
    }

    public void Save() {
        string savedAvatar = PlayerPrefs.GetString(AVATAR);
        PlayerPrefs.SetString(SAVED, savedAvatar);
    }

    void LoadAvatar(string savedAvatar) {
        // Load current avatar 
        Image currentAvatar = GameObject.Find("Current").GetComponent<Image>();

        Sprite chosenOne = Resources.Load<Sprite>("Avatars/" + savedAvatar);
        currentAvatar.sprite = chosenOne;
    }
}
