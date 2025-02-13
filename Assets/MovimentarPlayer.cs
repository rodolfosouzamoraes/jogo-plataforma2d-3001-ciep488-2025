using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    public FlipCorpoPlayer flipCorpo; //C�digo para efetuar o flip do personagem
    public LimitePlayer limiteDireita;
    public LimitePlayer limiteEsquerda;
    public LimitePlayer limitePe;
    public float velocidade; //Velocidade de movimenta��o do jogador

    public float forcaDoPuloY; //For�a do pulo no eixo Y
    private bool estaPulando; //Diz se o Player est� em modo de pulo
    private bool puloDuplo; //Permite o personagem efetuar um pulo duplo
    private Coroutine coroutinePulo; //Contador de tempo para poder limitar o pulo do Player

    // Update is called once per frame
    void Update()
    {
        Movimentar();
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
        if (Input.GetKeyDown("Jump"))
        {
            //Verificar se est� apto a pular
            if(limitePe.estaNoLimite == true && estaPulando == false)
            {
                //Habilitar o pulo
                estaPulando = true;

                //Habilitar o pulo duplo
                puloDuplo = true;

                //Ativar o tempo do pulo
            }
        }
    }
}
