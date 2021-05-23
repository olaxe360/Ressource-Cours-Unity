using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{

    Vector3 direction;
    [SerializeField] private Transform player;
    private float Zangle = 0;
    private Rigidbody2D rb;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject balleprefab;
    [SerializeField] private float bulletForce;
    [SerializeField] private float tickshoot;
    private float tickshoottimer = 0;
    private bool isshooting;
    [SerializeField] private float range;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        Lookandshoot();
        shoottimer();
    }

    //fonction qui permet d'avoir l'orientation du canon par rapport au joueur + la distance par rapport au joueur
    private void Lookandshoot()
    {
        //calcul du vecteur direction
        direction = player.position - transform.position;
        direction.z = 0;

        //test si le joueur est dans la portée du canon
        if (direction.magnitude < range)
        {
            isshooting = true;
        }
        else isshooting = false;

        //calcul et application de l'angle du canon
        direction.Normalize();
        Zangle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = Zangle + 180;
    }

    private void shoottimer()
    {
        //cooldown entre chaque tire
        tickshoottimer += Time.deltaTime;
        if(tickshoottimer > tickshoot && isshooting)
		{
            shoot();
            tickshoottimer = 0;

		}
    }

    //création de la balle + apliquer les forces dessus
    private void shoot()
    {
        GameObject balle = Instantiate(balleprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rbu = balle.GetComponent<Rigidbody2D>();
        rbu.AddForce(-firepoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
