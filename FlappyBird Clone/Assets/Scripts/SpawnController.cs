using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject topPipe;
    public GameObject downPipe;
    public GameObject platform;
    public float distanceBetweenPlatforms = 4f;
    private float xPlatformValue = 3.36f;
    private float xPipeValue = 2f;

    private void Awake()
    {
        //Inicializamos los valores X de las plataformas y los tubos.
        xPlatformValue = 3.36f;
        xPipeValue = 2f;

        //Creamos 3 plataformas y 3 tubos (superior e inferior).
        for (int i = 0; i < 3; i++)
        {
            //Creamos la plataforma.
            CreateNewPlatform();

            //Creamos los tubos.
            CreateNewPipes();
        }
    }

    public void CreateNewPipes()
    {
        //Se calcula aleatoriamente la altura del tubo superior.
        float yTopValue = Random.Range(1.5f, 3.5f);
        //En base a la plataforma superior asignamos el tubo inferior.
        float yDownValue = yTopValue - distanceBetweenPlatforms;

        GameObject theTopPipe = Instantiate(topPipe, new Vector3(xPipeValue, yTopValue, 0f), Quaternion.identity);
        GameObject theDownPipe = Instantiate(downPipe, new Vector3(xPipeValue, yDownValue, 0f), Quaternion.identity);
        xPipeValue = xPipeValue + 2f;
    }

    public void CreateNewPlatform()
    {
        GameObject thePlatform = Instantiate(platform, new Vector3(xPlatformValue, -2f, 0f), Quaternion.identity);
        xPlatformValue = xPlatformValue + 3.36f;
    }
}
