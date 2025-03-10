using UnityEngine;

public class InimigoPassaroAzul : MonoBehaviour
{
    public GameObject passaroAzul; //Gameobject do pai
    public float velocidade;
    public Vector3 posicaoFinal; //Posi��o para onde o passaro deve ir
    private Vector3 posicaoInicial; //Posi��o onde o objeto come�a
    private Vector3 posicaoAlvo; //Dire��o para onde o passaro deve ir
    private SpriteRenderer corpoPassaroAzul;
    private Animator animator;
    private bool estaMorto; //Diz se o passaro morreu ou n�o
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Configurar a posi��o inicial do p�ssaro
        posicaoInicial = passaroAzul.transform.position;

        //Dizer para onde o passaro deve ir de inicio
        posicaoAlvo = posicaoFinal;

        //Configurar o animator
        animator = GetComponent<Animator>();

        //Configurar o SpriteRenderer
        corpoPassaroAzul = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentar o passaro
        MovimentarPassaro();

        //Calcular distancia entre os pontos
        CalcularDistanciaAlvo();
    }


    private void MovimentarPassaro()
    {
        //Movimentar o p�ssaro de um ponto ao outro
        passaroAzul.transform.position = Vector3.MoveTowards(
            passaroAzul.transform.position,
            posicaoAlvo,
            velocidade * Time.deltaTime
            );
    }

    /// <summary>
    /// M�todo para poder calcular a distancia entre o passaro e o alvo
    /// e mudar sua dire��o
    /// </summary>
    private void CalcularDistanciaAlvo()
    {
        //Verificar a distancia do passaro em rela��o ao alvo
        if (Vector3.Distance(passaroAzul.transform.position, posicaoAlvo) < 0.001f)
        {
            //Verificar o flip do sprite para saber a nova dire��o do passaro
            if(corpoPassaroAzul.flipX == false)
            {
                //Altera a posi��o alvo para o ponto inicial
                posicaoAlvo = posicaoInicial;
            }
            else
            {
                //Altera a posi��o alvo para o ponto final
                posicaoAlvo = posicaoFinal;
            }
            //Inverto o flip do passaro para ele olhar para onde deve ir
            corpoPassaroAzul.flipX = !corpoPassaroAzul.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Player" && estaMorto == false) { 
            //Dizer que o passaro morreu
            estaMorto = true;

            //Arremessar o player
            colisao.GetComponent<PlayerControlador>().MovimentarPlayer.ArremessarPlayer();

            //Ativar anima��o de morte
            animator.SetTrigger("Morte");
        }
    }
    /// <summary>
    /// M�todo acionado no fim da anima��o de morte do passaro
    /// </summary>
    public void DestruirPassaro()
    {
        Destroy(passaroAzul);
    }
}
