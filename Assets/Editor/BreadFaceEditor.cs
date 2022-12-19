using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(BreadFace))]
    public class BreadFaceEditor : UnityEditor.Editor
    {
        private GameObject _go;

        private void OnEnable() {
            var script = (BreadFace) target;
            _go = script.gameObject;
        }
        
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Attach constraints"))
            {
                var rigidBodies = _go.GetComponentsInChildren<Rigidbody2D>()
                    .ToList();

                if (rigidBodies.Count == 0) return;
                
                var last = rigidBodies[^1];
                
                for(var i = 0; i < rigidBodies.Count; i++)
                {
                    if(i == rigidBodies.Count -1) continue;

                    var rigid = rigidBodies[i];
                    
                    if (!rigid.TryGetComponent<SpringJoint2D>(out var r))
                    {
                        var spring1 = rigid.gameObject.AddComponent<SpringJoint2D>();
                        var spring2 = rigid.gameObject.AddComponent<SpringJoint2D>();
                        var spring3 = rigid.gameObject.AddComponent<SpringJoint2D>();

                        var prev = i == 0 ? rigidBodies[^2] : rigidBodies[i - 1];
                        var next = i == rigidBodies.Count - 2 ? rigidBodies[0] : rigidBodies[i + 1];

                        spring1.connectedBody = prev;
                        spring2.connectedBody = next;
                        spring3.connectedBody = last;
                        
                        var springs = new []
                        {
                            spring1, 
                            spring2,
                            spring3
                        };
                        
                        foreach (var spring in springs)
                        {
                            spring.autoConfigureConnectedAnchor = true;
                            spring.frequency = 12f;
                            spring.dampingRatio = 0.6f;
                        }
                    }
                }
            }

            DrawDefaultInspector();
        }
    }
}
