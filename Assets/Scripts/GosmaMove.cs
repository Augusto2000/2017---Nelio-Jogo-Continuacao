﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosmaMove : MonoBehaviour {

    public float velocidadeHorizontal;
    public float velocidadeVertical;
    public float min;
    public float max;
    public float espera;
    private GameObject player;
    private bool pontuou = false;

    private GameObject player;
    private bool pontuou = false;

    private void Awake() {
        player = GameObject.Find("Player");
    }

    void Start () {
        StartCoroutine(Move(min));
	}

    private void Awake() {
        player = GameObject.Find("Player");
    }

    void Update () {
        Vector3 velocidadeVetorial = Vector3.left * velocidadeHorizontal;
        transform.position = transform.position + velocidadeVetorial * Time.deltaTime;
        if (!pontuou && GameController.instancia.estado == Estado.Jogando) {
            if (transform.position.x < player.transform.position.x) {
                GameController.instancia.incrementarPontos(1);
                pontuou = true;
            }
        }
<<<<<<< HEAD

    }
=======
	}
>>>>>>> 6abb0c7cc58a58c27e5568d5e7d0c98c3e3f936a

    IEnumerator Move(float destino) {
        while (Mathf.Abs(destino - transform.position.y) > 0.2f) {
            Vector3 direcao = (destino == max) ? Vector3.up : Vector3.down;
            Vector3 velocidadeVetorial = direcao * velocidadeVertical;
            transform.position = transform.position + velocidadeVetorial * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(espera);

        destino = (destino == max) ? min : max;
        StartCoroutine(Move(destino));
    }
}
