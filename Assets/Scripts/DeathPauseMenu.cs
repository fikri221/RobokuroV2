using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPauseMenu : MonoBehaviour
{
	public GameObject pauseMenu;
	public GameObject btnPause;
	public void PauseGame()
	{
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

    public void RestartGame()
	{
		Time.timeScale = 1f;
		FindObjectOfType<GameManager>().Reset();
		pauseMenu.SetActive(false);
		btnPause.SetActive(false);
	}

	public void QuitToMain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Main Menu");
	}
}
