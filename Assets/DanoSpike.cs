using System.Collections;
using UnityEngine;

public class DanoSpike : MonoBehaviour
{
    private bool houveColisao;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Verificar se é o player que colidiu com o spike
        if(collision.gameObject.tag == "Player" && houveColisao == false)
        {
            //Diz que houve a colisão com o player
            houveColisao = true;

            //Efetua dano ao jogador
            collision.gameObject.GetComponent<DanoPlayer>().EfetuarDano();

            //Reabilitar o dano ao jogador
            StartCoroutine(ResetarColisao());
        }
    }

    private IEnumerator ResetarColisao()
    {
        //Esperar 0.3 segundos para voltar a permitir a colisao
        yield return new WaitForSeconds(0.3f);
        houveColisao = false;
    }
}
