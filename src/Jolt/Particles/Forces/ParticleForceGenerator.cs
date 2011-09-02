namespace Jolt.Particles.Forces
{
	public abstract class ParticleForceGenerator
	{
		public Particle Particle { get; private set; }

		protected ParticleForceGenerator(Particle particle)
		{
			Particle = particle;
		}

		public abstract void UpdateForce(float duration);
	}
}