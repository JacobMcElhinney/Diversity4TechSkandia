namespace ClassLibrary.Models
{
    public abstract class Entity
    {

        public abstract bool IsHuman { get; set; }

        public Entity(bool human)
        {
            IsHuman = human;
        }


    }
}
