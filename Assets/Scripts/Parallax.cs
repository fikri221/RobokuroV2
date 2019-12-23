using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	// deklarasi panjang dan posisi awal
	private float length, startpos;
	// deklarasi gameObject kamera;
	public GameObject cam;
	// berapa banyak parallax efek yang akan di munculkan
	public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
		// menentukan posisi awal
		startpos = transform.position.x;

		// menentukan panjang sprite
		length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float temp = (cam.transform.position.x * (1 - parallaxEffect));
		// berapa jauh kita bergerak di dalam world space

		float distance = (cam.transform.position.x * parallaxEffect);

		// pergerakan kamera
		transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

		if (temp > startpos + length)
		{
			startpos += length;
		} else if (temp < startpos - length)
		{
			startpos -= length;
		}
	}
}
