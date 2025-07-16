using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //public GameObject settingsMenu;
    //public GameObject mainMenuButton1;
    //public GameObject mainMenuButton2;
    //public GameObject mainMenuButton3;
    //public GameObject highScore;

    // Starts loading the main game scene asynchronously
    public GameObject credits;
	public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    // Coroutine to load LoadingScreen first, then asynchronously load the "DayTest" scene
    IEnumerator LoadGame()
    {

        SceneManager.LoadScene("LoadingScreen");

        yield return new WaitForSeconds(0.5f);


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("DayTest");

        asyncLoad.allowSceneActivation = false;


        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    // Show the credits UI
    public void Credits()
    {
        credits.SetActive(true);
    }

    // Hide the credits UI
    public void CloseCredits()
    {
        credits.SetActive(false);
    }


    // Quit the application (only works in built executable)
    public void QuitGame()
    {
        Application.Quit();
    }

    // Load the settings scene
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
   


}
