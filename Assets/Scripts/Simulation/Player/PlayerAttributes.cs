using System.Collections.Generic;

public class PlayerAttributes {
  public Dictionary<string, float> Attributes = new Dictionary<string, float>();

  public PlayerAttributes() {
    // Physical attributes
    Attributes.Add("MaxSpeed", 0);
    Attributes.Add("Acceleration", 0);
    Attributes.Add("Deceleration", 0);
    Attributes.Add("Recuperation", 0);
    Attributes.Add("Resistance", 0);
    
    // Physical attributes (dribbling)
    Attributes.Add("Agility", 0);
    Attributes.Add("Balance", 0);
    Attributes.Add("Flexibility", 0);
    
    // Physical attributes (shooting)
    Attributes.Add("Jump", 0);

    // Physical attributes (tackling)
    Attributes.Add("Strength", 0);
    Attributes.Add("Aggressiveness", 0);
    Attributes.Add("Determination", 0);

    // Tecnical attributes
    Attributes.Add("BallControl", 0);
    Attributes.Add("FirstTouch", 0);
    Attributes.Add("Dribbling", 0);
    Attributes.Add("Passing", 0);
    Attributes.Add("LongPassing", 0);
    Attributes.Add("Crossing", 0);
    Attributes.Add("Shooting", 0);
    Attributes.Add("Heading", 0);
    Attributes.Add("Tackling", 0);
    Attributes.Add("Marking", 0);
    Attributes.Add("Intercepting", 0);
    Attributes.Add("Clearing", 0);

    // Mental attributes
    Attributes.Add("Positioning", 0);
    Attributes.Add("Anticipation", 0);
    Attributes.Add("Vision", 0);
    Attributes.Add("Composure", 0);
    Attributes.Add("Concentration", 0);
    Attributes.Add("Decisions", 0);
    Attributes.Add("Teamwork", 0);
    Attributes.Add("Leadership", 0);
    Attributes.Add("WorkRate", 0);
    Attributes.Add("OffTheBall", 0);
    Attributes.Add("Bravery", 0);
    Attributes.Add("Aggression", 0);
    Attributes.Add("Flair", 0);
    Attributes.Add("Dirtiness", 0);
    Attributes.Add("Temperament", 0);
    Attributes.Add("Adaptability", 0);
    Attributes.Add("Loyalty", 0);
    Attributes.Add("Pressure", 0);
    Attributes.Add("Versatility", 0);

    Attributes.Add("ConsistencyInAGame", 0);
    Attributes.Add("ConsistencyInCareer", 0);

    Attributes.Add("Controversy", 0);
    Attributes.Add("Professionalism", 0);
    Attributes.Add("ImportantMatches", 0);
    Attributes.Add("InjuryProneness", 0);
    Attributes.Add("Sportsmanship", 0);
  }
}