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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Update the attributes for an accelerator. To see an AWS CLI example of updating an
    /// accelerator to enable flow logs, scroll down to <b>Example</b>.
    /// </summary>
    [Cmdlet("Update", "GACLAcceleratorAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.AcceleratorAttributes")]
    [AWSCmdlet("Calls the AWS Global Accelerator UpdateAcceleratorAttributes API operation.", Operation = new[] {"UpdateAcceleratorAttributes"})]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.AcceleratorAttributes",
        "This cmdlet returns a AcceleratorAttributes object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.UpdateAcceleratorAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGACLAcceleratorAttributeCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        #region Parameter AcceleratorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the accelerator that you want to update. Attribute
        /// is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AcceleratorArn { get; set; }
        #endregion
        
        #region Parameter FlowLogsEnabled
        /// <summary>
        /// <para>
        /// <para>Update whether flow logs are enabled. The default value is false. If the value is
        /// true, <code>FlowLogsS3Bucket</code> and <code>FlowLogsS3Prefix</code> must be specified.</para><para>For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/monitoring-global-accelerator.flow-logs.html">Flow
        /// Logs</a> in the <i>AWS Global Accelerator Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean FlowLogsEnabled { get; set; }
        #endregion
        
        #region Parameter FlowLogsS3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket for the flow logs. Attribute is required if <code>FlowLogsEnabled</code>
        /// is <code>true</code>. The bucket must exist and have a bucket policy that grants AWS
        /// Global Accelerator permission to write to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FlowLogsS3Bucket { get; set; }
        #endregion
        
        #region Parameter FlowLogsS3Prefix
        /// <summary>
        /// <para>
        /// <para>Update the prefix for the location in the Amazon S3 bucket for the flow logs. Attribute
        /// is required if <code>FlowLogsEnabled</code> is <code>true</code>. If you don’t specify
        /// a prefix, the flow logs are stored in the root of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FlowLogsS3Prefix { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AcceleratorArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GACLAcceleratorAttribute (UpdateAcceleratorAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AcceleratorArn = this.AcceleratorArn;
            if (ParameterWasBound("FlowLogsEnabled"))
                context.FlowLogsEnabled = this.FlowLogsEnabled;
            context.FlowLogsS3Bucket = this.FlowLogsS3Bucket;
            context.FlowLogsS3Prefix = this.FlowLogsS3Prefix;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GlobalAccelerator.Model.UpdateAcceleratorAttributesRequest();
            
            if (cmdletContext.AcceleratorArn != null)
            {
                request.AcceleratorArn = cmdletContext.AcceleratorArn;
            }
            if (cmdletContext.FlowLogsEnabled != null)
            {
                request.FlowLogsEnabled = cmdletContext.FlowLogsEnabled.Value;
            }
            if (cmdletContext.FlowLogsS3Bucket != null)
            {
                request.FlowLogsS3Bucket = cmdletContext.FlowLogsS3Bucket;
            }
            if (cmdletContext.FlowLogsS3Prefix != null)
            {
                request.FlowLogsS3Prefix = cmdletContext.FlowLogsS3Prefix;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AcceleratorAttributes;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.GlobalAccelerator.Model.UpdateAcceleratorAttributesResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.UpdateAcceleratorAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "UpdateAcceleratorAttributes");
            try
            {
                #if DESKTOP
                return client.UpdateAcceleratorAttributes(request);
                #elif CORECLR
                return client.UpdateAcceleratorAttributesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AcceleratorArn { get; set; }
            public System.Boolean? FlowLogsEnabled { get; set; }
            public System.String FlowLogsS3Bucket { get; set; }
            public System.String FlowLogsS3Prefix { get; set; }
        }
        
    }
}
