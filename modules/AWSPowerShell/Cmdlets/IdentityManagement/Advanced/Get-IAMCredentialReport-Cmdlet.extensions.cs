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
using System.IO;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    public partial class GetIAMCredentialReportCmdlet
    {

        #region Parameter AsTextArray
        /// <summary>
        /// If set the cmdlet will process the memory stream contained in the service response
        /// to the pipeline as a series of lines of text.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SplitLines")]
        public SwitchParameter AsTextArray { get; set; }
        #endregion

        #region Parameter Raw
        /// <summary>
        /// If set the cmdlet output will be a single string containing all of the lines in the
        /// report/
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Raw { get; set; }
        #endregion

        protected override void PreExecutionContextLoad(ExecutorContext context)
        {
            if (ParameterWasBound(nameof(this.Select)) && (AsTextArray.IsPresent || Raw.IsPresent))
            {
                throw new System.ArgumentException("-AsTextArray or -Raw cannot be used when -Select is specified.", nameof(this.Select));
            }
        }

        protected override void ProcessOutput(CmdletOutput cmdletOutput)
        {
            try
            {
                if (cmdletOutput.PipelineOutput != null && (this.AsTextArray.IsPresent || this.Raw.IsPresent))
                {
                    using (var reader = new StreamReader((cmdletOutput.PipelineOutput as Amazon.IdentityManagement.Model.GetCredentialReportResponse).Content))
                    {
                        if (this.Raw.IsPresent)
                        {
                            cmdletOutput.PipelineOutput = reader.ReadToEnd();
                        }
                        else
                        {
                            var lines = new List<string>();
                            var line = reader.ReadLine();
                            while (line != null)
                            {
                                lines.Add(line);
                                line = reader.ReadLine();
                            }
                            cmdletOutput.PipelineOutput = lines;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (cmdletOutput.ErrorResponse != null)
                {
                    cmdletOutput.ErrorResponse = e;
                }
            }

            base.ProcessOutput(cmdletOutput);
        }
    }
}
