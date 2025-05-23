﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

using NUnit.Framework;
using Assert = ModestTree.Assert;

namespace Zenject.Tests.Injection
{
    [TestFixture]
    public class TestBaseClassPropertyInjection : ZenjectUnitTestFixture
    {
        class Test0
        {
        }

        class Test3
        {
        }

        class Test1 : Test3
        {
            [Inject] protected Test0 val = null;

            public Test0 GetVal()
            {
                return val;
            }
        }

        class Test2 : Test1
        {
        }

        [Test]
        public void TestCaseBaseClassPropertyInjection()
        {
            Container.Bind<Test0>().AsSingle().NonLazy();
            Container.Bind<Test2>().AsSingle().NonLazy();

            var test1 = Container.Resolve<Test2>();

            Assert.That(test1.GetVal() != null);
        }
    }
}


