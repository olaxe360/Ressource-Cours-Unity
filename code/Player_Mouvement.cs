using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mouvement : MonoBehaviour
{
    //creation
    private Rigidbody2D rb;

    //stat
    [SerializeField] private float maxSpeed;

    //jump
    private bool CanJumpAgain = true;
    private float jumpTimeRemember = 0, groundTimeRemember = 0;
    private float jumpTimeRememberValue = 0.1f, groundTimeRememberValue = 0.1f;
    [SerializeField] private float jumpCutHeight = 0.5f;
    [SerializeField] private float jumpforce = 15f;
    private float slowfrotfly = 0;

    //checkcollision
    private bool isGrounded = false;
    [SerializeField] private LayerMask groundmask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rotationsprite();
    }

    private void FixedUpdate()
    {
        checkCollision();
        mouvement();
        JumpFixedUpdate();
    }




    private void mouvement()
    {
        float vx = rb.velocity.x; //recuperer la velocité en x du rb donc du jouer dans notre cas


        //vitesse max
        if (Mathf.Abs(vx) > maxSpeed)//si la vitesse du perso depasse maxspeed
        {
            rb.velocity = new Vector3(maxSpeed * vx / (Mathf.Abs(vx)), rb.velocity.y, 0);//on cape la vitesse max
        }


        //contre mouvement
        if (isGrounded) { slowfrotfly = 1f; } else slowfrotfly = 0.1f;
        if (Mathf.Abs(vx) > 0.01f && (Mathf.Abs(Player_Controls.xy.x) < 0.05f) || (vx < -0.01f && Player_Controls.xy.x > 0) || (vx > 0.01f && Player_Controls.xy.x < 0))
        {
            rb.AddForce(Vector2.right * -vx * 12f * slowfrotfly);
        }


        //mouvement
        rb.AddForce(Player_Controls.xy * 100 * Time.deltaTime, ForceMode2D.Impulse);//le addforce pour le déplacement
    }



    public void JumpFixedUpdate()
    {

        //savoir si le sol a été touché réssamment
        if (isGrounded)//si on touche le sol on reset la memoire du sol
        {
            groundTimeRemember = groundTimeRememberValue;

        }
        else groundTimeRemember -= Time.deltaTime;

        //le saut
        if ((jumpTimeRemember > 0) && (groundTimeRemember > 0) && CanJumpAgain)
        {
            CanJumpAgain = false;
            jumpTimeRemember = 0;
            groundTimeRemember = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }


    //permet de faire des jump adaptatif en fonction du temps du bouton jump pressé
    public void jumpUp()
    {
        if (rb.velocity.y > 0 || !isGrounded)
        {

            //les deux ligne qui suis empeche le bug du wall jump pour plus tard
            jumpTimeRemember = 0;
            groundTimeRemember = 0;

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutHeight);
        }
        Invoke("CanJump", 0.001f);
    }

    //se rappeler de la derniere dois que l'on a pressé le bouton jump
    public void jumpDown()
    {
        if (CanJumpAgain)
        {
            jumpTimeRemember = jumpTimeRememberValue;
        }
        else jumpTimeRemember -= Time.deltaTime;
    }

    //tout les Ivokes
    void CanJump()
    {
        CanJumpAgain = true;
    }


    //detecte si colisition avec un layer donner
    private void checkCollision()
    {
        //check si on touche le sol par une boite en dessous le personage (layer: ground)
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f * Mathf.Abs(gameObject.transform.localScale.y) + 0.03f), new Vector2(Mathf.Abs(gameObject.transform.localScale.x) - 0.15f, 0.1f), 0f, groundmask);
    }

    //rotation du sprite du joueur
    private void rotationsprite()
    {
        Vector3 characterScale = transform.localScale;
        if (Player_Controls.xy.x > 0) characterScale.x = Mathf.Abs(characterScale.x);
        if (Player_Controls.xy.x < 0) characterScale.x = -Mathf.Abs(characterScale.x);
        transform.localScale = characterScale;
    }

    //dessiner les boite de collision dans l'éditeur
    private void OnDrawGizmosSelected()
    {
        //montre box isGrounded
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f * Mathf.Abs(gameObject.transform.localScale.y) + 0.03f), new Vector2(Mathf.Abs(gameObject.transform.localScale.x) - 0.15f, 0.1f));
    }


    
}
