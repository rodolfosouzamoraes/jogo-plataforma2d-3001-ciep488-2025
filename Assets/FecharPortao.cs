using UnityEngine;

public class FecharPortao : MonoBehaviour
{
    public float velocidade;
    public GameObject cadeado;
    public GameObject grade;
    private Quaternion rotacaoAlvo;
    private bool fechouPortao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir a rota��o alvo
        rotacaoAlvo = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se pode abrir o portao
        if (fechouPortao == true) {
            grade.transform.rotation = Quaternion.RotateTowards(
                grade.transform.rotation,
                rotacaoAlvo,
                velocidade * Time.deltaTime
            );
        }
    }

    private void AtivarCadeado()
    {
        cadeado.SetActive(true);
    }

    private void MudarLayer()
    {
        transform.gameObject.layer = 6;
    }

    private void OnTriggerExit2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Player" && fechouPortao == false) 
        {
            //Tocar audio do portao
            AudioMng.Instance.PlayAudioPortao();

            //Definir para fechar o portao
            fechouPortao = true;

            //Mudar o boxcollider para um corpo rigido
            GetComponent<BoxCollider2D>().isTrigger = false;

            //Ativar cadeado depois de um tempo
            Invoke("AtivarCadeado", 1f);

            //Mudar layer depois que sair da area
            Invoke("MudarLayer", 1f);
        }
    }
}
