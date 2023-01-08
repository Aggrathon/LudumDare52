using UnityEngine;
using TMPro;

public class FieldUI : MonoBehaviour
{

    public Field field;

    public TextMeshProUGUI text;


    int collected = -1;
    int trampled = -1;
    int left = -1;


    void Update()
    {
        int newcollected = field.HarvestedCrops * 100 / field.TotalCrops;
        int newtrampled = field.TrampledCrops * 100 / field.TotalCrops;
        if (newcollected != collected || newtrampled != trampled)
        {
            collected = newcollected;
            trampled = newtrampled;
            left = 100 - collected - trampled;
            text.text = string.Format("Crops Left: {0,2:d}%   Harvested: {1,2:d}%   Trampled: {2,2:d}%", left, collected, trampled);
        }
    }
}
