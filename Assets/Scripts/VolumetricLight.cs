// Example script to enable volumetric lighting
using UnityEngine;

[RequireComponent(typeof(Light))]
public class VolumetricLight : MonoBehaviour
{
    private new Light light;

    void Start()
    {
        light = GetComponent<Light>();
        light.renderMode = LightRenderMode.ForcePixel;
        light.cookie = null;
    }
}
