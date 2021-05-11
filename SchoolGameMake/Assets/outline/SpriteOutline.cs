using UnityEngine;


[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour
{
    public Color color_ = Color.white;

    [Range(0, 16)]
    public int outlineSize = 1;

    private SpriteRenderer spriteRenderer;

    float c_r = 0; 
    float c_g = 255;
    float ca_deadtime = 13f;
    float time= 0;


    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateOutline(true);
    }

    void OnDisable()
    {
        UpdateOutline(false);
    }

    void Update()
    {
        UpdateOutline(true);

        time += Time.deltaTime / ca_deadtime;
        c_r = Mathf.Lerp(0f, 255f, time);
        if (c_r >= 255f) c_g = Mathf.Lerp(255f, 0f, time);
        color_ = new Color(c_r / 255f, c_g / 255f, 0);
    }

    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color_);
        mpb.SetFloat("_OutlineSize", outlineSize);
        spriteRenderer.SetPropertyBlock(mpb);
    }

    public void reeeset()
    {
        time = 0;
        c_r = 0;
        c_g = 255;
    }
}
