using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;

public class LayoutUI : MonoBehaviour
{
    [SerializeField]
    private Logger _logger;

    [SerializeField]
    CalendarController calendarController;

    UIDocument document;
    Button nextBtn;

    private TextElement dateString;

    private Label club;


    [SerializeField]
    GameObject Calendar;

    void Awake() {
        calendarController = GameObject
            .Find("GameController")
            .GetComponent<GameController>().calendarController;

        document = GetComponent<UIDocument>();

        nextBtn = document.rootVisualElement.Q<Button>("next-date");
        nextBtn.clicked += NextDay;

        dateString = document.rootVisualElement.Q<TextElement>("date");

        club = document.rootVisualElement.Q<Label>("club");

    }

    private void NextDay() {
        calendarController.NextDay();
    }

    public void SetDateString(string date) {
        dateString.text = date;
    }

    public void SetClub(string name, Color color) {
        club.text = name;
        club.style.color = color;
    }
}
