using ProjObiektowe.Models;
using ProjObiektowe.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ProjObiektowe.ViewModels
{
    class RecipeViewModel: ObservableObject
    {

        /// <summary>
        /// list of recipes
        /// </summary>
        public ObservableCollection<RecipeModel> recipes { get; set; } = new ObservableCollection<RecipeModel>();

        /// <summary>
        /// command to show/refresh recipe list
        /// </summary>
        public ICommand ShowRecipesCommand { get; }


        /// <summary>
        /// Text from search bar
        /// </summary>
        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public RecipeViewModel()
        {
            ShowRecipesCommand = new ShowAllRecipesCommand(this);
            ShowRecipesCommand.Execute(this);
            CollectionViewSource.GetDefaultView(this.recipes).Refresh();
        }
    }
}
