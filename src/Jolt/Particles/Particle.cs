using System;
using Nexus;

namespace Jolt.Particles
{
	public class Particle
	{
		private Vector3D _forceAccumulator;

		public float Mass
		{
			get
			{
				return (InverseMass == 0.0f) 
					? float.PositiveInfinity 
					: 1.0f / InverseMass;
			}
			set
			{
				if (value == 0.0f)
					throw new ArgumentOutOfRangeException("value", "Mass cannot be 0.");
				InverseMass = 1.0f / value;
			}
		}

		public float InverseMass
		{
			get;
			set;
		}

		public bool HasFiniteMass
		{
			get { return InverseMass >= 0.0f; }
		}

		public float Damping { get; set; }
		public Point3D Position { get; set; }
		public Vector3D Velocity { get; set; }
		public Vector3D Acceleration { get; set; }

		public void AddForce(Vector3D force)
		{
			_forceAccumulator += force;
		}

		public void Integrate(float duration)
		{
			// Don't integrate things with zero mass.
			if (InverseMass <= 0.0f)
				return;

			if (duration <= 0.0f)
				throw new ArgumentOutOfRangeException("duration", "Duration must be greater than 0.");

			// Update linear position.
			Position += Velocity * duration;

			// Calculate the acceleration from the force.
			Vector3D resultingAcceleration = Acceleration;
			resultingAcceleration += _forceAccumulator * InverseMass;

			// Update linear velocity from the acceleration.
			Velocity += resultingAcceleration * duration;

			// Impose drag.
			Velocity *= MathUtility.Pow(Damping, duration);

			// Clear the forces.
			ClearAccumulator();
		}

		private void ClearAccumulator()
		{
			_forceAccumulator = Vector3D.Zero;
		}
	}
}