using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisToggleButton : MonoBehaviour 
{
    public GameObject Target;
    public string TextOnVisible;
    public string TextOnInvisible;
    public float FadeTime = 0.5f;
    public bool Visible = true;

    private Button _button;
    private Text _text;
    private TransparentChildren _fader;

	void Start () 
    {
        _button = gameObject.GetComponent<Button>();
        _text = _button.GetComponentInChildren<Text>();

        _button.onClick.AddListener(this.ButtonClicked);

        _fader = Target.GetComponent<TransparentChildren>();
        if (_fader == null)
        {
            _fader = Target.AddComponent<TransparentChildren>();
        }
    }
	
    void Update()
    {
        if (Visible && _fader.Transparency < 1.0f)
        {
            _fader.Transparency += 1.0f * Time.deltaTime / FadeTime;
        }
        else if (!Visible && _fader.Transparency > 0.0f)
        {
            _fader.Transparency -= 1.0f * Time.deltaTime / FadeTime;
        }
    }

    void OnGUI()
    {
        if (Visible)
        {
            _text.text = TextOnVisible;
        }
        else
        {
            _text.text = TextOnInvisible;
        }
    }

    void ButtonClicked()
    {
        Visible = !Visible;
    }
}
