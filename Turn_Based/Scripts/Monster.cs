public class Monster 
{
    private string monsterName;
    private int maxHealth;
    private int health;
    private int  defense;
    private int attack;
    private int hpRegen;
    
    private int speed;
    private string renderingArt;
    private int rage;
    private int baseStats;
    private int baseStatsRemaining;
    private int penetration;
    private int element;
    private int attackMultiplier = 1;
    private int numberOfSkipTurn = 0;
    private string turnLogs; 
    private int exp;
    private int level;
    private Monster selectedMonster;
    private Monster enemy;
    public Monster()
    {

    }
    public Monster(string monsterName, string renderingArt) 
    {
        this.monsterName = monsterName;
        this.RenderingArt = renderingArt;
    }
    public void SkipFor(int numberOfSkipTurn){
        this.numberOfSkipTurn += numberOfSkipTurn;
    }
    public bool isSkip()
    {
        if(numberOfSkipTurn > 0) {
            this.numberOfSkipTurn--;
            return true;
        }
        return false;
    }
    public void IncreaseLevel(){
        GenerateStats(++this.level);
    }
    public void GenerateStats(int level)
    {
        Random random = new Random();
        int health, attack, penetration, hpRegen, speed, defense;
        this.level = level;
        this.baseStats = Convert.ToInt32((20.2*(level)) + (1*level)); 
        this.baseStatsRemaining = this.baseStats;
        health = random.Next(((this.maxHealth > 0)? this.maxHealth : level*16), level*24);
        this.maxHealth = health;
        this.baseStatsRemaining -= Convert.ToInt32(this.health/4);
        attack = random.Next(this.attack, this.attack + (Convert.ToInt32(this.baseStatsRemaining*0.7) + 1)) + 2;
        this.baseStatsRemaining -= attack;
        penetration = this.penetration + random.Next(0, 2);
        penetration += Convert.ToInt32((attack/10.00f)*2.0f);
        this.baseStatsRemaining -= penetration;
        int maxHpRegen = this.hpRegen + (Convert.ToInt32(this.baseStatsRemaining*0.5) + 1);
        if(this.hpRegen > maxHpRegen) hpRegen = random.Next(this.hpRegen, this.hpRegen + 1) + 1;
        else hpRegen = random.Next(this.hpRegen, maxHpRegen) + 1;
        this.baseStatsRemaining -= hpRegen;
        speed = random.Next(this.speed, this.speed + (Convert.ToInt32(this.baseStatsRemaining*0.1) + 1));
        this.baseStatsRemaining -= speed;
        defense = this.baseStatsRemaining;
        if(this.defense < 0)
        {
            penetration -= Math.Abs(defense);
            defense = 0;
        }
        this.health = health;
        this.attack = attack;
        this.penetration = penetration;
        this.hpRegen = hpRegen;
        this.speed = speed;
        this.defense = defense;
    }
    public void UltimateSkill(){
        enemy.SkipFor(2);
        this.rage -= 100;   
    }
    public void AddShield(){
        defense += Convert.ToInt32(health * 0.10);
    }
    public void Heal()
    {
        Random random = new Random();
        this.Health += this.HpRegen;
        float rageReduction = (this.hpRegen * 1.0f)/(this.MaxHealth* 1.0f);
        this.Rage -=  (rageReduction*45 < this.rage)? Convert.ToInt32(rageReduction*45) : this.rage;
        if(this.Health > MaxHealth) this.Health = MaxHealth;
    }
    public void DealDamage()
    {
        this.enemy.TakeDamage(this.Attack, this.penetration);
    }
    public void SetEnemy(Monster enemy) 
    {
        this.enemy = enemy;
    }
    public void TakeDamage(int damage, int pen)
    {
        turnLogs = $"{this.enemy.MonsterName} deal {damage} damage with {pen} true damage";
        Random random = new Random();
        int chanceToDodge = (this.speed - enemy.speed > 0) ? (this.speed - enemy.speed ): 0;
        if(chanceToDodge > 8) chanceToDodge = 8;
        bool isDodge =  (chanceToDodge*10)+10 >= random.Next(1, 90);
        if(!isDodge)
        {
            if(pen >= damage)
            {
                this.health -= damage;
            }
            else{
                this.health -= pen;
                if((damage - pen) > defense) this.health -=  (damage - pen);
            }
            turnLogs += turnLogs + $"{this.MonsterName} deal true {pen} damage";
        }
        else turnLogs += turnLogs + $"{this.MonsterName} dodge the attack";
        float rageIncrease = (damage * 1.0f)/(this.MaxHealth* 1.0f);
        this.rage += Convert.ToInt32(rageIncrease*30) + 5;
    }
    public void AddExp(int expIncrease){
        this.exp += expIncrease;
        if(this.exp >= 10){
            this.exp -= 10;
            IncreaseLevel();
        }
    }
    public global::System.String MonsterName { get => monsterName; set => monsterName = value; }
    public global::System.Int32 Health { get => health; set => health = value; }
    public global::System.Int32 Defense { get => defense; set => defense = value; }
    public global::System.Int32 Attack { get => attack; set => attack = value; }
    public global::System.String RenderingArt { get => renderingArt; set => renderingArt = value; }
    public global::System.Int32 HpRegen { get => hpRegen; set => hpRegen = value; }
    public global::System.Int32 Rage { get => rage; set => rage = value; }
    public global::System.Int32 BaseStats { get => baseStats; set => baseStats = value; }
    public global::System.Int32 Element { get => element; set => element = value; }
    public global::System.Int32 Penetration { get => penetration; set => penetration = value; }
    public global::System.Int32 Speed { get => speed; set => speed = value; }
    public global::System.Int32 MaxHealth { get => maxHealth; set => maxHealth = value; }
    public global::System.Int32 Level { get => level; set => level = value; }
    public global::System.Int32 Exp { get => exp;}
}
