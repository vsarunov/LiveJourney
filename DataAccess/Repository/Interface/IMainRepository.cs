﻿namespace DataAccess.Repository
{
    using Infrastructure.Entities;
    using System.Collections.Generic;

    public interface IMainRepository
    {
        UserModel GetUser(string username);
        long InsertTrainline(TrainLine trainLine);
        long InsertStation(Station station);
        void UpdateTrainLine(TrainLine trainLine);
        void UpdateStation(Station station);
        IEnumerable<TrainLine> ReadTrainLines();
        IEnumerable<Station> ReadStations();
        void DeleteTrainLine(TrainLine trainLine);
        void DeleteStation(Station station);
    }
}
