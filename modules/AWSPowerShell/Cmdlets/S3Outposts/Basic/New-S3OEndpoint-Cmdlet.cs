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
using Amazon.S3Outposts;
using Amazon.S3Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.S3O
{
    /// <summary>
    /// Creates an endpoint and associates it with the specified Outpost.
    /// 
    ///  <note><para>
    /// It can take up to 5 minutes for this action to finish.
    /// </para></note><para>
    /// Related actions include:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_s3outposts_DeleteEndpoint.html">DeleteEndpoint</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_s3outposts_ListEndpoints.html">ListEndpoints</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "S3OEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon S3 Outposts CreateEndpoint API operation.", Operation = new[] {"CreateEndpoint"}, SelectReturnType = typeof(Amazon.S3Outposts.Model.CreateEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3Outposts.Model.CreateEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3Outposts.Model.CreateEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewS3OEndpointCmdlet : AmazonS3OutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessType
        /// <summary>
        /// <para>
        /// <para>The type of access for the network connectivity for the Amazon S3 on Outposts endpoint.
        /// To use the Amazon Web Services VPC, choose <c>Private</c>. To use the endpoint with
        /// an on-premises network, choose <c>CustomerOwnedIp</c>. If you choose <c>CustomerOwnedIp</c>,
        /// you must also provide the customer-owned IP address pool (CoIP pool).</para><note><para><c>Private</c> is the default access type value.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Outposts.EndpointAccessType")]
        public Amazon.S3Outposts.EndpointAccessType AccessType { get; set; }
        #endregion
        
        #region Parameter CustomerOwnedIpv4Pool
        /// <summary>
        /// <para>
        /// <para>The ID of the customer-owned IPv4 address pool (CoIP pool) for the endpoint. IP addresses
        /// are allocated from this pool for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerOwnedIpv4Pool { get; set; }
        #endregion
        
        #region Parameter OutpostId
        /// <summary>
        /// <para>
        /// <para>The ID of the Outposts. </para>
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
        public System.String OutpostId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the security group to use with the endpoint.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in the selected VPC. The endpoint subnet must belong to the Outpost
        /// that has Amazon S3 on Outposts provisioned.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Outposts.Model.CreateEndpointResponse).
        /// Specifying the name of a property of type Amazon.S3Outposts.Model.CreateEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutpostId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3OEndpoint (CreateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Outposts.Model.CreateEndpointResponse, NewS3OEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessType = this.AccessType;
            context.CustomerOwnedIpv4Pool = this.CustomerOwnedIpv4Pool;
            context.OutpostId = this.OutpostId;
            #if MODULAR
            if (this.OutpostId == null && ParameterWasBound(nameof(this.OutpostId)))
            {
                WriteWarning("You are passing $null as a value for parameter OutpostId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityGroupId = this.SecurityGroupId;
            #if MODULAR
            if (this.SecurityGroupId == null && ParameterWasBound(nameof(this.SecurityGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.S3Outposts.Model.CreateEndpointRequest();
            
            if (cmdletContext.AccessType != null)
            {
                request.AccessType = cmdletContext.AccessType;
            }
            if (cmdletContext.CustomerOwnedIpv4Pool != null)
            {
                request.CustomerOwnedIpv4Pool = cmdletContext.CustomerOwnedIpv4Pool;
            }
            if (cmdletContext.OutpostId != null)
            {
                request.OutpostId = cmdletContext.OutpostId;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupId = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
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
        
        private Amazon.S3Outposts.Model.CreateEndpointResponse CallAWSServiceOperation(IAmazonS3Outposts client, Amazon.S3Outposts.Model.CreateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Outposts", "CreateEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateEndpoint(request);
                #elif CORECLR
                return client.CreateEndpointAsync(request).GetAwaiter().GetResult();
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
            public Amazon.S3Outposts.EndpointAccessType AccessType { get; set; }
            public System.String CustomerOwnedIpv4Pool { get; set; }
            public System.String OutpostId { get; set; }
            public System.String SecurityGroupId { get; set; }
            public System.String SubnetId { get; set; }
            public System.Func<Amazon.S3Outposts.Model.CreateEndpointResponse, NewS3OEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointArn;
        }
        
    }
}
