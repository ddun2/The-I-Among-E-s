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
    public GameObject writeMbtiScreen;
    private bool areYouI = false;
    private bool areYouE = false;


    public void OnClickStartBtn()
    {
        JudgeI();
        JudgeE();
        if (areYouI)
        {
            SceneManager.LoadScene(1);
            areYouI = false;
        }
        else if (areYouE)
        {
            warningScreen.SetActive(true);
            areYouE = false;
        }
        else
        {
            writeMbtiScreen.SetActive(true);
        }
    }

    public void CloseScreen()
    {
        warningScreen.SetActive(false);
        writeMbtiScreen.SetActive(false);
    }

    public void JudgeI()
    {
        if (inputField.text.Length == 4 && (inputField.text[0] == 'i' || inputField.text[0] == 'I')
            && (inputField.text[1] == 'n' || inputField.text[1] == 'N' || inputField.text[1] == 's' || inputField.text[1] == 'S')
            && (inputField.text[2] == 'f' || inputField.text[2] == 'F' || inputField.text[2] == 't' || inputField.text[2] == 'T')
            && (inputField.text[3] == 'p' || inputField.text[3] == 'P' || inputField.text[3] == 'j' || inputField.text[3] == 'J'))
        {
            areYouI = true;
        }
    }

    public void JudgeE()
    {
        if ((inputField.text[0] == 'e' || inputField.text[0] == 'E')
            && (inputField.text[1] == 'n' || inputField.text[1] == 'N' || inputField.text[1] == 's' || inputField.text[1] == 'S')
            && (inputField.text[2] == 'f' || inputField.text[2] == 'F' || inputField.text[2] == 't' || inputField.text[2] == 'T')
            && (inputField.text[3] == 'p' || inputField.text[3] == 'P' || inputField.text[3] == 'j' || inputField.text[3] == 'J'))
        {
            areYouE = true;
        }
    }

}
