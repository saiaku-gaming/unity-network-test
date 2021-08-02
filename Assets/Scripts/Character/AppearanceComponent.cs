using UnityEngine;

namespace Character
{
    public class AppearanceComponent : MonoBehaviour
    {

        [SerializeField] private Material selectedMaterial;
        [SerializeField] private Material deSelectedMaterial;

        public void Deselected()
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = deSelectedMaterial;
        }

        public void Selected()
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = selectedMaterial;
        }
    }
}
