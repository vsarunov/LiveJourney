using Dapper;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace DataAccess.Repository
{

    public class MainRepository : IMainRepository
    {
        private readonly string DatabasePath = @"DataSource=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/LiveJourney.db;foreign keys=true;";

        public MainRepository()
        {
            this.CreateDatabase();
        }

        private void CreateDatabase()
        {
            this.CreateUserTable();
            this.InsertAdminUser();
            this.CreateTrainLineTable();
            this.CreateStationTable();
            this.CreateDelayTable();
            this.CreateConfigTable();
        }

        private static string CREATE_USER_TABLE =
            @"
                CREATE TABLE IF NOT EXISTS [UserTable] 
           (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
           Username TEXT NOT NULL,
            Password TEXT NOT NULL,
            AdminType INTEGER);
            ";

        private static string CREATE_TRAIN_LINE_TABLE =
            @"
               CREATE TABLE IF NOT EXISTS [TrainLines]
                (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                TrainLineName TEXT NOT NULL,
                TrainLineColour TEXT NOT NULL,
                TrainTravelSpeed INTEGER NOT NULL,
                TrainDepartureDelay INTEGER NOT NULL);  
            ";

        private static string CREATE_STATION_TABLE =
            @"
                CREATE TABLE IF NOT EXISTS [Stations]
                (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                StationName TEXT NOT NULL,
                TrainLineId INTEGER NOT NULL,
                NextStationId INTEGER,
                PreviousStationId INTEGER,
                DistanceToPreviousStation INTEGER,
                FOREIGN KEY(TrainLineId) REFERENCES TrainLines(Id)); 
            ";

        private static string CREATE_DELAY_TABLE =
            @"
               CREATE TABLE IF NOT EXISTS [DelayTable]
                (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DelayTime INTEGER NOT NULL,
                TrainLineId INTEGER NOT NULL,
                StartDelayStationId INTEGER NOT NULL,
                EndDelayStationId INTEGER NOT NULL,
                TimeStamp INTEGER NOT NULL,
                FOREIGN KEY(TrainLineId) REFERENCES TrainLines(Id),
                FOREIGN KEY(StartDelayStationId) REFERENCES Stations(Id),
                FOREIGN KEY(EndDelayStationId) REFERENCES Stations(Id));
            ";

        private static string CREATE_CONFIG_TABLE =
            @"
            CREATE TABLE IF NOT EXISTS [Configurations]
            (Id INTEGER PRIMARY KEY AUTOINCREMENT,
             MockDataAdded INTEGER NOT NULL);
            ";

        private static string INSERT_CONFIG =
            @"
              INSERT INTO Configurations (MockDataAdded) VALUES (@MockDataAdded);
            ";

        private static string INSERT_TRAIN_LINE =
            @"
              INSERT INTO TrainLines (TrainLineName,TrainLineColour,TrainTravelSpeed,TrainDepartureDelay) VALUES (@TrainLineName,@TrainLineColour,@TrainTravelSpeed,@TrainDepartureDelay);
            ";

        private static string INSERT_STATION =
            @"
              INSERT INTO Stations (StationName,TrainLineId,NextStationId,PreviousStationId,DistanceToPreviousStation) VALUES (@StationName,@TrainLineId,@NextStationId,@PreviousStationId,@DistanceToPreviousStation);
            ";

        private static string INSERT_DELAY =
            @"
             INSERT INTO DelayTable (DelayTime,TrainLineId,StartDelayStationId,EndDelayStationId,TimeStamp) VALUES (@DelayTime,@TrainLineId,@StartDelayStationId,@EndDelayStationId,@TimeStamp);
            ";

        private static string UPDATE_TRAIN_LINE =
            @"
               UPDATE TrainLines SET TrainLineName = @TrainLineName, TrainLineColour = @TrainLineColour,TrainTravelSpeed = @TrainTravelSpeed,TrainDepartureDelay = @TrainDepartureDelay WHERE Id = @id;
            ";

        private static string UPDATE_STATION =
            @"
               UPDATE Stations SET StationName = @StationName, TrainLineId = @TrainLineId, NextStationId = @NextStationId, PreviousStationId = @PreviousStationId, DistanceToPreviousStation = @DistanceToPreviousStation WHERE Id = @Id;
            ";

        private static string UPDATE_DELAY =
            @"
               UPDATE DelayTable SET DelayTime = @DelayTime, TrainLineId = @TrainLineId, StartDelayStationId = @StartDelayStationId, EndDelayStationId = @EndDelayStationId, TimeStamp = @TimeStamp WHERE Id = @Id;
            ";

        private static string READ_CONFIG =
            @"
                SELECT MockDataAdded FROM Configurations;
            ";

        private static string READ_TRAIN_LINES =
            @"
                SELECT * FROM TrainLines;
            ";

        private static string READ_STATIONS =
            @"
                SELECT * FROM Stations;
            ";

        private static string READ_DELAYS =
            @"
                SELECT * FROM DelayTable;
            ";

        private static string DELETE_TRAIN_LINE =
            @"
               DELETE FROM TrainLines WHERE Id = @Id;
            ";

        private static string DELETE_STATION =
            @"
               DELETE FROM Stations WHERE Id = @Id
            ";

        private static string DELETE_DELAY =
            @"
               DELETE FROM DelayTable WHERE Id = @Id
            ";

        private static string SELECT_STATION_BY_ID = @"SELECT * FROM Stations WHERE Id = @Id;";

        private static string INSERT_ADMIN_USER = @"INSERT INTO UserTable (Username,Password,AdminType) VALUES(@Username,@Password,@AdminType);";

        private static string GET_USER = @"SELECT * FROM UserTable WHERE Username = :Username;";

        private void CreateConfigTable()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(CREATE_CONFIG_TABLE, sqliteConnection))
                    {
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateUserTable()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(CREATE_USER_TABLE, sqliteConnection))
                    {
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateTrainLineTable()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(CREATE_TRAIN_LINE_TABLE, sqliteConnection))
                    {
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateStationTable()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(CREATE_STATION_TABLE, sqliteConnection))
                    {
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateDelayTable()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(CREATE_DELAY_TABLE, sqliteConnection))
                    {
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void InsertAdminUser()
        {
            if (this.GetUser("Admin") != null)
            {
                return;
            }

            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(INSERT_ADMIN_USER, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@Username", "Admin");
                        mCmd.Parameters.AddWithValue("@Password", "admin");
                        mCmd.Parameters.AddWithValue("@AdminType", 1);
                        mCmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public UserModel GetUser(string username)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    return sqliteConnection.Query<UserModel>(GET_USER, new
                    {
                        Username = username
                    }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return new UserModel();
            }
        }

        public long InsertTrainline(TrainLine trainLine)
        {
            long lastInsertedId = -1;
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(INSERT_TRAIN_LINE, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@TrainLineName", trainLine.TrainLineName);
                        mCmd.Parameters.AddWithValue("@TrainLineColour", trainLine.TrainLineColour);
                        mCmd.Parameters.AddWithValue("@TrainTravelSpeed", trainLine.TrainTravelSpeed);
                        mCmd.Parameters.AddWithValue("@TrainDepartureDelay", trainLine.TrainDepartureDelay);
                        mCmd.ExecuteNonQuery();
                        lastInsertedId = sqliteConnection.LastInsertRowId;
                    }
                }
                return lastInsertedId;
            }
            catch (Exception e)
            {
                return lastInsertedId;
            }
        }

        public void InsertConfig()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(INSERT_CONFIG, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@MockDataAdded", 1);
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long InsertStation(Station station)
        {
            long lastInsertedId = -1;
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(INSERT_STATION, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@StationName", station.StationName);
                        mCmd.Parameters.AddWithValue("@TrainLineId", station.TrainLineId);
                        mCmd.Parameters.AddWithValue("@NextStationId", station.NextStationId);
                        mCmd.Parameters.AddWithValue("@PreviousStationId", station.PreviousStationId);
                        mCmd.Parameters.AddWithValue("@DistanceToPreviousStation", station.DistanceToPreviousStation);
                        mCmd.ExecuteNonQuery();
                        lastInsertedId = sqliteConnection.LastInsertRowId;
                    }
                }
                return lastInsertedId;
            }
            catch (Exception e)
            {
                return lastInsertedId;
            }
        }

        public long InsertDelay(DelayModel delay)
        {
            long lastInsertedId = -1;
            try
            {

                //@DelayTime,@TrainLineId,@StartDelayStationId,@EndDelayStationId,@TimeStamp
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(INSERT_DELAY, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@DelayTime", delay.DelayTime);
                        mCmd.Parameters.AddWithValue("@TrainLineId", delay.TrainLineId);
                        mCmd.Parameters.AddWithValue("@StartDelayStationId", delay.StartDelayStationId);
                        mCmd.Parameters.AddWithValue("@EndDelayStationId", delay.EndDelayStationId);
                        mCmd.Parameters.AddWithValue("@TimeStamp", delay.TimeStamp);
                        mCmd.ExecuteNonQuery();
                        lastInsertedId = sqliteConnection.LastInsertRowId;
                    }
                }
                return lastInsertedId;
            }
            catch (Exception e)
            {
                return lastInsertedId;
            }
        }

        public void UpdateTrainLine(TrainLine trainLine)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(UPDATE_TRAIN_LINE, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@TrainLineName", trainLine.TrainLineName);
                        mCmd.Parameters.AddWithValue("@TrainLineColour", trainLine.TrainLineColour);
                        mCmd.Parameters.AddWithValue("@TrainTravelSpeed", trainLine.TrainTravelSpeed);
                        mCmd.Parameters.AddWithValue("@TrainDepartureDelay", trainLine.TrainDepartureDelay);
                        mCmd.Parameters.AddWithValue("@Id", trainLine.Id);
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateStation(Station station)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(UPDATE_STATION, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@StationName", station.StationName);
                        mCmd.Parameters.AddWithValue("@TrainLineId", station.TrainLineId);
                        mCmd.Parameters.AddWithValue("@NextStationId", station.NextStationId);
                        mCmd.Parameters.AddWithValue("@PreviousStationId", station.PreviousStationId);
                        mCmd.Parameters.AddWithValue("@DistanceToPreviousStation", station.DistanceToPreviousStation);
                        mCmd.Parameters.AddWithValue("@Id", station.Id);
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateDelay(DelayModel delay)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(UPDATE_DELAY, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@DelayTime", delay.DelayTime);
                        mCmd.Parameters.AddWithValue("@TrainLineId", delay.TrainLineId);
                        mCmd.Parameters.AddWithValue("@StartDelayStationId", delay.StartDelayStationId);
                        mCmd.Parameters.AddWithValue("@EndDelayStationId", delay.EndDelayStationId);
                        mCmd.Parameters.AddWithValue("@TimeStamp", delay.TimeStamp);
                        mCmd.Parameters.AddWithValue("@Id", delay.Id);
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long ReadConfig()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    return sqliteConnection.Query<long>(READ_CONFIG).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public IEnumerable<TrainLine> ReadTrainLines()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    return sqliteConnection.Query<TrainLine>(READ_TRAIN_LINES);
                }
            }
            catch (Exception e)
            {
                return Enumerable.Empty<TrainLine>();
            }
        }

        public IEnumerable<Station> ReadStations()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    return sqliteConnection.Query<Station>(READ_STATIONS);
                }
            }
            catch (Exception e)
            {
                return Enumerable.Empty<Station>();
            }
        }

        public Station ReadStationsById(long id)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    return sqliteConnection.Query<Station>(SELECT_STATION_BY_ID, new
                    {
                        Id = id
                    }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<DelayModel> ReadDelay()
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    return sqliteConnection.Query<DelayModel>(READ_DELAYS);
                }
            }
            catch (Exception e)
            {
                return Enumerable.Empty<DelayModel>();
            }
        }

        public void DeleteTrainLine(TrainLine trainLine)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(DELETE_TRAIN_LINE, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@Id", trainLine.Id);
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteStation(Station station)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(DELETE_STATION, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@Id", station.Id);
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteDelay(DelayModel delay)
        {
            try
            {
                using (var sqliteConnection = new SQLiteConnection(this.DatabasePath))
                {
                    sqliteConnection.Open();
                    using (SQLiteCommand mCmd = new SQLiteCommand(DELETE_DELAY, sqliteConnection))
                    {
                        mCmd.Parameters.AddWithValue("@Id", delay.Id);
                        mCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
