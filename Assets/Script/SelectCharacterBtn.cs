using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectCharacterBtn : MonoBehaviour
{
    [SerializeField] private List<AudioSource> audioNames;
    [SerializeField] private List<AudioSource> audiosCharacter_men;
    [SerializeField] private List<AudioSource> audiosCharacter_women;
    [SerializeField] private List<AudioSource> audiosCharacter_a12;
    [SerializeField] private TextMeshProUGUI m_TextMeshProPlayer, m_TextMeshProNPC;
    [SerializeField] private List<Sprite> machoManSprites;
    [SerializeField] private List<Sprite> kimYunaSprites;
    [SerializeField] private List<Sprite> a12Sprites;
    [SerializeField] private List<Sprite> kwesiSprites;
    [SerializeField] private List<Sprite> roiSprites;
    [SerializeField] private List<Sprite> xManSprites;
    [SerializeField] private List<Sprite> devilManSprites;
    [SerializeField] private List<Sprite> amySprites;
    [SerializeField] private Player player;
    [SerializeField] private NPC npc;
    [SerializeField] private GameObject gamePlay;
    private SpriteRenderer spritePlayer, spriteNPC;
    private bool check = false, checkNPC = false;
    private void Start()
    {
        spritePlayer = player.GetComponent<SpriteRenderer>();
        spriteNPC = npc.GetComponent<SpriteRenderer>();
    }
    public void Fight()
    {
        AudioManager.Instance.PlayAudioSelect();
        if (check && checkNPC)
        {
            StartCoroutine(Count3seconds.Instance.Count(gameObject, gamePlay));
            check = false;
            checkNPC = false;
        }
    }
    public void SelectKimYuna()
    {
        AudioManager.Instance.PlayAudioClick();
        check = true;
        m_TextMeshProPlayer.SetText("Kim Yuna");
        for (int i = 0; i < 7; i++)
        {
            player.AnimationPlayer[i] = kimYunaSprites[i];
        }
        player.Hp = 10f;
        player.Damage = 1.3f;
        player.KeyPressCooldown = 0.8f;
        spritePlayer.sprite = kimYunaSprites[3];
        player.PlayerName = audioNames[0];
        for (int i = 0; i < audiosCharacter_women.Count; i++)
        {
            player.Playerfights[i] = audiosCharacter_women[i];
        }
    }
    public void SelectMachoMan()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlock(0) == true)
        {
            check = true;
            m_TextMeshProPlayer.SetText("Macho Man");
            for (int i = 0; i < 7; i++)
            {
                player.AnimationPlayer[i] = machoManSprites[i];
            }
            player.Hp = 14f;
            player.Damage = 1.1f;
            player.KeyPressCooldown = 1f;
            spritePlayer.sprite = machoManSprites[3];
            player.PlayerName = audioNames[1];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                player.Playerfights[i] = audiosCharacter_men[i];
            }
        }

    }
    public void SelectA12()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlock(1) == true)
        {
            check = true;
            m_TextMeshProPlayer.SetText("A12");
            for (int i = 0; i < 7; i++)
            {
                player.AnimationPlayer[i] = a12Sprites[i];
            }
            player.Hp = 8f;
            player.Damage = 1.8f;
            player.KeyPressCooldown = 0.5f;
            spritePlayer.sprite = a12Sprites[3];
            player.PlayerName = audioNames[3];
            for (int i = 0; i < audiosCharacter_a12.Count; i++)
            {
                player.Playerfights[i] = audiosCharacter_a12[i];
            }
        }

    }
    public void SelectKwesi()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlock(3) == true)
        {
            check = true;
            m_TextMeshProPlayer.SetText("Kwesi");
            for (int i = 0; i < 7; i++)
            {
                player.AnimationPlayer[i] = kwesiSprites[i];
            }
            player.Hp = 17f;
            player.Damage = 1f;
            player.KeyPressCooldown = 1.3f;
            spritePlayer.sprite = kwesiSprites[3];
            player.PlayerName = audioNames[6];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                player.Playerfights[i] = audiosCharacter_men[i];
            }
        }

    }
    public void SelectRoi()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlock(4) == true)
        {
            check = true;
            m_TextMeshProPlayer.SetText("Roi");
            for (int i = 0; i < 7; i++)
            {
                player.AnimationPlayer[i] = roiSprites[i];
            }
            player.Hp = 9f;
            player.Damage = 1.7f;
            player.KeyPressCooldown = 0.7f;
            spritePlayer.sprite = roiSprites[3];
            player.PlayerName = audioNames[5];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                player.Playerfights[i] = audiosCharacter_men[i];
            }
        }

    }
    public void SelectXMan()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlock(2) == true)
        {
            check = true;
            m_TextMeshProPlayer.SetText("X-Man");
            for (int i = 0; i < 7; i++)
            {
                player.AnimationPlayer[i] = xManSprites[i];
            }
            player.Hp = 10f;
            player.Damage = 1.6f;
            player.KeyPressCooldown = 0.75f;
            spritePlayer.sprite = xManSprites[3];
            player.PlayerName = audioNames[2];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                player.Playerfights[i] = audiosCharacter_men[i];
            }
        }

    }
    public void SelectDevilMan()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlock(6) == true)
        {
            check = true;
            m_TextMeshProPlayer.SetText("Devil Man");
            for (int i = 0; i < 7; i++)
            {
                player.AnimationPlayer[i] = devilManSprites[i];
            }
            player.Hp = 6f;
            player.Damage = 2.3f;
            player.KeyPressCooldown = 0.3f;
            spritePlayer.sprite = devilManSprites[3];
            player.PlayerName = audioNames[7];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                player.Playerfights[i] = audiosCharacter_men[i];
            }
        }

    }
    public void SelectAmy()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlock(5) == true)
        {
            check = true;
            m_TextMeshProPlayer.SetText("Amy");
            for (int i = 0; i < 7; i++)
            {
                player.AnimationPlayer[i] = amySprites[i];
            }
            player.Hp = 25f;
            player.Damage = 1f;
            player.KeyPressCooldown = 2f;
            spritePlayer.sprite = amySprites[3];
            player.PlayerName = audioNames[4];
            for (int i = 0; i < audiosCharacter_women.Count; i++)
            {
                player.Playerfights[i] = audiosCharacter_women[i];
            }
        }
    }
    public void SelectKimYunaNPC()
    {
        AudioManager.Instance.PlayAudioClick();
        checkNPC = true;
        m_TextMeshProNPC.SetText("Kim Yuna");
        for (int i = 0; i < 7; i++)
        {
            npc.AnimationNPC[i] = kimYunaSprites[i];
        }
        npc.HP = 20f;
        npc.Damage = 1.9f;
        spriteNPC.sprite = kimYunaSprites[3];
        npc.NPCNAME = audioNames[0];
        for (int i = 0; i < audiosCharacter_women.Count; i++)
        {
            npc.NPCFIGHTs[i] = audiosCharacter_women[i];
        }
    }
    public void SelectMachoManNPC()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlockLevel(1) == true)
        {
            checkNPC = true;
            m_TextMeshProNPC.SetText("Macho Man");
            for (int i = 0; i < 7; i++)
            {
                npc.AnimationNPC[i] = machoManSprites[i];
            }
            npc.HP = 25f;
            npc.Damage = 2.2f;
            spriteNPC.sprite = machoManSprites[3];
            npc.NPCNAME = audioNames[1];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                npc.NPCFIGHTs[i] = audiosCharacter_men[i];
            }
            npc.LevelOfNPC = 1;
        }

    }
    public void SelectA12NPC()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlockLevel(2) == true)
        {
            checkNPC = true;
            m_TextMeshProNPC.SetText("A12");
            for (int i = 0; i < 7; i++)
            {
                npc.AnimationNPC[i] = a12Sprites[i];
            }
            npc.HP = 16f;
            npc.Damage = 3.6f;
            spriteNPC.sprite = a12Sprites[3];
            npc.NPCNAME = audioNames[3];
            for (int i = 0; i < audiosCharacter_a12.Count; i++)
            {
                npc.NPCFIGHTs[i] = audiosCharacter_a12[i];
            }
            npc.LevelOfNPC = 2;
        }

    }
    public void SelectKwesiNPC()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlockLevel(4) == true)
        {
            checkNPC = true;
            m_TextMeshProNPC.SetText("Kwesi");
            for (int i = 0; i < 7; i++)
            {
                npc.AnimationNPC[i] = kwesiSprites[i];
            }
            npc.HP = 30f;
            npc.Damage = 2f;
            spriteNPC.sprite = kwesiSprites[3];
            npc.NPCNAME = audioNames[6];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                npc.NPCFIGHTs[i] = audiosCharacter_men[i];
            }
            npc.LevelOfNPC = 4;
        }

    }
    public void SelectRoiNPC()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlockLevel(5) == true)
        {
            checkNPC = true;
            m_TextMeshProNPC.SetText("Roi");
            for (int i = 0; i < 7; i++)
            {
                npc.AnimationNPC[i] = roiSprites[i];
            }
            npc.HP = 18f;
            npc.Damage = 3.4f;
            spriteNPC.sprite = roiSprites[3];
            npc.NPCNAME = audioNames[5];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                npc.NPCFIGHTs[i] = audiosCharacter_men[i];
            }
            npc.LevelOfNPC = 5;
        }

    }
    public void SelectXManNPC()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlockLevel(2) == true)
        {
            checkNPC = true;
            m_TextMeshProNPC.SetText("X-Man");
            for (int i = 0; i < 7; i++)
            {
                npc.AnimationNPC[i] = xManSprites[i];
            }
            npc.HP = 20f;
            npc.Damage = 3.2f;
            spriteNPC.sprite = xManSprites[3];
            npc.NPCNAME = audioNames[2];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                npc.NPCFIGHTs[i] = audiosCharacter_men[i];
            }
            npc.LevelOfNPC = 2;
        }

    }
    public void SelectDevilManNPC()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlockLevel(7) == true)
        {
            checkNPC = true;
            m_TextMeshProNPC.SetText("Devil Man");
            for (int i = 0; i < 7; i++)
            {
                npc.AnimationNPC[i] = devilManSprites[i];
            }
            npc.HP = 12f;
            npc.Damage = 6.9f;
            spriteNPC.sprite = devilManSprites[3];
            npc.NPCNAME = audioNames[7];
            for (int i = 0; i < audiosCharacter_men.Count; i++)
            {
                npc.NPCFIGHTs[i] = audiosCharacter_men[i];
            }
            npc.LevelOfNPC = 7;
        }

    }
    public void SelectAmyNPC()
    {
        AudioManager.Instance.PlayAudioClick();
        if (DatabaseGame.Instance.GetUnlockLevel(6) == true)
        {
            checkNPC = true;
            m_TextMeshProNPC.SetText("Amy");
            for (int i = 0; i < 7; i++)
            {
                npc.AnimationNPC[i] = amySprites[i];
            }
            npc.HP = 50f;
            npc.Damage = 2f;
            spriteNPC.sprite = amySprites[3];
            npc.NPCNAME = audioNames[4];
            for (int i = 0; i < audiosCharacter_women.Count; i++)
            {
                npc.NPCFIGHTs[i] = audiosCharacter_women[i];
            }
            npc.LevelOfNPC = 6;
        }

    }
}
