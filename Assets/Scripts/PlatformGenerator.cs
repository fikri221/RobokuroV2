using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
	// deklarasi untuk objek Platform
	public GameObject thePlatform;
	// titik ground yang akan digenerate
	public Transform generationPoint;

	// jarak antar ground
	public float distanceBetween;
	// jarak minimum antar platform
	public float distanceBetweenMin;
	// jarak maksimum antar platform
	public float distanceBetweenMax;

	// panggil kelas ObjectPooler dengan tipe array
	public ObjectPooler[] theObjectPools;

	private float platformWidth;
	// array untuk menampung panjang masing2 platform
	private float[] platformWidths;

	// buat array yang gameObject Platform
	// public GameObject[] thePlatforms;

	// variabel yang menentukan objek mana yang akan diambil
	private int platformSelector;

	// variabel untuk atur tinggi rendahnya platform
	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;

	// var untuk mengatur perbedaan tinggi maksimum tiap platform
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;



    // Start is called before the first frame update
    void Start()
    {
		// atur panjang masing2 ground
		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		platformWidths = new float[theObjectPools.Length];

		// atur berapa jarak antar masing2 ground
		for(int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		// menentukan posisi titik awal dari tinggi
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<CoinGenerator>();
	}

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
		{
			// atur jarak minimum & maksimum dengan random
			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

			// mengambil platform secara random
			platformSelector = Random.Range(0, theObjectPools.Length);

			// menempatkan tinggi platform secara random
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

			// kondisi agar tinggi platform tidak lebih atau kurang
			if(heightChange > maxHeight)
			{
				heightChange = maxHeight;
			} else if(heightChange < minHeight)
			{
				heightChange = minHeight;
			}

			// atur posisi platform baru setengah dari panjang platform
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween,
				heightChange, transform.position.z);

			// membuat copy an dari objek yang aktif
			//Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

			if(Random.Range(0f, 100f) < randomCoinThreshold)
			{
				theCoinGenerator.SpawnCoins(new Vector3(transform.position.x + (platformWidths[platformSelector] / 2f), 
					transform.position.y + 3f, transform.position.z));

			}

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2),
				transform.position.y, transform.position.z);
		}
    }
}
