using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public GameObject target, obstacle;
    bool isTarget, isObstacle;
    float timeNext;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (isTarget)
      {
        target.SetActive(true);
      }
      else
      {
        if (Time.time >= timeNext)
        {
          target.SetActive(false);
        }
      }

      if (isObstacle)
      {
        obstacle.SetActive(true);
      }
      else
      {
        obstacle.SetActive(false);
      }
    }

    public void setTarget(bool b)
    {
      if (!b)
      {
        isTarget = b;
      }
      else
      {
        if (!isObstacle)
        {
          isTarget = b;
        }
      }
    }

    public void setObstacle(bool b)
    {
      if (!b)
      {
        isObstacle = b;
      }
      else
      {
        if (!isTarget)
        {
          isObstacle = b;
        }
      }
    }

    public void sendTrigger(Collider2D other)
    {
      if (other.tag == "Player")
      {
        if (isTarget)
        {
          GameObject.FindWithTag("GameController").GetComponent<GameController>().targetHit();
          target.GetComponent<Animator>().Play("Idle");
          timeNext = Time.time + 0.5f;
          isTarget = false;
        }
        else if (isObstacle)
        {
          GameObject.FindWithTag("GameController").GetComponent<GameController>().obstacleHit();
          isObstacle = false;
        }
      }
    }
}
