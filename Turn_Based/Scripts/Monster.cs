public class Monster {
    private string monsterName;
    private int health;
    private int  defense;
    private int attack;
    private int hpRegen;
    private string renderingArt;
    private Monster enemy;
    public Monster(string monsterName, int health, int defense, int attack, int hpRegen, string renderingArt) 
    {
        this.monsterName = monsterName;
        this.attack = attack;
        this.health = health;
        this.defense = defense;
        this.RenderingArt = renderingArt;
        this.HpRegen = hpRegen;
    }
    public void AddShield(){
        defense += Convert.ToInt32(health * 0.10);
    }
    public void Heal()
    {
        Random random = new Random();
        this.Health += this.HpRegen;
    }
    public void DealDamage()
    {
        this.enemy.TakeDamage(this.attack);
    }
    public void SetEnemy(Monster enemy) 
    {
        this.enemy = enemy;
    }
    public void TakeDamage(int damage)
    {
        if(damage > this.defense)
        {
            this.health -=  (damage - this.defense);
            this.defense = 0;
        }
        else if(damage == this.defense)
        {
            this.defense = 0;
        }
        else
        {
            this.defense -= damage;
        }
    }
    public global::System.String MonsterName { get => monsterName; set => monsterName = value; }
    public global::System.Int32 Health { get => health; set => health = value; }
    public global::System.Int32 Defense { get => defense; set => defense = value; }
    public global::System.Int32 Attack { get => attack; set => attack = value; }
    public global::System.String RenderingArt { get => renderingArt; set => renderingArt = value; }
    public global::System.Int32 HpRegen { get => hpRegen; set => hpRegen = value; }
}