using System.Diagnostics;
using System.Windows.Data;

/*
 * 
 */

class SwordDamage
{
    //Константы хранят занчение дополнительного урона меча
    private const int BASE_DAMAGE = 3;
    private const int FLAME_DAMAGE = 2;

    /// <summary>
    /// Конструктор вычисляет повреждения для значений Magic и Flaming по умолчанию
    /// и начального броска 3d6.
    /// </summary>
    /// <param name="startingRoll">Начальный бросок 3d6<</param>
    public SwordDamage(int startingRoll)
    {
        roll = startingRoll;
        CalculateDamage();
    }

    private int roll;
    /// <summary>
    /// Sets or gets the 3d6 roll.
    /// </summary>
    public int Roll
    {
        get { return roll; }
        set { roll = value; CalculateDamage();}
    }

    private bool flaming;
    /// <summary>
    /// True, если меч огненный; false в противном случае.
    /// </summary>
    public bool Flaming
    {
        get { return flaming; }
        set { flaming = value; CalculateDamage();}
    }
    private bool magic;
    /// <summary>
    /// True, если меч волшебный; false в противном случае.
    /// </summary>
    public bool Magic
    {
        get { return magic; }
        set { magic = value; CalculateDamage();}
    }
    /// <summary>
    /// Contains the calculated damage.
    /// </summary>
    public int Damage { get; private set; }

    /// <summary>
    /// Вычисляет повреждения в зависимости от текущих значений свойств.
    /// </summary>
    private void CalculateDamage()
    {
        decimal magicMultiplier = 1M;
        if (Magic) magicMultiplier = 1.75M;
        Damage = BASE_DAMAGE;
        Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
        if (Flaming) Damage += FLAME_DAMAGE;
    }
}