using UnityEngine;

public class Logger : MonoBehaviour {
  public bool CanLog;
  public bool ErrorLog = true;

  public void Log(object message) {
    if(CanLog) {
      Debug.Log(message);
    }
  }

  public void LogError(object message) {
    if(ErrorLog) {
      Debug.Log(message);
    }
  }

  public System.Exception Error(string message) {
    if(ErrorLog) {
      Debug.Log(message);
    }
    return new System.Exception(message);
  }
}