using AWSSDK_DotNet35.UnitTests.TestTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Amazon.PowerShell.Common.Internal;

namespace Common.Tests.TestHelpers
{
    internal class SensitiveDataSanitization
    {
        private static List<Type> GetRequestResponseTypes(Assembly assembly)
        {
            var amazonWebServiceResponseType = Type.GetType("Amazon.Runtime.AmazonWebServiceResponse, AWSSDK.Core, Version=3.3.0.0, Culture=neutral, PublicKeyToken=885c28607f98e604");
            var amazonWebServiceRequestType = Type.GetType("Amazon.Runtime.AmazonWebServiceRequest, AWSSDK.Core, Version=3.3.0.0, Culture=neutral, PublicKeyToken=885c28607f98e604");

            return
              assembly.GetTypes()
                      .Where(t => t.IsSubclassOf(amazonWebServiceRequestType) || t.IsSubclassOf(amazonWebServiceResponseType))
                      .ToList();
        }

        private static List<Type> GetAllRequestResponseTypesFromAssemblies()
        {
            List<Type> allTypes = new List<Type>();
            string DotNetPlatformNetStandard20 = "netstandard2.0";
            string path = Directory.GetCurrentDirectory();
            string SdkAssembliesFolder = "../../../../../../Include/sdk/assemblies";
            string platformAssembliesFolder = Path.Combine(SdkAssembliesFolder, DotNetPlatformNetStandard20);
            string baseName = "AWSSDK.Core";
            var coreAssemblyFile = Path.Combine(SdkAssembliesFolder, DotNetPlatformNetStandard20, $"{baseName}.dll");
            
            var assemblies = Directory.GetFiles(platformAssembliesFolder, "*.dll");

            var coreAssembly = Assembly.LoadFrom(coreAssemblyFile);

            var coreRequestResponseTypes = GetRequestResponseTypes(coreAssembly);
            allTypes.AddRange(coreRequestResponseTypes);

            foreach (string assembly in assemblies)
            {
                var loadedAssembly = Assembly.LoadFrom(assembly);
                var requestResponsetypes = GetRequestResponseTypes(loadedAssembly);

                allTypes.AddRange(requestResponsetypes);
            }

            return allTypes;
        }

        private static List<object> GenerateDataForRequestResponseTypes(string typeName = null, List<string> excludeTypes = null)
        {
            List<object> objects = new List<object>();
            var types = GetAllRequestResponseTypesFromAssemblies();
            if (typeName != null)
            {
                types = types.Where(t => t.FullName == typeName).ToList();
            }

            if (excludeTypes != null)
            {
                types = types.Where(t => !excludeTypes.Contains(t.FullName)).ToList();
            }

            foreach (var type in types)
            {
                var x = InstantiateClassGenerator.Execute(type);
                objects.Add(x);
            }
            return objects;
        }

        private static bool IsDataSanitized(object sanitizedData)
        {
            if (sanitizedData == null)
            {
                return true;
            }

            var sanitizedDataType = sanitizedData.GetType();

            if (sanitizedData is IList listData)
            {
                foreach (var item in listData)
                {
                    if (item.GetType().FullName.Contains("Amazon.") && !IsDataSanitized(item))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (sanitizedData is IDictionary dictionaryData)
            {
                foreach (DictionaryEntry item in dictionaryData)
                {
                    if (item.Key.GetType().FullName.Contains("Amazon.") && !IsDataSanitized(item.Key))
                    {
                        return false;
                    }

                    if (item.Value.GetType().FullName.Contains("Amazon.") && !IsDataSanitized(item.Value))
                    {
                        return false;
                    }
                }
                return true;
            }

            foreach (PropertyInfo property in sanitizedDataType.GetProperties())
            {
                var propertyValue = property.GetValue(sanitizedData);
                if (SensitiveData.IsPropertySensitive(property))
                {
                    var expectedValue = GetDefault(property.PropertyType);
                    if (propertyValue is IList listProperty)
                    {
                        if (listProperty.Count > 0)
                        {
                            return false;
                        }
                    }
                    else if (propertyValue is IDictionary dictProperty)
                    {
                        if (dictProperty.Count > 0)
                        {
                            return false;
                        }
                    }
                    else if (propertyValue is Stream streamProperty)
                    {
                        if (streamProperty.Length == 0)
                        {
                            return false;
                        }
                    }
                    // if the values are different
                    else if (!((propertyValue != null && propertyValue.Equals(expectedValue)) || propertyValue == expectedValue))
                    {
                        return false;
                    }
                }
                else if (property.PropertyType.FullName.Contains("Amazon.") && SensitiveData.TypeContainsSensitiveData(property.PropertyType) && !IsDataSanitized(propertyValue))
                {
                    return false;
                }
            }
            return true;
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        public static void TestSanitizedDataDoesntThrowError(string typeName = null, List<string> excludeTypes = null)
        {
            var allObjects = GenerateDataForRequestResponseTypes(typeName: typeName, excludeTypes: excludeTypes);
            foreach (var sdkObject in allObjects)
            {
                try
                {
                    var sanitizedData = SensitiveData.GetSanitizedData(sdkObject);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"{sdkObject.GetType().FullName} {ex.Message}");
                }
            }
        }

        public static void ValidateObjectsFullyInstantiated(string typeName = null, List<string> excludeTypes = null)
        {
            var allObjects = GenerateDataForRequestResponseTypes(typeName: typeName, excludeTypes: excludeTypes);
            foreach (var response in allObjects)
            {
                InstantiateClassGenerator.ValidateObjectFullyInstantiated(response);
            }
        }

        public static void TestSensitiveSanitizedData(string typeName = null, List<string> excludeTypes = null)
        {
            bool isDataSanitized = false;
            var allObjects = GenerateDataForRequestResponseTypes(typeName: typeName, excludeTypes: excludeTypes);
            foreach (var sdkObject in allObjects)
            {
                var response = sdkObject;
                // Check whether the sdkObject has Sensitive data if yes then sanitize
                var isSensitiveData = SensitiveData.TypeContainsSensitiveData(response.GetType());
                if (isSensitiveData)
                {
                    try
                    {
                        var sanitizedData = SensitiveData.GetSanitizedData(response);
                        isDataSanitized = IsDataSanitized(sanitizedData);
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail($"Sanitization Failed for {sdkObject.GetType().FullName} with error {ex.Message}");
                    }
                    Assert.AreEqual(isDataSanitized, true, $"Sanitization Failed for {sdkObject.GetType().FullName}");
                }
            }
        }
    }
}
