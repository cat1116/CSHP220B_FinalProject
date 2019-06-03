using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CatApp.Models
{
    public class CatModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name = string.Empty;
        private string nameError;

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private int age =-1;
        //private int age;

        private string ageError;

        public string AgeError
        {
            get
            {
                return ageError;
            }
            set
            {
                if (ageError != value)
                {
                    ageError = value;
                    OnPropertyChanged("AgeError");
                }
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        public int? Weight { get; set; }

        private string gender= string.Empty;
        private string genderError;
        public string GenderError
        {
            get
            {
                return genderError;
            }
            set
            {
                if (genderError != value)
                {
                    genderError = value;
                    OnPropertyChanged("GenderError");
                }
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (gender != value)
                {
                    gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        private string primaryColor = string.Empty;
        private string primaryColorError;

        public string PrimaryColorError
        {
            get
            {
                return primaryColorError;
            }
            set
            {
                if (primaryColorError != value)
                {
                    primaryColorError = value;
                    OnPropertyChanged("PrimaryColorError");
                }
            }
        }

        public string PrimaryColor
        {
            get
            {
                return primaryColor;
            }
            set
            {
                if (primaryColor != value)
                {
                    primaryColor = value;
                    OnPropertyChanged("PrimaryColor");
                }
            }
        }

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

        private string colonyBorough = string.Empty;
        private string colonyBoroughError;

        public string ColonyBoroughError
        {
            get
            {
                return colonyBoroughError;
            }
            set
            {
                if (colonyBoroughError != value)
                {
                    colonyBoroughError = value;
                    OnPropertyChanged("ColonyBoroughError");
                }
            }
        }

        public string ColonyBorough 
        {
            get
            {
                return colonyBorough;
            }
            set
            {
                if (colonyBorough != value)
                {
                    colonyBorough = value;
                    OnPropertyChanged("ColonyBorough");
                }
            }
        }

        private string colonyNeighborhood = string.Empty;
        private string colonyNeighborhoodError;

        public string ColonyNeighborhoodError
        {
            get
            {
                return colonyNeighborhoodError;
            }
            set
            {
                if (colonyNeighborhoodError != value)
                {
                    colonyNeighborhoodError = value;
                    OnPropertyChanged("ColonyNeighborhoodError");
                }
            }
        }

        public string ColonyNeighborhood
        {
            get
            {
                return colonyNeighborhood;
            }
            set
            {
                if (colonyNeighborhood != value)
                {
                    colonyNeighborhood = value;
                    OnPropertyChanged("ColonyNeighborhood");
                }
            }
        }

       private string colonyCaretakerName = string.Empty;
        private string colonyCaretakerNameError;

        public string ColonyCaretakerNameError
        {
            get
            {
                return colonyCaretakerNameError;
            }
            set
            {
                if (colonyCaretakerNameError != value)
                {
                    colonyCaretakerNameError = value;
                    OnPropertyChanged("ColonyCaretakerNameError");
                }
            }
        }

        public string ColonyCaretakerName
        {
            get
            {
                return colonyCaretakerName;
            }
            set
            {
                if (colonyCaretakerName != value)
                {
                    colonyCaretakerName = value;
                    OnPropertyChanged("ColonyCaretakerName");
                }
            }
        }

        private string colonyCaretakerPhone = string.Empty;
        private string colonyCaretakerPhoneError;

        public string ColonyCaretakerPhoneError
        {
            get
            {
                return colonyCaretakerPhoneError;
            }
            set
            {
                if (colonyCaretakerPhoneError != value)
                {
                    colonyCaretakerPhoneError = value;
                    OnPropertyChanged("ColonyCaretakerPhoneError");
                }
            }
        }

        public string ColonyCaretakerPhone
        {
            get
            {
                return colonyCaretakerPhone;
            }
            set
            {
                if (colonyCaretakerPhone != value)
                {
                    colonyCaretakerPhone = value;
                    OnPropertyChanged("ColonyCaretakerPhone");
                }
            }
        }




        public CatRepository.CatModel ToRepositoryModel()
        {
            var repositoryModel = new CatRepository.CatModel
            {
                Id= Id,
                Name = Name,
                Age = Age,
                Weight = Weight,
                Gender = Gender,
                PrimaryColor = PrimaryColor,
                SecondaryColor = SecondaryColor,
                Breed = Breed,
                Friendly = Friendly,
                EarTipped = EarTipped,
                DeClawed = DeClawed,
                MicroChipped = MicroChipped,
                SpayedNeutered = SpayedNeutered,
                Vaccinated = Vaccinated,
                Comments = Comments,
                Photo = Photo,
                ColonyBorough = ColonyBorough,
                ColonyNeighborhood = ColonyNeighborhood,
                ColonyCaretakerName = ColonyCaretakerName,
                ColonyCaretakerPhone = ColonyCaretakerPhone
            };

            return repositoryModel;
        }

        public static CatModel ToModel(CatRepository.CatModel respositoryModel)
        {
            var catModel = new CatModel
            {
                Id = respositoryModel.Id,
                Name = respositoryModel.Name,
                Age = respositoryModel.Age,
                Weight = respositoryModel.Weight,
                Gender = respositoryModel.Gender,
                PrimaryColor = respositoryModel.PrimaryColor,
                SecondaryColor = respositoryModel.SecondaryColor,
                Breed = respositoryModel.Breed,
                Friendly = respositoryModel.Friendly,
                EarTipped = respositoryModel.EarTipped,
                DeClawed = respositoryModel.DeClawed,
                MicroChipped = respositoryModel.MicroChipped,
                SpayedNeutered = respositoryModel.SpayedNeutered,
                Vaccinated = respositoryModel.Vaccinated,
                Comments = respositoryModel.Comments,
                Photo = respositoryModel.Photo,
                ColonyBorough = respositoryModel.ColonyBorough,
                ColonyNeighborhood = respositoryModel.ColonyNeighborhood,
                ColonyCaretakerName = respositoryModel.ColonyCaretakerName,
                ColonyCaretakerPhone = respositoryModel.ColonyCaretakerPhone
            };

            return catModel;
        }

        internal CatModel Clone()
        {
            return (CatModel)this.MemberwiseClone();
        }
        

        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return NameError + ", " + AgeError + ", " + GenderError + ", " + PrimaryColorError + ", " + ColonyBoroughError + ", " + 
                    ColonyNeighborhoodError + ", " + ColonyCaretakerNameError + ", " + ColonyCaretakerPhoneError;
            }
        }

        private static readonly Regex _validRegex = new Regex(@"^\d{1-2}$"); //regex for 1 or 2 digits.
        string AllErrors = "";


        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnName]
        {
            get
            {
                //NameError = "";
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";
                            if (string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty. ";
                                
                            }


                            if(NameError != null)
                            {
                                AllErrors = AllErrors + NameError;

                            }
                            break;
                        }
                    case "Age":
                        {
                            string tempAgeError = "";
                            AgeError = "";

                            if (Age<0)
                            {
                                tempAgeError = "Age cannot be negative. ";
                            }

                            bool validAge = !(_validRegex.IsMatch(Age.ToString()));
                            if (!validAge)
                            {
                                tempAgeError += "Age must be 1 or 2 digits.";
                            }

                            if(tempAgeError != "")
                            {
                                AgeError = tempAgeError;
                            }

                            if (AgeError != null)
                            {
                                AllErrors = AllErrors + AgeError;

                            }
                            break;
                        }
                    case "Gender":
                        {
                            GenderError = "";

                            if (string.IsNullOrEmpty(Gender))
                            {
                                GenderError = "Gender cannot be empty. ";
                            }

                            if (GenderError != null)
                            {
                                AllErrors = AllErrors + GenderError;

                            }
                            break;
                        }
                    case "PrimaryColor":
                        {
                            PrimaryColorError = "";

                            if (string.IsNullOrEmpty(PrimaryColor))
                            {
                                PrimaryColorError = "Primary Color cannot be empty. ";
                            }

                            if (PrimaryColorError != null)
                            {
                                AllErrors = AllErrors + PrimaryColorError;

                            }
                            break;
                        }
                    case "ColonyBorough":
                        {
                            ColonyBoroughError = "";

                            if (string.IsNullOrEmpty(ColonyBorough))
                            {
                                ColonyBoroughError = "Colony Borough cannot be empty. ";
                            }

                            if (ColonyBoroughError != null)
                            {
                                AllErrors = AllErrors + ColonyBoroughError;

                            }
                            break;
                        }
                    case "ColonyNeighborhood":
                        {
                            ColonyNeighborhoodError = "";

                            if (string.IsNullOrEmpty(ColonyNeighborhood))
                            {
                                ColonyNeighborhoodError = "Colony Neighborhood cannot be empty. ";
                            }

                            if (ColonyNeighborhoodError != null)
                            {
                                AllErrors = AllErrors + ColonyNeighborhoodError;

                            }
                            break;
                        }
                    case "ColonyCaretakerName":
                        {
                            ColonyCaretakerNameError = "";

                            if (string.IsNullOrEmpty(ColonyCaretakerName))
                            {
                                ColonyCaretakerNameError = "Colony Caretaker Name cannot be empty. ";
                            }

                            if (ColonyCaretakerNameError != null)
                            {
                                AllErrors = AllErrors + ColonyCaretakerNameError;

                            }
                            break;
                        }
                    case "ColonyCaretakerPhone":
                        {
                            ColonyCaretakerPhoneError = "";

                            if (string.IsNullOrEmpty(ColonyCaretakerPhone))
                            {
                                ColonyCaretakerPhoneError = "Colony Caretaker Phone cannot be empty. ";
                            }

                            if (ColonyCaretakerPhoneError != null)
                            {
                                AllErrors = AllErrors + ColonyCaretakerPhoneError;

                            }
                            break;
                        }


                }

                return AllErrors;
            }
        }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
