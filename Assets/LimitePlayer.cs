using UnityEngine;

public class LimitePlayer : MonoBehaviour
{
    public bool estaNoLimite;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            estaNoLimite = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            estaNoLimite = false;
        }
    }
}
