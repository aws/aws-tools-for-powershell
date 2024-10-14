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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// High-level information about a rule group, returned by operations like create and
    /// describe. You can use the information provided in the metadata to retrieve and manage
    /// a rule group. You can retrieve all objects for a rule group by calling <a>DescribeRuleGroup</a>.
    /// </summary>
    [Cmdlet("Get", "NWFWRuleGroupMetadata")]
    [OutputType("Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DescribeRuleGroupMetadata API operation.", Operation = new[] {"DescribeRuleGroupMetadata"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse object containing multiple properties."
    )]
    public partial class GetNWFWRuleGroupMetadataCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RuleGroupArn
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the rule group. You can't change the name of a rule group
        /// after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RuleGroupArn { get; set; }
        #endregion
        
        #region Parameter RuleGroupName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the rule group. You can't change the name of a rule group
        /// after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleGroupName { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Indicates whether the rule group is stateless or stateful. If the rule group is stateless,
        /// it contains stateless rules. If it is stateful, it contains stateful rules. </para><note><para>This setting is required for requests that do not include the <c>RuleGroupARN</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.RuleGroupType")]
        public Amazon.NetworkFirewall.RuleGroupType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleGroupArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleGroupArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleGroupArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse, GetNWFWRuleGroupMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleGroupArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RuleGroupArn = this.RuleGroupArn;
            context.RuleGroupName = this.RuleGroupName;
            context.Type = this.Type;
            
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
            var request = new Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataRequest();
            
            if (cmdletContext.RuleGroupArn != null)
            {
                request.RuleGroupArn = cmdletContext.RuleGroupArn;
            }
            if (cmdletContext.RuleGroupName != null)
            {
                request.RuleGroupName = cmdletContext.RuleGroupName;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DescribeRuleGroupMetadata");
            try
            {
                #if DESKTOP
                return client.DescribeRuleGroupMetadata(request);
                #elif CORECLR
                return client.DescribeRuleGroupMetadataAsync(request).GetAwaiter().GetResult();
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
            public System.String RuleGroupArn { get; set; }
            public System.String RuleGroupName { get; set; }
            public Amazon.NetworkFirewall.RuleGroupType Type { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DescribeRuleGroupMetadataResponse, GetNWFWRuleGroupMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
