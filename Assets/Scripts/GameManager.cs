using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	// array untuk menghapus platform yang menumpuk
	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;
	public DeathPauseMenu theDeathScreen;

    // Start is called before the first frame update
    void Start()
    {
		// menentukan posisi awal dari player dan platform
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void RestartGame()
	{
		// menghilangkan player kemudian kembali ke pos. awal
		thePlayer.gameObject.SetActive(false);
		theDeathScreen.gameObject.SetActive(true);
		//StartCoroutine("RestartGameCoroutine");
	}

	public void Reset()
	{
		theDeathScreen.gameObject.SetActive(false);
		// saat player menunggu beberapa detik,
		// platform akan dihancurkan juga
		platformList = FindObjectsOfType<PlatformDestroyer>();

		// membuat array untuk menghapus platform yang menumpuk
		for (int i = 0; i < platformList.Length; i++)
		{
			// ketika objek berada di posisi ke-[i]
			// ambil gameObject yg terkait lalu nonaktifkan
			platformList[i].gameObject.SetActive(false);
		}

		// mengembalikkan posisi player ke posisi awal start
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		// setelah sampai ke posisi awal, player muncul kembali		
		thePlayer.gameObject.SetActive(true);

		theScoreManager.scoreCount = 0;
	}

	/*public IEnumerator RestartGameCoroutine()
	{
		// menghilangkan player kemudian kembali ke pos. awal
		thePlayer.gameObject.SetActive(false);

		// delay saat player mati
		yield return new WaitForSeconds(0.5f);

		// saat player menunggu beberapa detik,
		// platform akan dihancurkan juga
		platformList = FindObjectsOfType<PlatformDestroyer>();

		// membuat array untuk menghapus platform yang menumpuk
		for(int i = 0; i < platformList.Length; i++)
		{
			// ketika objek berada di posisi ke-[i]
			// ambil gameObject yg terkait lalu nonaktifkan
			platformList[i].gameObject.SetActive(false);
		}

		// mengembalikkan posisi player ke posisi awal start
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		// setelah sampai ke posisi awal, player muncul kembali		
		thePlayer.gameObject.SetActive(true);

		theScoreManager.scoreCount = 0;
	}*/
}
