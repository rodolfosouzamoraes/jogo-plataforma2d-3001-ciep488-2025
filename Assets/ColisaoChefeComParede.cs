using UnityEngine;

public class ColisaoChefeComParede : MonoBehaviour
{
    private MovimentarChefe movimentarChefe;
    private bool houveColisao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obter a referencia do movimentar chefe
        movimentarChefe = GetComponentInParent<MovimentarChefe>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        //Verificar se o chefe colidiu com a parede para inverter a direção
        if(colisao.gameObject.layer == 6 && houveColisao == false)
        {
            //Informo que houve a colisao
            houveColisao = true;

            //Mudo o flip do chefe
            movimentarChefe.FlipCorpo();
        }
    }

    private void OnTriggerExit2D(Collider2D colisao)
    {
        //Verificar se o chefe deixou de colidir com a parede
        if(colisao.gameObject.layer == 6)
        {
            //Permitir colidir com a parede novamente
            houveColisao = false;
        }
    }
}
