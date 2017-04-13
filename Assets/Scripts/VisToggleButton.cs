using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisToggleButton : MonoBehaviour 
{
    public GameObject Target;
    public string TextOnVisible;
    public string TextOnInvisible;

    private Button _button;
    private Text _text;

	void Start () 
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
                _text.text = TextOnVisible;
            }
            else
            {
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
