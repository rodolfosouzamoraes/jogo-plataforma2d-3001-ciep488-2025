using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public AnimacaoPlayer animacaoPlayer;

    public void EfetuarDano()
    {
        //Ativar a anima��o do dano
        animacaoPlayer.PlayDano();

        //Resetar a fisica do jogador
        movimentarPlayer.ResetarFisicaDeMovimento();

        //Arremessar o jogador
        movimentarPlayer.ArremessarPlayer();

        //Decrementar a vida do jogador
        CanvasGameMng.Instance.DecrementarVidaJogador();
    }

    /// <summary>
    /// Remove as movimenta��es e fisicas do player ao morrer
    /// </summary>
    public void MatarJogador()
    {
        //Remover a f�sica do player
        movimentarPlayer.RemoverGravidade();

        //Remover as dire��es da f�sica
        movimentarPlayer.ResetarFisicaDeMovimento();

        //Ativar anima��o de morte
        animacaoPlayer.PlayMorte();
    }
}
