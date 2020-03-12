using UnityEngine;

public class CollisionPainter : MonoBehaviour
{
    Vector3 pos;
    public Transform Player;
    public Brush brush;
    public bool RandomChannel = false;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision);
        if (collision.gameObject.tag == "wall")
        {
            /*벽 충돌시 벽 부수기 기능*/
            collision.transform.GetComponent<Cube>().Explosion();

            //this.gameObject.transform.position = Vector3.forward;
            //Player.transform.Translate(Vector3.forward);
            
            //pos = this.gameObject.transform.position;
            
            //this.gameObject.transform.position = pos;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        HandleCollision(collision);
        //if (collision.gameObject.tag == "wall")
        //{
       
            
        //    //this.gameObject.transform.Translate(pos, Space.World);
        //}
    }

    private void HandleCollision(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            PaintTarget paintTarget = contact.otherCollider.GetComponent<PaintTarget>();
            if (paintTarget != null)
            {
                if (RandomChannel) brush.splatChannel = Random.Range(0, 4);
                PaintTarget.PaintObject(paintTarget, contact.point, contact.normal, brush);
            }
        }
    }
}