using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public LayerMask groundLayer;
    public Vector2 groundCheckSize = Vector2.one;
    public bool IsGrounded()
    {
        if (Physics2D.OverlapBox(transform.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, groundCheckSize);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (IsGrounded())
            {
                GetComponentInParent<Animator>().SetBool("Grounded", true);
            }
        }
    }
}
