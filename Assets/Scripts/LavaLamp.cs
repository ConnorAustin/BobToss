using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaLamp : MonoBehaviour {
    public Material lavaLamp;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, lavaLamp);
    }
}
