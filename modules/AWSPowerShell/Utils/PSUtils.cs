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
using System.Text;
using System.Management.Automation.Runspaces;
using System.Collections;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Amazon.PowerShell.Utils
{
    public static class PSUtils
    {
        public static void UpdateProgress(int activityId, string activity, string status)
        {
            string command = string.Format("Write-Progress -Id {0} -Activity \"{1}\" -Status \"{2}\"",
                activityId, activity, status);
            InvokeCommand(command);
        }

        public static IList<PSObject> InvokeCommand(string command, IEnumerable input = null)
        {
            Runspace runspace = Runspace.DefaultRunspace;
            using (Pipeline pipeline = runspace.CreateNestedPipeline(command, false))
            {
                Collection<PSObject> response;
                if (input == null)
                    response = pipeline.Invoke();
                else
                    response = pipeline.Invoke(input);

                return response;
            }
        }
    }
}
