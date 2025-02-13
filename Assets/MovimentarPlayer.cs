using System.Collections;
using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    public FlipCorpoPlayer flipCorpo; //Código para efetuar o flip do personagem
    public LimitePlayer limiteDireita;
    public LimitePlayer limiteEsquerda;
    public LimitePlayer limitePe;
    public Rigidbody2D rigidbody2d;
    public float velocidade; //Velocidade de movimentação do jogador

    public float forcaDoPuloY; //Força do pulo no eixo Y
    private bool estaPulando; //Diz se o Player está em modo de pulo
    private bool puloDuplo; //Permite o personagem efetuar um pulo duplo
    private Coroutine coroutinePulo; //Contador de tempo para poder limitar o pulo do Player

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Pular();
    }

    /// <summary>
    /// Método para movimentação do Player
    /// </summary>
    private void Movimentar()
    {
        //Obter a entrada do usuário para futuramente mover o personagem
        float eixoX = Input.GetAxis("Horizontal");

        //Verificar se chegou nos limites da esquerda e da direita
        if(eixoX > 0 && limiteDireita.estaNoLimite == true) { eixoX = 0; }
        else if(eixoX < 0 && limiteEsquerda.estaNoLimite == true) { eixoX = 0; } 

        //Verificar para onde o personagem está indo
        if (eixoX > 0)
        {
            flipCorpo.OlharParaDireita();
        }
        else if (eixoX < 0)
        {
            flipCorpo.OlharParaEsquerda();
        }

        //Definir a direção da movimentação
        Vector3 direcaoMovimento = new Vector3(eixoX, 0, 0);

        //Mover o personagem
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }

    private void Pular()
    {
        //Obter a entrada do usuário para efetuar o pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Verificar se está apto a pular
            if(limitePe.estaNoLimite == true && estaPulando == false)
            {
                //Habilitar o pulo
                estaPulando = true;

                //Habilitar o pulo duplo
                puloDuplo = true;

                //Ativar o tempo do pulo
                AtivarTempoPulo();
            }
        }

        EfetuarPulo();
    }

    /// <summary>
    /// Método para fazer o player subir para simbolizar o pulo
    /// </summary>
    private void EfetuarPulo()
    {
        //Verificar se o player pode subir
        if(estaPulando == true)
        {
            //Zerar as forças do rigidbody2D
            rigidbody2d.linearVelocity = Vector3.zero;

            //Alterar as propriedades do ridigbody2D para poder subir
            rigidbody2d.gravityScale = 0;

            //Direcionar o player para subir
            Vector3 direcaoPulo = new Vector3(0, forcaDoPuloY, 0);

            //Mover o player para direção de subida
            transform.position += direcaoPulo * velocidade * Time.deltaTime;
        }
        else
        {
            //Reconfigurar as propriedades do rigibody2d para poder fazer o player descer
            rigidbody2d.gravityScale = 4;
        }
    }

    /// <summary>
    /// Contar o tempo do pulo
    /// </summary>
    private IEnumerator TempoPulo()
    {
        //Permitir 0.3 de segundo para o player continuar subindo
        yield return new WaitForSeconds(0.3f);//Espere 0.3 segundo para continuar o código

        //Desabilitar a variavel que permite o pulo
        estaPulando = false;
    }

    /// <summary>
    /// Ativa a coroutine do tempo de pulo
    /// </summary>
    private void AtivarTempoPulo()
    {
        //Verificar se já existe uma coroutina contando o tempo
        if(coroutinePulo != null)
        {
            StopCoroutine(coroutinePulo);
        }
        StartCoroutine(TempoPulo());
    }
}
