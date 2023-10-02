using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace AWSSDK_DotNet35.UnitTests.TestTools
{
    /// <summary>
    /// This class instantiates an object of the passed in type. It will also set values for all the properties 
    /// and create and fill lists and maps.
    /// 
    /// The class should always return back the same object for the same object definition. This make debugging 
    /// more predictable.
    /// </summary>
    public class InstantiateClassGenerator
    {
        public static T Execute<T>()
            where T : new()
        {
            var type = typeof(T);
            var result = Execute(type);
            var rootObject = (T)result;
            return rootObject;
        }

        public static object Execute(Type type)
        {

            var rootObject = Activator.CreateInstance(type);
            TypeCircularReference<Type> tcr = new TypeCircularReference<Type>();
            InstantiateProperties(tcr, rootObject);
            return rootObject;
        }

        private static void InstantiateProperties(TypeCircularReference<Type> tcr, object owningObject)
        {
            if (owningObject == null)
            {
                return;
            }

            foreach (var info in owningObject.GetType().GetProperties())
            {
                if (info.SetMethod == null)
                    continue;
                var propertyName = info.Name;
                var type = info.PropertyType;
                var propertyValue = info switch
                {
                    var x when string.Equals(x.Name, "AccountId") && type == typeof(string) => "0123456789",
                    var x when string.Equals(x.Name, "PartNumber") && (type == typeof(int) || type == typeof(int?)) => 100,
                    //var x when string.Equals(x.Name, "ContentType") && type == typeof(string) => null,
                    var x when string.Equals(x.Name, "ClientContextBase64") && type == typeof(string) => Convert.ToBase64String(Encoding.UTF8.GetBytes("%2FTest-Value/~.$\\&*value")),


                    _ => InstantiateType(tcr, type)
                };
                info.SetMethod.Invoke(owningObject, new object[] { propertyValue });
            }
        }

        private static object InstantiateType(TypeCircularReference<Type> tcr, Type type)
        {
            bool pushed = false;
            if (!type.FullName.StartsWith("System."))
            {
                pushed = tcr.Push(type);
                if (!pushed)
                    return null;
            }

            try
            {
                if (type == typeof(string))
                {
                    return "%2FTest-Value/~.$\\&*value";
                }
                else if (type == typeof(bool) || type == typeof(bool?))
                {
                    return true;
                }
                else if (type == typeof(int) || type == typeof(int?))
                {
                    return int.MaxValue;
                }
                else if (type == typeof(long) || type == typeof(long?))
                {
                    return long.MaxValue;
                }
                else if (type == typeof(double) || type == typeof(double?))
                {
                    return double.MaxValue;
                }
                else if (type == typeof(float) || type == typeof(float?))
                {
                    return float.MaxValue;
                }
                else if (type == typeof(DateTime) || type == typeof(DateTime?))
                {
                    return Constants.DEFAULT_DATE;
                }
                else if (type == typeof(MemoryStream))
                {
                    return new MemoryStream(Constants.DEFAULT_BLOB);
                }
                else if (type.FullName == "Amazon.Runtime.Documents.Document")
                {
                    var doc1 = type.GetMethod("FromObject").Invoke(null, new object[] { new { Hello = "World", Testing = true } });
                    var doc2 = Activator.CreateInstance(type, new object[] { 42 });
                    return Activator.CreateInstance(type, new object[] { doc1, doc2 });
                }
                else if (type.BaseType != null && type.BaseType.FullName == "Amazon.Runtime.ConstantClass")
                {
                    var value = type.GetFields()[0].GetValue(null);
                    return value;
                }
                else if (type == typeof(Stream))
                {
                    return new MemoryStream(Constants.DEFAULT_BLOB);
                }
                else if (type.BaseType != null && type.BaseType.FullName == "System.MulticastDelegate")
                {
                    return null; // Event Handlers
                }
                else if (type.FullName == "Amazon.S3.Model.HeadersCollection" || type.FullName == "Amazon.S3.Model.MetadataCollection" || type.FullName == "Amazon.S3.Model.ParameterCollection")
                {
                    return Activator.CreateInstance(type);
                }
                else if (type.GetConstructor(Type.EmptyTypes) != null)
                {
                    var value = Activator.CreateInstance(type);
                    if (type.GetInterface("System.Collections.IList") != null)
                    {
                        var list = value as System.Collections.IList;
                        var listType = type.GenericTypeArguments[0];
                        if (!tcr.Contains(listType))
                        {
                            // Add some variability to the length to the array 
                            for (int i = 0; i < (1 + listType.FullName.Length % 5); i++)
                            {
                                list.Add(InstantiateType(tcr, listType));
                            }
                        }
                    }
                    else if (type.GetInterface("System.Collections.IDictionary") != null)
                    {
                        var map = value as System.Collections.IDictionary;
                        var valueType = type.GenericTypeArguments[1];
                        if (!tcr.Contains(valueType))
                        {
                            // Add some variability to the length to the array 
                            for (int i = 0; i < (1 + valueType.FullName.Length % 5); i++)
                            {
                                map.Add("key" + i, InstantiateType(tcr, valueType));
                            }
                        }
                    }
                    else
                    {
                        InstantiateProperties(tcr, value);
                    }

                    return value;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                if (pushed)
                    tcr.Pop();
            }
        }
        public static void ValidateObjectFullyInstantiated(object owningObject)
        {
            ValidateObjectFullyInstantiated(owningObject, new TypeCircularReference<Type>());
        }

        private static void ValidateObjectFullyInstantiated(object owningObject, TypeCircularReference<Type> tcr)
        {
            Assert.IsNotNull(owningObject, "Root object null");

            var owningType = owningObject.GetType();

            if (tcr?.Push(owningType) == true) // No circular reference found
            {
                foreach (var info in owningType.GetProperties())
                {
                    if (info.SetMethod == null || info.Name == "ContentLength")
                        continue;

                    if (owningObject is Exception &&
                        (info.Name.Equals("HelpLink") || info.Name.Equals("Source") || info.Name.Equals("HResult") || info.Name.Equals("AmazonId2")))
                        continue;
                    //when streaming responses we don't buffer the payload in memory fully, so the bufferSize will not be int.MaxValue. 
                    if (info.Name.Equals("BufferSize") && owningType.BaseType.Name == "EnumerableEventStream`2")
                        continue;
                    if (info.Name.Equals("ContentType")) continue;
                    var type = info.PropertyType;
                    var propertyValue = info.GetMethod.Invoke(owningObject, new object[] { });

                    if (type == typeof(int))
                    {
                        if (info.Name == "Status" ||
                        info.Name == "StatusCode")
                        {
                            if (Enum.IsDefined(typeof(HttpStatusCode), propertyValue))
                            {
                                // Special case for GetJobOutputResponse.Status property which is unmarshalled from 
                                // HttpResponse's Status code.
                                Assert.AreEqual(200, propertyValue);
                                continue;
                            }
                        }
                    }

                    ValidatePropertyValueInstantiated(type, propertyValue, info.Name, tcr);
                }
                tcr.Pop();
            }
        }

        private static void ValidatePropertyValueInstantiated(Type type, object propertyValue, string propertyName, TypeCircularReference<Type> tcr = null)
        {
            if (type == typeof(string))
            {
                Assert.IsTrue(propertyValue is string, "Invalid value for " + propertyName);
                Assert.IsTrue(((string)propertyValue).Length > 0, "Invalid value for " + propertyName);
            }
            else if (type == typeof(bool))
            {
                Assert.IsTrue(propertyValue is bool, "Invalid value for " + propertyName);
                //Assert.IsTrue(((bool)propertyValue), "Invalid value for " + propertyName);
            }
            else if (type == typeof(int))
            {
                Assert.IsTrue(propertyValue is int, "Invalid value for " + propertyName);
                if (propertyName == "PartNumber")
                {
                    Assert.AreEqual(((int)propertyValue), 100, "Invalid value for " + propertyName);

                }
                else
                {
                    Assert.AreEqual(((int)propertyValue), int.MaxValue, "Invalid value for " + propertyName);
                }
            }
            else if (type == typeof(long))
            {
                Assert.IsTrue(propertyValue is long, "Invalid value for " + propertyName);
                Assert.AreEqual(((long)propertyValue), long.MaxValue, "Invalid value for " + propertyName);
            }
            else if (type == typeof(double))
            {
                Assert.IsTrue(propertyValue is double, "Invalid value for " + propertyName);
                Assert.AreEqual(((double)propertyValue), double.MaxValue, "Invalid value for " + propertyName);
            }
            else if (type == typeof(DateTime))
            {
                Assert.IsTrue(propertyValue is DateTime, "Invalid value for " + propertyName);
                Assert.AreEqual(((DateTime)propertyValue).ToUniversalTime(), Constants.DEFAULT_DATE.ToUniversalTime(), "Invalid value for " + propertyName);
            }
            else if (type == typeof(MemoryStream))
            {
                Assert.IsTrue(propertyValue is MemoryStream, "Invalid value for " + propertyName);
                Assert.IsTrue(((MemoryStream)propertyValue).Length > 0, "Invalid value for " + propertyName);
            }
            else if (type == typeof(Stream))
            {
                Assert.IsTrue(propertyValue is Stream, "Invalid value for " + propertyName);
                Assert.IsTrue(((Stream)propertyValue).Length > 0, "Invalid value for " + propertyName);
            }
            else if (type.BaseType != null && type.BaseType.FullName == "Amazon.Runtime.ConstantClass")
            {
                Assert.IsNotNull(propertyValue, "Invalid value for " + propertyName);
            }
            else if (type.BaseType != null && type.BaseType.FullName == "System.MulticastDelegate")
            {
                Assert.IsNull(propertyValue, "Invalid value for " + propertyName);
            }
            else if (type.FullName == "Amazon.S3.Model.HeadersCollection" || type.FullName == "Amazon.S3.Model.MetadataCollection" || type.FullName == "Amazon.S3.Model.ParameterCollection")
            {
                // Depending on the class it can be null or empty list
                Assert.AreEqual(((dynamic)propertyValue).Count, 0, "Invalid value for " + propertyName);
            }
            else if (type.GetConstructor(Type.EmptyTypes) != null)
            {
                if (type.GetInterface("System.Collections.IList") != null)
                {
                    var list = propertyValue as System.Collections.IList;

                    var listType = type.GenericTypeArguments[0];
                    foreach (var item in list)
                    {
                        ValidatePropertyValueInstantiated(listType, item, propertyValue + "_Dictionary", tcr);
                    }
                }
                else if (type.GetInterface("System.Collections.IDictionary") != null)
                {
                    var map = propertyValue as System.Collections.IDictionary;

                    var valueType = type.GenericTypeArguments[1];
                    foreach (var key in map.Keys)
                    {
                        ValidatePropertyValueInstantiated(valueType, map[key], propertyValue + "_Dictionary", tcr);
                    }
                }
                else if (propertyValue == null && tcr != null && tcr.Contains(type))
                {
                    // Circular reference found, stop here
                    return;
                }
                else
                {
                    ValidateObjectFullyInstantiated(propertyValue, tcr);
                }
            }
            else
            {
                // no public constuctors. Check for null
            }
        }
    }
}
