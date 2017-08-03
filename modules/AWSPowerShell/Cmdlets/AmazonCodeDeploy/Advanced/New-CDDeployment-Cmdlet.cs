/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

using System.Collections.Generic;
using Amazon.PowerShell.Common;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    public partial class NewCDDeploymentCmdlet
    {
        
        #region Parameter Ec2InstanceTagGroup
        /// <summary>
        /// <para>
        /// <para>A list containing other lists of EC2 instance tag groups. In order for an instance
        /// to be included in the deployment group, it must be identified by all the tag groups
        /// in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodeDeploy.Model.EC2TagFilter[][] Ec2InstanceTagGroup { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (this.Ec2InstanceTagGroup != null)
            {
                cmdletContext.Ec2TagSetList = new List<List<Amazon.CodeDeploy.Model.EC2TagFilter>>();
                foreach (var innerList in this.Ec2InstanceTagGroup)
                {
                    cmdletContext.Ec2TagSetList.Add(new List<EC2TagFilter>(innerList));
                }
            }
        }
        
        internal partial class CmdletContext
        {
            public List<List<Amazon.CodeDeploy.Model.EC2TagFilter>> Ec2TagSetList { get; set; }
        }
        
    }
}
