using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearRT : MonoBehaviour
{
    public RenderTexture renderTexture;

    private void LateUpdate()
    {
        renderTexture.Release();        
    }
}
