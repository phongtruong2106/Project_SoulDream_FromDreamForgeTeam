
using UnityEngine;

public class ObjPosition : NewMonoBehaviour
{

    private void Update() 
    {
        Shader.SetGlobalVector("ObjectPosition", new Vector4(this.transform.position.x, this.transform.position.y, this.transform.position.z, this.transform.localScale.x));
    }
}
