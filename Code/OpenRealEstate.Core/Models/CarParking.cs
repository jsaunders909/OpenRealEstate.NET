﻿using System.Diagnostics;
using OpenRealEstate.Core.Primitives;

namespace OpenRealEstate.Core.Models
{
    public class CarParking : BaseModifiedData
    {
        private const string CarportsName = "Carports";
        private const string GaragesName = "Garages";
        private const string OpenSpacesName = "OpenSpaces";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Int32Notified _carports;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Int32Notified _garages;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Int32Notified _openspaces;

        public CarParking()
        {
            _carports = new Int32Notified(CarportsName);
            _carports.PropertyChanged += ModifiedData.OnPropertyChanged;

            _garages = new Int32Notified(GaragesName);
            _garages.PropertyChanged += ModifiedData.OnPropertyChanged;

            _openspaces = new Int32Notified(OpenSpacesName);
            _openspaces.PropertyChanged += ModifiedData.OnPropertyChanged;
        }

        public int Garages
        {
            get { return _garages.Value; }
            set { _garages.Value = value; }
        }

        public int Carports
        {
            get { return _carports.Value; }
            set { _carports.Value = value; }
        }

        public int OpenSpaces
        {
            get { return _openspaces.Value; }
            set { _openspaces.Value = value; }
        }

        public int TotalCount
        {
            get { return Garages + Carports + OpenSpaces; }
        }

        public void Copy(CarParking newCarParking,
            CopyDataOptions copyDataOptions = CopyDataOptions.OnlyCopyModifiedProperties)
        {
            ModifiedData.Copy(newCarParking, this, copyDataOptions);
        }

        public override string ToString()
        {
            return string.Format("C:{0} G:{1} O:{2} / T:{3}",
                Carports,
                Garages,
                OpenSpaces,
                TotalCount);
        }
    }
}