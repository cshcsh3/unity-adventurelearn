using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BarChart : MonoBehaviour {
    // For dynamic bar generation, not used 
    public Bar barPrefab;

    float chartWidth;

	// Use this for initialization
	void Start () {
        chartWidth = Screen.width + GetComponent<RectTransform>().sizeDelta.x;

        float[] inputValues = { 0.1f, 0.2f, 0.5f };

        // Display the graph    
        DisplayGraph(inputValues);
	}
	
    void DisplayGraph(float[] vals)
    {
        for (int i = 0; i < vals.Length; i++)
        {
            Bar newBar = Instantiate<Bar>(barPrefab, transform);
            newBar.transform.SetParent(transform);

            // Change bar color
            if (i == 0)
            {
                newBar.bar.color = new Color32(255, 0, 0, 180);
            }
            else if (i == 1)
            {
                newBar.bar.color = new Color32(0, 255, 0, 180);
            }
            else if (i == 2)
            {
                newBar.bar.color = new Color32(0, 0, 255, 180);
            }

            RectTransform rt = newBar.bar.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector3(chartWidth * vals[i], rt.sizeDelta.y);
        }
    }
}
