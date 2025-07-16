using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject pauseMenubUTTON;
	public GameObject gameScore;
	public AudioMixer audioMixer;
    public static bool GameIsPaused = false;
    void Start()
    {
        // Hide the mouse cursor and lock it to the center at game start
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;       
    }

    // Update is called once per frame
    void Update()
    {
        // Make the cursor visible and unlock it (probably for UI interaction)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    // Pauses the game and shows pause menu, mutes audio and hides score
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        audioMixer.SetFloat("Volume", -80f);
        gameScore.SetActive(false);

    }

    // Resumes the game, hides pause menu, restores audio and shows score
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        audioMixer.SetFloat("Volume", 0.03f);
        gameScore.SetActive(true);

    }

    // Shows the game over UI and disables the pause button
    public void gameOver()
    {
        gameOverUI.SetActive(true);
        pauseMenubUTTON.SetActive(false);
        
    }

    // Resets game state and reloads the current scene using a loading screen

    public void restart()
    {
        Time.timeScale = 1f;
        GameOverHandler.GameOverIsOn = false;

		audioMixer.SetFloat("Lowpasscuttoff", 5000f);
        GameOver.ScoreAmount = 0;
        GameOver.DaysSurvived = 0;

        StartCoroutine(LoadGame());

    }

    // Loads main menu scene and resets game state and audio
    public void mainMenu()
    {
        Time.timeScale = 1f;
        GameOverHandler.GameOverIsOn = false;
        audioMixer.SetFloat("Lowpasscuttoff", 5000f);
        audioMixer.SetFloat("Volume", 0.03f);
        SceneManager.LoadScene("MainMenu");
        GameOver.ScoreAmount = 0;
        GameOver.DaysSurvived = 0;
    }

    // Loads settings scene and resets game state and audio
    public void Settings()
    {
        GameOverHandler.GameOverIsOn = false;
        audioMixer.SetFloat("Lowpasscuttoff", 5000f);
        audioMixer.SetFloat("Volume", 0.03f);
        SceneManager.LoadScene("Settings");
        GameOver.ScoreAmount = 0;
        GameOver.DaysSurvived = 0;
    }

    // Quits the application/game
    public void quit()
    {
        Application.Quit();
    }

    // Coroutine to load the current game scene asynchronously with a loading screen
    IEnumerator LoadGame()
	{
		// Lataa ensin Loading Screen Scene
		SceneManager.LoadScene("LoadingScreen");

		// Odota hetki, jotta loading screen ehtii näkyä
		yield return new WaitForSeconds(0.5f);

		// Lataa nykyinen peli-scene uudelleen
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

		asyncLoad.allowSceneActivation = false;

		// Odota, että lataus on valmis
		while (!asyncLoad.isDone)
		{
			if (asyncLoad.progress >= 0.9f)
			{
				yield return new WaitForSeconds(1f); // Voit muuttaa tätä animaation pituuden mukaan
				asyncLoad.allowSceneActivation = true;
			}
			yield return null;
		}
	}


}
