using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace NUnitTestRunner
{
    public class TestRunner
    {
        private readonly Assembly _testAssembly;

        public TestRunner(Assembly testAssembly)
        {
            _testAssembly = testAssembly;
        }

        public void RunTests()
        {
            var testTypes = GetTestTypes();

            foreach (var testType in testTypes)
            {
                RunTestType(testType);
            }
        }

        private ICollection<Type> GetTestTypes()
        {
            return _testAssembly.ExportedTypes
                .Where(x => x.IsClass && x.GetCustomAttributes<TestFixtureAttribute>().Any())
                .ToList();
        }

        private void RunTestType(Type testType)
        {
            var testMethods = GetTestMethods(testType);
            var setUpMethods = GetSetUpMethods(testType);
            var tearDownMethods = GetTearDownMethods(testType);

            if (!testMethods.Any())
                return;

            var instance = Activator.CreateInstance(testType);

            foreach (var testMethod in testMethods)
            {
                var arguments = GetArguments(testType, testMethod);

                foreach (var args in arguments)
                {
                    try
                    {
                        foreach (var setUpMethod in setUpMethods)
                        {
                            setUpMethod.Invoke(instance, default(object[]));
                        }

                        var argsString = args == null ? string.Empty : string.Join(", ", args);

                        Console.WriteLine($"Run method {testType.Name}.{testMethod.Name}({argsString})");
                        testMethod.Invoke(instance, args);
                        Console.WriteLine("   success");
                    }
                    catch (TargetInvocationException exception)
                    {
                        if (exception.InnerException is AssertionException)
                        {
                            Console.WriteLine(exception.InnerException.Message);
                        }
                        else
                        {
                            Console.WriteLine($"Unexpected: {exception.Message}");
                        }
                    }
                    finally
                    {
                        foreach (var tearDownMethod in tearDownMethods)
                        {
                            tearDownMethod.Invoke(instance, default(object[]));
                        }
                    }
                }
            }
        }

        private ICollection<MethodInfo> GetTestMethods(Type testType)
        {
            return testType.GetRuntimeMethods()
                .Where(x => x.GetCustomAttributes<TestAttribute>().Any() ||
                            x.GetCustomAttributes<TestCaseAttribute>().Any() ||
                            x.GetCustomAttributes<TestCaseSourceAttribute>().Any())
                .ToList();
        }

        private ICollection<MethodInfo> GetSetUpMethods(Type testType)
        {
            return testType.GetRuntimeMethods()
                .Where(x => x.GetCustomAttributes<SetUpAttribute>().Any())
                .ToList();
        }

        private ICollection<MethodInfo> GetTearDownMethods(Type testType)
        {
            return testType.GetRuntimeMethods()
                .Where(x => x.GetCustomAttributes<TearDownAttribute>().Any())
                .ToList();
        }

        private ICollection<TestCaseAttribute> GetTestCaseAttributes(MethodInfo testMethod)
        {
            return testMethod.GetCustomAttributes<TestCaseAttribute>().ToList();
        }

        private TestCaseSourceAttribute GetTestCaseSourceAttributes(MethodInfo testMethod)
        {
            return testMethod.GetCustomAttributes<TestCaseSourceAttribute>().FirstOrDefault();
        }

        private List<object[]> GetArguments(Type testType, MethodInfo testMethod)
        {
            var arguments = new List<object[]>();

            var testCaseAttributes = GetTestCaseAttributes(testMethod);
            if (testCaseAttributes.Any())
            {
                arguments.AddRange(testCaseAttributes.Select(x => x.Arguments));
            }

            var testCaseSourceAttribute = GetTestCaseSourceAttributes(testMethod);
            if (testCaseSourceAttribute != null)
            {
                var sourceValues = testType.GetRuntimeFields()
                    .FirstOrDefault(x => x.Name == testCaseSourceAttribute.SourceName)
                    .GetValue(null);

                foreach (var sourceValue in (sourceValues as object[]))
                {
                    if (sourceValue is Array sourceArr)
                    {
                        var obj = new object[sourceArr.Length];
                        sourceArr.CopyTo(obj, 0);
                        arguments.Add(obj);
                    }
                    else
                    {
                        arguments.Add(new object[1] { sourceValue });
                    }
                }
            }

            if (arguments.Count == 0)
            {
                arguments.Add(default(object[]));
            }

            return arguments;
        }
    }
}