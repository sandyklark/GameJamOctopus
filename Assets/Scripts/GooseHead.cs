using UnityEngine;

public class GooseHead : MonoBehaviour
{
    public Transform head;
    public Transform body;
    public LineRenderer neck;

    public Vector2 offset;
    public float headDist = 4f;
    
    private Vector2 _targetPos;
    private Vector2 _targetDirection;

    private void SetDirection(Vector2 direction)
    {
        _targetDirection = direction;
    }

    private void Update()
    {
        var dir = new Vector2();
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1f;
        }
        
        SetDirection(dir);

        _targetPos = ((Vector2)body.position + _targetDirection.normalized * headDist) + offset;
        head.position = Vector3.Lerp(head.position, (Vector3)_targetPos, Time.deltaTime * 8f);

        neck.SetPositions(new []{body.transform.position, head.transform.position});
    }
}
