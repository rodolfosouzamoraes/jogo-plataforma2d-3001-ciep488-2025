using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    public MovimentarPlayer movimentarPlayer;
    public AnimacaoPlayer animacaoPlayer;
    public void EfetuarDano()
    {
        //Verificar se o jogo acabou para deixar de tomar dano
        if (CanvasGameMng.Instance.fimDeJogo == true) return;

        //Tocar audio dano
        AudioMng.Instance.PlayAudioDanos();

        //Ativa anima��o de dano
        animacaoPlayer.PlayDano();

        //Resetar a fisica do jogador
        movimentarPlayer.ResetarFisicaDeMovimentacao();

        //Arremessar o jogador
        movimentarPlayer.ArremessarPlayer();

        //Decrementar a vida do jogador
        CanvasGameMng.Instance.DecrementarVidaJogador();
    }

    /// <summary>
    /// Desalibita as moviventa��es e as fisicas do player ao morrer
    /// </summary>
    public void MatarJogador()
    {
        //tocar audio morte player
        AudioMng.Instance.PlayAudioMortePlayer();

        //Remover a gravidade do player
        movimentarPlayer.RemoverGravidade();

        //Remover a as for�as direcionais do player
        movimentarPlayer.ResetarFisicaDeMovimentacao();

        //Ativar anima��o de morte
        animacaoPlayer.PlayMorte();
    }
}
