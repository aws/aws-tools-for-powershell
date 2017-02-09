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

using System.IO;
using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    internal static class AmazonEC2Helper
    {
        /// <summary>
        /// Converts a list of string instance ids, RunningInstance objects or Reservation objects 
        /// to a collection of string instance ids
        /// </summary>
        /// <param name="instances"></param>
        /// <returns></returns>
        public static List<string> InstanceParamToIDs(params object[] instances)
        {
            var ids = new List<string>();
            if (instances != null)
            {
                foreach (object o in instances)
                {
                    string instanceId = string.Empty;
                    var reservation = o as Reservation;
                    if (reservation != null)
                    {
                        ids.AddRange(reservation.Instances.Select(ri => ri.InstanceId));
                        continue;
                    }

                    var runningInstance = o as Instance;
                    if (runningInstance != null)
                    {
                        ids.Add(runningInstance.InstanceId);
                        continue;
                    }

                    // PSObject type can be obtained if the user does this:
                    //    PS C:\> $instanceid = Get-EC2InstanceMetadata -Category InstanceId
                    //    (or $instanceid = Invoke-RestMethod 'http://169.254.169.254/latest/meta-data/instance-id')
                    //    PS C:\> Get-EC2Instance -InstanceId $instanceid
                    // $instanceid appears as a string when inspected, but the 'as string' cast
                    // fails. If they quote surround $instanceid though, the 'as string' 
                    // cast succeeds (as you'd hope). Calling ToString on the PSObject
                    // gets us what we need.
                    var psobject = o as System.Management.Automation.PSObject;
                    if (psobject != null)
                    {
                        ids.Add(psobject.ToString());
                        continue;
                    }

                    var id = o as string;
                    if (id != null)
                    {
                        ids.Add(id);
                    }
                }
            }
            return ids;
        }

        public static string LoadUserData(string userData, string userDataFile, bool encodeData)
        {
            if (userData == null && userDataFile == null)
                return null;

            string loadedData;
            if (!string.IsNullOrEmpty(userDataFile))
            {
                // coreclr StreamReader does not have ctor that takes filename
                using (var stream = File.OpenRead(userDataFile))
                using (var reader = new StreamReader(stream))
                {
                    loadedData = reader.ReadToEnd();
                }
            }
            else
                loadedData = userData;

            return encodeData
                ? Convert.ToBase64String(Encoding.UTF8.GetBytes(loadedData))
                : loadedData;
        }
    }
}
