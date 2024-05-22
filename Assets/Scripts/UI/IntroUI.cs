using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    
    public TMP_InputField inputField;
    // Start is called before the first frame update
    public GameObject warningScreen;
   

    public void OnClickStartBtn()
    {

        if (inputField.text.Length == 4 && inputField.text[0] == 'i' || inputField.text[0] == 'I')
        {
            SceneManager.LoadScene(1);
        }
        else if (inputField.text[0] == 'e' || inputField.text[0] == 'E')
        {
            warningScreen.SetActive(true);
        }
        else return;
    }

    public void CloseScreen()
    {
        warningScreen.SetActive(false);
    }

}
