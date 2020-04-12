using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
 //   public Transform Fence;
 //   private Touch touch;
 //   private float speedModifier;
 //   private Boundary restrictionBoundary;
 //   private Rigidbody rigidBody;

 //   //private Vector3 delta;
 //   //private Vector3 startPostion;
 //   //private Vector3 endPosition;
 //   //private Vector3 lastPosition;

 //   // Start is called before the first frame update
 //   void Start()
 //   {
 //       speedModifier = 0.01f;
 //       restrictionBoundary = new Boundary(Fence.GetChild(8).position.z,
 //           Fence.GetChild(9).position.z,
 //           Fence.GetChild(7).position.x,
 //           Fence.GetChild(6).position.x);
 //       rigidBody = GetComponent<Rigidbody>();
 //   }

 //   private void FixedUpdate()
 //   {

	//	//}
	//	//void Update()
	//	//{
	//	if (Input.touchCount > 0)
	//	{
	//		touch = Input.GetTouch(0); //Index of first touch
	//		if (touch.phase == TouchPhase.Moved)
	//		{
	//			rigidBody.position = new Vector3(
	//				Mathf.Clamp(transform.position.x + touch.deltaPosition.x * speedModifier, restrictionBoundary.xMin, restrictionBoundary.xMax),
	//				transform.position.y,
	//				Mathf.Clamp(transform.position.z + touch.deltaPosition.y * speedModifier, restrictionBoundary.zMin, restrictionBoundary.zMax));

	//		}
	//	}
	//}


	//GameManager gm;

	//// Use this for initialization
	//void Start()
	//{
	//	gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
	//}

	//// Update is called once per frame
	//void Update()
	//{

	//}

	//void OnTriggerEnter(Collider c)
	//{
	//	if (c.tag == "AI_GOAL")
	//	{
	//		gm.pScore += 1f;
	//		gm.Reset(1);
	//	}
	//	if (c.tag == "PLAYER_GOAL")
	//	{
	//		gm.eScore += 1f;
	//		gm.Reset(0);
	//	}
	//}

}

class Boundary{

	public float zMin, zMax, xMin, xMax;
	public Boundary(float up, float down, float right, float left)
	{
		zMax = up;
		zMin = down;
		xMin = left;
		xMax = right;
	}

}


