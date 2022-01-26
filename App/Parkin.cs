using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Parkin : IEnumerable<Car>
    {

        private List<Car> _cars = new List<Car>();
        private const int MAX_CARS = 100;
        public string Name { get; set; }
        public int count => _cars.Count;
        public Car this[string Number]
        {
            get
            {
                var car = _cars.FirstOrDefault(c => c.Number == Number);
                return car;
            }
        }
        public Car this[int position]
        {
            get
            {
                if (position < _cars.Count)
                {
                    return _cars[position];
                }
                return null;
            }
            set
            {
                if (position < _cars.Count)
                {
                    _cars[position] = value;
                }
            }
        }
        public int AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car is null");
            }
            if (count < MAX_CARS)
            {
                _cars.Add(car);
                return _cars.Count - 1;
            }
            return -1;
        }
        public void RemoveCar(string Number)
        {
            if (string.IsNullOrWhiteSpace(Number))
            {
                throw new ArgumentNullException(nameof(Number), "Number is Null");
            }
            var car = _cars.FirstOrDefault(c => c.Number == Number);
            if (car != null)
            {   
                _cars.Remove(car);
            }
        }
        public IEnumerator<Car> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cars.GetEnumerator();
        }
    }
    public class ParkingEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
