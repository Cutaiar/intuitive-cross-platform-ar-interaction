using UnityEngine;
using UnityEngine.UI;

// https://stackoverflow.com/questions/44820839/two-color-background
public class GradientTexture : MonoBehaviour {
    private RawImage img;
    private Texture2D backgroundTexture ;

    public Color bottomColor = Color.black;
    public Color topColor = Color.white;
    
    void Awake()
    {
        img = gameObject.GetComponent<RawImage>();
        backgroundTexture  = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
        SetColor(bottomColor, topColor) ;
    }

    public void SetColor( Color color1, Color color2 )
    {
        backgroundTexture.SetPixels( new Color[] { color1, color2 } );
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }
}