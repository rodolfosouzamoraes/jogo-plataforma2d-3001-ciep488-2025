using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;

    public void EfetuarDano()
    {
        movimentarPlayer.ResetarFisicaDeMovimento();

        movimentarPlayer.ArremessarPlayer();
    }
}
