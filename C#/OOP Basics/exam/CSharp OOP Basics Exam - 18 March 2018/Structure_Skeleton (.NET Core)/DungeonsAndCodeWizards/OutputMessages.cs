public class OutputMessages
{
    public static string MustBeAlive => "Must be alive to perform this action!";

    public static string CharacterNotFound => "Character {0} not found!";

    public static string CharacterDead => "{0} is dead!";

    public static string ItemNotFound => "No item with name {0} in bag!";

    public static string BagIsFull => "Bag is full!";

    public static string BagIsEmpty => "Bag is empty!";

    public static string SelfAttack => "Cannot attack self!";

    public static string FriendlyFire => "Friendly fire! Both characters are from {0} faction!";

    public static string CannotHealEnemy => "Cannot heal enemy character!";

    public static string InvalidFaction => "Invalid faction \"{0}\"!";

    public static string InvalidCharacter => "Invalid character type \"{0}\"!";

    public static string JoinedParty => "{0} joined the party!";

    public static string InvalidItem => "Invalid item \"{0}\"!";

    public static string ItemAdded => "{0} added to pool.";

    public static string NoItemsLeft => "No items left in pool!";

    public static string ItemPickedUp => "{0} picked up {1}!";

    public static string ItemUsed => "{0} used {1}.";

    public static string ItemUsedOn => "{0} used {1} on {2}.";

    public static string ItemGiven => "{0} gave {1} {2}.";

    public static string CannotAttack => "{0} cannot attack!";

    public static string SuccessfulAttack => "{0} attacks {1} for {2} hit points! {1} has {3}/{4} HP and {5}/{6} AP left!";

    public static string CannotHeal => "{0} cannot heal!";

    public static string SuccessfulHeal => "{0} heals {1} for {2}! {1} has {3} health now!";

    public static string Rest => "{0} rests ({1} => {2})";

    public static string InvalidName => "Name cannot be null or whitespace!";
}
