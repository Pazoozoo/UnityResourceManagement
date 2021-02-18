using System.IO;
using UnityEngine;

public class OneAssetBundle : MonoBehaviour {
    int _index;
    Skybox _skybox;
    AssetBundle _skyboxes;

    void Start() {
        _skyboxes = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "skyboxes"));
        if (_skyboxes == null) {
            Debug.Log("Failed to load AssetBundle");
            return;
        }
        _skybox = GetComponent<Skybox>();
        _skybox.material = _skyboxes.LoadAsset<Material>("skybox" + _index);
    }
    
    public void NextSkybox() {
        // Destroy(_skybox.material);
        // Resources.UnloadUnusedAssets();
        // GC.Collect();
        
        if (_index < 5) 
            _index++;
        else 
            _index = 0;

        _skybox.material = _skyboxes.LoadAsset<Material>("skybox" + _index);
    }
}
