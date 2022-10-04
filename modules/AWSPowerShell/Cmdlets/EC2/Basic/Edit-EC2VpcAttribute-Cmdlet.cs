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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified attribute of the specified VPC.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName="DnsSupport")]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcAttribute API operation.", Operation = new[] {"ModifyVpcAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcAttributeResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifyVpcAttributeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifyVpcAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpcAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter EnableDnsHostname
        /// <summary>
        /// <para>
        /// <para>Indicates whether the instances launched in the VPC get DNS hostnames. If enabled,
        /// instances in the VPC get DNS hostnames; otherwise, they do not.</para><para>You cannot modify the DNS resolution and DNS hostnames attributes in the same request.
        /// Use separate requests for each attribute. You can only enable DNS hostnames if you've
        /// enabled DNS support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "DnsHostnames")]
        [Alias("EnableDnsHostnames")]
        public System.Boolean? EnableDnsHostname { get; set; }
        #endregion
        
        #region Parameter EnableDnsSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether the DNS resolution is supported for the VPC. If enabled, queries
        /// to the Amazon provided DNS server at the 169.254.169.253 IP address, or the reserved
        /// IP address at the base of the VPC network range "plus two" succeed. If disabled, the
        /// Amazon provided DNS service in the VPC that resolves public DNS hostnames to IP addresses
        /// is not enabled.</para><para>You cannot modify the DNS resolution and DNS hostnames attributes in the same request.
        /// Use separate requests for each attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "DnsSupport")]
        public System.Boolean? EnableDnsSupport { get; set; }
        #endregion
        
        #region Parameter EnableNetworkAddressUsageMetric
        /// <summary>
        /// <para>
        /// <para>Indicates whether Network Address Usage metrics are enabled for your VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableNetworkAddressUsageMetrics")]
        public System.Boolean? EnableNetworkAddressUsageMetric { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcAttributeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcAttribute (ModifyVpcAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcAttributeResponse, EditEC2VpcAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EnableDnsHostname = this.EnableDnsHostname;
            context.EnableDnsSupport = this.EnableDnsSupport;
            context.EnableNetworkAddressUsageMetric = this.EnableNetworkAddressUsageMetric;
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpcAttributeRequest();
            
            if (cmdletContext.EnableDnsHostname != null)
            {
                request.EnableDnsHostnames = cmdletContext.EnableDnsHostname.Value;
            }
            if (cmdletContext.EnableDnsSupport != null)
            {
                request.EnableDnsSupport = cmdletContext.EnableDnsSupport.Value;
            }
            if (cmdletContext.EnableNetworkAddressUsageMetric != null)
            {
                request.EnableNetworkAddressUsageMetrics = cmdletContext.EnableNetworkAddressUsageMetric.Value;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.EC2.Model.ModifyVpcAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyVpcAttribute(request);
                #elif CORECLR
                return client.ModifyVpcAttributeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? EnableDnsHostname { get; set; }
            public System.Boolean? EnableDnsSupport { get; set; }
            public System.Boolean? EnableNetworkAddressUsageMetric { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcAttributeResponse, EditEC2VpcAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
