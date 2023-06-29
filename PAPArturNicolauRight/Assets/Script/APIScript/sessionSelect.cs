using UnityEngine;

public class sessionSelect : MonoBehaviour
{
    [SerializeField]
    GameObject sessionInfoContainer, sessionInfoTemplate;

    public void ExecutSelect()
    {
        foreach (Transform child in sessionInfoContainer.transform)
        {
            Destroy(child.gameObject);
        }

        if (ClassUser.SessionList == null || ClassUser.SessionList.Count == 0)
            return;

        foreach (ClassSession session in ClassUser.SessionList)
        {

            GameObject gobj = (GameObject)Instantiate(sessionInfoTemplate);

            gobj.transform.SetParent(sessionInfoContainer.transform);

            gobj.GetComponent<sessionInfo>().sessionName.text = session.nameSession;
            gobj.GetComponent<sessionInfo>().sessionDate.text = session.dateSession;

            gobj.transform.localScale = new Vector3(1, 1, 1);
            gobj.transform.localPosition = new Vector3(0, -61.645f, 0f);

        }
    }
}
