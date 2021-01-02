using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsColorCtrl : MonoBehaviour
{
    bool fadeOut = false;
    
    [SerializeField]
    float fadeOutSpeed;
    [SerializeField]
    float colorChangeSpeed;
    public Renderer[] ren;
    void Update()
    {
        if (fadeOut)
        {
            foreach (Renderer r in ren)
            {
                Color objColor = r.material.color;
                float fadeAmount = objColor.a - (fadeOutSpeed * Time.deltaTime);
                r.material.color = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
            }
            if (ren[0].material.color.a <= 0 && ren[1].material.color.a <= 0)
            {
                fadeOut = false;
                ren[0].gameObject.SetActive(false);
                ren[1].gameObject.SetActive(false);

                this.enabled = false;
            }
        }
    }

    public void FadeOut()
    {
        fadeOut = true;
        foreach (Renderer r in ren)
        {
            r.material.SetFloat("_Mode", 2);
            r.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            r.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            r.material.SetInt("_ZWrite", 0);
            r.material.DisableKeyword("_ALPHATEST_ON");
            r.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            r.material.EnableKeyword("_ALPHABLEND_ON");
            r.material.renderQueue = 3000;
        }
    }

    public void TurnRed()
    {
        StartCoroutine(StartTurnRed());
    }

    IEnumerator StartTurnRed()
    {
        while (ren[0].material.color.g > 0)
        {
            foreach (Renderer r in ren)
            {
                Color objColor = r.material.color;
                float fadeAmount = objColor.g - (colorChangeSpeed * Time.deltaTime);
                r.material.color = new Color(objColor.r, fadeAmount, fadeAmount, objColor.a);
            }
            yield return new WaitForSeconds(0.1f);
        }

        //StartCoroutine(StartTurnWhite());

    }


    IEnumerator StartTurnWhite()
    {
        while (ren[0].material.color.g < 1)
        {
            foreach (Renderer r in ren)
            {
                Color objColor = r.material.color;
                float fadeAmount = objColor.g + (colorChangeSpeed * Time.deltaTime);
                r.material.color = new Color(objColor.r, fadeAmount, fadeAmount, objColor.a);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
