using UnityEngine;

public class Grounded : MonoBehaviour
{
    #region  Collison
    [Header("Collison")]
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected Transform WallCheck;
    [Range(0f, 1f)]
    [SerializeField] protected float GroundCheckDistance;
    [Range(0f, 1f)]
    [SerializeField] protected float WallCheckDistance;
    public LayerMask groundMask;
    #endregion
    public float facing;
    #region  collison checks
    public virtual bool Ground() => Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, groundMask);
    public virtual bool Walled() => Physics2D.Raycast(WallCheck.position, Vector2.right * facing, WallCheckDistance, groundMask);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position, new Vector3(GroundCheck.position.x, GroundCheck.position.y - GroundCheckDistance));
        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance, WallCheck.position.y));
    }
    #endregion
    public void Facing(float _x)
    {
        facing = _x;
    }
}