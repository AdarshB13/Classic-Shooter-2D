using UnityEngine;

public class camcon : MonoBehaviour
{
	[SerializeField]
	Transform shooter;
	[SerializeField]
	Vector3 offset;
	[SerializeField]
	float spedf=0.125f;
	Vector3 desiredpos;
	
	void FixedUpdate()
	{
		desiredpos.x=Mathf.Clamp(shooter.position.x,-0.25f,8.2f)+offset.x;
		desiredpos.z=offset.z;
		desiredpos.y=Mathf.Clamp(shooter.position.y,0.65f,2.3f)+offset.y;
		transform.position=Vector3.Lerp(transform.position,desiredpos,spedf);
	}
}
