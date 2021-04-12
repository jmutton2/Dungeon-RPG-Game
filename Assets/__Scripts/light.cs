using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class light : MonoBehaviour
{
    private PostProcessVolume activeVolume;

    // Start is called before the first frame update
    void Start()
    {
        GameObject light = GameObject.Find("PostProcessing");
        activeVolume = light.GetComponent<PostProcessVolume>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            if (activeVolume != null)
            {
                Vignette vignette;

                activeVolume.profile.TryGetSettings(out vignette);

                if (vignette != null) 
                { 
                    vignette.intensity.value = 0.6f; 
                }

                Destroy(gameObject);
            }
        }

    }
}
