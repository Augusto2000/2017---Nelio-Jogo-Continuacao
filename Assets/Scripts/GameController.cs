using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject menuCamera;
    public GameObject menuPanel;
<<<<<<< HEAD
    
=======
    public GameObject gameOverPanel;
    public GameObject pontosPanel;
>>>>>>> 6abb0c7cc58a58c27e5568d5e7d0c98c3e3f936a

    public Estado estado { get; private set; }

    public GameObject obstaculo;
    public float espera;
    public float tempoDestruicao;
    private int pontos;
    public Text txtPontos;

    private int pontos;
    public Text txtPontos;
    public Text txtMaiorPontuacao;

    public static GameController instancia = null;

<<<<<<< HEAD
   

    private void atualizarPontos(int x) {
        pontos = x;
        txtPontos.text = "" + x;
    }

    public void incrementarPontos(int x) {
        atualizarPontos(pontos + x);
    }


=======
    private List<GameObject> obstaculos;
>>>>>>> 6abb0c7cc58a58c27e5568d5e7d0c98c3e3f936a

    void Awake() {
        if (instancia == null) {
            instancia = this;
        }
        else if (instancia != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

	void Start () {
        obstaculos = new List<GameObject>();
        estado = Estado.AguardoComecar;
        PlayerPrefs.SetInt("HighScore", 0);
        menuCamera.SetActive(true);
        menuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        pontosPanel.SetActive(false);
    }

    IEnumerator GerarObstaculos() {
        while (GameController.instancia.estado == Estado.Jogando) {
            Vector3 pos = new Vector3(7.7f, Random.Range(1f, 5f), 0f);
            GameObject obj = Instantiate(obstaculo, pos, Quaternion.identity) as GameObject;
            obstaculos.Add(obj);
            StartCoroutine(DestruirObstaculo(obj));
            yield return new WaitForSeconds(espera);
        }
	}

    IEnumerator DestruirObstaculo(GameObject obj) {
        yield return new WaitForSeconds(tempoDestruicao);
        if (obstaculos.Remove(obj)) {
            Destroy(obj);
        }
    }

    public void PlayerComecou() {
        estado = Estado.Jogando;
        menuCamera.SetActive(false);
        menuPanel.SetActive(false);
<<<<<<< HEAD
=======
        pontosPanel.SetActive(true);
>>>>>>> 6abb0c7cc58a58c27e5568d5e7d0c98c3e3f936a
        atualizarPontos(0);
        StartCoroutine(GerarObstaculos());
    }

    public void PlayerMorreu() {
        estado = Estado.GameOver;
        if (pontos > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", pontos);
            txtMaiorPontuacao.text = "" + pontos;
        }
        gameOverPanel.SetActive(true);
    }

    public void PlayerVoltou() {
        while (obstaculos.Count > 0) {
            GameObject obj = obstaculos[0];
            if (obstaculos.Remove(obj)) {
                Destroy(obj);
            }
        }
        estado = Estado.AguardoComecar;
        menuCamera.SetActive(true);
        menuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        pontosPanel.SetActive(false);
        GameObject.Find("micro_zombie_mobile").GetComponent<PlayerController>().recomecar();
    }

    private void atualizarPontos(int x) {
        pontos = x;
        txtPontos.text = "" + x;
    }

    public void incrementarPontos(int x) {
        atualizarPontos(pontos + x);
    }
}
