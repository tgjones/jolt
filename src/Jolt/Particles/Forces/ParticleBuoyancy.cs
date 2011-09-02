using Nexus;

namespace Jolt.Particles.Forces
{
	public class ParticleBuoyancy : ParticleForceGenerator
	{
		private readonly float _maxDepth;
		private readonly float _volume;
		private readonly float _waterHeight;
		private readonly float _liquidDensity;

		public ParticleBuoyancy(Particle particle, float maxDepth, float volume, float waterHeight, float liquidDensity = 1000.0f) 
			: base(particle)
		{
			_maxDepth = maxDepth;
			_volume = volume;
			_waterHeight = waterHeight;
			_liquidDensity = liquidDensity;
		}

		public override void UpdateForce(float duration)
		{
			// Calculate the submersion depth.
			float depth = Particle.Position.Y;

			// Check if we're out of the water.
			if (depth >= _waterHeight + _maxDepth)
				return;

			Vector3D force = Vector3D.Zero;

			// Check if we're at maximum depth.
			if (depth <= _waterHeight - _maxDepth)
			{
				force.Y = _liquidDensity * _volume;
				Particle.AddForce(force);
				return;
			}

			// Otherwise we are partly submerged.
			force.Y = _liquidDensity * _volume * (depth - _maxDepth - _waterHeight) / 2 * _maxDepth;
			Particle.AddForce(force);
		}
	}
}