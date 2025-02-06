/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Amazon.Runtime;
using System.IO;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Converts strings and byte arrays to Base64 encoded strings.
    /// </summary>
    public class Base64StringParameterConverterAttribute : ArgumentTransformationAttribute
    {
        public override object Transform(EngineIntrinsics engineIntrinsics, object inputData)
        {
            switch (inputData)
            {
                case PSObject psObject when psObject.BaseObject != null:
                    return Transform(engineIntrinsics, psObject.BaseObject);
                case string stringValue:
                    return Utils.Common.ConvertToBase64(stringValue);
                case byte[] byteArrayValue:
                    return Utils.Common.ConvertToBase64(byteArrayValue);
                case null:
                    return inputData;
                default:
                    throw new ArgumentException($"Cannot perform Base64 conversion for type {inputData.GetType().FullName}");
            }
        }
    }

    /// <summary>
    /// Converts different input types to byte[] to be used for MemoryStream parameters.
    /// Then performs a Base64 conversion on the array.
    /// </summary>
    public class Base64StreamParameterConverterAttribute : ArgumentTransformationAttribute
    {
        public override object Transform(EngineIntrinsics engineIntrinsics, object inputData)
        {
            var bytes = MemoryStreamParameterConverterAttribute.TransformToByteArray(inputData);
            if (bytes is byte[] byteArrayValue)
            {
                return Encoding.UTF8.GetBytes(Utils.Common.ConvertToBase64(byteArrayValue));
            }
            throw new ArgumentException($"Cannot perform Base64 conversion for type {inputData.GetType().FullName}");
        }
    }

    /// <summary>
    /// Converts different input types to byte[] to be used for MemoryStream parameters
    /// </summary>
    public class MemoryStreamParameterConverterAttribute : ArgumentTransformationAttribute
    {
        public override object Transform(EngineIntrinsics engineIntrinsics, object inputData)
        {
            return TransformToByteArray(inputData) ?? inputData;
        }

        internal static byte[] TransformToByteArray(object inputData)
        {
            switch (inputData)
            {
                case PSObject psObject when psObject.BaseObject != null:
                    return TransformToByteArray(psObject.BaseObject);
                case string stringValue:
                    return Encoding.UTF8.GetBytes(stringValue);
                case byte[] byteArrayValue:
                    return byteArrayValue;
                case MemoryStream memoryStreamValue:
                    return memoryStreamValue.ToArray();
                case Stream streamValue:
                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            byte[] tempBuffer = new byte[81920];
                            int len;
                            while ((len = streamValue.Read(tempBuffer, 0, tempBuffer.Length)) != 0)
                            {
                                memoryStream.Write(tempBuffer, 0, len);
                            }
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            return memoryStream.ToArray();
                        }
                    }
                    finally
                    {
                        streamValue.Dispose();
                    }
                case string[] stringArrayValue:
                    return ConvertStringsToBytes(stringArrayValue);
                case System.Collections.IEnumerable enumerable when enumerable.Cast<object>().All(item => item is string):
                    return ConvertStringsToBytes(enumerable.Cast<string>());
                case FileInfo fileInfoValue:
                    return File.ReadAllBytes(fileInfoValue.FullName);
                default:
                    return null;
            }
        }

        private static byte[] ConvertStringsToBytes(IEnumerable<string> stringEnumerable)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream, new UTF8Encoding(false)))
            {
                foreach (var line in stringEnumerable)
                {
                    writer.WriteLine(line);
                }
                writer.Flush();
                return memoryStream.ToArray();
            }
        }
    }

    /// <summary>
    /// Converts different input types to System.IO.Stream. We are not using an
    /// ArgumentTransformationAttribute for this because we don't want to risk creating
    /// a stream (for example a FileStream) and then fail to dispose of it. So we will
    /// instead wait to convert during the actual Cmdlet execution.
    /// </summary>
    public static class StreamParameterConverter
    {
        public static Stream TransformToStream(object inputData)
        {
            switch (inputData)
            {
                case PSObject psObject when psObject.BaseObject != null:
                    return TransformToStream(psObject.BaseObject);
                case Stream streamValue:
                    return streamValue;
                case FileInfo fileInfoValue:
                    return new FileStream(fileInfoValue.FullName, FileMode.Open, FileAccess.Read);
                case null:
                    throw new ArgumentNullException();
                default:
                    var byteArrayValue = MemoryStreamParameterConverterAttribute.TransformToByteArray(inputData);
                    if (byteArrayValue == null)
                    {
                        throw new ArgumentException($"Cannot conver type {inputData.GetType().FullName} to System.IO.Stream.");
                    }
                    return new MemoryStream(byteArrayValue);
            }
        }
    }
}