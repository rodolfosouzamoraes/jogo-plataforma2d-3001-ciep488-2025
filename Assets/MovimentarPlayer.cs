using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    public FlipCorpoPlayer flipCorpo; //Código para efetuar o flip do personagem
    public float velocidade; //Velocidade de movimentação do jogador

    // Update is called once per frame
    void Update()
    {
        //Obter a entrada do usuário para futuramente mover o personagem
        float eixoX = Input.GetAxis("Horizontal");

        //Verificar para onde o personagem está indo
        if(eixoX > 0)
        {
            flipCorpo.OlharParaDireita();
        }
        else if(eixoX < 0)
        {
            flipCorpo.OlharParaEsquerda();
        }

        //Definir a direção da movimentação
        Vector3 direcaoMovimento = new Vector3(eixoX, 0, 0);

        //Mover o personagem
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }
}
