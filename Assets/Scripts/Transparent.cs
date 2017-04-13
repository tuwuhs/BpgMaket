using UnityEngine;
using System.Collections;

public class Transparent : MonoBehaviour 
{
    public float Transparency = 1.0f;

    private Material _material = null;
    private Material _oldMaterial = null;

    void Start()
    {
    }

	void Update() 
    {
        if (Transparency < 1.0f)
        {
            if (_material == null)
            {
                _material = GetComponent<Renderer>().material;
                _oldMaterial = new Material(_material);

                // Change rendering mode to transparent
                _material.SetFloat("_Mode", 3.0f);
                _material.SetInt("_SrcBlend",
                    (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                _material.SetInt("_DstBlend",
                    (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                _material.SetInt("_ZWrite", 0);
                _material.DisableKeyword("_ALPHATEST_ON");
                _material.EnableKeyword("_ALPHABLEND_ON");
                _material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                _material.renderQueue = 3000;
            }

            Color c = _material.color;
            c.a = Transparency;
            _material.color = c;
        }
        else
        {
            // Reset the material and remove this script
            _material.CopyPropertiesFromMaterial(_oldMaterial);            
            Destroy(this);
        }
	}
}
