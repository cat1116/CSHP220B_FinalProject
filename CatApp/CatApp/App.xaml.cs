using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static CatRepository.CatRepository catRepository;

        static App()
        {
            catRepository = new CatRepository.CatRepository();
        }

        public static CatRepository.CatRepository CatRepository
        {
            get
            {
                return catRepository;
            }
        }
    }
}
