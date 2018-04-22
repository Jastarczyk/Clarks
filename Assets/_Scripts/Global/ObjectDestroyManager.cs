using UnityEngine;
using System.Collections;

public class ObjectDestroyManager : MonoBehaviour {

	public int objectEndurance;
	float damageCooldown = 2f;
	float timer;

	void Update ()
	{
		timer += Time.deltaTime;
	}

	void LateUpdate()
	{
		if(objectEndurance <= 0)
		{
			Destroy(gameObject, 0.2f);
		}

	}
		void OnTriggerStay(Collider objectCol) 
		{
			if(objectCol.CompareTag("Target") && timer > damageCooldown)
			{
				objectEndurance--;
				timer = 0;

			}
		}
}
