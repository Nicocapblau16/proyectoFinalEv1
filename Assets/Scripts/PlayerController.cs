using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 startPos = new Vector3(0, 100, 0);

    private float limX = 200f;
    private float limY = 200f;
    private float limLowY = 0f;
    private float limZ = 200f;

    private  float speed = 20f;
    //private float horizontalInput;
    //private float verticalInput;

    public AudioClip shootClip;

    private AudioSource cameraAudioSource;
    private AudioSource playerAudioSource;

    public GameObject projectilePrefab;
    public GameObject recoletable;
    public GameObject obstacle;

    private float spawnRate = 5f;
    private float spawnMargin = 5f;

    private Vector3 randomPos;

    private int score;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // posicion inicial
        transform.position = startPos;

        //marcador a 0
        score = 0;

        //spawn de recolectables
        for (float coinInstances = 10f; coinInstances >=0; coinInstances -= 1f)
        {
            randomPos = RandomPosition();
            Instantiate(recoletable, randomPos, recoletable.transform.rotation);
        }

        //inicio corrutina


        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento constante
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

       // horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        //limites
        if (transform.position.x <= -limX)
        {
            transform.position = new Vector3(-limX, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= limX)
        {
            transform.position = new Vector3(limX, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= limLowY) 
        {
            transform.position = new Vector3(transform.position.x, limLowY, transform.position.z);
        }
        if (transform.position.y >= limY)
        {
            transform.position = new Vector3(transform.position.x, limY, transform.position.z);
        }
        if (transform.position.z <= -limZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limZ);
        }
        if (transform.position.z >= limZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limZ);
        }

        //rotacion ortopedica del helicoptero
        RotateGameObject(KeyCode.A, new Vector3(0, -10, 0));
        RotateGameObject(KeyCode.D, new Vector3(0, 10, 0));
        RotateGameObject(KeyCode.W, new Vector3(-10, 0, 0));
        RotateGameObject(KeyCode.S, new Vector3(10, 0, 0));



        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            //disparo
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation = transform.rotation);

            playerAudioSource.PlayOneShot(shootClip, 1);
        }
    }

    public void RotateGameObject(KeyCode key, Vector3 rotation)
    {
        if (Input.GetKeyDown(key))
        {
            transform.rotation *= Quaternion.Euler(rotation);
        }
    }


    // Genera una posicion aleatoria 
    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-limX + spawnMargin, limX - spawnMargin), Random.Range(limLowY + spawnMargin, limY - spawnMargin), Random.Range(-limZ + spawnMargin, limZ - spawnMargin));
    }

    private IEnumerator SpawnObstacle()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            randomPos = RandomPosition();
            Instantiate(obstacle, randomPos, recoletable.transform.rotation);

        }

    }
}
