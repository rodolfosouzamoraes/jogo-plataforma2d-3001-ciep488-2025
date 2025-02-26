using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public AnimacaoPlayer animacaoPlayer;

    public void EfetuarDano()
    {
        //Ativar a animação do dano
        animacaoPlayer.PlayDano();

        //Resetar a fisica do jogador
        movimentarPlayer.ResetarFisicaDeMovimento();

        //Arremessar o jogador
        movimentarPlayer.ArremessarPlayer();

        //Decrementar a vida do jogador
        CanvasGameMng.Instance.DecrementarVidaJogador();
    }

    /// <summary>
    /// Remove as movimentações e fisicas do player ao morrer
    /// </summary>
    public void MatarJogador()
    {
        //Remover a física do player
        movimentarPlayer.RemoverGravidade();

        //Remover as direções da física
        movimentarPlayer.ResetarFisicaDeMovimento();

        //Ativar animação de morte
        animacaoPlayer.PlayMorte();
    }
}
