using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadKonamiCode : MonoBehaviour
{
    public bool loadSecret;
    private void Awake()
    {
        loadSecret = false;
    }

    private void Update()
    {
        if (loadSecret)
        {
            Loader.load(Loader.Scene.SecretMarioStarship);
        }
    }

    public void startLoad()
    {
        loadSecret=true;
    }
}
