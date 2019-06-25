using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform circleX, circleY, pulse, bridge;
    public float timePulse;
    float pulseStart, timeNext;
    bool pulsing, pulseOnX;
    public Element[] elements;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      circleX.localPosition = new Vector3(-Mathf.Cos((360 * Mathf.Deg2Rad * Input.mousePosition.x / Screen.width) - 90 * Mathf.Deg2Rad), Mathf.Sin((360 * Mathf.Deg2Rad * Input.mousePosition.x / Screen.width) - 90 * Mathf.Deg2Rad), 0) * 4.15f;
      circleY.localPosition = new Vector3(-Mathf.Cos((360 * Mathf.Deg2Rad * Input.mousePosition.y / Screen.height) - 90 * Mathf.Deg2Rad), Mathf.Sin((360 * Mathf.Deg2Rad * Input.mousePosition.y / Screen.height) - 90 * Mathf.Deg2Rad), 0) * 4.15f;

      if (Input.GetMouseButtonDown(0) && !pulsing)
      {
        pulsing = true;
        pulseStart = Time.time;
        if (pulseOnX)
        {
          circleX.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
          circleY.GetComponent<SpriteRenderer>().color = Color.white;
        }
      }

      if (pulsing)
      {
        if (pulseOnX)
        {
          pulse.position = Vector3.Lerp(circleX.position, circleY.position, (Time.time - pulseStart) / timePulse);
        }
        else
        {
          pulse.position = Vector3.Lerp(circleY.position, circleX.position, (Time.time - pulseStart) / timePulse);
        }

        if ((Time.time - pulseStart) / timePulse >= 1f)
        {
          pulseOnX = !pulseOnX;
          pulsing = false;
        }
      }
      else
      {
        if (pulseOnX)
        {
          pulse.position = circleX.position;
          circleX.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
        }
        else
        {
          pulse.position = circleY.position;
          circleY.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
        }
      }

      bridge.localScale = new Vector3((circleY.position - circleX.position).magnitude * 2, bridge.localScale.y, 1f);
      bridge.position = Vector3.Lerp(circleY.position, circleX.position, 0.5f);
      bridge.right = circleY.position - bridge.position;

      if (Time.time >= timeNext)
      {
        if (!(Random.Range(0, 4) == 0))
        {
          elements[Random.Range(0, elements.Length)].setTarget(true);
        }
        else
        {
          elements[Random.Range(0, elements.Length)].setObstacle(true);
        }
        timeNext = Time.time + Random.Range(5f, 15f);
      }
    }

    public void targetHit()
    {
      Debug.Log("target!");
    }

    public void obstacleHit()
    {
      Debug.Log("obstacle ||");
    }
}
