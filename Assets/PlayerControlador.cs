using UnityEngine;

public class PlayerControlador : MonoBehaviour
{
    private MovimentarPlayer movimentarPlayer;
    private AnimacaoPlayer animacaoPlayer;
    private DanoPlayer danoPlayer;

    //Criar as propriedades das variáveis do player
    public MovimentarPlayer MovimentarPlayer
    {
        get { return movimentarPlayer; }
    }
    public AnimacaoPlayer AnimacaoPlayer
    {
        get { return animacaoPlayer; }
    }
    public DanoPlayer DanoPlayer
    {
        get { return danoPlayer; }
    }

    private void Awake()
    {
        //Obter a referencia do movimentar do player
        movimentarPlayer = GetComponent<MovimentarPlayer>();

        //Obter a referencia da animação do player
        animacaoPlayer = GetComponentInChildren<AnimacaoPlayer>();

        //Obter a referencia do dano ao player
        danoPlayer = GetComponent<DanoPlayer>();
    }
}
