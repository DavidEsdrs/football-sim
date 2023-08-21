using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SimulationController : MonoBehaviour {
  public Field field;
  public Ball ball;
  public List<Player> players = new();
  public List<Player> bench = new();
  public List<Player> p = new();
  public ContractManager contractManager;

  public void Start() {

    ball = GameObject.Find("Ball").GetComponent<Ball>();
    field = GameObject.Find("Field").GetComponent<Field>();
    contractManager = GetComponent<ContractManager>();

    GameObject[] playersObj = GameObject.FindGameObjectsWithTag("Player");
    foreach (GameObject p in playersObj) {
      var playerComponent = p.GetComponent<Player>();
      players.Add(playerComponent);
    }

    GameObject[] benchObj = GameObject.FindGameObjectsWithTag("Bench");
    foreach (GameObject p in benchObj) {
      var playerComponent = p.GetComponent<Player>();
      bench.Add(playerComponent);
    }

    Debug.Log(players[0].Name);

    p = GetPlayersNextTo(players[0], 2);
  }

  public List<Player> GetPlayersNextTo(Player player, int quantity) {
    var players = new List<Player>();

    var playerIndex = this.players.IndexOf(player);

    Transform playerTransform = player.transform;

    var playersNext = players
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
      .Select(player => player.player)
      .TakeWhile(p => {
        if(quantity == 0) {
          return false;
        }
        return true;
      });
      // .ForEach(player => {
      //   if (quantity == 0) {
      //     return;
      //   }
      //   Debug.Log($"player: {player.player.Name}");
      //   playersNext.Add(player.player);
      //   quantity--;
      // });

    Debug.Log(playersNext.ToString());

    return playersNext.ToList();
  }
}