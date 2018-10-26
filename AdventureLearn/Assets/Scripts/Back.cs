using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // Insert Code Here (I.E. Load Scene, Etc)
                // OR Application.Quit();
                Scene scene = SceneManager.GetActiveScene();

                if (scene.name.Equals("Login"))
                {
                    Application.Quit();
                }
                else if (scene.name.Equals("Menu")){
                    Application.Quit();
                }
                else if (scene.name.Equals("SurveySelect")) {
                    SceneManager.LoadScene("Menu");
                }
                else if (scene.name.Equals("Survey")) {
                    SceneManager.LoadScene("SurveySelect");
                }
                else if (scene.name.Equals("Avatar")) {
                    SceneManager.LoadScene("Menu");
                }
            }
        }
	}

    public void OnBack() {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("Login"))
        {
            Application.Quit();
        }
        else if (scene.name.Equals("Menu"))
        {
            Application.Quit();
        }
        else if (scene.name.Equals("SurveySelect"))
        {
            SceneManager.LoadScene("Menu");
        }
        else if (scene.name.Equals("Survey"))
        {
            SceneManager.LoadScene("SurveySelect");
        }
        else if (scene.name.Equals("Avatar"))
        {
            SceneManager.LoadScene("Menu");
        } 
        else if (scene.name.Equals("Stats")) 
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
