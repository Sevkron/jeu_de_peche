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
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DirectorFinalCutscene = this.gameObject.GetComponent<PlayableDirector>();
            var Player = other.gameObject.GetComponent<CharacterController>();
            var hasMcGuffin = Player.hasMcGuffin;
            Player.enabled = false;
            if(Player.hasMcGuffin == true)
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
