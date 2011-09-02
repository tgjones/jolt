using System.Collections.Generic;
using Jolt.Particles.Forces;

namespace Jolt.Particles
{
	public class ParticleWorld
	{
		private readonly List<Particle> _particles;
		private readonly List<ParticleForceGenerator> _particleForceGenerators;

		public ParticleWorld()
		{
			_particles = new List<Particle>();
			_particleForceGenerators = new List<ParticleForceGenerator>();
		}

		public void AddParticle(Particle particle)
		{
			_particles.Add(particle);
		}

		public void AddParticleForceGenerator(ParticleForceGenerator particleForceGenerator)
		{
			_particleForceGenerators.Add(particleForceGenerator);
		}

		public void UpdateForces(float duration)
		{
			foreach (var particleForceGenerator in _particleForceGenerators)
				particleForceGenerator.UpdateForce(duration);
		}
	}
}