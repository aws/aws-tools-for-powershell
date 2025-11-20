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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Gets the allocation rules for an IPAM policy.
    /// 
    ///  
    /// <para>
    /// An IPAM policy is a set of rules that define how public IPv4 addresses from IPAM pools
    /// are allocated to Amazon Web Services resources. Each rule maps an Amazon Web Services
    /// service to IPAM pools that the service will use to get IP addresses. A single policy
    /// can have multiple rules and be applied to multiple Amazon Web Services Regions. If
    /// the IPAM pool run out of addresses then the services fallback to Amazon-provided IP
    /// addresses. A policy can be applied to an individual Amazon Web Services account or
    /// an entity within Amazon Web Services Organizations.
    /// </para><para>
    /// Allocation rules are optional configurations within an IPAM policy that map Amazon
    /// Web Services resource types to specific IPAM pools. If no rules are defined, the resource
    /// types default to using Amazon-provided IP addresses.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2IpamPolicyAllocationRule")]
    [OutputType("Amazon.EC2.Model.IpamPolicyDocument")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetIpamPolicyAllocationRules API operation.", Operation = new[] {"GetIpamPolicyAllocationRules"}, SelectReturnType = typeof(Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.IpamPolicyDocument or Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.IpamPolicyDocument objects.",
        "The service call response (type Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2IpamPolicyAllocationRuleCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters for the allocation rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IpamPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM policy for which to get allocation rules.</para>
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
        public System.String IpamPolicyId { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale for which to get the allocation rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type for which to get the allocation rules.</para><para>The Amazon Web Services service or resource type that can use IP addresses through
        /// IPAM policies. Supported services and resource types include:</para><ul><li><para>Elastic IP addresses</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpamPolicyResourceType")]
        public Amazon.EC2.IpamPolicyResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPolicyDocuments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPolicyDocuments";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IpamPolicyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IpamPolicyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IpamPolicyId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse, GetEC2IpamPolicyAllocationRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IpamPolicyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.IpamPolicyId = this.IpamPolicyId;
            #if MODULAR
            if (this.IpamPolicyId == null && ParameterWasBound(nameof(this.IpamPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.EC2.Model.GetIpamPolicyAllocationRulesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IpamPolicyId != null)
            {
                request.IpamPolicyId = cmdletContext.IpamPolicyId;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetIpamPolicyAllocationRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetIpamPolicyAllocationRules");
            try
            {
                #if DESKTOP
                return client.GetIpamPolicyAllocationRules(request);
                #elif CORECLR
                return client.GetIpamPolicyAllocationRulesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.String IpamPolicyId { get; set; }
            public System.String Locale { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.EC2.IpamPolicyResourceType ResourceType { get; set; }
            public System.Func<Amazon.EC2.Model.GetIpamPolicyAllocationRulesResponse, GetEC2IpamPolicyAllocationRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPolicyDocuments;
        }
        
    }
}
