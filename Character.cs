using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Character : MonoBehaviour
{
	// Przechowuje dane o postaci
	// Wykonuje aktywne efekty na postaci
	// Sprawdza czy jest targetowany i lootowany

	public Caster caster = new Caster();

	public int id;
	public int targetId;
	public bool isDead;
	public int killerId;
	public bool isPlayer;
	public int lvl;
	public string nickname;
	public int fraction;

	public List<int> reputation = new List<int>();
	public List<Effect> activeEffects = new List<Effect>();
	public List<int> skills = new List<int>(); //global skill id
	public List<float> skillsCD = new List<float>();

	// Attributes
	public int might;
	public int agility;
	public int will;
	public int vitality;

	// bars
	public float morale;
	public float power;
	public float moraleCurrent;
	public float powerCurrent;

	//other parameters
	public int meleeAttackPower;
	public int rangedAttackPower;
	public int spellpower;
	public int armor;
	public int hitValue;
	public int critValue;
	public int blockValue;
	public int parryValue;
	public int dodgeValue;
	public float hitChance;
	public float critChance;
	public float blockChance;
	public float parryChance;
	public float dodgeChance;
	public float physicalMitigation;
	public float powerMitigation;
	public float moraleRegen;
	public float powerRegen;

	// primary skills
	public List<float> primarySkills = new List<float>();
	
	private float regenTimer = 0.2f;

	public void ExecuteEffects()
	{
		for(int i = activeEffects.Count-1; i >=0; i--)
		{
			if(!activeEffects[i].Execute())
				activeEffects.RemoveAt(i);
		}
	}
	public void UseSkill(int id)
	{
		if(SkillsManager.Instance.CanExecute(skills[id],sCharactersManager.characters.FindIndex(x => x == this),targetId) && skillsCD[id] == 0)
		{
			SkillsManager.Instance.Execute(skills[id],sCharactersManager.characters.FindIndex(x => x == this),targetId,false);
			skillsCD[id] = (int)SkillsManager.Instance.skills[id].GetParam(6);
		}
	}
	
	public void UseCastedSkill(int id, int u, int t)
	{
		if(SkillsManager.Instance.CanExecute(skills[id],u,targetId) && skillsCD[id] == 0)
		{
			SkillsManager.Instance.Execute(skills[id],u,t,true);
			skillsCD[id] = (int)SkillsManager.Instance.skills[id].GetParam(6);
		}
	}

	private void ProcSkillsCD()
	{
		for(int i = 0;i < skillsCD.Count; i++)
		{
			if(skillsCD[i] > 0)
			{
				skillsCD[i] -= Time.deltaTime;
				if(skillsCD[i] < 0)
					skillsCD[i] = 0;
			}
		}
	}

	private void ApplyRegen()
	{
		regenTimer -= Time.deltaTime;
		if(regenTimer<=0)
		{
			moraleCurrent += moraleRegen/5;
			if(moraleCurrent>morale)
				moraleCurrent = morale;
			powerCurrent += powerRegen/5;
			if(powerCurrent>power)
				powerCurrent = power;

			regenTimer = 0.2f;
		}
	}

	private void ResetSkills()
	{
		for(int i =0; i<11; i++){
			primarySkills.Add(1);
		}
		primarySkills[0] = (primarySkills[1]+primarySkills[2]+primarySkills[3]+primarySkills[4]+primarySkills[5])/5;
		primarySkills[6] = (primarySkills[7]+primarySkills[8]+primarySkills[9]+primarySkills[10])/4;
	}

	private void ResetReputation()
	{
		reputation.Add(0); // Frakcja 0
		reputation.Add(0); // Fire Kingdom
		reputation.Add(0);
		reputation.Add(0);
		reputation.Add(0);
		reputation.Add(0);
		reputation.Add(0);
		reputation.Add(0); // Neutral - permanent
		reputation.Add(-5000); // Hostile - permanent
		reputation.Add(0); // Greil's Pack
		reputation.Add(-500); // Randy's Bandits
		reputation.Add(0); // Scarlet Trail Merchants
	}

	private void Recalculate()
	{
		meleeAttackPower = might*10;
		rangedAttackPower = agility*10;
		spellpower = will*10;
		physicalMitigation = Mathf.Round(armor/100);
	}

	private void Target()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit info;
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(r,out info);
			if(info.collider.Equals(this.gameObject.GetComponent<Collider>()))
			{
				sCharactersManager.characters[0].targetId = sCharactersManager.characters.IndexOf(this);
				Engine.Instance.targeted = true;
			}
		}
	}

	private void Loot()
	{
		if(isDead && !isPlayer){
			if(Input.GetMouseButtonDown(1))
			{
				RaycastHit info = new RaycastHit();
				Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(r,out info);
				if(info.collider.Equals(this.gameObject.GetComponent<Collider>()))
				{
					sItemMaganer.targetItemContainer = gameObject.GetComponent<ItemContainer>();
				}
			}
		}
	}

	private void HandleDead()
	{
		if(moraleCurrent < 1)
		{
			activeEffects.Clear();
			isDead = true;
			sCharactersManager.characters[0].targetId = -1;
		}
	}

	public bool IsCasting()
	{
		return caster.Casting();
	}

	public void SetCastBarValues(out string text, out float progress)
	{
		text = caster.GetName();
		progress = caster.GetProgress();
	}

	void Start()
	{
		//tymczasowe dane - potem z servera i pliku
		skills.Add(0);
		skillsCD.Add(0);

		isDead = false;
		killerId = -1;
		targetId = -1;
		might=10;
		agility=10;
		will=10;
		vitality=10;
		morale=vitality*100;
		power=will*10;
		moraleCurrent = 1;
		
		//other parameters
	 	armor=0;
		hitValue=agility*10;
		critValue=agility*1;
		blockValue=0;
		parryValue=0;
		dodgeValue=agility*2;
	 	hitChance=hitValue/10;
		critChance=critValue/10;
		blockChance=blockValue/10;
		parryChance=parryValue/10;
		dodgeChance=dodgeValue/10;
		physicalMitigation=armor/100;
		powerMitigation=will/100;
		moraleRegen=vitality*5;
		powerRegen=will*0.1f;

		// primary skills
		fraction = 1;
		ResetSkills();
		ResetReputation();
	}

	void Update()
	{
		if(!isDead)
		{
			HandleDead();
			Recalculate();
			if(caster.Casting())
				caster.Update();
			ExecuteEffects();
			ProcSkillsCD();
			ApplyRegen();

			Target();
		}
		Loot();
	}	
}

