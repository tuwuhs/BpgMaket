using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisToggleButton : MonoBehaviour 
{
    public GameObject Target;
    public string TextOnVisible;
    public string TextOnInvisible;
    public Color ActiveBackgroundColor;
    public Color ActiveTextColor;
    public Color InactiveBackgroundColor;
    public Color InactiveTextColor;

    private Button _button;
    private Text _text;

	void Start() 
    {
        _button = gameObject.GetComponent<Button>();
        _text = _button.GetComponentInChildren<Text>();

        _button.onClick.AddListener(this.ButtonClicked);
    }
	
    void Update()
    {
    }

    void OnGUI()
    {
        if (Target != null)
        {
            if (Target.activeSelf)
            {
                ColorBlock cb = _button.colors;
                cb.normalColor = ActiveBackgroundColor;
                _button.colors = cb;
                _text.color = ActiveTextColor;
                _text.text = TextOnVisible;
            }
            else
            {
                ColorBlock cb = _button.colors;
                cb.normalColor = InactiveBackgroundColor;
                _button.colors = cb;
                _text.color = InactiveTextColor;
                _text.text = TextOnInvisible;
            }
        }
    }

    void ButtonClicked()
    {
        if (Target != null)
        {
            if (Target.activeSelf)
            {
                Target.SetActive(false);
            }
            else
            {
                Target.SetActive(true);
            }
        }
    }
}
