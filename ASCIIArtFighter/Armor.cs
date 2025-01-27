using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    public abstract class Armor
    {
        public string Name { get; set; }
        public int ArmorPoints { get; set; }
        public int Cost { get; set; }

        public Armor(string name, int armor, int cost)
        {
            Name = name;
            ArmorPoints = armor;
            Cost = cost;
        }
    }

    public class ArmorGenerator
    {
        public IEnumerable<Armor> GenerateArmors()
        {
            yield return new ClothArmor();
            yield return new LeatherArmor();
            yield return new MailArmor();
            yield return new PlateArmor();
            yield return new CooperArmor();
            yield return new IronArmor();
            yield return new SilverArmor();
            yield return new GoldArmor();
            yield return new DiamondArmor();
        }
    }

    public class ClothArmor : Armor
    {
        public ClothArmor() : base("Cloth Armor", 5, 50) {}
    }

    public class LeatherArmor : Armor
    {
        public LeatherArmor() : base("Leather Armor", 10, 150) { }
    }

    public class MailArmor : Armor
    {
        public MailArmor() : base("Mail Armor", 25, 500) { }
    }

    public class PlateArmor : Armor
    {
        public PlateArmor() : base("Plate Armor", 35, 1000) { }
    }

    public class CooperArmor : Armor
    {
        public CooperArmor() : base("Cooper Armor", 50, 2500) { }
    }

    public class IronArmor : Armor
    {
        public IronArmor() : base("Iron Armor", 75, 5000) { }
    }

    public class SilverArmor : Armor
    {
        public SilverArmor() : base("Silver Armor", 75, 5000) { }
    }

    public class GoldArmor : Armor
    {
        public GoldArmor() : base("Gold Armor", 90, 7500) { }
    }

    public class DiamondArmor : Armor
    {
        public DiamondArmor() : base("Diamond Armor", 100, 10000) { }
    }
}
