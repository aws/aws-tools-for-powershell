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
using Amazon.PowerShell.Common;
using Amazon.EC2.Model;
using Amazon.EC2.Util;
using Amazon.EC2;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    public partial class NewEC2LaunchTemplateCmdlet
    {
        #region Parameter SourceTemplateData
        /// <summary>
        /// <para>
        /// The information for the launch template, returned from a call to Get-EC2LaunchTemplateData. The data
        /// will be used to construct the data for the -LaunchTemplateData parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.ResponseLaunchTemplateData SourceTemplateData { get; set; }
        #endregion

        protected override void PreExecutionContextLoad(ExecutorContext context)
        {
            if (this.SourceTemplateData != null)
            {
                this.LaunchTemplateData = AmazonEC2Helper.FromResponseTemplateData(this.SourceTemplateData);
            }
        }
    }
}
