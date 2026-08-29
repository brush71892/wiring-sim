using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    public Transform cam;

    public TextMeshProUGUI teh;

    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        teh.text = "x: " + Mathf.RoundToInt(player.position.x).ToString() + " y: " + (string)Mathf.RoundToInt(player.position.y).ToString();
    }
}
