using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
	// tambahkan titik penghancuran
	public GameObject platformDestructionPoint;
    // Start is called before the first frame update
    void Start()
    {
		// mencari objek dengan nama PlatformDestructionPoint
		platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
		// kondisi jika posisi kamera pada titik x lebih kecil dari PlatformDestructionPoint
		if (transform.position.x < platformDestructionPoint.transform.position.x)
		{
			// akan mengahncurkan objek apapun yang berkaitan.
			//Destroy(gameObject);

			// menonaktifkan gamObject.
			gameObject.SetActive(false);
		}
    }
}
