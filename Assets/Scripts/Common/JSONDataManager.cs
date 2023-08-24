using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public enum DataType {
  Player,
  Club,
  Championship
}

public class JSONDataManager : MonoBehaviour {
  [SerializeField]
  private Logger _logger;

  [SerializeField]
  private string championshipFile = "championships.json";

  [SerializeField]
  private string clubsFile = "clubs.json";
  
  [SerializeField]
  private string playersFile = "players.json";

  private string applicationPath;


  void Awake() {
    applicationPath = Application.persistentDataPath;
  }

  private bool Save<T>(T value, string target) {
    try {
      string path = $"{applicationPath}/{target}";
      if(!File.Exists(path)) {
        File.Create(path);
      }
      var playerAsJson = JsonUtility.ToJson(value, true);
      File.WriteAllText(path, playerAsJson);
      return true;
    } catch(System.Exception err)  {
      _logger.LogError(err);
      return false;
    }
  }

  public bool SaveJson<T>(DataType key, T value) {
    switch (key) {
      case DataType.Player:
        return Save(value, playersFile);
      case DataType.Club:
        return Save(value, clubsFile);
      case DataType.Championship:
        return Save(value, championshipFile);
    }
    _logger.LogError("Invalid data type given");
    return false;
  }

  private (T, bool) Read<T>(string source) {
    try {
      string path = $"{applicationPath}/{source}";
      if(!File.Exists(source)) {
        File.Create(path);
      }
      string fileContents = File.ReadAllText(path);
      T content = JsonUtility.FromJson<T>(fileContents);
      return (content, true);
    } catch(System.Exception err) {
      _logger.LogError(err.Message);
      T zeroValue = default;
      return (zeroValue, false);
    }
  }

  /// <summary>
  /// Get data from a JSON file
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="dataType"></param>
  /// <returns></returns>
  public (T, bool) GetFromJson<T>(DataType dataType) {
    T zeroValue = default;
    return dataType switch {
      DataType.Player => Read<T>(playersFile),
      DataType.Club => Read<T>(clubsFile),
      DataType.Championship => Read<T>(championshipFile),
      _ => (zeroValue, false)
    };
  }
}