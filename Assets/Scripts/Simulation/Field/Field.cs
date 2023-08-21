using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Field : MonoBehaviour {
  public List<Player> Starter;
  public List<Player> Bench;
  public Ball ball;

  void Start() {
    this.Starter = new();
    this.ball = GameObject.Find("Ball").GetComponent<Ball>();
  }

  public void StarterEleven(Player[] players, Player[] bench) {
    this.Starter = players.ToList();
    this.Bench = bench.ToList();
  }

  public void ChangePlayer(Player player, Player newPlayer) {
    var playerIsInField = this.Starter.Contains(player);

    if (!playerIsInField) {
      Debug.Log("Player is not in field");
      return;
    }

    var playerIsInBench = this.Bench.Contains(newPlayer);

    if (!playerIsInBench) {
      Debug.Log("Player is not in bench");
      return;
    }


    this.Starter.Remove(player);
    this.Bench.Add(player);

    this.Bench.Remove(newPlayer);
    this.Starter.Add(newPlayer);
  }

  public List<Player> GetPlayersNextTo(Player player, int quantity) {
    var players = new List<Player>();

    var playerIndex = this.Starter.IndexOf(player);

    Transform playerTransform = player.transform;

    var playersNext = new List<Player>();

    players
      .Select((player, index) => {
        var playerTransform = player.transform;

        var distance = Vector3.Distance(playerTransform.position, playerTransform.position);

        return new {
          player,
          distance
        };
      })
      .OrderBy(player => player.distance)
      .ToList()
      .ForEach(player => {
        if (quantity == 0) {
          return;
        }
        playersNext.Add(player.player);
        quantity--;
      });

    Debug.Log(playersNext);

    return playersNext;
  }
}