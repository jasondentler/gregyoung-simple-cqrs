﻿using System;
using log4net;
using NUnit.Framework;

namespace SimpleCQRS.EventStore
{
    public abstract class BaseFixture
    {

        protected static ILog Log = new Func<ILog>(() =>
        {
            log4net.Config.XmlConfigurator.Configure();
            return LogManager.GetLogger(typeof(BaseFixture));
        }).Invoke();


        protected virtual void OnFixtureSetup() { }
        protected virtual void OnFixtureTeardown() { }
        protected virtual void OnSetup() { }
        protected virtual void OnTeardown() { }

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            OnFixtureSetup();
        }

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            OnFixtureTeardown();
        }

        [SetUp]
        public void Setup()
        {
            OnSetup();
        }

        [TearDown]
        public void Teardown()
        {
            OnTeardown();
        }

    }

}
