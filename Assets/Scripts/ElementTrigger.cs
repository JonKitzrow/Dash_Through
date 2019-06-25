using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTrigger : MonoBehaviour
{
    public Element element;

    void OnTriggerEnter2D(Collider2D other)
    {
      element.sendTrigger(other);
    }
}
