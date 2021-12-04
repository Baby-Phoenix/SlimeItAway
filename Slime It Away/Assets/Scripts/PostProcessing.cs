using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume processVolume;
    private Vignette vignette;
    public GarbageSpawner spawner;
    public PlayerInfo player;

    // Start is called before the first frame update
    void Start()
    {
        processVolume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0f;
    }

    private void Update()
    {
        float value = spawner.garbageSpawned / player.health;
        Debug.Log(value);
        vignette.intensity.value = value;
    }

}
