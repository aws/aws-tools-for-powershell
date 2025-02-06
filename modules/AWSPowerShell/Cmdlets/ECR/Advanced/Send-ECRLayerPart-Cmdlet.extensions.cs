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

using System;
using Amazon.PowerShell.Common;
using System.Text;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    public partial class SendECRLayerPartCmdlet
    {
        #region Parameter LayerPartStream
        /// <summary>
        /// This parameter is obsolete and will be removed in a future version. Use 'LayerPartBytes' instead.
        /// The base64-encoded layer part payload.
        /// The fully qualified name to a file containing the data to be used instead of the Record_Data parameter.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName="FromStream", Mandatory = true)]
        [System.ObsoleteAttribute("This parameter is obsolete and will be removed in a future version. Use 'LayerPartBytes' instead.")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.IO.MemoryStream LayerPartStream { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.LayerPartStream != null)
            {
                cmdletContext.LayerPartBlob = LayerPartStream.ToArray();
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
        }
    }
}
