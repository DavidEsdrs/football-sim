using UnityEngine;

public class ConfigController : MonoBehaviour {
  private static Config _instance;

  [SerializeField]
  private int spanIntervalSec; // span between ticks in seconds

  public static Config GetConfig() {
    if(_instance == null) {
      var configController = FindObjectOfType<ConfigController>();
      _instance = new(configController.spanIntervalSec);
    }
    return _instance;
  }
}