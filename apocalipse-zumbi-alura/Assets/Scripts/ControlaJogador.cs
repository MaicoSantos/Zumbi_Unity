using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public float Velocidade = 10;
    Vector3 direcao;
    public LayerMask MascaraPiso;
    public GameObject TextoGameOver;
    public bool Vivo = true ;

    private void Start()
    {
        Time.timeScale = 1;
    }

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

           if(Vivo == false)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

     void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + 
        (direcao * Velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraPiso))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotação = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotação);
        }

     
    }
}
