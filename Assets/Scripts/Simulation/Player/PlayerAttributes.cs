using System;
using System.Collections.Generic;

[Serializable]
public class PlayerAttributes {
  public Dictionary<string, float> Attributes = new();
  private List<PlayerAttribute> playerAttributes = new();

  [Serializable]
  protected class PlayerAttribute {
    public string key;
    public int value;

    public PlayerAttribute(string key, int value) {
      this.key = key;
      this.value = value;
    }
  }

  public PlayerAttributes() {
    // Physical attributes
    AddProperty("MaxSpeed", 0);
    AddProperty("Acceleration", 0);
    AddProperty("Deceleration", 0);
    AddProperty("Recuperation", 0);
    AddProperty("Resistance", 0);
    
    // Physical attributes (dribbling)
    AddProperty("Agility", 0);
    AddProperty("Balance", 0);
    AddProperty("Flexibility", 0);
    
    // Physical attributes (shooting)
    AddProperty("Jump", 0);

    // Physical attributes (tackling)
    AddProperty("Strength", 0);
    AddProperty("Aggressiveness", 0);
    AddProperty("Determination", 0);

    // Tecnical attributes
    AddProperty("BallControl", 0);
    AddProperty("FirstTouch", 0);
    AddProperty("Dribbling", 0);
    AddProperty("Passing", 0);
    AddProperty("LongPassing", 0);
    AddProperty("Crossing", 0);
    AddProperty("Shooting", 0);
    AddProperty("Heading", 0);
    AddProperty("Tackling", 0);
    AddProperty("Marking", 0);
    AddProperty("Intercepting", 0);
    AddProperty("Clearing", 0);

    // Mental attributes
    AddProperty("Positioning", 0);
    AddProperty("Anticipation", 0);
    AddProperty("Vision", 0);
    AddProperty("Composure", 0);
    AddProperty("Concentration", 0);
    AddProperty("Decisions", 0);
    AddProperty("Teamwork", 0);
    AddProperty("Leadership", 0);
    AddProperty("WorkRate", 0);
    AddProperty("OffTheBall", 0);
    AddProperty("Bravery", 0);
    AddProperty("Aggression", 0);
    AddProperty("Flair", 0);
    AddProperty("Dirtiness", 0);
    AddProperty("Temperament", 0);
    AddProperty("Adaptability", 0);
    AddProperty("Loyalty", 0);
    AddProperty("Pressure", 0);
    AddProperty("Versatility", 0);

    AddProperty("ConsistencyInAGame", 0);
    AddProperty("ConsistencyInCareer", 0);

    AddProperty("Controversy", 0);
    AddProperty("Professionalism", 0);
    AddProperty("ImportantMatches", 0);
    AddProperty("InjuryProneness", 0);
    AddProperty("Sportsmanship", 0);
  }

  public void AddProperty(string key, int value) {
    Attributes.Add(key, value);
    playerAttributes.Add(new(key, value));
  }
}