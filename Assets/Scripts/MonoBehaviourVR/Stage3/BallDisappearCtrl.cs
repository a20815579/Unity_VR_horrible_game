using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDisappearCtrl : MonoBehaviour
{
    private InputActions inputActions;
    [SerializeField]
    int _id;
    public ItemGazeDetect gazeDetect;
    bool fadeOut;
    [SerializeField]
    float fadeOutSpeed;
    public Renderer ren;
    void Awake()
    {
        // create instance of ScriptableObject
        inputActions = ScriptableObject.CreateInstance<InputActions>();
        inputActions.id = _id;
    }
    private void Update()
    {
        if (gazeDetect && gazeDetect.IsGazingUpon && !fadeOut)
        {
            FadeOut();
        }
        else if (fadeOut)
        {
            Color objColor = ren.material.color;
            float fadeAmount = objColor.a - (fadeOutSpeed * Time.deltaTime);
            ren.material.color = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
            Debug.Log(ren.material.color);
            if(ren.material.color.a <= 0)
            {
                fadeOut = false;
                ren.gameObject.SetActive(false);
                inputActions.ResponseOnInput();

                this.enabled = false;
            }
        }
    }

    void FadeOut()
    {
        fadeOut = true;
        ren.material.SetFloat("_Mode", 2);
        ren.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        ren.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        ren.material.SetInt("_ZWrite", 0);
        ren.material.DisableKeyword("_ALPHATEST_ON");
        ren.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        ren.material.EnableKeyword("_ALPHABLEND_ON");
        ren.material.renderQueue = 3000;
        

    }
}
