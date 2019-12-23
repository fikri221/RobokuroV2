using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	// objek yang akan di pooling
	public GameObject pooledObject;
	
	// banyak objek yang akan di pooling
	public int pooledAmount;

	// list dari objek, dapat mengatur jumlah platform sesuai keinginan
	List<GameObject> pooledObjects;
	
    // Start is called before the first frame update
    void Start()
    {
		// buat list kosong
		pooledObjects = new List<GameObject>();

		// akan mengisi list dengan angka dari pooledAmount
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			// menonaktifkan object dalam scene
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
    }

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		GameObject obj = (GameObject)Instantiate(pooledObject);
		// mengaktifkan object dalam scene
		obj.SetActive(false);
		pooledObjects.Add(obj);
		return obj;
	}  
}
