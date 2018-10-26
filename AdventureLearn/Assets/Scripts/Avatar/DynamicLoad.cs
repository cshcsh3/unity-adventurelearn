using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicLoad : MonoBehaviour {
    // Does it dynamically but has formatting issues
    public RectTransform prefab;
    private string[] avatars = { "Default", "Graduation", "Ninja", "Rocker", "Batman" };

	// Use this for initialization
	void Start () {
        GameObject content = GameObject.Find("Content");

        foreach (string avatar in avatars) {
            Image image = prefab.GetComponent<Image>();
            image.SetNativeSize();
            Sprite style = Resources.Load<Sprite>("Avatars/" + avatar);
            image.sprite = style;

            var instance = Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content.transform, false);
        }
	}
}
