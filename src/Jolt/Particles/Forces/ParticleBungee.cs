using Nexus;

namespace Jolt.Particles.Forces
{
	public class ParticleBungee : ParticleForceGenerator
	{
		private readonly Particle _other;
		private readonly float _springConstant;
		private readonly float _restLength;

		public ParticleBungee(Particle particle, Particle other, float springConstant, float restLength) 
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

			// Check if the bungee is compressed.
			float magnitude = force.Length();
			if (magnitude <= _restLength)
				return;

			// Calculate the magnitude of the force.
			magnitude = _springConstant * (_restLength - magnitude);

			// Calculate the final force and apply it.
			force.Normalize();
			force *= -magnitude;
			Particle.AddForce(force);
		}
	}
}