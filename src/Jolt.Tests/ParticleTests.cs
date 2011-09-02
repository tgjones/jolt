using System;
using NUnit.Framework;
using Nexus;

namespace Jolt.Tests
{
	[TestFixture]
	public class ParticleTests
	{
		[Test]
		 public void CanCreateParticle()
		{
			Assert.DoesNotThrow(() => new Particle());
		}

		[Test]
		public void CanSetAndGetParticleMass()
		{
			// Arrange.
			var particle = new Particle();

			// Act.
			particle.Mass = 2f;

			// Assert.
			Assert.That(particle.Mass, Is.EqualTo(2));
		}

		[Test]
		public void SettingParticleMassToInvalidValueThrowsException()
		{
			// Arrange.
			var particle = new Particle();

			// Act / Assert.
			Assert.Throws<ArgumentOutOfRangeException>(() => particle.Mass = 0);
		}

		[Test]
		public void ParticleMassIsInfinityWhenInverseMassIsZero()
		{
			// Arrange.
			var particle = new Particle();

			// Act.
			particle.InverseMass = 0f;

			// Assert.
			Assert.That(particle.Mass, Is.EqualTo(float.PositiveInfinity));
		}

		[Test]
		public void ParticleIntegrationDoesNothingWhenNoForces()
		{
			// Arrange.
			var particle = new Particle();
			particle.Mass = 2f;

			// Act.
			particle.Integrate(1.0f);

			// Assert.
			Assert.That(particle.Position, Is.EqualTo(Point3D.Zero));
			Assert.That(particle.Velocity, Is.EqualTo(Vector3D.Zero));
			Assert.That(particle.Acceleration, Is.EqualTo(Vector3D.Zero));
		}

		[Test]
		public void ParticleIntegrationAltersValuesCorrectly()
		{
			// Arrange.
			var particle = new Particle();
			particle.Mass = 2f;
			particle.Damping = 0.99f;
			particle.AddForce(Vector3D.Forward);

			// Act.
			particle.Integrate(1.0f);

			// Assert.
			Assert.That(particle.Position, Is.EqualTo(Point3D.Zero));
			Assert.That(particle.Velocity, Is.EqualTo(new Vector3D(0, 0, -0.495f)));
			Assert.That(particle.Acceleration, Is.EqualTo(Vector3D.Zero));
		}
	}
}