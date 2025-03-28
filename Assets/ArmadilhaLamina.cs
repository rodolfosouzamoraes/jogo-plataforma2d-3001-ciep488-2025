using UnityEngine;

public class ArmadilhaLamina : MonoBehaviour
{
    public Vector3[] destinos; //Os destinos que a lamina deve fazer
    public float velocidade;
    public float tempoProximoDestino;//Tempo que vai aguardar para ir para o próximo destino
    private int idProximoDestino;//Identificador do proximo destino que a lamina deve ir
    private bool chegouAoDestino; //Verificar se a lamina chegou ao destino definido
    private float tempoEspera;//Tempo de espera para mudar o destino
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Mandar a lamina para a posição inicial
        transform.position = destinos[0];

        //Dizer o proximo destino que lamina deve ir
        idProximoDestino = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLamina();
    }
    
    /// <summary>
    /// Movimentar a lamina entre os destinos
    /// </summary>
    private void MovimentarLamina()
    {
        //Verificar se a lamina chegou ao destino definido
        if (chegouAoDestino == true)
        {
            //Verificar se a lamina deve aguardar para movimentar
            if (Time.time > tempoEspera)
            {
                //Mandar a lamina para o proximo destino
                idProximoDestino++;

                //Verificar se chegou no ultimo destino o id
                if(idProximoDestino == destinos.Length)
                {
                    //Mandar ele para o destino inicial
                    idProximoDestino = 0;
                }

                //Após alterar o destino, definir que a lamina não chegou ao destino atual
                chegouAoDestino = false;
            }
        }
        //Movimentar a lamina para o destino
        else
        {
            //Calcular a movimentacao
            float velocidadeMovimento = velocidade * Time.deltaTime;

            //Mover a lamina até o ponto do destino
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinos[idProximoDestino],
                velocidadeMovimento
            );

            //Verificar se chegou ao destino final para dizer ao programa
            if(Vector3.Distance(transform.position, destinos[idProximoDestino]) < 0.001f){
                //Alterar o tempo de espera
                tempoEspera = Time.time + tempoProximoDestino;

                //Dizer que chegou ao destino
                chegouAoDestino= true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o player colidiu
        if(colisao.gameObject.tag == "Player")
        {
            //Matar o jogador
            CanvasGameMng.Instance.FimDeJogo();
        }
    }
}
