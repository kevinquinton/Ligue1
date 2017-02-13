namespace Ligue1.Entities
{
    public class Team : EntityBase
    {
        private string _name;

        public Team() { }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

    }
}