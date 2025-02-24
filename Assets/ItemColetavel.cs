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

            //Ativar anima��o de coleta
            animator.SetTrigger("Coletar");

            //Incrementar o item no jogo
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    /// <summary>
    /// M�todo para destruir o objeto ap�s o fim da anima��o de coleta
    /// </summary>
    public void DestruirColetavel()
    {
        Destroy(gameObject);
    }
}
