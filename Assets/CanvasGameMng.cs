using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;

    private void Awake()
    {
        //Criar a instancia estática
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        //Destroi o gameobject caso já exista uma instancia da classe
        Destroy(gameObject);
    }

    public Image imgVida; //Imagem da vida
    public Sprite[] sptsVida; //Os sprites que vão aparecer na img da vida
    private int totalVidas; //Quantidade de vidas do player

    public bool fimDeJogo; //Diz se acabou o jogo

    private DanoPlayer danoPlayer; //Códigos para manipular a morte do player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Adicionar o total de vidas que o jogador vai começar
        totalVidas = sptsVida.Length -1;

        //Pegar a referencia do dano player na cena
        danoPlayer = FindFirstObjectByType<DanoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Método para consumir uma vida do jogador
    /// </summary>
    public void DecrementarVidaJogador()
    {
        //Decrementar a vida do jogador
        totalVidas--;

        //Verificar se o jogador tem vidas para continuar no jogo
        if (totalVidas < 1) {
            //Finalizar o jogo
            FimDeJogo();
        }
        else
        {
            //Atualiza a imagem de vida para o sprite correspondente
            imgVida.sprite = sptsVida[totalVidas];
        }
    }

    /// <summary>
    /// Método para finalizar o jogo
    /// </summary>
    public void FimDeJogo()
    {
        //Dizer que o jogo acabou
        fimDeJogo = true;

        //Zerar as vidas do jogador
        totalVidas = 0;

        //Colocar o sprite de vida zerada na imagem
        imgVida.sprite = sptsVida[totalVidas];

        //Desabilitar as funções do jogador
        danoPlayer.MatarJogador();

        //Contar um tempo para poder reiniciar o level
        StartCoroutine(ReiniciarLevel());
    }

    /// <summary>
    /// Reiniciar o level da cena atual
    /// </summary>
    public void ResetarLevelAtual()
    {
        //Reiniciar a cena do jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Contar um tempo para poder reiniciar o level
    /// </summary>
    /// <returns></returns>
    IEnumerator ReiniciarLevel()
    {
        //Aguardar 3 segundos para resetar o level
        yield return new WaitForSeconds(3f);

        //Reiniciar o level
        ResetarLevelAtual();
    }
}
