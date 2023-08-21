using System.Collections.Generic;

public abstract class Championship {
  public List<Club> Participants { get; set; }
  public List<Match> Matches { get; set; }

  public abstract void OnWin(Club club);
  public abstract void OnDefeat(Club club);
  public abstract void OnTie(Club club);
}