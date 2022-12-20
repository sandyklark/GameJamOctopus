using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class GooseLeg : MonoBehaviour
{
    public Rigidbody2D body;
    public Transform footL;
    public Transform footR;
    public Transform legStemL;
    public Transform legStemR;
    public LineRenderer lineL;
    public LineRenderer lineR;
    public float legLength = 2f;
    public float updateDistanceL = 2f;
    public float updateDistanceR = 2.5f;
    public Vector2 offset;
    
    private Vector2 _currentPosL;
    private Vector2 _nextPosL;
    private Vector2 _currentPosR;
    private Vector2 _nextPosR;

    private void Start()
    {
        UpdateLeg(legStemL, lineL, ref _currentPosL, ref _nextPosL, true);
        UpdateLeg(legStemR, lineR, ref _currentPosR, ref _nextPosR, false);
    }

    private void Update()
    {
        
        UpdateLeg(legStemL, lineL, ref _currentPosL, ref _nextPosL, true);
        UpdateLeg(legStemR, lineR, ref _currentPosR, ref _nextPosR, false);

        var lOffset = Mathf.Abs(_currentPosL.x - _nextPosL.x) > 0.5f ? 1.5f : 0f;
        var rOffset = Mathf.Abs(_currentPosR.x - _nextPosR.x) > 0.5f ? 1.5f : 0f;
        
        _currentPosL = Vector2.Lerp(_currentPosL, _nextPosL + new Vector2(0f, lOffset), Time.deltaTime * 29f);
        _currentPosR = Vector2.Lerp(_currentPosR, _nextPosR + new Vector2(0f, rOffset), Time.deltaTime * 33f);

        lineL.SetPositions(new []{legStemL.position, (Vector3)_currentPosL});
        lineR.SetPositions(new []{legStemR.position, (Vector3)_currentPosR});
        footL.position = _currentPosL;
        footR.position = _currentPosR;
    }

    private void UpdateLeg(Transform legStem, LineRenderer line, ref Vector2 current, ref Vector2 next, bool isLeft)
    {
        var hit = Physics2D.Raycast(legStem.position, Vector2.down + offset, legLength);

        if (hit.collider != null)
        {
            if (Vector2.Distance(hit.point, current) > (isLeft ? updateDistanceL : updateDistanceR))
            {
                next = hit.point;
            }
        }
        else
        {
            next = legStem.position + (Vector3)offset;
        }

    }
}
