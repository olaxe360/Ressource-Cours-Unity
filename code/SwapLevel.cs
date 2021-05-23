using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapLevel : MonoBehaviour
{

	[SerializeField] private int level;

	//si on entre en collision, on change de scene
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Manager.loadScene(level);
		}
	}
}
