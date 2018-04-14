using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoin : MonoBehaviour
{
    private PlayAudio myAudio;

    private void Awake()
    {
        myAudio = GetComponent<PlayAudio>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameController.IsPlaying)
        {
            myAudio.ExecuteAudio();
            GameController.AddOneCoin();
        }
    }
}
