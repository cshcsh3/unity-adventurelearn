using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserLoad : MonoBehaviour {

    private string SAVED = "saved";

	// Use this for initialization
	void Start () {
        string savedAvatar = PlayerPrefs.GetString(SAVED, "Default");
        LoadAvatar(savedAvatar);
	}

    void LoadAvatar(string savedAvatar)
    {
        // Load current avatar 
        Image currentAvatar = GameObject.Find("Avatar").GetComponent<Image>();

        Sprite chosenOne = Resources.Load<Sprite>("Avatars/" + savedAvatar);
        currentAvatar.sprite = chosenOne;
    }

    private void LateUpdate()
    {
        // Fix avatar sizing 
        Image currentAvatar = GameObject.Find("Avatar").GetComponent<Image>();
        currentAvatar.SetNativeSize();
    }
}
