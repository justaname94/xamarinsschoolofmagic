using practice_4.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace practice_4.Services
{
    [Headers("Authorization: Token f3d9ff8dbe3b119dd10c2d1c467f4c9d4da4cad7")]
    interface IPRMApi
    {
        [Get("/activities/")]
        Task<ObservableCollection<Activity>> GetActivities();
    }
}
