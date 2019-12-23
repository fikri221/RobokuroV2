using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
	public GameObject bar;
	public int time;
	public GameManager theGameManager;
	public PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
		AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
	
    }

	public void AnimateBar()
	{
		LeanTween.scaleX(bar, 1, time).setOnComplete(RestartPlayer);
	}

	void RestartPlayer()
	{
		// player akan menjalankan method RestartGame
		// pada kelas GameManager
		theGameManager.RestartGame();

		// reset speed ke nilai awal
		thePlayer.SpeedRestart();
	}
}
