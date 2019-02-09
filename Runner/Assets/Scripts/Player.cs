using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	[SerializeField]
	private Rigidbody rigidBody;
	
	[SerializeField]
	private float speed;

	[SerializeField]
	private float sideSpeed;

	private float spawnX= -0.473f;
	private float spawnY=	-0.703f;
	private float spawnZ=	-5.34f;

	void Start () {
		
	}
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			//Move left
		rigidBody.AddForce(-sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			//Move right
		rigidBody.AddForce(sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		else if(Input.GetKey(KeyCode.W))
		{
			//Move front
		rigidBody.AddForce(0, 0, speed * Time.deltaTime, ForceMode.VelocityChange);
		}
		else if(Input.GetKey(KeyCode.S))
		{
		rigidBody.AddForce(0, 0, -speed * Time.deltaTime, ForceMode.VelocityChange);
		}
	}

	private void OnCollisionEnter(Collision other) {
	
	if(other.gameObject.tag == "Obstacle"){
		
		rigidBody.AddForce(0,0,-speed*100);

	}	

	}

	private void OnTriggerEnter(Collider other) {


		if(other.gameObject.tag=="Relocation"){

		  this.transform.position= new Vector3(spawnX, spawnY, spawnZ);

		}

	  if(other.tag == "Springboard"){
			rigidBody.AddForce(0,500,0);	
		}

		if(other.gameObject.tag=="Coin"){
			//destroy object
			Destroy(other.gameObject);

			speed=speed+5;
			sideSpeed=sideSpeed+2;

			Debug.Log("+1 COIN");
		}
				
		if(other.gameObject.tag=="Finish"){
			
			this.enabled=false;

			Debug.Log("FOU WON");
		}
	}


}
