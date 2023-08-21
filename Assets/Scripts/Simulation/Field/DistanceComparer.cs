using System.Collections.Generic;

public class DistanceComparer : IComparer<float> {
  public int Compare(float a, float b) {
    if (a < b) {
      return -1;
    } else if (a > b) {
      return 1;
    } else {
      return 0;
    }
  }
}