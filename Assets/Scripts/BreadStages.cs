using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BreadStages : MonoBehaviour
{
    public List<GameObject> breadStages;
    public ParticleSystem crumbs;
    
    private List<Transform> _centerPoints;
    private int _index;

    public void Next()
    {
        breadStages[_index].SetActive(false);
        var center = _centerPoints[_index].transform.position;
        
        crumbs.transform.position = center;
        crumbs.Emit(10);
        
        if (_index >= breadStages.Count - 1) return;
        
        _index++;
        breadStages[_index].transform.position = center;
        breadStages[_index].SetActive(true);

        breadStages[_index].GetComponentsInChildren<Rigidbody2D>()
            .ToList()
            .ForEach(rigid =>
            {
                rigid.AddTorque(Random.Range(-8f, 8), ForceMode2D.Impulse);
            });
    }
    
    private void Awake()
    {
        _centerPoints = new List<Transform>();
        
        breadStages.ForEach(stage =>
        {
            stage.SetActive(false);
            var center = stage.GetComponentsInChildren<SpriteRenderer>()[1].transform.parent;
            _centerPoints.Add(center);
            Debug.Log(center.gameObject.name);
        });
    }

    private void Start()
    {
        breadStages[0].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Next();
        }
    }
}
