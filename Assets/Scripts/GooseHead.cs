using UnityEngine;
using UnityEngine.InputSystem;

public class GooseHead : MonoBehaviour
{
    public Transform head;
    public Transform body;
    public LineRenderer neck;

    public Vector2 offset;
    public float headDist = 4f;
    
    private Vector2 _targetPos;
    private Vector2 _targetDirection;
    private Vector2 _moveDirection;

    public void Move(InputAction.CallbackContext move)
    {
        _moveDirection = move.ReadValue<Vector2>();
    }
    
    private void SetDirection(Vector2 direction)
    {
        _targetDirection = direction;
    }

    private void Update()
    {
        // var dir = new Vector2();
        // if (Input.GetKey(KeyCode.A))
        // {
        //     dir.x = -1f;
        // }
        // if (Input.GetKey(KeyCode.D))
        // {
        //     dir.x = 1f;
        // }
        // if (Input.GetKey(KeyCode.W))
        // {
        //     dir.y = 1f;
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     dir.y = -1f;
        // }
        
        SetDirection(_moveDirection);

        _targetPos = ((Vector2)body.position + _targetDirection.normalized * headDist) + offset;
        head.position = Vector3.Lerp(head.position, (Vector3)_targetPos, Time.deltaTime * 8f);

        neck.SetPositions(new []{body.transform.position, head.transform.position});
    }
}
