using UnityEngine;

public class CanvasMenuMng : MonoBehaviour
{
    public GameObject[] paineis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Exibir o painel menu ao iniciar o jogo
        ExibirPainel(0);
    }

    public void ExibirPainel(int id)
    {
        //Ocultar todos os outros paineis
        foreach (var painel in paineis)
        {
            //Desativar o painel
            painel.SetActive(false);
        }

        //Exibir o painel desejado
        paineis[id].SetActive(true);
    }
}
