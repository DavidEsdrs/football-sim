using System;
using UnityEngine;

public enum Position {
  Goalkeeper,
  Defender,
  Midfielder,
  Forward
}

public class Player : MonoBehaviour, EventEmitter<Contract, ContractType> {
  public string Name;
  public Position Position;
  public PlayerAttributes Attributes;

  public Transform Feet;

  public bool IsWithBall;
  public Ball ball;

  void Start() {
    Emit("contract", new TriangularContract(this));
    var matchController = GameObject.Find("GameController").GetComponent<MatchController>();
    ball = matchController.Ball;
  }

  void Update() {
    CheckBall();
    Move();
  }

  void CheckBall() {
    if (IsWithBall) {
      Debug.Log("Player is with ball");
    }
    IsWithBall = Vector3.Distance(ball.transform.position, transform.position) <= ball.MaxDistanceToBall;
  }

  void Move() {
    if(IsWithBall) {
      ball.gameObject.transform.position = Feet.position;
    }
  }

  public void Emit(string eventName, Contract data) {
    
  }

  public void On(ContractType contractType, Action<Contract> callback) {
    switch (contractType) {
      case ContractType.Triangular:
        Debug.Log("Triangular");
        break;
      case ContractType.Tabelinha:
        Debug.Log("Tabelinha");
        break;
    }
  }

  public void Off(ContractType contractType, Action<Contract> callback) {

  }



}