using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;

    private void Awake()
    {
        //Criar a instancia est�tica
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        //Destroi o gameobject caso j� exista uma instancia da classe
        Destroy(gameObject);
    }

    public Image imgVida; //Imagem da vida
    public Sprite[] sptsVida; //Os sprites que v�o aparecer na img da vida
    private int totalVidas; //Quantidade de vidas do player

    public bool fimDeJogo; //Diz se acabou o jogo

    private PlayerControlador playerControlador; //C�digos para manipular a morte do player

    public TextMeshProUGUI txtTotalItensColetados;//Texto que exibe o total de itens coletados
    private int totalItensColetados;//Vari�vel que armazena os itens coletados

    public TextMeshProUGUI txtTempoDeJogo; //Texto exibido com o tempo do jogo
    public float tempoJogo; //Diz o tempo que o level ter�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Adicionar o total de vidas que o jogador vai come�ar
        totalVidas = sptsVida.Length -1;

        //Pegar a referencia do dano player na cena
        playerControlador = FindFirstObjectByType<PlayerControlador>();

        //Zerar o total de itens coletados
        totalItensColetados = 0;

        //Exibir o valor atualizado no texto de total itens coletados
        txtTotalItensColetados.text = $"x{totalItensColetados}";

        //Atualizar o texto com o tempo atual do jogo
        txtTempoDeJogo.text = $"{tempoJogo}";
    }

    // Update is called once per frame
    void Update()
    {
        //Contar o tempo do jogo
        ContarTempo();
    }

    /// <summary>
    /// M�todo para consumir uma vida do jogador
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
    /// M�todo para finalizar o jogo
    /// </summary>
    public void FimDeJogo()
    {
        //Dizer que o jogo acabou
        fimDeJogo = true;

        //Zerar as vidas do jogador
        totalVidas = 0;

        //Colocar o sprite de vida zerada na imagem
        imgVida.sprite = sptsVida[totalVidas];

        //Desabilitar as fun��es do jogador
        playerControlador.DanoPlayer.MatarJogador();

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

    /// <summary>
    /// M�todo para poder incrementar no total de itens coletaveis 
    /// </summary>
    public void IncrementarItemColetavel()
    {
        //Incrementar o item na vari�vel
        totalItensColetados++;

        //Atualizar o texto com o total de itens coletados
        txtTotalItensColetados.text = $"x{totalItensColetados}";
    }

    /// <summary>
    /// M�todo para poder contar o tempo do jogo
    /// </summary>
    public void ContarTempo()
    {
        //Verificar se o jogo acabou para parar de contar o tempo
        if (fimDeJogo == true) return;

        //Decrementar o tempo do jogo
        tempoJogo -= Time.deltaTime;

        //Verificar se o tempo acabou
        if(tempoJogo <= 0)
        {
            //Finalizar jogo
            FimDeJogo();
        }
        else
        {
            //Atualiza o tempo do jogo na tela
            txtTempoDeJogo.text = ((int)tempoJogo).ToString();
        }
    }

    /// <summary>
    /// M�todo para finalizar o level
    /// </summary>
    public void CompletouLevel()
    {
        //Dizer que o jogo acabou
        fimDeJogo = true;

        //Congelar o player
        playerControlador.MovimentarPlayer.CongelarPlayer();

        //Exibir a tela final do level
    }
}
