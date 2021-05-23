using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public static bool GameOver = false;

    public static int scoreCoins = 0;
    public static Text scoreText;


    
	private void Awake()
	{
        //permet de garder l'objet entre les scenes
        DontDestroyOnLoad(this.gameObject);
	}


	// Update is called once per frame
	void Update()
    {
        if (GameOver) gameOver();

        //actualisation de l'affichage du score
        GameObject.FindGameObjectWithTag("scoreUI").GetComponent<Text>().text = "Score = " + scoreCoins.ToString("0");
        if (scoreCoins > 999) scoreCoins = 0;

    }

    //si on a un gameover alors
    //on charge la scene 0: on change le tuto
    //on reset le score
    private void gameOver()
	{
        loadScene(0);
        GameOver = false;
        scoreCoins = 0;

    }


    //changement de scene au choix
    public static void loadScene(int choix)
	{
        
        switch (choix)
		{
            case 0:
                SceneManager.LoadScene("tuto",LoadSceneMode.Single);
                break;
            case 1:
                SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
                break;
			default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
                break;
		}
	}

}
