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

namespace Amazon.PowerShell.Cmdlets.LM
{
    public partial class PublishLMFunctionCmdlet
    {
        #region Parameter ZipFilename
        /// <summary>
        /// <para>
        /// This parameter is obsolete and will be removed in a future version. Use 'Code_ZipFile' instead.
        /// The path to a zip file containing your deployment package. For more information about creating a .zip file,
        /// go to <a href="http://docs.aws.amazon.com/lambda/latest/dg/intro-permission-model.html#lambda-intro-execution-role.html">Execution
        /// Permissions</a> in the <i>AWS Lambda Developer Guide</i>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, Mandatory = true, ParameterSetName = "FromZipFile", ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is obsolete and will be removed in a future version. Use 'Code_ZipFile' instead.")]
        [Alias("FunctionZip", "Filename")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ZipFilename { get; set; }
        #endregion

        #region Parameter Publish
        /// <summary>
        /// <para>
        /// This parameter is obsolete. Use PublishVersion instead.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Obsolete("This parameter is obsolete. Use PublishVersion instead.")]
        public SwitchParameter Publish { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ZipFilename != null)
            {
                var fqZipFilename = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.ZipFilename);
                if (!File.Exists(fqZipFilename))
                {
                    this.ThrowArgumentError($"'{this.ZipFilename}' ('{fqZipFilename}') is not a valid file path for the ZipFilename parameter.", this);
                }
                cmdletContext.Code_ZipFile = File.ReadAllBytes(fqZipFilename);
            }

            if (this.Publish.IsPresent)
            {
                cmdletContext.PublishVersion = true;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
        }
    }
}
