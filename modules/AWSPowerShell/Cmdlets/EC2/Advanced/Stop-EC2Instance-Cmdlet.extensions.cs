/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.PowerShell.Common;
using Amazon.EC2.Model;
using Amazon.EC2;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    public partial class StopEC2InstanceCmdlet
    {
        #region Parameter ForceStop
        /// <summary>
        /// The ForceStop parameter is deprecated and will be removed in a future version. Use Enforce instead.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Obsolete("The ForceStop parameter is deprecated and will be removed in a future version. Use Enforce instead.")]
        public SwitchParameter ForceStop { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ForceStop.IsPresent)
            {
                cmdletContext.Enforce = true;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
        }      
    }
}
