namespace Batlle_Сабитов.Classes.Object
{
    public class MedicinalPotions : Items
    {
        public double Heal;
        public MedicinalPotions(int price, string images, string name, bool canUse, double heal) : base(price, images, name, canUse)
        {
            Heal = heal;
        }
    }
}
