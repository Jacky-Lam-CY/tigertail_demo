using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    GameObject DistanceFrom;

    [SerializeField]
    TextMeshProUGUI MaxDistance, CurrentDistance;

    float maxDistance, currentDistance = 0;

    bool keepTrack = true;

    // Start is called before the first frame update
    void Start()
    {
        DisplayText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Playground") && keepTrack)
        {
            currentDistance = Calculate2dDistance();
            if (currentDistance > maxDistance)
            {
                maxDistance = currentDistance;
            }
            DisplayText();
            keepTrack = false;
        }

        if (collision.gameObject.CompareTag("Start") && !keepTrack)
        {
            keepTrack = true;
        }
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    void DisplayText()
    {
        MaxDistance.text = "Max Distance: " + maxDistance.ToString("0.00") + " m";
        CurrentDistance.text = "Current Distance: " + currentDistance.ToString("0.00") + " m";
    }

    float Calculate2dDistance()
    {
        Vector2 difference = new Vector2(gameObject.transform.position.x - DistanceFrom.transform.position.x, gameObject.transform.position.z - DistanceFrom.transform.position.z);
        return Mathf.Sqrt(Mathf.Pow(difference.x, 2f) + Mathf.Pow(difference.y, 2f));
    }
}
