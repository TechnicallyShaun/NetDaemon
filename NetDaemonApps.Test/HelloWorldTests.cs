using FluentAssertions;
using HassModel;
using Moq;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using NUnit.Framework.Interfaces;
using System.Net.Sockets;

namespace NetDaemonApps.Test
{
    public class HelloWorldTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var mock = new Mock<IHaContext>();
            var heyaMock = new Mock<ITestThis>();
            var helloWorld = new HelloWorldApp(mock.Object, heyaMock.Object);

            var expected = new { test = "Hi!", other = "test" };

            heyaMock.Verify(x => x.Heya("Hi!"), Times.Once());
            heyaMock.Verify(x => x.Heya2(It.Is<object>(y => y.GetHashCode() == expected.GetHashCode())));
            mock.Verify(x => x.CallService("notify", "persistent_notification", It.IsAny<ServiceTarget>(), It.IsAny<object>()), Times.Once());
        }
    }
}