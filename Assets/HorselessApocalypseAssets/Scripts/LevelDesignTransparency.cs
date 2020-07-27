using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignTransparency : MonoBehaviour
{
    [Range(0.25f, 1)] public float minAlpha = 0.25f;
    public List<Material> roomMaterials;

    private List<CharacterStats> playerList;
    public bool PlayerInArea { get; private set; } = false;
    public float currentAlpha { get; private set; } = 1.0f;

    void Start()
    {
        ResetMaterialAlpha();
    }

    void Update()
    {
        ChangeMaterialAlpha();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterStats>())
        {
            if (!PlayerInArea)
            {
                StopCoroutine(WallFadeSolid());
                StartCoroutine(WallFadeTransparent());
            }

            PlayerInArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterStats>())
        {
            if (PlayerInArea)
            {
                StopCoroutine(WallFadeTransparent());
                StartCoroutine(WallFadeSolid());
            }

            PlayerInArea = false;
        }
    }

    void ResetMaterialAlpha()
    {
        if (roomMaterials.Count == 0)
            return;

        foreach (Material m in roomMaterials)
        {
            float r = m.color.r;
            float g = m.color.g;
            float b = m.color.b;

            m.color = new Color(r, g, b, 1);
        }
    }

    void ChangeMaterialAlpha()
    {
        if (roomMaterials.Count == 0)
            return;

        foreach (Material m in roomMaterials)
        {
            float r = m.color.r;
            float g = m.color.g;
            float b = m.color.b;

            //m.SetColor("_Color", new Color(r, g, b, currentAlpha));
            m.color = new Color(r, g, b, currentAlpha);
        }
    }

    IEnumerator WallFadeTransparent()
    {
        for (float j = currentAlpha; j > 0.25f; j -= 0.01f)
        {
            currentAlpha -= 0.01f;

            yield return new WaitForSeconds(0.01f);
        }

        currentAlpha = 0.25f;
    }

    IEnumerator WallFadeSolid()
    {
        for (float j = currentAlpha; j < 1; j += 0.01f)
        {
            currentAlpha += 0.01f;

            yield return new WaitForSeconds(0.01f);
        }

        currentAlpha = 1.0f;
    }
}
