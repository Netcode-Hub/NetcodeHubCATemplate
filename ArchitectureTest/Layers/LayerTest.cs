
using NetArchTest.Rules;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureTest.Layers
{
    public class LayerTest : BaseTest
    {
        // Domain Layer
        [Fact]
        public void Domain_Should_not_Depend_On_Any_Layer()
        {
            List<string> Assemblies = [
                ApplicationAssembly.GetName().Name,
                InfrastructureAssembly.GetName().Name,
                PresentationAssembly.GetName().Name
                ];

            foreach (var assembly in Assemblies)
            {
                TestResult result = Types.InAssembly(DomainAssembly)
                .ShouldNot()
                .HaveDependencyOn(assembly)
                .GetResult();
                result.IsSuccessful.ShouldBeTrue();
            }
        }

        // Application
        [Fact]
        public void Application_Should_Not_Depend_On_Any_Except_Domain()
        {
            List<string> Assemblies = [
                InfrastructureAssembly.GetName().Name,
                PresentationAssembly.GetName().Name
                ];

            foreach (var assembly in Assemblies)
            {
                TestResult result = Types.InAssembly(ApplicationAssembly)
                .ShouldNot()
                .HaveDependencyOn(assembly)
                .GetResult();
                result.IsSuccessful.ShouldBeTrue();
            }
        }

        //Infrastructure
        [Fact]
        public void Infrastructure_Should_Not_Depend_On_Presentation()
        {
           
                TestResult result = Types.InAssembly(InfrastructureAssembly)
                .ShouldNot()
                .HaveDependencyOn(PresentationAssembly.GetName().Name)
                .GetResult();
                result.IsSuccessful.ShouldBeTrue();
            
        }

        // Presentation

    }
}
