using Nexus;

namespace Jolt.Particles.Forces
{
	public class ParticleAnchoredBungee : ParticleAnchoredSpring
	{
		public ParticleAnchoredBungee(Particle particle, Point3D anchor, float springConstant, float restLength) 
			: base(particle, anchor, springConstant, restLength)
		{
		}

		public override void UpdateForce(float duration)
		{
			// Calculate the vector of the spring.
			Vector3D force = Particle.Position - Anchor;

			// Calculate the magnitude of the force.
			float magnitude = force.Length();
			if (magnitude <= RestLength)
				return;

			magnitude -= RestLength;
			magnitude *= SpringConstant;

			// Calculate the final force and apply it.
			force.Normalize();
			force *= -magnitude;
			Particle.AddForce(force);
		}
	}
}