/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using System.Text;

using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public class S3BucketTypeConverter : PSTypeConverter
    {
        public override bool CanConvertFrom(object sourceValue, Type destinationType)
        {
            if (sourceValue == null) // not sure if this is needed
                return false;

            if (sourceValue is S3Bucket && destinationType == typeof(string))
                return true;

            if (sourceValue is PSObject && (sourceValue as PSObject).BaseObject is S3Bucket && destinationType == typeof(string))
                return true;

            return false;
        }

        public override bool CanConvertTo(object sourceValue, Type destinationType)
        {
            return false;
        }

        public override object ConvertFrom(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            if (sourceValue is S3Bucket)
                return ((S3Bucket)sourceValue).BucketName;

            if (sourceValue is PSObject)
            {
                PSObject pso = sourceValue as PSObject;
                if (pso.BaseObject != null && pso.BaseObject is S3Bucket)
                    return ((S3Bucket)pso.BaseObject).BucketName;
            }

            return null;
        }

        public override object ConvertTo(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase)
        {
            return null;
        }
    }
}
