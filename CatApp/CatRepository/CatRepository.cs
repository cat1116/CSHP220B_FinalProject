using CatDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatRepository
{
    public class CatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? Weight { get; set; }
        public string Gender { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Breed { get; set; }
        public bool Friendly { get; set; }
        public bool EarTipped { get; set; }
        public bool DeClawed { get; set; }
        public bool MicroChipped { get; set; }
        public bool SpayedNeutered { get; set; }
        public bool Vaccinated { get; set; }
        public string Comments { get; set; }
        public string Photo { get; set; }
        public string ColonyBorough { get; set; }
        public string ColonyNeighborhood { get; set; }
        public string ColonyCaretakerName { get; set; }
        public string ColonyCaretakerPhone { get; set; }
    }


    public class CatRepository
    {
        public CatModel Add(CatModel catModel)
        {
            var catDb = ToDbModel(catModel);

            try
            {
                DatabaseManager.Instance.Cats.Add(catDb);
                DatabaseManager.Instance.SaveChanges();

            }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            catModel = new CatModel
            {
                Id=catDb.Id,
                Name = catDb.Name,
                Age = catDb.Age,
                Weight = catDb.Weight,
                Gender = catDb.Gender,
                PrimaryColor = catDb.PrimaryColor,
                SecondaryColor = catDb.SecondaryColor,
                Breed = catDb.Breed,
                Friendly = catDb.Friendly,
                EarTipped = catDb.EarTipped,
                DeClawed = catDb.DeClawed,
                MicroChipped = catDb.MicroChipped,
                SpayedNeutered = catDb.SpayedNeutered,
                Vaccinated = catDb.Vaccinated,
                Comments = catDb.Comments,
                Photo = catDb.Photo,
                ColonyBorough = catDb.ColonyBorough,
                ColonyNeighborhood = catDb.ColonyNeighborhood,
                ColonyCaretakerName = catDb.ColonyCaretakerName,
                ColonyCaretakerPhone = catDb.ColonyCaretakerPhone
            };
            return catModel;
        }

        public List<CatModel> GetAll()
        {
            // Use .Select() to map the database contacts to CatModel
            var items = DatabaseManager.Instance.Cats
              .Select(t => new CatModel
              {
                  Id = t.Id,
                  Name = t.Name,
                  Age = t.Age,
                  Weight = t.Weight,
                  Gender = t.Gender,
                  PrimaryColor = t.PrimaryColor,
                  SecondaryColor = t.SecondaryColor,
                  Breed = t.Breed,
                  Friendly = t.Friendly,
                  EarTipped = t.EarTipped,
                  DeClawed = t.DeClawed,
                  MicroChipped = t.MicroChipped,
                  SpayedNeutered = t.SpayedNeutered,
                  Vaccinated = t.Vaccinated,
                  Comments = t.Comments,
                  Photo = t.Photo,
                  ColonyBorough = t.ColonyBorough,
                  ColonyNeighborhood = t.ColonyNeighborhood,
                  ColonyCaretakerName = t.ColonyCaretakerName,
                  ColonyCaretakerPhone = t.ColonyCaretakerPhone
              }).ToList();

            return items;
        }

        public bool Update(CatModel catModel)
        {
            var original = DatabaseManager.Instance.Cats.Find(catModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(catModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int catId)
        {
            var items = DatabaseManager.Instance.Cats
                                .Where(t => t.Id == catId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Cats.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Cat ToDbModel(CatModel catModel)
        {
            var catDb = new Cat
            {
                Id = catModel.Id,
                Name = catModel.Name,
                Age = catModel.Age,
                Weight = catModel.Weight,
                Gender = catModel.Gender,
                PrimaryColor = catModel.PrimaryColor,
                SecondaryColor = catModel.SecondaryColor,
                Breed = catModel.Breed,
                Friendly = catModel.Friendly,
                EarTipped = catModel.EarTipped,
                DeClawed = catModel.DeClawed,
                MicroChipped = catModel.MicroChipped,
                SpayedNeutered = catModel.SpayedNeutered,
                Vaccinated = catModel.Vaccinated,
                Comments = catModel.Comments,
                Photo = catModel.Photo,
                ColonyBorough = catModel.ColonyBorough,
                ColonyNeighborhood = catModel.ColonyNeighborhood,
                ColonyCaretakerName = catModel.ColonyCaretakerName,
                ColonyCaretakerPhone = catModel.ColonyCaretakerPhone
            };

            return catDb;
        }
    }
}
