using UnityEngine;

public class AbrirPortao : MonoBehaviour
{
    public ColetarChave chave; //Script da chave que vai abrir o portao
    public float velocidade; //Velocidade da rotacao do portao
    public GameObject cadeado; //Cadeado que está no portão
    private Quaternion rotacaoAlvo; //Angulo alvo para qual o portão irá rotacionar
    private bool abriuPortao; //Diz se o portao está ou não aberto
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir o angulo da rotacao alvo
        rotacaoAlvo = Quaternion.Euler(new Vector3(0,90,0));
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o portão pode abrir
        if(abriuPortao == true)
        {
            //Abrir o portão
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotacaoAlvo,
                velocidade * Time.deltaTime
                );
        }
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        //Verificar se o player colidiu e se a chave foi coletada
        if (colisao.gameObject.tag == "Player" && chave.ColetouChave == true)
        {
            //Definir para abrir o portão
            abriuPortao = true;

            //Desativar o cadeado
            cadeado.SetActive(false);

            //Desativar a colisao com o objeto 
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
