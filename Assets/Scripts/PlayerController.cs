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

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento constante
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

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
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    public void RotateGameObject(KeyCode key, Vector3 rotation)
    {
        if (Input.GetKeyDown(key))
        {
            transform.rotation *= Quaternion.Euler(rotation);
        }
    }
}
