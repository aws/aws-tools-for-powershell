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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Update the attributes for a custom routing accelerator.
    /// </summary>
    [Cmdlet("Update", "GACLCustomRoutingAcceleratorAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.CustomRoutingAcceleratorAttributes")]
    [AWSCmdlet("Calls the AWS Global Accelerator UpdateCustomRoutingAcceleratorAttributes API operation.", Operation = new[] {"UpdateCustomRoutingAcceleratorAttributes"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.CustomRoutingAcceleratorAttributes or Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.CustomRoutingAcceleratorAttributes object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGACLCustomRoutingAcceleratorAttributeCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        #region Parameter AcceleratorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the custom routing accelerator to update attributes
        /// for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FlowLogsEnabled { get; set; }
        #endregion
        
        #region Parameter FlowLogsS3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket for the flow logs. Attribute is required if <code>FlowLogsEnabled</code>
        /// is <code>true</code>. The bucket must exist and have a bucket policy that grants AWS
        /// Global Accelerator permission to write to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowLogsS3Bucket { get; set; }
        #endregion
        
        #region Parameter FlowLogsS3Prefix
        /// <summary>
        /// <para>
        /// <para>Update the prefix for the location in the Amazon S3 bucket for the flow logs. Attribute
        /// is required if <code>FlowLogsEnabled</code> is <code>true</code>. </para><para>If you don’t specify a prefix, the flow logs are stored in the root of the bucket.
        /// If you specify slash (/) for the S3 bucket prefix, the log file bucket folder structure
        /// will include a double slash (//), like the following:</para><para>DOC-EXAMPLE-BUCKET//AWSLogs/aws_account_id</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowLogsS3Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcceleratorAttributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcceleratorAttributes";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AcceleratorArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AcceleratorArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AcceleratorArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AcceleratorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GACLCustomRoutingAcceleratorAttribute (UpdateCustomRoutingAcceleratorAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse, UpdateGACLCustomRoutingAcceleratorAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AcceleratorArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceleratorArn = this.AcceleratorArn;
            #if MODULAR
            if (this.AcceleratorArn == null && ParameterWasBound(nameof(this.AcceleratorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AcceleratorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesRequest();
            
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "UpdateCustomRoutingAcceleratorAttributes");
            try
            {
                #if DESKTOP
                return client.UpdateCustomRoutingAcceleratorAttributes(request);
                #elif CORECLR
                return client.UpdateCustomRoutingAcceleratorAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.GlobalAccelerator.Model.UpdateCustomRoutingAcceleratorAttributesResponse, UpdateGACLCustomRoutingAcceleratorAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AcceleratorAttributes;
        }
        
    }
}
