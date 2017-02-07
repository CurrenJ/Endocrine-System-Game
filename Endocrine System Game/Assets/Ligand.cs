using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ligand : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 0.1f;
    public float movementSpeed = 1F;
    public char ligandType;
    public int ligIndex;

    private void Start()
    {
        Debug.Log(ligIndex);
        GameObject.FindGameObjectWithTag("receptedgui").GetComponent<TextMesh>().text = (ligIndex) + "/28 Receptors Bound";
        if (ligIndex == 28)
            GameObject.FindGameObjectWithTag("receptedgui").GetComponent<TextMesh>().text = "All Receptors Bound! :)";
    }

    void Update()
    {

        //create rotation
        //Quaternion wantedRotation = Quaternion.LookRotation(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0) - player.position);
        //Quaternion wantedRotation = Quaternion.LookRotation(Input.GetTouch(0).position - new Vector2(player.position.x, player.position.y));
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Main Scene" && Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            Vector3 mouse_pos;
            Vector3 object_pos;
            
            mouse_pos = Input.GetTouch(0).position;
            mouse_pos.z = 1; //The distance between the camera and object
            object_pos = Camera.main.WorldToScreenPoint(player.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            Quaternion angle = Quaternion.Euler(0, 0, Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90);

            //then rotate
            transform.rotation = Quaternion.Lerp(player.rotation, angle, rotationSpeed);
            //Vector3 oldRot = transform.rotation.eulerAngles; transform.rotation = Quaternion.Euler(0, 0, oldRot.z);
            transform.position += transform.up * Time.deltaTime * movementSpeed * 100;
        }
        else if (SceneManager.GetActiveScene().name == "Main Scene" && Input.GetMouseButton(0))
        {
            Vector3 mouse_pos;
            Vector3 object_pos;

            mouse_pos = Input.mousePosition;
            mouse_pos.z = 1; //The distance between the camera and object
            object_pos = Camera.main.WorldToScreenPoint(player.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            Quaternion angle = Quaternion.Euler(0, 0, Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90);

            //then rotate
            transform.rotation = Quaternion.Lerp(player.rotation, angle, rotationSpeed);
            //Vector3 oldRot = transform.rotation.eulerAngles; transform.rotation = Quaternion.Euler(0, 0, oldRot.z);
            transform.position += transform.up * Time.deltaTime * movementSpeed * 100;
        }
    }

    void bindToReceptor() {
        Destroy(gameObject);
    }

}
