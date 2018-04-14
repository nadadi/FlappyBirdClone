using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    public PlayAudio playAudio;

    //Se ejecuta cuando algo choca con el objeto.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Obtenemos el gameobject del objeto colisionado.
        GameObject bird = collision.gameObject;

        //Si el objeto que chocó era el Jugador.
        if (bird.CompareTag("Player"))
        {
            //Obtenemos su script de movimiento y lo destruimos.
            PlayerMovement playerMovement = bird.GetComponent<PlayerMovement>();
            Animator playerAnimator = bird.GetComponent<Animator>();
            Destroy(playerMovement);
            Destroy(playerAnimator);

            //Ejecutamos audio, lo marcamos como muerto y reiniciamos el nivel luego de 3 segundos.
            playAudio.ExecuteAudio();
            GameController.PlayerIsDead();
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
