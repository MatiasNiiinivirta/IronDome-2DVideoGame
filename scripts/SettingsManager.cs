using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Toggle hideHealthBarToggle;
    public Toggle hideScore;

    void Start()
    {
        // When the scene starts, load saved preferences and update toggle UI according

        if (PlayerPrefs.HasKey("HealthBarVisible"))
		{
			int healthBarVisible = PlayerPrefs.GetInt("HealthBarVisible");
			hideHealthBarToggle.isOn = healthBarVisible == 1;
		}

		if (PlayerPrefs.HasKey("ScoreVisible"))
		{
			int ScoreVisible = PlayerPrefs.GetInt("ScoreVisible");
			hideScore.isOn = ScoreVisible == 1;
		}
	}


    public void mainMenu()
    {
        // Load Main Menu scene, reset time scale and score
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        GameOver.ScoreAmount = 0;

    }

	public void game()
    {
        // Start the game scene by loading it with a loading screen, reset time scale and score
        Time.timeScale = 1f;
        GameOver.ScoreAmount = 0;
        StartCoroutine(LoadGame());
    }


    public void ToggleHealthBar()
    {
        if (!hideHealthBarToggle.isOn)
        {
            // Health bar visible
            PlayerPrefs.SetInt("HealthBarVisible", 0);
            PlayerPrefs.Save();
        }
        else
		{
            // Health bar hidden
            PlayerPrefs.SetInt("HealthBarVisible", 1);
            PlayerPrefs.Save();
        }
    }

    public void ToggleScore()
    {
        if (!hideScore.isOn)
        {
            // score bar visible
            PlayerPrefs.SetInt("ScoreVisible", 0);
            PlayerPrefs.Save();
        }
        else
        {
            // score bar hidden
            PlayerPrefs.SetInt("ScoreVisible", 1);
            PlayerPrefs.Save();
        }
    }

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


}
