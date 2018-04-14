using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public SpawnController spawner;

    //Podriamos usar el LateUpdate()
    private void Update()
    {
        //La camara solo sigue al jugador en el eje X.
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            spawner.CreateNewPlatform();
        }

        if (collision.CompareTag("Pipe"))
        {
            spawner.CreateNewPipes();
        }
    }
}
