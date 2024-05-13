using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace KinightsChallenge.Models
{
    public class Knight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Attributes Attributes { get; set; }
        public string KeyAttribute { get; set; }
        public int Age => CalculateAge();
        public int Attack => CalculateAttack();
        public int Exp => CalculateExperience();

        // Métodos de cálculo
        private int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if (Birthday.Date > today.AddYears(-age)) age--;
            return age;
        }

        private int CalculateAttack()
        {
            int modValue;
            if (Attributes.Strength >= 0 && Attributes.Strength <= 8)
                modValue = -2;
            else if (Attributes.Strength >= 9 && Attributes.Strength <= 10)
                modValue = -1;
            else if (Attributes.Strength >= 11 && Attributes.Strength <= 12)
                modValue = 0;
            else if (Attributes.Strength >= 13 && Attributes.Strength <= 15)
                modValue = 1;
            else if (Attributes.Strength >= 16 && Attributes.Strength <= 18)
                modValue = 2;
            else // 19 - 20
                modValue = 3;

            int weaponMod = Weapons.Any(w => w.Equipped) ? Weapons.First(w => w.Equipped).Mod : 0;

            return 10 + modValue + weaponMod;
        }

        private int CalculateExperience()
        {
            if (Age < 7)
                return 0;

            return (int)Math.Floor((Age - 7) * Math.Pow(22, 1.45));
        }
    }

    public class Weapon
    {
        public string Name { get; set; }
        public int Mod { get; set; }
        public string Attr { get; set; }
        public bool Equipped { get; set; }
    }

    public class Attributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }
}
