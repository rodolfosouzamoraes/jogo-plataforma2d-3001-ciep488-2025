using UnityEngine;

public class FimDoLevel : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o player que colidiu
        if(colisao.gameObject.tag == "Player")
        {
            //Ativo a animação do fim do level
            animator.SetBool("FimDoLevel", true);

            //Finalizar o level
            CanvasGameMng.Instance.CompletouLevel();
        }
    }
}
