using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Implements the basic functionality for "Player walks up to object, presses 'e' and something happens"
/// </summary>
public class InteractWithObject : MonoBehaviour
{
    //-----Material Blinking-------
    public bool BlinkWhenPlayerNear = true;
    private Material mat_original;
    public Material mat_blink;
    private MeshRenderer _meshRenderer;
    private float timer = 0;
    private bool blinkOn = false;
    private bool playerInCollider = false;
    //-----------------------------

    //-----MaterialBlinkOnInteract-----
    public bool BlinkOnInteract;
    private Material mat_blinkOnce;
    public float blinkOnceLength;
    //-----------------------------


    private bool hasItem;
    //---------------------------
    
    //-----Interaction Text-----
    public string InteractionDisplayText;
    [Header("if null, will attempt to find")]
   
    //---------------------------
    
    //------Event Methods--------
    [Header("Called when Player presses Interact Button (likely 'E')")]
    public UnityEvent CallOnInteract;
    [Header("Called when Player enters the trigger collider on this object")]
    public UnityEvent CallOnEnterCollider;
    //----------------------------
    
    [Header("Destroys script after use")]
    public bool killAfterUse = true;
    
    [Header("Destroys this gameObject after use")]
    public bool DestoryObjectAfterUse = false;
    
    private byte interactionDelayFrames = 0;
    private byte interactionDelayFramesMax = 20;

    private void Awake()
    {
    }


    public void Start()
    {
        
        // materials for material blinking
        if (BlinkWhenPlayerNear)
        {
            mat_original = gameObject.GetComponent<MeshRenderer>().material;
            //mat_blink = Resources.Load("Materials/TurquoiseSmooth", typeof(Material)) as Material;
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        if (BlinkOnInteract)
        {
            mat_original = gameObject.GetComponent<MeshRenderer>().material;
            //mat_blinkOnce = Resources.Load("Materials/Transparent Object 1", typeof(Material)) as Material; //pick another color (blue) how?
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    public void FixedUpdate() // Fixed update responds to timescale
    {
        if (BlinkWhenPlayerNear && playerInCollider)
        {
            timer += Time.deltaTime;
            if (timer > .6)
            {
                timer = 0;
                if (blinkOn)
                {
                    _meshRenderer.material = mat_original;
                    blinkOn = false;
                }
                else
                {
                    _meshRenderer.material = mat_blink;
                    blinkOn = true;
                }
            }
        }
        
        
        if (interactionDelayFrames <= 0 && playerInCollider && Input.GetAxis("Interact") > 0)
        {
            interactionDelayFrames = interactionDelayFramesMax;
            //if (hasItem && itemToReceive != null)
            {
                //foreach (var item in itemToReceive)
                    //inventory.AddItem(item,1);

                //itemToReceive = null;
            }
            CallOnInteract.Invoke();

            if (BlinkOnInteract)
            {
                StartCoroutine(nameof(BlinkOnce), BlinkOnce());
            }

            if (DestoryObjectAfterUse)
            {
                //interactText.ToggleVisibility(false);
                Destroy(gameObject);
            }
            
            if (killAfterUse)
            {
                Kill();
            }
        }
        else if (interactionDelayFrames > 0)
        {
            interactionDelayFrames--;    
        }
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (!playerInCollider && other.CompareTag("Player"))
        {
            CallOnEnterCollider.Invoke();
            
            
            
            playerInCollider = true;
            timer = .6f;
            blinkOn = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!playerInCollider && other.CompareTag("Player"))
        {
            
            playerInCollider = true;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            playerInCollider = false;
            if(BlinkWhenPlayerNear) _meshRenderer.material = mat_original;
        }
    }

    public void SetInteractText(string newText)
    {
        this.InteractionDisplayText = newText;
       
    }

    public void DeleteItems()
    {
        
        hasItem = false;
    }

    public void StopBlink()
    {
        _meshRenderer.material = mat_original;
        blinkOn = false;
        BlinkWhenPlayerNear = false;
    }

    private IEnumerator BlinkOnce()
    {
        _meshRenderer.material = mat_blinkOnce;
        if (blinkOnceLength == 0f) { blinkOnceLength = 0.1f; }
        yield return new WaitForSeconds(blinkOnceLength);
        _meshRenderer.material = mat_original;
    }

    public void Kill()
    {
        
        _meshRenderer.material = mat_original;
        Destroy(this);
    }

    
}
