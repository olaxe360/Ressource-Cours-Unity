using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    private float destroyitselftime = 0;
    private float destroyitselffinal = 10f;


    

    void Update()
    {
        //cooldown d'auto déstruction
        destroyitselftime += Time.deltaTime;
        if (destroyitselftime > destroyitselffinal) Destroy(gameObject, 0f);
    }

    //entre en collision avec soit
	private void OnTriggerEnter2D(Collider2D other)
	{
        //le sol et se détruit
		if(other.CompareTag("Ground"))
		{
            Destroy(gameObject, 0f);
		}

        //le joueur et le tue
        if (other.CompareTag("Player"))
        {
            Manager.GameOver = true;
            Destroy(gameObject, 0f);
        }
    }
}
