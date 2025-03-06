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

    private PlayerControlador playerControlador; //Códigos para manipular a morte do player

    public TextMeshProUGUI txtTotalItensColetados;//Texto que exibe o total de itens coletados
    private int totalItensColetados;//Variável que armazena os itens coletados

    public TextMeshProUGUI txtTempoDeJogo; //Texto exibido com o tempo do jogo
    public float tempoJogo; //Diz o tempo que o level terá

    public GameObject pnlTopo; //Variável com o painel do topo do canvas
    public GameObject pnlLevelCompletado; //Variável com o painel do level completado
    public TextMeshProUGUI txtTotalItensColetadosFinal; //Variável para exibir no final do jogo o total de itens coletados

    public Image imgIconeMedalha; //Imagem que vai receber o sprite da medalha
    public Sprite[] sptsMedalhas; //Vetor com os sprites das medalhas. 1 - Bronze, 2 - Prata, 3 - Ouro
    private float qtdDeItensColetaveisNoLevel; //Armazena a quantidade de itens existente no inicio do jogo
    private int idMedalha; //Identificador da medalha que o jogador conseguiu no level

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Adicionar o total de vidas que o jogador vai começar
        totalVidas = sptsVida.Length -1;

        //Pegar a referencia do dano player na cena
        playerControlador = FindFirstObjectByType<PlayerControlador>();

        //Zerar o total de itens coletados
        totalItensColetados = 0;

        //Exibir o valor atualizado no texto de total itens coletados
        txtTotalItensColetados.text = $"x{totalItensColetados}";

        //Atualizar o texto com o tempo atual do jogo
        txtTempoDeJogo.text = $"{tempoJogo}";

        //Atualizar o texto do total itens coletados no final do jogo
        txtTotalItensColetadosFinal.text = $"x{totalItensColetados}";

        //Ocultar a tela do level completado e exibir a tela do topo
        pnlTopo.SetActive(true);
        pnlLevelCompletado.SetActive(false);

        //Obter a quantidade de itens coletáveis no inicio do jogo 
        qtdDeItensColetaveisNoLevel = FindObjectsByType<ItemColetavel>(FindObjectsSortMode.None).Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Contar o tempo do jogo
        ContarTempo();
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
    /// Método para poder incrementar no total de itens coletaveis 
    /// </summary>
    public void IncrementarItemColetavel()
    {
        //Incrementar o item na variável
        totalItensColetados++;

        //Atualizar o texto com o total de itens coletados
        txtTotalItensColetados.text = $"x{totalItensColetados}";
    }

    /// <summary>
    /// Método para poder contar o tempo do jogo
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
    /// Método para finalizar o level
    /// </summary>
    public void CompletouLevel()
    {
        //Dizer que o jogo acabou
        fimDeJogo = true;

        //Congelar o player
        playerControlador.MovimentarPlayer.CongelarPlayer();

        //Exibir a tela final do level
        StartCoroutine(ExibirTelaDoLevelCompletado());
    }

    /// <summary>
    /// Método para exibir a tela final do jogo depois de um tempo
    /// </summary>
    /// <returns></returns>
    IEnumerator ExibirTelaDoLevelCompletado()
    {
        //Aguardar 3 segundos para continuar o código
        yield return new WaitForSeconds(3f);

        //Calcular a medalha obtida no level
        CalcularMedalhaLevel();

        //Exibir a tela do level completado e ocultar a tela do topo
        pnlTopo.SetActive(false);
        pnlLevelCompletado.SetActive(true);

        //Fazer uma contagem dos itens coletados
        int contagem = 0;
        while(contagem < totalItensColetados)
        {
            //Incrementar a contagem
            contagem++;

            //Exibir a contagem atualizada na tela
            txtTotalItensColetadosFinal.text = $"x{contagem}";

            //Aguardar 0.1 segundo para poder reiniciar o loop do while e fazer a contagem novamente
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// Método para descobrir qual medalha que o jogador conseguiu no level
    /// </summary>
    private void CalcularMedalhaLevel()
    {
        //Definir a porcentagem dos itens coletaveis obtidos no jogo
        float porcentagem = (totalItensColetados / qtdDeItensColetaveisNoLevel) * 100;

        //Definir qual medalha foi conquista com base na porcentagem
        idMedalha = porcentagem < 50 ? 1 : porcentagem < 100 ? 2 : 3;

        //Atualizar a imagem com a medalha correta
        imgIconeMedalha.sprite = sptsMedalhas[idMedalha];
    }
}
