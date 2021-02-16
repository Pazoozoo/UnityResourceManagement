using System;
using UnityEngine;

public class ToggleSkyboxGameObjects : MonoBehaviour {
    public GameObject[] cameras;
    private int _index;

    private void Start() {
        foreach (var c in cameras) {
            c.SetActive(false);
        }
        cameras[_index].SetActive(true);
    }

    public void NextSkybox() {
        cameras[_index].SetActive(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
        
        if (_index < cameras.Length -1) 
            _index++;
        else 
            _index = 0;
        
        cameras[_index].SetActive(true);
    }
}
