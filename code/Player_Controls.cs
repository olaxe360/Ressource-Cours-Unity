using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    //input
    private PlayerInput input;
    public Player_Mouvement Pmove;

    //valeur mouvement
    public static Vector2 xy;


    private void Awake()
    {
        //recupere les information des controles possibles
        input = new PlayerInput();
    }

    //respectivement, active et désactive les contrôles au début et à la fin
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    //setup des bouton
    void Start()
    {
        //se rappeler de la derniere dois que l'on a pressé le bouton jump
        //la fonction InputJumpUp() est appelée quand le boutton est pressé
        input.playerControl.Jump.performed += ctxjumpeform => InputJumpDown();

        //permet de faire des jump adaptatif en fonction du temps du bouton jump pressé
        //la fonction InputJumpUp() est appelée quand le boutton n'est plus pressé
        input.playerControl.Jump.canceled += ctxjumpcancel => InputJumpUp();
    }

    //setup des fleche directionel
    void Update()
    {
        xy = input.playerControl.move.ReadValue<Vector2>();
    }


    private void InputJumpDown()
    {
        Pmove.jumpDown();
    }
    private void InputJumpUp()
    {
        Pmove.jumpUp();
    }

}
