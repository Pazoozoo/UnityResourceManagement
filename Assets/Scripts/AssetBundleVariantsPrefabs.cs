using System;
using System.IO;
using UnityEngine;

public class AssetBundleVariantsPrefabs : MonoBehaviour {
    int _index;
    GameObject _skybox;
    AssetBundle _skyboxes;

    void Start() {
        InstantiateSkybox();
    }
    
    public void NextSkybox() {
        Destroy(_skybox);
        if (_index < 5) 
            _index++;
        else 
            _index = 0;
        
        InstantiateSkybox();
        Resources.UnloadUnusedAssets();
    }

    void InstantiateSkybox() {
        if (_skybox != null)
            _skyboxes.Unload(true);
            
        _skyboxes = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "skyboxprefabs." + _index));
        if (_skyboxes == null) {
            Debug.Log("Failed to load AssetBundle");
            return;
        }
        _skybox = Instantiate(_skyboxes.LoadAsset<GameObject>($"skybox ({_index})"));
    }
}
