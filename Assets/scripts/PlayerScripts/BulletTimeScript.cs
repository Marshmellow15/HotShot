using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeScript : MonoBehaviour {
    public float slowDown = 0.0f;
    public float slowdDownLength = 2f;

    private void Update()
    {
        Time.timeScale += (1f / slowdDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    public void doSlowMotion()
    {
        Time.timeScale = slowDown;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

}
