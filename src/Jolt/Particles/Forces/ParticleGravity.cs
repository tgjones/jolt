using Nexus;

namespace Jolt.Particles.Forces
{
	public class ParticleGravity : ParticleForceGenerator
	{
		private readonly Vector3D _gravity;

		public ParticleGravity(Particle particle, Vector3D gravity)
			: base(particle)
		{
			_gravity = gravity;
		}

		public override void UpdateForce(float duration)
		{
			// Check that we do not have infinite mass.
			if (!Particle.HasFiniteMass)
				return;

			// Apply the mass-scaled force to the particle.
			Particle.AddForce(_gravity * Particle.Mass);
		}
	}
}