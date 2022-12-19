using UnityEngine;

public class GooseControl : MonoBehaviour
{
    public Rigidbody2D footRigid;
    public float jumpForce = 20f;
    
    public float moveSpeed = 20f;
    private bool _shouldJump;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shouldJump = true;
        }
    }
    
    private void FixedUpdate()
    {
        var moveVector = new Vector2();
        
        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x = -1;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x = 1;
        }

        footRigid.AddForce(moveVector * moveSpeed, ForceMode2D.Force);
        
        if (_shouldJump)
        {
            footRigid.velocity = Vector2.up * jumpForce;
            _shouldJump = false;
        }
    }
}
