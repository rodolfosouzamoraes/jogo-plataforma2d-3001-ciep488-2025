using UnityEngine;

public class DireitaPlayer : MonoBehaviour
{
    public bool limiteDireita;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            limiteDireita = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            limiteDireita = false;
        }
    }
}
