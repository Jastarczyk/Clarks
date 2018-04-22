using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	PlayerController player;
	Rigidbody rb;
	public float bulletSpeed;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		rb = GetComponent<Rigidbody>();

		rb.velocity = player.transform.forward * bulletSpeed;
	}

	void OnTriggerEnter()
	{
		Destroy(gameObject);	
	}
}
