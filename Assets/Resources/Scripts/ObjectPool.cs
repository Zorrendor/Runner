using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour 
{
	private static ObjectPool instance;
	public static ObjectPool Instance{
		get{
			return instance;
		}
	}
	
	// for Blocks
	public GameObject [] blocksZ = null;
	public int countBlocksZ = 7;
	private int indexBlockZ = 0;
	
	// for Blocks
	public GameObject [] blocksX = null;
	public int countBlocksX = 7;
	private int indexBlockX = 0;
	
	// for AngleBox
	public GameObject [] angleBlocks = null;
	public int countAngleBlocks = 3;
	private int indexAngleBlock = 0;
	
	// for Coins
	public GameObject [] coins = null;
	public int countCoins = 40;
	private int indexCoin = 0;
	
	// Use this for initialization
	public void Awake () 
	{
		instance = this;		
		blocksZ = new GameObject[countBlocksZ];
		blocksX = new GameObject[countBlocksX];
		angleBlocks = new GameObject[countAngleBlocks];
		coins = new GameObject[countCoins];
		this.InstantiateObjects();
	
	}
	
	public ObjectPool () 
	{
		blocksZ = new GameObject[countBlocksZ];
		blocksX = new GameObject[countBlocksX];
		angleBlocks = new GameObject[countAngleBlocks];
		coins = new GameObject[countCoins];
	
	}
	

	
	public void InstantiateObjects () 
	{
//		blocks = new GameObject[countBlocks];
		for (int i = 0; i < countBlocksZ; i++)
		{
			blocksZ[i] = (GameObject)Instantiate(Resources.Load("Prefabs/RoadWallZ"));
			blocksZ[i].SetActive(false);
		}
		
		for (int i = 0; i < countBlocksZ; i++)
		{
			blocksX[i] = (GameObject)Instantiate(Resources.Load("Prefabs/RoadWallX"));
			blocksX[i].SetActive(false);
		}
		
		for (int i = 0; i < countAngleBlocks; i++)
		{
			angleBlocks[i] = (GameObject)Instantiate(Resources.Load("Prefabs/AngleBlock"));
			angleBlocks[i].SetActive(false);

		}
		
		for (int i = 0; i < countCoins; i++)
		{
			coins[i] = (GameObject)Instantiate(Resources.Load("Prefabs/Coin"));
			coins[i].SetActive(false);

		}
		
	}
	
//	---------------------------------------------------------------------	
	public GameObject GetBlockZ (Vector3 position) 
	{
		if(indexBlockZ == countBlocksZ) indexBlockZ = 0;
		blocksZ[indexBlockZ].transform.position = position;
		blocksZ[indexBlockZ].SetActive(true);
		indexBlockZ++;
		return blocksZ[indexBlockZ-1];
	}
//	---------------------------------------------------------------------	
	public GameObject GetBlockX (Vector3 position) 
	{
		if(indexBlockX == countBlocksX) indexBlockX = 0;
		blocksX[indexBlockX].transform.position = position;
		blocksX[indexBlockX].SetActive(true);
		indexBlockX++;
		return blocksX[indexBlockX-1];
	}
//	---------------------------------------------------------------------	
	public GameObject GetAngleBlock (Vector3 position) 
	{
		if(indexAngleBlock == countAngleBlocks) indexAngleBlock = 0;
		angleBlocks[indexAngleBlock].transform.position = position;
		angleBlocks[indexAngleBlock].SetActive(true);
		indexAngleBlock++;
		return angleBlocks[indexAngleBlock-1];
	}
	
	
//	---------------------------------------------------------------------	
	public GameObject GetCoin (Vector3 position) 
	{
		if(indexCoin == countCoins) indexCoin = 0;
		coins[indexCoin].transform.position = position;
		coins[indexCoin].SetActive(true);
		indexCoin++;
		return coins[indexCoin-1];
	}	
	
	
//	---------------------------------------------------------------------	
		
}
