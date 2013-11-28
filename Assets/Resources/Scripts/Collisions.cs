using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {
	
	private int counter = 0;
	
	private static GUIStyle myStyle;
	// Use this for initialization
	void Start () 
	{
		myStyle = new GUIStyle();
		myStyle.fontSize = 50;
	}
	
	void OnCollisionEnter (Collision col)
	{
		Debug.Log(col.gameObject.name);
		if (col.gameObject.tag == "Coin") 
		{
//			Debug.Log(col.gameObject.name);
			counter++;	
			Destroy(col.gameObject);
		}
		
		if (col.gameObject.tag == "AngleBlock")
		{
//			MoveController.unlockRotate = true;
//			if(Input.GetKeyUp(KeyCode.A))
//			{
//				Debug.Log("Hello World");
//				transform.Rotate(0, -90, 0);
//			}
//			
//			if(Input.GetKeyUp(KeyCode.D))
//			{
//				transform.Rotate(0, 90, 0);
//			}
		}
	}
	
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "AngleBlock")
		{
//			MoveController.unlockRotate = false;
//			if(Input.GetKeyUp(KeyCode.A))
//			{
//				Debug.Log("Hello World");
//				transform.Rotate(0, -90, 0);
//			}
//			
//			if(Input.GetKeyUp(KeyCode.D))
//			{
//				transform.Rotate(0, 90, 0);
//			}
		}
	}
	
	
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/8,Screen.height/8,58,58), counter.ToString(), myStyle);
	}
}
