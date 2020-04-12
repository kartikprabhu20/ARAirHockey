using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Fence;
    private Touch touch;
    private float speedModifier;
    private Boundary restrictionBoundary;
    private Rigidbody rigidBody;
	public GameObject puck;

	BoxCollider coll;
	Rigidbody striker;
	GameObject st;
	public float playerSpeed; //set value from inspector
	public float strikerSpeed; //speed at which striker moves
	private bool isDown = false;

	void Awake()
	{
		strikerSpeed = PlayerPrefs.GetFloat("Striker_Speed");
	}


	//private Vector3 delta;
	private Vector3 startPosition;
	//private Vector3 endPosition;
	//private Vector3 lastPosition;

	// Start is called before the first frame update
	void Start()
    {
        speedModifier = 0.01f;
        restrictionBoundary = new Boundary(Fence.GetChild(8).position.z,
            Fence.GetChild(9).position.z,
            Fence.GetChild(7).position.x,
            Fence.GetChild(6).position.x);
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

		//}
		//void Update()
		//{
		//Input.simulateMouseWithTouches;

		if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0); //Index of first touch
            if (touch.phase == TouchPhase.Moved)
            {
                rigidBody.position = new Vector3(
                    Mathf.Clamp(transform.position.x + touch.deltaPosition.x * speedModifier, restrictionBoundary.xMin, restrictionBoundary.xMax),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z + touch.deltaPosition.y * speedModifier, restrictionBoundary.zMin, restrictionBoundary.zMax));

            }
        }


		if (Input.GetMouseButtonDown(0))
		{
			isDown = true;
			startPosition = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0))
		{
			isDown = false;
		}
		if (isDown)
		{


			rigidBody.position = new Vector3(
							   Mathf.Clamp(transform.position.x + (startPosition.x - Input.mousePosition.x) * speedModifier, restrictionBoundary.xMin, restrictionBoundary.xMax),
							   transform.position.y,
							   Mathf.Clamp(transform.position.z + (startPosition.y - Input.mousePosition.y) * speedModifier, restrictionBoundary.zMin, restrictionBoundary.zMax));
			startPosition = Input.mousePosition;

			//Vector3 targetVelocity = new Vector3(
			//				   Mathf.Clamp(transform.position.x + (startPosition.x - Input.mousePosition.x) * speedModifier, restrictionBoundary.xMin, restrictionBoundary.xMax),
			//				   transform.position.y,
			//				   Mathf.Clamp(transform.position.z + (startPosition.y - Input.mousePosition.y) * speedModifier, restrictionBoundary.zMin, restrictionBoundary.zMax));
			//startPosition = Input.mousePosition;
			//Debug.Log("targetvelocity");
			//Debug.Log(targetVelocity);

			//targetVelocity = transform.TransformDirection(targetVelocity);
			//targetVelocity *= speedModifier;

			//// Apply a force that attempts to reach our target velocity
			//Vector3 velocity = rigidBody.velocity;
			//Debug.Log("velocity");
			//Debug.Log(velocity);

			//Vector3 velocityChange = targetVelocity - velocity;
			//Debug.Log("velocityChange");
			//Debug.Log(velocityChange);

			//Debug.Log(velocityChange);
			////velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			////velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			//velocityChange.y = 0;
			//rigidBody.AddForce(targetVelocity, ForceMode.VelocityChange);
		}



	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "puck")
		{
			//ai.counter = 0f; //see AI.cs for explanation

		 //puck.gameobject.velocity = new Vector3(strikerSpeed, striker.velocity.y, strikerSpeed);
		    puck.GetComponent<Rigidbody>().AddForce(new Vector3(rigidBody.velocity.x * 100, 0f, rigidBody.velocity.z * 100));
			//striker.velocity = new Vector3(-strikerSpeed, striker.velocity.y, strikerSpeed);


		}
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
     

}
