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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modify the instance metadata parameters on a running or stopped instance. When you
    /// modify the parameters on a stopped instance, they are applied when the instance is
    /// started. When you modify the parameters on a running instance, the API responds with
    /// a state of “pending”. After the parameter modifications are successfully applied to
    /// the instance, the state of the modifications changes from “pending” to “applied” in
    /// subsequent describe-instances API calls. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-metadata.html">Instance
    /// metadata and user data</a> in the <i>Amazon EC2 User Guide</i>.
    /// </summary>
    [Cmdlet("Edit", "EC2InstanceMetadataOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyInstanceMetadataOptions API operation.", Operation = new[] {"ModifyInstanceMetadataOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse object containing multiple properties."
    )]
    public partial class EditEC2InstanceMetadataOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter HttpEndpoint
        /// <summary>
        /// <para>
        /// <para>Enables or disables the HTTP metadata endpoint on your instances. If this parameter
        /// is not specified, the existing state is maintained.</para><para>If you specify a value of <c>disabled</c>, you cannot access your instance metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceMetadataEndpointState")]
        public Amazon.EC2.InstanceMetadataEndpointState HttpEndpoint { get; set; }
        #endregion
        
        #region Parameter HttpProtocolIpv6
        /// <summary>
        /// <para>
        /// <para>Enables or disables the IPv6 endpoint for the instance metadata service. Applies only
        /// if you enabled the HTTP metadata endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceMetadataProtocolState")]
        public Amazon.EC2.InstanceMetadataProtocolState HttpProtocolIpv6 { get; set; }
        #endregion
        
        #region Parameter HttpPutResponseHopLimit
        /// <summary>
        /// <para>
        /// <para>The desired HTTP PUT response hop limit for instance metadata requests. The larger
        /// the number, the further instance metadata requests can travel. If no parameter is
        /// specified, the existing state is maintained.</para><para>Possible values: Integers from 1 to 64</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter HttpToken
        /// <summary>
        /// <para>
        /// <para>Indicates whether IMDSv2 is required.</para><ul><li><para><c>optional</c> - IMDSv2 is optional. You can choose whether to send a session token
        /// in your instance metadata retrieval requests. If you retrieve IAM role credentials
        /// without a session token, you receive the IMDSv1 role credentials. If you retrieve
        /// IAM role credentials using a valid session token, you receive the IMDSv2 role credentials.</para></li><li><para><c>required</c> - IMDSv2 is required. You must send a session token in your instance
        /// metadata retrieval requests. With this option, retrieving the IAM role credentials
        /// always returns IMDSv2 credentials; IMDSv1 credentials are not available.</para></li></ul><para>Default:</para><ul><li><para>If the value of <c>ImdsSupport</c> for the Amazon Machine Image (AMI) for your instance
        /// is <c>v2.0</c> and the account level default is set to <c>no-preference</c>, the default
        /// is <c>required</c>.</para></li><li><para>If the value of <c>ImdsSupport</c> for the Amazon Machine Image (AMI) for your instance
        /// is <c>v2.0</c>, but the account level default is set to <c>V1 or V2</c>, the default
        /// is <c>optional</c>.</para></li></ul><para>The default value can also be affected by other combinations of parameters. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/configuring-instance-metadata-options.html#instance-metadata-options-order-of-precedence">Order
        /// of precedence for instance metadata options</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HttpTokens")]
        [AWSConstantClassSource("Amazon.EC2.HttpTokensState")]
        public Amazon.EC2.HttpTokensState HttpToken { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter InstanceMetadataTag
        /// <summary>
        /// <para>
        /// <para>Set to <c>enabled</c> to allow access to instance tags from the instance metadata.
        /// Set to <c>disabled</c> to turn off access to instance tags from the instance metadata.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html#work-with-tags-in-IMDS">Work
        /// with instance tags using the instance metadata</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceMetadataTags")]
        [AWSConstantClassSource("Amazon.EC2.InstanceMetadataTagsState")]
        public Amazon.EC2.InstanceMetadataTagsState InstanceMetadataTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstanceMetadataOption (ModifyInstanceMetadataOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse, EditEC2InstanceMetadataOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.HttpEndpoint = this.HttpEndpoint;
            context.HttpProtocolIpv6 = this.HttpProtocolIpv6;
            context.HttpPutResponseHopLimit = this.HttpPutResponseHopLimit;
            context.HttpToken = this.HttpToken;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceMetadataTag = this.InstanceMetadataTag;
            
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
            var request = new Amazon.EC2.Model.ModifyInstanceMetadataOptionsRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.HttpEndpoint != null)
            {
                request.HttpEndpoint = cmdletContext.HttpEndpoint;
            }
            if (cmdletContext.HttpProtocolIpv6 != null)
            {
                request.HttpProtocolIpv6 = cmdletContext.HttpProtocolIpv6;
            }
            if (cmdletContext.HttpPutResponseHopLimit != null)
            {
                request.HttpPutResponseHopLimit = cmdletContext.HttpPutResponseHopLimit.Value;
            }
            if (cmdletContext.HttpToken != null)
            {
                request.HttpTokens = cmdletContext.HttpToken;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.InstanceMetadataTag != null)
            {
                request.InstanceMetadataTags = cmdletContext.InstanceMetadataTag;
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
        
        private Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstanceMetadataOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyInstanceMetadataOptions");
            try
            {
                return client.ModifyInstanceMetadataOptionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public Amazon.EC2.InstanceMetadataEndpointState HttpEndpoint { get; set; }
            public Amazon.EC2.InstanceMetadataProtocolState HttpProtocolIpv6 { get; set; }
            public System.Int32? HttpPutResponseHopLimit { get; set; }
            public Amazon.EC2.HttpTokensState HttpToken { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.EC2.InstanceMetadataTagsState InstanceMetadataTag { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyInstanceMetadataOptionsResponse, EditEC2InstanceMetadataOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
