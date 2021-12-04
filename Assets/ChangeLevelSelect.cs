using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      // don't forget this
                                        // scenes must be added to the build index
                                        
public class ChangeLevelSelect : MonoBehaviour
{
    [Tooltip("The name of the level you want to go to.")]
    public string destination = "Level 2";

    public int levelWithJump = 5;

    PlayerMovement player;

    void Awake()
    {
         // if we are in the main menu, reset all Playerprefs
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("canJump", 0);
            //canDash
        }
                //once the scene is loaded
        else if(SceneManager.GetActiveScene().buildIndex >= levelWithJump)
        {
            PlayerPrefs.SetInt("canJump", 1);
        }

        Time.timeScale = 1;     // mostly unpauses the game
    }

   // public void ChangeScene(string destination = "") {
    public void ChangeScene() {
       
    //use playerprefs to save the current level +1
        PlayerPrefs.SetInt("Progress", SceneManager.GetActiveScene().buildIndex + 1);

       // if(destination == "")
       // {
            //dev forgot to add destination, going to main menu
        //    destination = "MainMenu";
       // SceneManager.LoadScene(SceneManger.GetActiveScene().buildIndex + 1);
       // } else {
            //from the scene picker or pause menu, goes to destination
            //SceneManager.LoadScene(destination);
      //  }
        SceneManager.LoadScene(destination);
        //PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        player.startPosition = GameObject.Find("Start Here").transform.position;
        player.ResetPlayer();


    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            ChangeScene();
        }
    }

    /*
     at the start of a new level
     1. the game manager instantiatesthe player prefab in the start location
     2. the ui controller (on canvas) loads score
     3. player loads powerups

     at the end of a level
     1. the ui controller saves score
     2. the player saves powerups
     3. how do we call these functions?

     at main menu and credits
     1. none of that stuff happens

     */

}
