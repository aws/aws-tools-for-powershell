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
    /// Deletes the specified <a>FirewallPolicy</a>.
    /// </summary>
    [Cmdlet("Remove", "NWFWFirewallPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.NetworkFirewall.Model.FirewallPolicyResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DeleteFirewallPolicy API operation.", Operation = new[] {"DeleteFirewallPolicy"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.FirewallPolicyResponse or Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.FirewallPolicyResponse object.",
        "The service call response (type Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveNWFWFirewallPolicyCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FirewallPolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall policy.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FirewallPolicyArn { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall policy. You can't change the name of a firewall
        /// policy after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FirewallPolicyResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FirewallPolicyResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallPolicyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallPolicyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallPolicyArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NWFWFirewallPolicy (DeleteFirewallPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse, RemoveNWFWFirewallPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallPolicyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FirewallPolicyArn = this.FirewallPolicyArn;
            context.FirewallPolicyName = this.FirewallPolicyName;
            
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
            var request = new Amazon.NetworkFirewall.Model.DeleteFirewallPolicyRequest();
            
            if (cmdletContext.FirewallPolicyArn != null)
            {
                request.FirewallPolicyArn = cmdletContext.FirewallPolicyArn;
            }
            if (cmdletContext.FirewallPolicyName != null)
            {
                request.FirewallPolicyName = cmdletContext.FirewallPolicyName;
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
        
        private Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DeleteFirewallPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DeleteFirewallPolicy");
            try
            {
                #if DESKTOP
                return client.DeleteFirewallPolicy(request);
                #elif CORECLR
                return client.DeleteFirewallPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String FirewallPolicyArn { get; set; }
            public System.String FirewallPolicyName { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DeleteFirewallPolicyResponse, RemoveNWFWFirewallPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FirewallPolicyResponse;
        }
        
    }
}
