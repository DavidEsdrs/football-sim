using UnityEngine;

public class Ball : MonoBehaviour {
  public float Speed = 10f;
  public float MaxSpeed = 20f;
  public float MinSpeed = 5f;
  public float Acceleration = 0.1f;
  public float Deceleration = 0.1f;
  public float MaxDistance = 10f;
  public float MinDistance = 1f;
  public float MaxDistanceToPlayer = 1f;
  public float MinDistanceToPlayer = 0.5f;
  public float MaxDistanceToGoal = 1f;
  public float MinDistanceToGoal = 0.5f;
  public float MaxDistanceToBall = .3f;
  public float MinDistanceToBall = 0f;
  public float MaxDistanceToBallToPass = 1f;
  public float MinDistanceToBallToPass = 0.5f;
  public float MaxDistanceToBallToShoot = 1f;
  public float MinDistanceToBallToShoot = 0.5f;
  public float MaxDistanceToBallToDribble = 1f;
  public float MinDistanceToBallToDribble = 0.5f;
  public float MaxDistanceToBallToCross = 1f;
  public float MinDistanceToBallToCross = 0.5f;
  public float MaxDistanceToBallToTackle = 1f;
  public float MinDistanceToBallToTackle = 0.5f;
  public float MaxDistanceToBallToMark = 1f;
  public float MinDistanceToBallToMark = 0.5f;
  public float MaxDistanceToBallToIntercept = 1f;
  public float MinDistanceToBallToIntercept = 0.5f;
  public float MaxDistanceToBallToClear = 1f;
  public float MinDistanceToBallToClear = 0.5f;
  public float MaxDistanceToBallToDefend = 1f;
  public float MinDistanceToBallToDefend = 0.5f;
  public float MaxDistanceToBallToAttack = 1f;
  public float MinDistanceToBallToAttack = 0.5f;
  public float MaxDistanceToBallToSupport = 1f;
  public float MinDistanceToBallToSupport = 0.5f;

  public Player PlayerWithBall;

  public void UpdatePlayerWithBall(Player player) {
    PlayerWithBall = player;
  }
}