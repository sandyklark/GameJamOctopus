using UnityEngine;
using UnityEngine.InputSystem;

public class GooseHead : MonoBehaviour
{
    public Transform head;
    public Transform body;
    public LineRenderer neck;

    public GameObject normalFace;
    public GameObject biteFace;
    
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
        SetDirection(_moveDirection);

        _targetPos = ((Vector2)body.position + _targetDirection.normalized * headDist) + offset;
        head.position = Vector3.Lerp(head.position, (Vector3)_targetPos, Time.deltaTime * 8f);

        neck.SetPositions(new []{body.transform.position, head.transform.position});
    }
}
