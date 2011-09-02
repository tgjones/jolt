using Nexus;

namespace Jolt.Particles.Forces
{
	public class ParticleAnchoredSpring : ParticleForceGenerator
	{
		protected Point3D Anchor { get; private set; }
		protected float SpringConstant { get; private set; }
		protected float RestLength { get; private set; }

		public ParticleAnchoredSpring(Particle particle, Point3D anchor, float springConstant, float restLength)
			: base(particle)
		{
			Anchor = anchor;
			SpringConstant = springConstant;
			RestLength = restLength;
		}

		public override void UpdateForce(float duration)
		{
			// Calculate the vector of the spring.
			Vector3D force = Particle.Position - Anchor;

			// Calculate the magnitude of the force.
			float magnitude = force.Length();
			magnitude = (RestLength - magnitude) * SpringConstant;

			// Calculate the final force and apply it.
			force.Normalize();
			force *= -magnitude;
			Particle.AddForce(force);
		}
	}
}