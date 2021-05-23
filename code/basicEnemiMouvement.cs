using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemiMouvement : MonoBehaviour
{

	//creation
	private Rigidbody2D rb;

	public LayerMask groundmask;

	private bool isGrounded=false;
	private bool isWall = false;

	[SerializeField]private float maxSpeed = 1f;



	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();

	}

	private void Update()
	{

		checkCollision();

		//retournement/rebondissement
		Vector3 characterScale = transform.localScale;
		if (!isGrounded) characterScale.x *= -1;
		if (isWall) characterScale.x *= -1;
		transform.localScale = characterScale;

		//orientation
		Vector2 look = new Vector2(transform.localScale.x, 0);
		look.Normalize();
		rb.velocity = look * maxSpeed;


	}

	private void checkCollision()
	{
		//avant
		isWall = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, 0), Vector3.right * transform.localScale.x, 0.6f, groundmask);


		//endessous
		isGrounded = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.x * 0.3f, transform.position.y), Vector2.down, 0.6f, groundmask);

	}


	//permet d'afficher des débuger dans l'éditeur
	private void OnDrawGizmosSelected()
	{

		Gizmos.color = Color.green;
		Gizmos.DrawRay(new Vector3(transform.position.x + transform.localScale.x * 0.3f, transform.position.y, 0), Vector3.down * 1f);

		Gizmos.color = Color.blue;
		Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y,0),Vector3.right*0.6f * transform.localScale.x);
	}


}
