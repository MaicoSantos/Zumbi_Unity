using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade = 25;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition( GetComponent<Rigidbody>().position + 
        transform.forward * Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoColisao) {
        
        if(objetoColisao.tag == "Inimigo")
        {
            Destroy(objetoColisao.gameObject);
        }

        Destroy(gameObject);
    }
}
