using UnityEngine;
using System.Collections;

public class DoorsOpen : MonoBehaviour 
{
	public GameObject room;
	public GameObject garden;
	public GameObject textHint;
	Collider openArea;
	AudioSource doorsSound;

	float timer= 0.0f;
	bool opening;

	void Start()
	{
		openArea = GetComponent<Collider>();
		doorsSound = GetComponent<AudioSource>();
		textHint.SetActive(false);
	}

	void Update()
	{
		if (opening)
			OpenDoor();	
	}
	
	void OnTriggerStay(Collider doorsCol)
	{

		if (doorsCol.CompareTag("Player"))
		{
			textHint.SetActive(true);

			if (Input.GetKey("f"))
			{
				opening = true;
				openArea.enabled = false;
				textHint.SetActive(false);
				doorsSound.Play();
			}
		}
	}

	void OnTriggerExit(Collider doorsCol)
	{
		if(doorsCol.CompareTag("Player"))
			textHint.SetActive(false);
	}

	void OpenDoor()
	{
		timer += Time.deltaTime;
		transform.rotation = Quaternion.Euler(new Vector3(0f, Mathf.LerpAngle(90, 180, 0.6f * timer) ,0f));
		if(transform.rotation.y == 180)
			opening = false;
	}

}
