namespace DungeonsAndCodeWizards.Models
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; set; }
        public abstract void AffectCharacter(Character character);
    }
}
