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
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Kinesis;
using System.IO;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    public partial class WriteKINRecordCmdlet
    {
        #region Parameter Text
        /// <summary>
        /// This parameter is obsolete and will be removed in a future version. Use 'Record_Data' instead.
        /// Text string containing the data to send, which is base64-encoded when the 
        /// blob is serialized. When the data blob (the payload before base64-encoding) is added to 
        /// the partition key size, the total size must not exceed the maximum record size (1 MB).
        /// </summary>
        [System.Management.Automation.Parameter(ParameterSetName = "FromText", Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is obsolete and will be removed in a future version. Use 'Record_Data' instead.")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Record_Text")]
        public string Text { get; set; }
        #endregion

        #region Parameter FilePath
        /// <summary>
        /// This parameter is obsolete and will be removed in a future version. Use 'Record_Data' instead.
        /// The fully qualified name to a file containing the data to send, which is base64-encoded 
        /// when the blob is serialized. When the data blob (the payload before base64-encoding) is 
        /// added to the partition key size, the total size must not exceed the maximum record size (1 MB).
        /// </summary>
        [System.Management.Automation.Parameter(ParameterSetName = "FromFile", Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is obsolete and will be removed in a future version. Use 'Record_Data' instead.")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Record_FilePath")]
        public string FilePath { get; set; }
        #endregion

        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FilePath != null)
            {
                if (!File.Exists(this.FilePath))
                    ThrowArgumentError("File not found", this.FilePath);
                cmdletContext.Data = File.ReadAllBytes(this.FilePath);
            }
            if (this.Text != null)
            {
                cmdletContext.Data = Encoding.UTF8.GetBytes(this.Text);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
        }
    }
}
