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

using Amazon.PowerShell.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public partial class GetS3ObjectV2Cmdlet
    {
        #region Parameter Key 
        /// <summary>
        /// Key value identifying a single object in S3 to return metadata for.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = "GetSingleObject", ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Key { get; set; }
        #endregion

        #region Parameter EnableLegacyKeyCleaning
        /// <summary>
        /// Specifies whether to use legacy key cleaning behavior for S3 key names. When this switch is present,
        /// the cmdlet will clean key names by removing leading spaces, forward slashes (/), and backslashes (\),
        /// converting all backslashes to forward slashes, and removing trailing spaces. When not specified,
        /// the legacy key cleaning is disabled.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter EnableLegacyKeyCleaning { get; set; }
        #endregion

        // try and anticipate all the ways a user might mean 'get everything from root'
        readonly string[] rootIndicators = new string[] { "/", @"\", "*", "/*", @"\*" };

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (this.Key != null)
            {
                string key = this.Key;
                if (this.EnableLegacyKeyCleaning.IsPresent)
                {
                    key = AmazonS3Helper.CleanKey(this.Key);
                    base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.Key, key);
                }

                this.Key = key;
                cmdletContext.Prefix = key;
            }
            else
            {
                cmdletContext.Prefix = rootIndicators.Contains<string>(this.Prefix, StringComparer.OrdinalIgnoreCase)
                    ? null : this.EnableLegacyKeyCleaning.IsPresent ? AmazonS3Helper.CleanKey(this.Prefix) : this.Prefix;
                base.UserAgentAddition = this.EnableLegacyKeyCleaning.IsPresent ? AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.Prefix, cmdletContext.Prefix) : base.UserAgentAddition;
            }
        }

        protected override void ProcessOutput(CmdletOutput cmdletOutput)
        {
            if (cmdletOutput == null)
                return;

            if (this.Key != null && cmdletOutput.PipelineOutput is System.Collections.Generic.List<Amazon.S3.Model.S3Object> objects)
            {
                cmdletOutput.PipelineOutput = objects.Where(b => b.Key == this.Key).ToList();
            }

            base.ProcessOutput(cmdletOutput);
        }
    }
}
