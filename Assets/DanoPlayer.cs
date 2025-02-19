using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public AnimacaoPlayer animacaoPlayer;

    public void EfetuarDano()
    {
        //Ativar a animação do dano
        animacaoPlayer.PlayDano();

        movimentarPlayer.ResetarFisicaDeMovimento();

        movimentarPlayer.ArremessarPlayer();
    }
}
