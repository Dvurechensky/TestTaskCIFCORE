﻿/*
 * Author: Nikolay Dvurechensky
 * Site: https://www.dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 12 мая 2025 08:07:05
 * Version: 1.0.1
 */

using NUnit.Framework;
using Assert = ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestFactoryFromSubContainerMethod0 : ZenjectUnitTestFixture
    {
        static Foo ConstFoo = new Foo();

        [Test]
        public void TestSelf()
        {
            Container.BindFactory<Foo, Foo.Factory>().FromSubContainerResolve().ByMethod(InstallFoo).NonLazy();

            Assert.IsEqual(Container.Resolve<Foo.Factory>().Create(), ConstFoo);
        }

        [Test]
        public void TestConcrete()
        {
            Container.BindFactory<IFoo, IFooFactory>()
                .To<Foo>().FromSubContainerResolve().ByMethod(InstallFoo).NonLazy();

            Assert.IsEqual(Container.Resolve<IFooFactory>().Create(), ConstFoo);
        }

        void InstallFoo(DiContainer subContainer)
        {
            subContainer.Bind<Foo>().FromInstance(ConstFoo);
        }

        interface IFoo
        {
        }

        class IFooFactory : PlaceholderFactory<IFoo>
        {
        }

        class Foo : IFoo
        {
            public class Factory : PlaceholderFactory<Foo>
            {
            }
        }
    }
}


