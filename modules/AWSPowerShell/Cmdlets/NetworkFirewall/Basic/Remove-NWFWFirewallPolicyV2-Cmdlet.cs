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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Deletes the specified <a>FirewallPolicyV2</a>.
    /// </summary>
    [Cmdlet("Remove", "NWFWFirewallPolicyV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.NetworkFirewall.Model.FirewallPolicyV2Response")]
    [AWSCmdlet("Calls the AWS Network Firewall DeleteFirewallPolicyV2 API operation.", Operation = new[] {"DeleteFirewallPolicyV2"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.FirewallPolicyV2Response or Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.FirewallPolicyV2Response object.",
        "The service call response (type Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveNWFWFirewallPolicyV2Cmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FirewallPolicyV2Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Next Generation policy.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyV2Arn { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2Name
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the Next Generation policy. You can't change the name of a
        /// firewall policy after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyV2Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FirewallPolicyV2Response'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FirewallPolicyV2Response";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallPolicyV2Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NWFWFirewallPolicyV2 (DeleteFirewallPolicyV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response, RemoveNWFWFirewallPolicyV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FirewallPolicyV2Arn = this.FirewallPolicyV2Arn;
            context.FirewallPolicyV2Name = this.FirewallPolicyV2Name;
            
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
            var request = new Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Request();
            
            if (cmdletContext.FirewallPolicyV2Arn != null)
            {
                request.FirewallPolicyV2Arn = cmdletContext.FirewallPolicyV2Arn;
            }
            if (cmdletContext.FirewallPolicyV2Name != null)
            {
                request.FirewallPolicyV2Name = cmdletContext.FirewallPolicyV2Name;
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
        
        private Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DeleteFirewallPolicyV2");
            try
            {
                return client.DeleteFirewallPolicyV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FirewallPolicyV2Arn { get; set; }
            public System.String FirewallPolicyV2Name { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DeleteFirewallPolicyV2Response, RemoveNWFWFirewallPolicyV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FirewallPolicyV2Response;
        }
        
    }
}
