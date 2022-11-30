using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class aa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GridLayout gridLayout = transform.parent.GetComponent<GridLayout>();
        Vector3Int cellPosition = gridLayout.LocalToCell(transform.localPosition);
        transform.localPosition = gridLayout.CellToLocal(cellPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
