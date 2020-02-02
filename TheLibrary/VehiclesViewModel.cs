using System.Collections.ObjectModel;

namespace TheLibrary
{
    public class VehiclesViewModel
    {
        private IVehicles _vehicles;

        public VehiclesViewModel(IVehicles vehicles)
        {
            _vehicles = vehicles;
            VehicleRows = new ObservableCollection<VehicleRowViewModel>();
            _vehicles.ListVehicles("secret", callback);
        }

        private void callback(object sender, MyAsyncCompletedEventArgs e)
        {
            if (e.Result is Vehicle[] vehicles)
            {
                foreach (var vehicle in vehicles)
                {
                    VehicleRows.Add(new VehicleRowViewModel {Name = vehicle.Name});
                }
            }
        }
        public ObservableCollection<VehicleRowViewModel> VehicleRows { get; set; }
    }

    public class VehicleRowViewModel
    {
        public string Name { get; set; }
    }

    public class Vehicle
    {
        public string Name { get; set; }
    }
}