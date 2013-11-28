using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateWorld : MonoBehaviour {
	
	private static GenerateWorld instance;
	public static GenerateWorld Instance{
		get{
			return instance;
		}
	}
	
	// Use this for initialization
	public int length = 20;
	
	private static List<object> objectList = new List<object>();
	private float coinOffset;
	private float countCoins;
	private float x=0, y=0, z=0;
	private static bool moveX = false;
	private static bool moveZ = true;
//	private Quaternion rot;
	private object newBlock;
	
	void Awake() 
	{
		instance = this;
		countCoins = length / 3.0F;
		x = 0;
		y = 0;
		z = 0;
		newBlock = ObjectPool.Instance.GetBlockZ(new Vector3(0, 0, 0));
		objectList.Add (newBlock);
//		rot = new Quaternion(0, 0, 0, 0);
		z += length;
		newBlock = ObjectPool.Instance.GetBlockZ(new Vector3(x, y, z));
		objectList.Add (newBlock);
		z += length;
	}
	
	public void GenerateBlocks() {
//		Debug.Log("Generate Block!!!!!");
		int move = Random.Range(0, 3);
		switch(move) {                                // Направление
			case 0: 
				if(moveX)
				{
					coinOffset = length  * Random.Range(-1, 2) / 3.0F;  /// position of Coins
					
					for (int j = 0; j < Random.Range(2, 5); j++) 	// Количество
					{           
						x += length;
						if ( j == 3) x += length;
						newBlock = ObjectPool.Instance.GetBlockX(new Vector3(x, y, z));
						objectList.Add (newBlock);	
						
						
						// Generating coins
						for ( int k = -1; k < 2; k++)
						{
							ObjectPool.Instance.GetCoin(new Vector3(x + countCoins*k, 3, z + coinOffset));
						}
					}
					// Add angle block
					x += length;
					newBlock = ObjectPool.Instance.GetAngleBlock(new Vector3(x, y ,z));
				
					objectList.Add (newBlock);	
				
					moveX = false;
					moveZ = true;
					break;
				}
				else goto case 1; 

			case 1: 
				if(moveZ)
				{
					coinOffset = length  * Random.Range(-1, 2) / 3.0F;
					
					for (int j = 0; j < Random.Range(2, 5); j++) {           // Количество
						z += length;
						if ( j == 3) z += length;
						newBlock = ObjectPool.Instance.GetBlockZ(new Vector3(x, y, z));
						objectList.Add (newBlock);
						
												// Generating coins
						for ( int k = -1; k < 2; k++)
						{
							ObjectPool.Instance.GetCoin(new Vector3(x + coinOffset, 3, z + countCoins*k));
						}
					}
					z += length;
					newBlock = ObjectPool.Instance.GetAngleBlock(new Vector3(x, y ,z));
					objectList.Add (newBlock);	
					moveZ = false;
					moveX = true;	
					break;
				}
				else goto case 2; 
			case 2: 
				if (moveX)
				{
					coinOffset = length  * Random.Range(-1, 2) / 3.0F;
					
					for (int j = 0; j < Random.Range(2, 5); j++) {           // Количество
						x -= length;
						if ( j == 3) x -= length;
						newBlock = ObjectPool.Instance.GetBlockX(new Vector3(x, y, z));
						objectList.Add (newBlock);
						
						// Generating coins
						for ( int k = -1; k < 2; k++)
						{
							ObjectPool.Instance.GetCoin(new Vector3(x + countCoins*k, 3, z + coinOffset));
						}
					}
					x -= length;
					newBlock = ObjectPool.Instance.GetAngleBlock(new Vector3(x, y ,z));
					objectList.Add (newBlock);
				
					moveX = false;
					moveZ = true;
					break;
				}
				else goto case 1; 
				
			case 3: 
				if (moveZ)
				{
					for (int j = 0; j < Random.Range(2, 5); j++) {           // Количество
						z -= length;
						if ( j == 3) z -= length;
						newBlock = ObjectPool.Instance.GetBlockZ(new Vector3(x, y, z));
//						newBlock = Instantiate(block, new Vector3(x, y, z), rot);
						objectList.Add (newBlock);
					}
					z -= length;
//					newBlock = Instantiate(angleBlock, new Vector3(x, y, z), rot);
					newBlock = ObjectPool.Instance.GetAngleBlock(new Vector3(x, y ,z));
					objectList.Add (newBlock);					
				}
				moveZ = false;
				moveX = true;
				break;	
			}	
	}
	
	
//	-------------------------------------------------------------------------------------
	public void InitFirstBlocks ()
	{
	}
	
//	-------------------------------------------------------------------------------------
	private void PushBlock ( GameObject gm) {
	}
	
//	-------------------------------------------------------------------------------------
	
	private void GenerateTransformedBlock () {
		
	}
}
