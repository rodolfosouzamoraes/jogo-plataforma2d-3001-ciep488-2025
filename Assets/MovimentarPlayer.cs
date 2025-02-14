using System.Collections;
using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    public FlipCorpoPlayer flipCorpo; //C�digo para efetuar o flip do personagem
    public LimitePlayer limiteDireita;
    public LimitePlayer limiteEsquerda;
    public LimitePlayer limitePe;
    public LimitePlayer limiteCabeca;
    public Rigidbody2D rigidbody2d;

    public float velocidade; //Velocidade de movimenta��o do jogador

    public float forcaDoPuloY; //For�a do pulo no eixo Y
    private float forcaDoPuloX; //For�a do pulo no eixo X
    private bool estaPulando; //Diz se o Player est� em modo de pulo
    private bool puloDuplo; //Permite o personagem efetuar um pulo duplo
    private bool pularDaParede = true; //Permite pular da parede
    private Coroutine coroutinePulo; //Contador de tempo para poder limitar o pulo do Player

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Pular();
        PularDaParede();
    }

    /// <summary>
    /// M�todo para movimenta��o do Player
    /// </summary>
    private void Movimentar()
    {
        //Obter a entrada do usu�rio para futuramente mover o personagem
        float eixoX = Input.GetAxis("Horizontal");

        //Verificar se chegou nos limites da esquerda e da direita
        if(eixoX > 0 && limiteDireita.estaNoLimite == true) { eixoX = 0; }
        else if(eixoX < 0 && limiteEsquerda.estaNoLimite == true) { eixoX = 0; } 

        //Verificar para onde o personagem est� indo
        if (eixoX > 0)
        {
            flipCorpo.OlharParaDireita();
        }
        else if (eixoX < 0)
        {
            flipCorpo.OlharParaEsquerda();
        }

        //Definir a dire��o da movimenta��o
        Vector3 direcaoMovimento = new Vector3(eixoX, 0, 0);

        //Mover o personagem
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }

    private void Pular()
    {
        //Obter a entrada do usu�rio para efetuar o pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Verificar se est� apto a pular
            if(limitePe.estaNoLimite == true && estaPulando == false)
            {
                //Habilitar o pulo
                estaPulando = true;

                //Habilitar o pulo duplo
                puloDuplo = true;

                //Ativar o tempo do pulo
                AtivarTempoPulo();
            }
            else
            {
                //Verificar se est� apto a fazer um segundo pulo
                if(puloDuplo == true)
                {
                    //Habilitar novamente o pulo
                    estaPulando = true;

                    //Desabilitar o pulo duplo
                    puloDuplo = false;

                    //Ativar o tempo de pulo novamente
                    AtivarTempoPulo();
                }
            }
        }

        EfetuarPulo();
    }

    /// <summary>
    /// M�todo para fazer o player subir para simbolizar o pulo
    /// </summary>
    private void EfetuarPulo()
    {
        //Verificar se o player pode subir
        if(estaPulando == true)
        {
            //Verificar se a cabe�a esta no limite
            if (limiteCabeca.estaNoLimite == false)
            {
                //Zerar as for�as do rigidbody2D
                rigidbody2d.linearVelocity = Vector3.zero;

                //Alterar as propriedades do ridigbody2D para poder subir
                rigidbody2d.gravityScale = 0;

                //Direcionar o player para subir
                Vector3 direcaoPulo = new Vector3(forcaDoPuloX, forcaDoPuloY, 0);

                //Mover o player para dire��o de subida
                transform.position += direcaoPulo * velocidade * Time.deltaTime;
            }            
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
        yield return new WaitForSeconds(0.3f);//Espere 0.3 segundo para continuar o c�digo

        //Desabilitar a variavel que permite o pulo
        estaPulando = false;

        //Zerar a for�a do eixo X
        forcaDoPuloX = 0;
    }

    /// <summary>
    /// Ativa a coroutine do tempo de pulo
    /// </summary>
    private void AtivarTempoPulo()
    {
        //Verificar se j� existe uma coroutina contando o tempo
        if(coroutinePulo != null)
        {
            StopCoroutine(coroutinePulo);
        }
        coroutinePulo = StartCoroutine(TempoPulo());
    }

    private void PularDaParede()
    {
        //Verificar se est� no ch�o para poder habilitar novamente o pulo da parede
        if(limitePe.estaNoLimite == true)
        {
            pularDaParede = true;
        }

        //Verificar se � permitido pular da parede
        if (pularDaParede == false) return;

        /*
         Verificar se o player n�o esta no ch�o e a cabe�a n�o esta no limite
         e se est� em algumas das extremidades
        */
        if (limitePe.estaNoLimite == false && limiteCabeca.estaNoLimite == false
            && (limiteDireita.estaNoLimite == true || limiteEsquerda.estaNoLimite == true))
        {
            //Obter a entrada do usuario para poder efetuar o pulo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Aplicar a for�a em x na dire��o contraria a parede que ele est� encostado
                if(limiteDireita.estaNoLimite == true)
                {
                    forcaDoPuloX = forcaDoPuloY * -1;
                }
                else if(limiteEsquerda.estaNoLimite == true)
                {
                    forcaDoPuloX = forcaDoPuloY;
                }
                else
                {
                    forcaDoPuloX = 0;
                }

                //Habilitar o pulo duplo
                puloDuplo = true;

                //Habilitar o pulo continuo
                estaPulando = true;

                //Desabilitar o pulo da parede
                pularDaParede = false;

                //Ativar um novo tempo de pulo
                AtivarTempoPulo();
            }
        }
    }
}
