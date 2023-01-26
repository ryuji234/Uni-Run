using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : GComponent
{
    private float width;
    public override void Awake()
    {
        base.Awake();

        width = gameObject.GetRectSizeDelta().x;
    }

    // Update is called once per frame
    public override void Update()
    {
        if(transform.localPosition.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector3 offset = new Vector3(width * 2f, 0);
        transform.localPosition = transform.localPosition + offset;
    }       // Reposition()
}
