using UnityEngine;

public class FlipCorpoPlayer : MonoBehaviour
{
    public SpriteRenderer spriteCorpo;

    //Olhar para direita
    public void OlharParaDireita()
    {
        spriteCorpo.flipX = false;
    }

    //Olhar para esquerda
    public void OlharParaEsquerda()
    {
        spriteCorpo.flipX = true;
    }
}
