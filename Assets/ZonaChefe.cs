using UnityEngine;

public class ZonaChefe : MonoBehaviour
{
    private ChefeControlador chefeControlador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chefeControlador = FindFirstObjectByType<ChefeControlador>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            //tocar audio do chefe
            AudioMng.Instance.PlayAudioChefe();

            //Habilita movimentação do chefe
            chefeControlador.HabilitaMovimentacao();
            //Destruir o objeto
            Destroy(gameObject);
        }
    }
}
