using UnityEngine; //No idea because it's a testscript rn?
using TMPro;

public class TestScript : MonoBehaviour
{
    public Transform cam;

    public TextMeshProUGUI tehMeh;

    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        teh.text = "x: " + Mathf.RoundToInt(player.position.x).ToString() + " y: " + (string)Mathf.RoundToInt(player.position.y).ToString();
    }
}
