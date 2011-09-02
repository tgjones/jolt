using System;
using Nexus;

namespace Jolt.Particles.Forces
{
	public class ParticleSpring : ParticleForceGenerator
	{
		private readonly Particle _other;
		private readonly float _springConstant;
		private readonly float _restLength;

		public ParticleSpring(Particle particle, Particle other, float springConstant, float restLength) 
			: base(particle)
		{
			_other = other;
			_springConstant = springConstant;
			_restLength = restLength;
		}

		public override void UpdateForce(float duration)
		{
			// Calculate the vector of the spring.
			Vector3D force = Particle.Position - _other.Position;

			// Calculate the magnitude of the force.
			float magnitude = force.Length();
			magnitude = Math.Abs(magnitude - _restLength);
			magnitude *= _springConstant;

			// Calculate the final force and apply it.
			force.Normalize();
			force *= -magnitude;
			Particle.AddForce(force);
		}
	}
}