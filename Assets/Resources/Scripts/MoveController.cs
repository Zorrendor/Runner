using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveController : MonoBehaviour {
	
	public GameObject block;
	public GameObject angleBlock;
	public GameObject coin;
	public GameObject barrier;
	
	
	
	public int length = 20;
	private bool unlockRotate = false;
	private bool unlockRun = true;
	private bool unlockJump = true;
	private float rotateAngle = 0.0F;
	
	private Vector3 step;
	private float tempX;
	private GameObject whereRotate;
	private int counter = 0;
//	public static
	
	public float moveSpeed = 5.0F;
	public float jumpSpeed = 5.0F;
	
	private Vector3 forward;
	private Vector3 newPosition;
	private float journeyLength = 0.0F;
	private Vector3 speedVector; 
		
	
	private float currentAngle = 0.0F;
	private float yScale;
	private GUIStyle myStyle;
	//private ArrayList <Vector3> vectorAngle = new ArrayList<Vector3>();
	
//	------------------------------------------------------------------------------------------------
	
	// Use this for initialization
	void Start () {
		myStyle = new GUIStyle();
		myStyle.fontSize = 50;
		
		
		Debug.Log(transform.forward.ToString());
		yScale = 3 / 2.0F;
		gameObject.rigidbody.freezeRotation = true;
//		vectorAngle
		
		GenerateWorld.Instance.GenerateBlocks();
		GenerateWorld.Instance.GenerateBlocks();
//		speedVector = new Vector3(0, moveSpeed, 0.04F);
		
	}

//	------------------------------------------------------------------------------------------------	
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= yScale && transform.position.y >= 0) unlockJump = true;
		if (transform.position.y <= 0) Debug.Log("GameOVER!!!");
		
		forward = transform.forward;
//			forward.y = 0;
				
		 /* + new Vector3(0, 1, 0)*/
		
		if (unlockRun == true)
		{
			newPosition = transform.position + forward * moveSpeed;
			transform.position = Vector3.Lerp(transform.position, newPosition, 0.04F);
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, newPosition, 0.1F);
			if ( Mathf.Abs(transform.position.x - newPosition.x) <= 1F && Mathf.Abs(transform.position.z - newPosition.z) <= 1F)
			{
				transform.Rotate(0, rotateAngle*(-1), 0);
				transform.position = newPosition;
				unlockRun = true;
			}
		}
		
		// Rotate 90 degress left
		
		
		if(Input.GetKeyUp(KeyCode.A))
		{
			if (unlockRotate)
			{
				transform.position = new Vector3(whereRotate.transform.position.x, transform.position.y, 
					whereRotate.transform.position.z);
				transform.Rotate(0, -90, 0);
				unlockRotate = false;
			}
			
			else 
			{
				if(unlockRun == true)
				{
					float temp = forward.x;
					forward.x = forward.z * (-1);
					forward.z = temp; 
//					transform.position = transform.position + forward * length / 3;
					newPosition = newPosition + forward * length / 3;
					unlockRun = false;
					rotateAngle = -45;
					transform.Rotate(0, rotateAngle, 0);
				}
			}
		}
		
		
		if(Input.GetKeyUp(KeyCode.D))
		{
			// Rotate 90 degress right
			//transform.RotateAround(new Vector3(0, 1, 0), -90);
			if (unlockRotate)
			{
				transform.position = new Vector3(whereRotate.transform.position.x, transform.position.y, 
					whereRotate.transform.position.z);
				transform.Rotate(0, 90, 0);
				unlockRotate = false;
			}	
			
			/// move right
			else 
			{
				if (unlockRun == true) 
				{
					float temp = forward.x;
					forward.x = forward.z ;
					forward.z = temp * (-1); 
					newPosition = newPosition + forward * length / 3;
					unlockRun = false;
					rotateAngle = 45;
					transform.Rotate(0, rotateAngle, 0);
				}
			}
			
//			transform.LookAt(transform.position + new Vector3(1, 0, 0));

		}
		
		
		if(Input.GetKeyUp(KeyCode.Space))
		{
			if (unlockJump)
			{
				rigidbody.AddForce(new Vector3(0, 500, 0));
				unlockJump = false;
				//transform.position += transform.position + new Vector3(0, 1, 1) * moveSpeed;
			}
		}
	}
	
//	------------------------------------------------------------------------------------------------
	
	void OnCollisionEnter (Collision col)
	{
//		Debug.Log(col.gameObject.name);
		if (col.gameObject.tag == "Coin") 
		{
			
//			Debug.Log(col.gameObject.name);
			counter++;	
//			col.gameObject.SetActive(false);
//			Destroy(col.gameObject);
			col.gameObject.SetActive(false);
		}
		
		if (col.gameObject.tag == "AngleBlock")
		{
			whereRotate = col.gameObject;
			unlockRotate = true;
			GenerateWorld.Instance.GenerateBlocks();
		
		}
	}
	
//	------------------------------------------------------------------------------------------------	
	
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.tag == "AngleBlock")
		{
			unlockRotate = false;
		}
	}
	
//	------------------------------------------------------------------------------------------------	
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/8,Screen.height/8,58,58), counter.ToString(), myStyle);
	}
}