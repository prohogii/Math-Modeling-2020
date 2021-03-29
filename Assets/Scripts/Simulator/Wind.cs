﻿using System;
using UnityEngine;

//using System.Numerics;

namespace AircraftSimulator {
    public class Wind : VectorQuantity {
        private readonly Model _model;

        public Wind(Model model) : base(model) {
            _model = model;
        }

        public override Vector3 Value(Vector3 position, float time) {
            if (_model is ConstantWindModel constantWindModel) return constantWindModel.Value;
            if (_model is TurbulentWindModel turbulentWindModel) return turbulentWindModel.Value(position, time);
            throw new Exception("Invalid wind model");
        }
    }
}