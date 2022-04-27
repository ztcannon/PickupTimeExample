using Microsoft.AspNetCore.Mvc.Rendering;

namespace PickupTimeExample.Models
{
    public class PickupTimeModel
    {
        public List<PickupTime> PickupTimes { get; set; }

        public List<SelectListItem> SelectPickupTimes { get; set; }
        public DateTime SelectedDate { get; set; }

        public PickupTimeModel(List<DateTime> UnavailableTimes, DateTime Selected)
        {
            SelectedDate = Selected;
            List<PickupTime> pickups = new List<PickupTime>();

            for (int i = 6; i < 20; i++)
                pickups.Add(new PickupTime() { IsAvailable = true, PickupDateTime = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, i, 0, 0) });

            //Iterate through the pickups list and set isAvailable to false for any time that is present in the DB already
            foreach (PickupTime i in pickups)
                if (UnavailableTimes.Contains(i.PickupDateTime))
                    i.IsAvailable = false;

            PickupTimes = pickups;

            SelectPickupTimes = new List<SelectListItem>();
            foreach (PickupTime i in PickupTimes)
            {
                if (i.IsAvailable)
                {
                    SelectPickupTimes.Add(new SelectListItem { Text = i.PickupDateTime.TimeOfDay.ToString(), Value = i.PickupDateTime.ToString() });
                }
            }
        }

    }
}
