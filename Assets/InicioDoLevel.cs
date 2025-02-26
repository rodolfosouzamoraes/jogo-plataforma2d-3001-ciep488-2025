using UnityEngine;

public class InicioDoLevel : MonoBehaviour
{
    private GameObject player;
    public GameObject posicaoInicialPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Pegar a referencia do gameObject do player
        player = FindFirstObjectByType<PlayerControlador>().gameObject;

        //Posicionar o player na posição inicial
        player.transform.position = posicaoInicialPlayer.transform.position;
    }
}
