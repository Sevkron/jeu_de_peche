using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class FinalCutsceneEvent : MonoBehaviour
{

    public PlayableAsset GoodEndingCutscene;
    public PlayableAsset BadEndingCutscene;
    private PlayableDirector DirectorFinalCutscene;
    private bool hasMcGuffin = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DirectorFinalCutscene = this.gameObject.GetComponent<PlayableDirector>();
            var Player = other.gameObject.GetComponent<CharacterController>();
            Player.enabled = false;
            if(Player.hasMcGuffin = !hasMcGuffin)
            {
                DirectorFinalCutscene.Play(GoodEndingCutscene);
                Player.transform.position = this.transform.position;
            }
            else
            {
                DirectorFinalCutscene.Play(BadEndingCutscene);
                Player.transform.position = this.transform.position;
            }
        }
    }
}
