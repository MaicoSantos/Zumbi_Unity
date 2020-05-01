using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public float Velocidade = 10;
    Vector3 direcao;

    void Update()
    {
        float eixo_X = Input.GetAxis("Horizontal");
        float eixo_Z = Input.GetAxis("Vertical");

        direcao = new Vector3(eixo_X, 0, eixo_Z);


        // transform.Translate(direcao * Velocidade * Time.deltaTime);

        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }
    }

     void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + 
        (direcao * Velocidade * Time.deltaTime));
    }
}
