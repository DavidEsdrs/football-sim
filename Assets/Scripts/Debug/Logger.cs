using UnityEngine;

public class Logger : MonoBehaviour {
  public bool CanLog;

  public void Log(object message) {
    if(CanLog) {
      Debug.Log(message);
    }
  }
}