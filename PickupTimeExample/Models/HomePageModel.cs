namespace PickupTimeExample.Models
{
    public class HomePageModel
    {
        //OTHER STUFF GOES HERE

        public PickupTimeModel pickupTimeModel { get; set; }
        public HomePageModel() { }
        public HomePageModel(PickupTimeModel pickup) { pickupTimeModel = pickup; }
    }
}
