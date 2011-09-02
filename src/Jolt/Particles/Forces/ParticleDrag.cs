using Nexus;

namespace Jolt.Particles.Forces
{
	public class ParticleDrag : ParticleForceGenerator
	{
		private readonly float _k1;
		private readonly float _k2;

		public ParticleDrag(Particle particle, float k1, float k2)
			: base(particle)
		{
			_k1 = k1;
			_k2 = k2;
		}

		public override void UpdateForce(float duration)
		{
			Vector3D force = Particle.Velocity;

			// Calculate the total drag coefficient.
			float dragCoefficient = force.Length();
			dragCoefficient = _k1 * dragCoefficient + _k2 * dragCoefficient * dragCoefficient;

			// Calculate the final force and apply it.
			force.Normalize();
			force *= -dragCoefficient;
			Particle.AddForce(force);
		}
	}
}