using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAppearCtrl : MonoBehaviour
{
    bool fadeIn = false;

    [SerializeField]
    float fadeInSpeed;
    public Renderer ren;
    [SerializeField]
    Material originalMat;
    private void Awake()
    {
        Color objColor = ren.material.color;
        ren.material.color = new Color(objColor.r, objColor.g, objColor.b, 0);
        ren.material.SetFloat("_Mode", 2);
        ren.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        ren.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        ren.material.SetInt("_ZWrite", 0);
        ren.material.DisableKeyword("_ALPHATEST_ON");
        ren.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        ren.material.EnableKeyword("_ALPHABLEND_ON");
        ren.material.renderQueue = 3000;
    }

    private void Start()
    {
        //FadeIn();
    }
    void Update()
    {
        if (fadeIn)
        {
            Color objColor = ren.material.color;
            float fadeAmount = objColor.a + (fadeInSpeed * Time.deltaTime);
            ren.material.color = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
            Debug.Log(ren.material.color);

            if (ren.material.color.a >= 1)
            {
                fadeIn = false;
                ren.material = originalMat;
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
    }
}
