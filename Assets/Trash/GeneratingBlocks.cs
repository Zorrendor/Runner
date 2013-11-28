using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratingBlocks : MonoBehaviour {
	
	
	public GameObject Block;
	public GameObject angleBlock;
	public GameObject coin;
	public GameObject barrier;	
	public int countBlocks = 30;
	public int length = 20;
	
	private List<GameObject> gameObjects;
	private ArrayList IDList;
	private float coinOffset;
	private float countCoins;
	
	private Quaternion rot;

	
	// Use this for initialization
	void Start () {
		
		IDList = new ArrayList();
		Object newBlock;
		countCoins = length / 3.0F;
		rot = new Quaternion(0, 0, 0, 0);
		float x = 0, y = 0, z = 0;
		float rx = 0, ry = 0, rz = 0;
		bool moveX = true;
		bool moveZ = true;
		float timeDestroy = 0.0F;
//		Block.transform.
		
		IDList.Add(GameObject.Find ("Block").gameObject);
		
		z += length;
		
		newBlock = Instantiate(angleBlock, new Vector3(x, y, z), rot);
		IDList.Add (newBlock);
		
		for (int i = 0; i < countBlocks; i++) {
			switch(Random.Range(0, 3)) {                                // Направление
			case (0): 
				if(moveX)
				{
					coinOffset = length  * Random.Range(-1, 2) / 3.0F;  /// position of Coins
					
					for (int j = 0; j < Random.Range(2, 5); j++) 	// Количество
					{           
						x += length;
						if ( j == 3) x += length;
						newBlock = Instantiate(Block, new Vector3(x, y, z), rot);
						IDList.Add (newBlock);	
						
						
						// Generating coins
						for ( int k = -1; k < 2; k++)
						{
							Instantiate(coin, new Vector3(x + countCoins*k, 3, z + coinOffset), rot);
						}
					}
					// Add angle block
					x += length;
					newBlock = Instantiate(angleBlock, new Vector3(x, y, z), rot);
					IDList.Add (newBlock);	
				}
				moveX = false;
				moveZ = true;
				break;
			case(1): 
				if(moveZ)
				{
					coinOffset = length  * Random.Range(-1, 2) / 3.0F;
					
					for (int j = 0; j < Random.Range(2, 5); j++) {           // Количество
						z += length;
						if ( j == 3) z += length;
						newBlock =  Instantiate(Block, new Vector3(x, y, z), rot);
						IDList.Add (newBlock);
						
												// Generating coins
						for ( int k = -1; k < 2; k++)
						{
							Instantiate(coin, new Vector3(x + coinOffset, 3, z + countCoins*k), rot);
						}
					}
					z += length;
					newBlock = Instantiate(angleBlock, new Vector3(x, y, z), rot);
					IDList.Add (newBlock);						
				}
				moveZ = false;
				moveX = true;
				break;
			case (2): 
				if (moveX)
				{
					coinOffset = length  * Random.Range(-1, 2) / 3.0F;
					
					for (int j = 0; j < Random.Range(2, 5); j++) {           // Количество
						x -= length;
						if ( j == 3) x -= length;
						newBlock = Instantiate(Block, new Vector3(x, y, z), rot);
						IDList.Add (newBlock);
						
						// Generating coins
						for ( int k = -1; k < 2; k++)
						{
							Instantiate(coin, new Vector3(x + countCoins*k, 3, z + coinOffset), rot);
						}
					}
					x -= length;
					newBlock = Instantiate(angleBlock, new Vector3(x, y, z), rot);
					IDList.Add (newBlock);					
				}
				moveX = false;
				moveZ = true;
				break;
			case (3): 
				if (moveZ)
				{
					for (int j = 0; j < Random.Range(2, 5); j++) {           // Количество
						z -= length;
						if ( j == 3) z -= length;
						newBlock = Instantiate(Block, new Vector3(x, y, z), rot);
						IDList.Add (newBlock);
					}
					z -= length;
					newBlock = Instantiate(angleBlock, new Vector3(x, y, z), rot);
					IDList.Add (newBlock);					
				}
				moveZ = false;
				moveX = true;
				break;	
			}	
		}
		
		
		foreach (Object gm in IDList)
		{
			timeDestroy += 2.0F;
			Destroy(gm, timeDestroy);
		}
	}
	

}
