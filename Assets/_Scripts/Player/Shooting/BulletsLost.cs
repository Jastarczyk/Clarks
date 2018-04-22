using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletsLost : MonoBehaviour 
{
	
	PlayerShooting playerShooting;
	Image image;
	public Sprite[] sprites;
	

	void Start () 
	{
		playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
		image = GetComponent<Image>();
	}

	void Update () 
	{
		image.sprite = sprites[(int)playerShooting.LoadedBullets];
	}
		

}
