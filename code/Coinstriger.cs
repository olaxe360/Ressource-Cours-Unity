using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinstriger : MonoBehaviour
{


    //si entre en collision avec le joueur, incrémente le score coin de 1 et se détruit
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Manager.scoreCoins++;
            Destroy(gameObject, 0f);
        }

    }
}
