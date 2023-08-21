using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchController : MonoBehaviour {
    public Match Match;
    public Field Field;
    public Ball Ball;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void StartMatch() {
        SceneManager.LoadScene("Match");
    }
}
