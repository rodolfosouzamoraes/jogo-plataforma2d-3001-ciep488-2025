using UnityEngine;

public class DanoChefe : MonoBehaviour
{
    private ChefeControlador chefeControlador;
    private bool houveColisao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chefeControlador = GetComponentInParent<ChefeControlador>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player" && houveColisao == false)
        {
            //Dizer que houve a colisao
            houveColisao = true;

            //Arremessar o player
            colisao.GetComponent<PlayerControlador>().MovimentarPlayer.ArremessarPlayer();

            //Decrementar a vida do chefe
            chefeControlador.DecrementarVidaChefe();

            //Reabilitar a colisão com o chefe depois de 0.3 segundos
            Invoke("PermitirColisao", 0.3f);
        }
    }

    private void PermitirColisao()
    {
        houveColisao = false;
    }
}
