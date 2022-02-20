using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using WpfApp7.Infrastructure;
using WpfApp7.Model;
using WpfApp7.View;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace WpfApp7.ViewModel
{
   public class MainViewModel:Property_Changed
    {
        private Product  _selected;

        public Product Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));

            }
        }
        public string NewName { get; set; }
        public string NewImage { get; set; }
        public string NewCod { get; set; }
        public double NewPrice { get; set; }
        
           private ObservableCollection<Product> catalog { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DellCommand { get; set; }
        public ICommand SortCommand { get; set; }
        public ICommand UpDataCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICollectionView List { get; set; }
        private bool CanAdd(object parametr)
        {
            return true;
        }
        private void Add(object parametr)
        {
            if (Selected != null)
                catalog.Add(new Product(Selected.Name, Selected.Image,Selected.Cod,Selected.Price));
            else
            {
                Product newProdukt = new Product(NewName, NewImage, NewCod, NewPrice);
                catalog.Add(newProdukt);

            }
        }
        private bool CanUpdata(object parametr)
        {
            return true;
        }
        private void Update(object parametr)
        {

            List?.Refresh();
        }
        private bool CanDell(object parametr)
        {
            return true;
        }
        private void Dell(object parametr)
        {
            if (catalog != null)
                catalog.Remove(Selected);

        }
        private bool CanSort(object parametr)
        {
            return true;
        }
        private void Sort(object parametr)
        {
            string param = parametr.ToString();
            List.SortDescriptions.Clear();
            List.SortDescriptions.Add(new SortDescription(param, ListSortDirection.Ascending));
        }
        private bool CanSave(object parametr)
        {
            return true;
        }
        public void Save(object parametr)
        {
            try
            {
                string path = "C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/text.txt";
                List<string> str = new List<string>();
                foreach (var ex in catalog)
                    str.Add(JsonConvert.SerializeObject(ex));

                File.WriteAllLines(path, str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool CanLoad(object parametr)
        {
            return true;
        }
        public void Load(object parametr)
        {
            try
            {
                string[] str = File.ReadAllLines("C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/text.txt");
                foreach (var ex in str)
                {

                    catalog.Add(JsonConvert.DeserializeObject<Product>(ex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public MainViewModel()
        {

            AddCommand = new RelayCommand(Add, CanAdd);
            DellCommand = new RelayCommand(Dell, CanDell);
            SortCommand = new RelayCommand(Sort, CanSort);
            UpDataCommand = new RelayCommand(Update, CanUpdata);
            SaveCommand = new RelayCommand(Save, CanSave);
            LoadCommand = new RelayCommand(Load, CanLoad);
            catalog = new ObservableCollection<Product>
            {
                new Product("Bowls", "C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/Goods_image/bowl.jpg", "Cds-23648",56.20),
                new Product ("Carrier", "C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/Goods_image/carry.jpg","Amh-93785",278.90),
                new Product("Collars","C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/Goods_image/collars.jpg","Dbg-758",45.70),
                new Product("Feeder","C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/Goods_image/feeder.jpg","Bgd-7585",256.80),
                new Product(" Humster Cage","C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/Goods_image/hamster_cage.jpg","Vvj-85485",153.60),
                new Product("Animal feed","C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/Goods_image/meal.jpg","Sfh-7586",120.00),
                new Product("Toys","C:/Users/Санчос/source/repos/WpfApp7/WpfApp7/Goods_image/toys.jpg","Tgfb-758",50.00)

            };
            List = CollectionViewSource.GetDefaultView(catalog);
        }
    }
}
