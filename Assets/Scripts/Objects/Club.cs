public class Club {
  public string Name { get; }
  public string City { get; }

  private float _strength;
  public float Strength { 
    get => _strength;
    set {
      if(value <= 5 && value >= 0) {
        _strength = value;
      }
    }
  }

  public Club(string Name, string City, float Strength) {
    this.Name = Name;
    this.City = City;
    this.Strength = Strength;
  }

  public override string ToString() {
    return $"{Name} - {City}";
  }
}