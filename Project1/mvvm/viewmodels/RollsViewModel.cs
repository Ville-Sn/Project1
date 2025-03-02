using CommunityToolkit.Mvvm.ComponentModel;
using Project1.mvvm.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.mvvm.viewmodels
{
    public class RollsViewModel : ObservableObject
    {
        public RollsViewModel()
        {
            Rolls = [];
        }

		private DetailedRollViewModel? _selectedRoll;
		public DetailedRollViewModel? SelectedRoll
		{
			get { return _selectedRoll; }
			set => SetProperty(ref _selectedRoll, value);
        }

        public ObservableCollection<DetailedRollViewModel> Rolls { get; set; }

        public async Task RefreshRolls()
        {

            IEnumerable<Roll> rollsData = await RollRepository.GetRolls();

            foreach (models.Roll roll in rollsData)
            {
                Rolls.Add(new DetailedRollViewModel(roll));
            }
        }

        public void DeleteRoll(DetailedRollViewModel roll)
        {
            Rolls.Remove(roll);
        }

        public void AddRoll(Roll roll)
        {
            Rolls.Add(new DetailedRollViewModel(roll));
        }

        public async Task SaveRolls()
        {
            await RollRepository.SaveRolls(Rolls);
        }
    }
}
