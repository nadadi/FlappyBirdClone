using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject message;
    public Text coinText;
    private SpriteRenderer playerRenderer;
    private static int score;
    private static bool isPlaying;

    private void Awake()
    {
        playerRenderer = player.GetComponent<SpriteRenderer>();
        coinText.enabled = false;
        playerRenderer.enabled = false;
        score = 0;
    }

    private void Update()
    {
        //Esto no deberíamos hacerlo porque es ineficiente, podríamos cambiar 
        //GameController para que fuera un Singleton. Eso cambiaría la lógica de algunos scripts.
        coinText.text = score.ToString();
    }

    public void BeginGame()
    {
        message.SetActive(false);
        coinText.enabled = true;
        playerRenderer.enabled = true;
        isPlaying = true;
    }

    public static void AddOneCoin()
    {
        if (isPlaying)
            score++;
    }

    public static void PlayerIsDead()
    {
        isPlaying = false;
    }

    public static bool IsPlaying
    {
        get
        {
            return isPlaying;
        }

        set
        {
            isPlaying = value;
        }
    }
}
