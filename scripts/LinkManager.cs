using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkManager : MonoBehaviour
{
    // Opens the website that shows the website where the vectors missiles have been downloaded
    public void OpenMissile()
    {
        Application.OpenURL("https://www.freepik.com/free-vector/various-ballistic-missiles-flat-set_9650925.htm");
    }

    // Opens the website that shows the website where the vectors of buildings have been downloaded
    public void OpenTown()
    {
        Application.OpenURL("https://www.freepik.com/free-vector/war-on-ukraine-concept-destroyed-ukrainian-city_24499440.htm");
    }
}
