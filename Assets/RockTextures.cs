using UnityEngine;

public class RockTextures : MonoBehaviour
{
    public Texture textureToApply; // Assign the texture in the inspector

    void Start()
    {
        // Check if textureToApply is assigned
        if (textureToApply != null)
        {
            // Apply texture to the material of the prefab
            Renderer renderer = GetComponent<Renderer>();

            if (renderer != null && renderer.material != null)
            {
                // Set the texture on the main texture property (usually "_MainTex")
                renderer.material.SetTexture("_MainTex", textureToApply);
            }
            else
            {
                Debug.LogError("Renderer or material not found on this prefab.");
            }
        }
        else
        {
            Debug.LogError("No texture assigned to apply.");
        }
    }
}
