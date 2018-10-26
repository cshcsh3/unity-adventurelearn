using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginValidation : MonoBehaviour {
    public void Login() {
        Text message = GameObject.Find("Message").GetComponent<Text>();
        string username = GameObject.Find("UsernameInput").GetComponent<InputField>().text;
        string password = GameObject.Find("PasswordInput").GetComponent<InputField>().text;

        // TODO: Better validation
        if (!username.Equals("") && !password.Equals("")) {
            SceneManager.LoadScene("Menu");
        } else {
            // Show error message
            message.text = "Oops, failed to login!";
        }
    }
}
