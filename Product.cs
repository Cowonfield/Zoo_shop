using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp7.Infrastructure;

namespace WpfApp7.Model
{
  public class Product : Property_Changed
    {
        private string _name;
        private string _image;
        private string _cod;
        private double _price;
       
        public string Name
        {
            get => _name;
            set
            {
                _name = value;

                OnPropertyChanged(nameof(Name));
            }
        }
        public string Cod
        {
            get => _cod;
            set
            {
                _cod= value;
                OnPropertyChanged(nameof(Cod));
            }
        }
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof( Price));
            }
        }
      
        public Product (string name, string image,string cod,double price)
        {
            _name =name;
            _image= image;
            _cod = cod;
            _price = price;
            
        }
        public Product()
        {
            _name = string.Empty;
            _image = string.Empty;
            _cod = string.Empty;
            _price = 0;
           
        }
        public override string ToString()
        {
            return $"{Name}\t{Image}\t{Cod}\t{Price}";
        }
    }
}
