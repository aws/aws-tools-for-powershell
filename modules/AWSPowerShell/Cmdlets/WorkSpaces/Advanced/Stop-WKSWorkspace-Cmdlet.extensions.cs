/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    public partial class StopWKSWorkspaceCmdlet
    {
        #region Parameter WorkspaceId
        /// <summary>
        /// The IDs of one or more WorkSpaces to be stopped.
        /// </summary>
        /// <returns></returns>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "SimpleId")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public string[] WorkspaceId { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (this.WorkspaceId != null)
            {
                var stopRequests = new List<Amazon.WorkSpaces.Model.StopRequest>();
                foreach (var id in this.WorkspaceId)
                {
                    stopRequests.Add(new StopRequest { WorkspaceId = id });
                }
                cmdletContext.Request = stopRequests;
            }
        }       
    }
}
