using CommunityToolkit.Mvvm.ComponentModel;
using Project1.mvvm.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.mvvm.viewmodels
{
    public class DetailedRollViewModel : ObservableObject
    {
        public DetailedRollViewModel(Roll roll)
        {
            _id = roll.Id;
            _name = roll.Name;
            _imagePath = roll.ImagePath;
            _traits = roll.Traits;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set => SetProperty(ref _id, value);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set => SetProperty(ref _name, value);
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set => SetProperty(ref _imagePath, value);
        }

        private Traits _traits;
        public Traits Traits
        {
            get { return _traits; }
            set => SetProperty(ref _traits, value);
        }
    }
}
