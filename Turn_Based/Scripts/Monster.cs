public class Monster {
    private string monsterName;
    private int health;
    private int  defense;
    private int attack;
    private int hpRegen;
    private string renderingArt;
    private int mana;
    private int baseStats;
    private int baseStatsRemaining;
    private int penetration;
    private int element;
    private Monster enemy;
    public Monster(string monsterName, string renderingArt) 
    {
        this.monsterName = monsterName;
        this.RenderingArt = renderingArt;
        this.health = 100;
    }
    public void GenerateStats(int level)
    {
        Random random = new Random();
        this.baseStats = Convert.ToInt32((10.2*level) + (1*level)); 
        this.baseStatsRemaining = this.baseStats;
        this.defense = random.Next(1, Convert.ToInt32(this.baseStatsRemaining*0.5));
        this.baseStatsRemaining -= this.defense;
        this.penetration = random.Next(1, Convert.ToInt32(this.baseStatsRemaining*0.5));
        this.baseStatsRemaining -= this.penetration * 2;
        this.attack = this.baseStatsRemaining;
    }
    public void UltimateSkill(){
        defense += enemy.Defense;
        enemy.Defense = 0;
        mana -= 100;
    }
    public void AddShield(){
        defense += Convert.ToInt32(health * 0.10);
    }
    public void Heal()
    {
        Random random = new Random();
        this.Health += this.HpRegen;
        if(this.Health > 100) this.Health = 100;
    }
    public void DealDamage()
    {
        this.enemy.TakeDamage(this.attack, this.penetration);
        this.mana += 10;
    }
    public void SetEnemy(Monster enemy) 
    {
        this.enemy = enemy;
    }
    public void TakeDamage(int damage, int pen)
    {
        if(damage - pen> this.defense)
        {
            this.health -=  ((damage - pen) - this.defense);
        }
        this.health -= pen;
    }
    public global::System.String MonsterName { get => monsterName; set => monsterName = value; }
    public global::System.Int32 Health { get => health; set => health = value; }
    public global::System.Int32 Defense { get => defense; set => defense = value; }
    public global::System.Int32 Attack { get => attack; set => attack = value; }
    public global::System.String RenderingArt { get => renderingArt; set => renderingArt = value; }
    public global::System.Int32 HpRegen { get => hpRegen; set => hpRegen = value; }
    public global::System.Int32 Mana { get => mana; set => mana = value; }
    public global::System.Int32 BaseStats { get => baseStats; set => baseStats = value; }
    public global::System.Int32 Element { get => element; set => element = value; }
    public global::System.Int32 Penetration { get => penetration; set => penetration = value; }
}