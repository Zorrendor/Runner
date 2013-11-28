using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour 
{
	public GameObject explosion; 
	
	void OnDestroy()
	{
		Destroy(Instantiate(explosion, transform.position, transform.rotation), 2.0F);		
	}
}
