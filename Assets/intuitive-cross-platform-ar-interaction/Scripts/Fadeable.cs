using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeable : MonoBehaviour
{
    [Tooltip("How long to take when fading in and out")]
    public float fadeTime;

    [Tooltip("Start faded out")]
    public bool startFadedOut;


    public enum FadeableType { CanvasGroup, Renderer }
    [Tooltip("Type of fadeable to use.")]
    public FadeableType fadeableType;

    [Tooltip("This object if not set. Or you can use the Canvas Group")]
    public Renderer mRenderer;

    [Tooltip("CG on this object if not set. Or you can use a renderer")]
    public CanvasGroup canvasGroup;

    private bool visible;
    public bool Visible
    {
        get
        {
            return visible;
        }
        set
        {
            if (visible != value)
            {
                StopAllCoroutines();
                if (visible)
                {
                    if (fadeableType == FadeableType.CanvasGroup)
                    {
                        StartCoroutine(FadeOutCanvasGroup(canvasGroup, fadeTime));
                    }
                    else
                    {
                        StartCoroutine(FadeOutMaterial(mRenderer.material, fadeTime));
                    }
                }
                else
                {
                    if (fadeableType == FadeableType.CanvasGroup)
                    {
                        StartCoroutine(FadeInCanvasGroup(canvasGroup, fadeTime));
                    }
                    else
                    {
                        StartCoroutine(FadeInMaterial(mRenderer.material, fadeTime));
                    }
                }
            }
            visible = value;
        }
    }

    private void Start()
    {
        if (fadeableType == FadeableType.CanvasGroup)
        {
            if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = startFadedOut ? 0 : 1;
            visible = !startFadedOut;
        }
        else
        {
            if (mRenderer == null) mRenderer = GetComponent<Renderer>();
            mRenderer.material.color = new Color(1, 1, 1, startFadedOut ? 0 : 1);
        }
    }
    private IEnumerator FadeInMaterial(Material mat, float time)
    {
        while (mat.color.a < 1)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + .015f);
            yield return new WaitForSeconds(time / 60f); // Todo: Use a different way to do this (this does divide the time to fade by a guessed at frame rate)
        }
    }

    private IEnumerator FadeOutMaterial(Material mat, float time)
    {
        while (mat.color.a > 0)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - .015f);
            yield return new WaitForSeconds(time / 60);
        }
    }

    private IEnumerator FadeInCanvasGroup(CanvasGroup cg, float time)
    {
        while (cg.alpha < 1)
        {
            cg.alpha += 0.015f;
            yield return new WaitForSeconds(time / 60f); 
        }
    }

    private IEnumerator FadeOutCanvasGroup(CanvasGroup cg, float time)
    {
        while (cg.alpha > 0)
        {
            cg.alpha -= 0.015f;
            yield return new WaitForSeconds(time / 60);
        }
    }

    // Use these in the inspector to test
    // -------------------------------------
    [ContextMenu("Visible True")]
    public void testVisibleTrue()
    {
        Visible = true;
    }

    [ContextMenu("Visible False")]

    public void testVisibleFalse()
    {
        Visible = false;
    }
}
