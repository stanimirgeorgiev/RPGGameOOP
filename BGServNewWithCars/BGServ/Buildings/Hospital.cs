namespace BulgarianReality.Buildings
{
    using System.Collections.Generic;
    using System.Drawing;
    using Items.Drugs;

    public class Hospital : MapTile
    {
        private readonly IList<Drug> drugs;
         
        public Hospital(int id, Image image, Point location)
            : base(id, image, location)
        {
            this.drugs = new List<Drug>();
        }

        public IEnumerable<Drug> Drugs
        {
            get
            {
                return this.drugs;
            }
        }

        private void Add(Drug drug)
        {
            this.drugs.Add(drug);
        }
    }
}
