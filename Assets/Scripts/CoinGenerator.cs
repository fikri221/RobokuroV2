using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
	public ObjectPooler coinPoolBronze;
	public ObjectPooler coinPoolSilver;
	public ObjectPooler coinPoolGold;
	public float distanceBetweenCoin;
    
	public void SpawnCoins(Vector3 startPos)
	{
		GameObject coin1 = coinPoolBronze.GetPooledObject();
		coin1.transform.position = startPos;
		coin1.SetActive(true);

		GameObject coin2 = coinPoolBronze.GetPooledObject();
		coin2.transform.position = new Vector3(startPos.x - distanceBetweenCoin, startPos.y, startPos.z);
		coin2.SetActive(true);

		GameObject coin3 = coinPoolBronze.GetPooledObject();
		coin3.transform.position = new Vector3(startPos.x + distanceBetweenCoin, startPos.y, startPos.z);
		coin3.SetActive(true);
	}
}
