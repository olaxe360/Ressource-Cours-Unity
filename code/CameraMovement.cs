using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Vector3 finalPosition;
    private Vector2 vitessecalator;

    private float ppx = 0, ppy = 0;
    private float ccx = 0, ccy = 0;

    public Transform transformjoueur;

    public Rigidbody2D rc;

    public float vitessecam = 4;
    public float distancecam = 2;

    
    void Update()
    {
        getallValue();
    }

	private void FixedUpdate()
	{
        cameraMovement();
	}

    //récupere les différente valeur qu'on a besoin
    private void getallValue()
	{
        ppx = transformjoueur.position.x;
        ppy = transformjoueur.position.y;
        ccx = rc.gameObject.transform.position.x;
        ccy = rc.gameObject.transform.position.y;

    }




    private void cameraMovement()
	{
        /*caméra colé sur le joueur
        finalPosition = transform.position;
        finalPosition.x = ppx;
        finalPosition.y = ppy;
        transform.position = finalPosition;
        */
        
        //caméra devans le joueur
        vitessecalator = new Vector2(ppx - ccx, ppy - ccy);
        rc.velocity = vitessecalator * vitessecam;

        finalPosition = transform.position;
        finalPosition.x = ppx + (ppx-ccx)* distancecam;
        finalPosition.y = ppy;
        transform.position = finalPosition;



    }
}
