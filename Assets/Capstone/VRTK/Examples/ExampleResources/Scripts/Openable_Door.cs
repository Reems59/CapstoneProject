namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Openable_Door : VRTK_InteractableObject
    {
        public bool flipped = false;
        public bool rotated = false;
        public AudioSource openAudio;
        public AudioSource closeAudio;
        public GameObject menu;
        private ActiveMenuAideTuto ama;

        private Collider[] collidersDoors = new Collider[3];
        private float sideFlip = -1;
        private float side = -1;
        private float smooth = 270.0f;
        public float doorOpenAngle = -90f;
        private bool open = false;
        private bool nextStepActivate = false;
        private Vector3 defaultRotation;
        private Vector3 openRotation;
        public float delta = 1f;
        private bool endClose = true;
        private bool endOpen = false;        

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            SetDoorRotation(usingObject.transform.position);
            SetRotation();
            open = !open;
            if (open) {
                endOpen = false;
                DisableColliders();
                if (!nextStepActivate)
                {
                    if (menu)
                    {
                        GameObject canvas = menu.transform.GetChild(0).gameObject;
                        if (canvas != null)
                        {
                            GameObject panel = canvas.transform.GetChild(0).gameObject;
                            if (panel != null)
                            {

                                Image image = panel.GetComponent<Image>();
                                image.sprite = Resources.Load("Screen_Interrupteur", typeof(Sprite)) as Sprite;
                                if(ama != null)
                                {
                                    ama.SubscribeMenuButton(ama.hideMenu);
                                    GameObject[] controlleurs = ama.getControllers();
                                    foreach (GameObject g in controlleurs)
                                    {
                                        g.GetComponent<VRTK_Pointer>().enabled = false;
                                        g.GetComponent<VRTK_InteractTouch>().enabled = false;
                                    }
                                }
                                
                                menu.SetActive(true);
                            }
                        }
                    }
                    nextStepActivate = true;
                }
                if(openAudio)
                    openAudio.Play();
            }else
            {
                endClose = false;
                DisableColliders();
                if (closeAudio)
                    closeAudio.Play();
            }
        }

        protected void Start()
        {
            ama = GameObject.Find("VRTK").gameObject.GetComponent<ActiveMenuAideTuto>();
            if(gameObject.GetComponent<Collider>() != null)
            {
                int i = 0;
               foreach (Collider c in gameObject.GetComponents<Collider>())
                {
                    collidersDoors[i] = c;
                    i++;
                }
            }else
            {
                foreach(Transform child in transform)
                {
                    int i = 0;
                    foreach (Collider c in child.GetComponents<Collider>())
                    {
                        collidersDoors[i] = c;
                        i++;
                    }
                }
            }
            defaultRotation = transform.eulerAngles;
            SetRotation();
            sideFlip = (flipped ? 1 : -1);
        }

        protected override void Update()
        {
            base.Update();

            if (open)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRotation),
                    Time.deltaTime * smooth * delta);
                if(!endOpen && transform.rotation == Quaternion.Euler(openRotation))
                {
                    EnableColliders();
                    endOpen = !endOpen;
                }
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(defaultRotation),
                    Time.deltaTime * smooth * delta);
                if (!endClose && transform.rotation == Quaternion.Euler(defaultRotation))
                {
                    EnableColliders();
                    endClose = !endClose;
                }
            }
            
        }

        private void EnableColliders()
        {
            for(int i= 0; i < collidersDoors.Length; i++)
            {
                if(collidersDoors[i] != null)
                {
                    collidersDoors[i].enabled = true;
                }
            }
        }

        private void DisableColliders()
        {
            for (int i = 0; i < collidersDoors.Length; i++)
            {
                if (collidersDoors[i] != null)
                {
                    collidersDoors[i].enabled = false;
                }
            }
        }

        private void SetRotation()
        {
            openRotation = new Vector3(defaultRotation.x, defaultRotation.y + (doorOpenAngle * (sideFlip * side)),
                defaultRotation.z);
        }

        private void SetDoorRotation(Vector3 interacterPosition)
        {
            side = ((rotated == false && interacterPosition.z > transform.position.z) 
                || (rotated == true && interacterPosition.x > transform.position.x) ? -1 : 1);
        }

        public bool doorOpen()
        {
            return open;
        }
        public void setOpen(bool open)
        {
            this.open = open;
        }
    }
}