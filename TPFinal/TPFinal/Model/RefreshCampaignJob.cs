﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TPFinal.Model;
using TPFinal.DAL;

namespace TPFinal.Model
{
    class RefreshCampaignJob : IJob
    {
        public void Execute (IJobExecutionContext context)
        {
            /*

            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0, 0, 0, 0, 30)); //(int)service.iRefreshTimer.Interval

            service.iActualCampaign = 0;
            service.iActualImage = 0;
            service.iCampaignList = iUnitOfWork.campaignRepository.GetActives(date, timeFrom, timeTo).ToList();

            //service.iIntervalTimer.Interval = service.iCampaignList.ElementAt(iActualCampaign).interval * 1000;

            service.NotifyListeners();*/
        }
    }
}