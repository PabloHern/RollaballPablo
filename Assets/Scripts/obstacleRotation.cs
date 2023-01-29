using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleRotation : MonoBehaviour
{
  // Start is called before the first frame update
  private bool flip;
  void Start()
  {
    flip = true;
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
  }
}
