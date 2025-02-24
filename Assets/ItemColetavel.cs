using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    public Animator animator;
    private bool coletouItem;

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o player colidiu com o item coletavel
        if(colisao.gameObject.tag == "Player" && coletouItem == false)
        {
            //Informar que o item foi coletado
            coletouItem = true;

            //Ativar animação de coleta
            animator.SetTrigger("Coletar");

            //Incrementar o item no jogo
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    /// <summary>
    /// Método para destruir o objeto após o fim da animação de coleta
    /// </summary>
    public void DestruirColetavel()
    {
        Destroy(gameObject);
    }
}
