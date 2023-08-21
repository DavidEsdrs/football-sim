using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class CalendarUI : MonoBehaviour
{
    [SerializeField]
    CalendarController calendarController;

    UIDocument document;
    Button nextBtn;

    [SerializeField]
    private string dateString;

    [SerializeField]
    private string club;

    [SerializeField]
    GameObject Calendar;

    void Awake() {
        calendarController = GameObject
            .Find("GameController")
            .GetComponent<GameController>().calendarController;

        document = GetComponent<UIDocument>();
        nextBtn = document.rootVisualElement.Q<Button>("next-date");
        nextBtn.clicked += calendarController.NextDay;
    }

    public void SetDateString(string date) {
        dateString = date;
    }

    public void SetClub(string name, Color color) {
        club = name;
    }

    public void SetEvents(List<IEventListener> events) {
    }
}
