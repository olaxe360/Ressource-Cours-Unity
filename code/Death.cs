using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{


	//si on rentre en collison le joueur meurt
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Manager.GameOver = true;
		}
	}




}
