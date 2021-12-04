using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePicker : MonoBehaviour
{

   

    // Start is called before the first frame update
    void Start()
    {
        int progress = PlayerPrefs.GetInt("Progress", 1);
         Button[] buttons = new Button[transform.childCount];

         //add all the buttons to an array of buttons.
         //and set them to NOT interactable.
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = transform.GetChild(i).GetComponent<Button>();
            buttons[i].interactable = false;
        }
        if(progress > 12)
        {
            progress = 12;
        }

        //for as many levels as the player has gotten to
        //set them to interactablr = true
        for(int i = 0; i < progress; i++)
        {
            buttons[i].interactable = true;
        }
    }

    // public void ResetProgress()
    // {
    //     PlayerPrefs.SetInt("Progress");
    //      UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    // }
}
