using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationScript : MonoBehaviour {

    [System.Serializable]
    public class AnimSpriteSet
    {
        public string AnimationName;
        public Sprite[] Anim_Sprites;
    }

    public GameObject AnimatedGameObject;
    public AnimSpriteSet[] AnimationSets;
    private int Cur_SpriteID;
    private float SecsPerFrame = 0.05f;

    void Awake()
    {
        Cur_SpriteID = 0;
        if (!AnimatedGameObject)
        {
            AnimatedGameObject = this.gameObject;
        }
        PlayAnimation(0, SecsPerFrame);
    }

    public void PlayAnimation(int ID, float secPerFrame)
    {
        SecsPerFrame = secPerFrame;
        StopCoroutine("AnimateSprite");
        //Add as much ID as necessary. Each is a different animation.
        switch (ID)
        {
            case 0:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 1:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 2:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 3:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 4:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 5:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 6:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 7:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 8:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 9:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 10:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 11:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 12:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 13:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 14:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 15:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 16:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 17:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 18:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 19:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
            default:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
        }
    }

    IEnumerator AnimateSprite(int ID)
    {
        switch (ID)
        {
            case 0:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 1:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 2:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 3:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 4:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 5:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 6:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 7:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 8:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 9:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 10:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 11:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 12:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 13:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 14:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 15:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 16:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 17:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 18:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            case 19:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
            default:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                StartCoroutine("AnimateSprite", ID);
                break;
        }
    }
}
