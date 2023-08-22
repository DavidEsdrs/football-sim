using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;

public class SchedulingUI : MonoBehaviour
{
    [SerializeField]
    private Logger _logger;

    public UIDocument document { get; set; }

    void Awake() {
        document = GetComponent<UIDocument>();
    }
}
