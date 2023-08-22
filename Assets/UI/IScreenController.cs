using UnityEngine.UIElements;

public interface IScreenController {
  string ScreenName { get; set; }
  UIDocument document { get; set; }
  void DrawScreen();
}