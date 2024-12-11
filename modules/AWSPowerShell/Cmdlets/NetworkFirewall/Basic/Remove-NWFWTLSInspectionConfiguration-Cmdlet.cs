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
    /// Deletes the specified <a>TLSInspectionConfiguration</a>.
    /// </summary>
    [Cmdlet("Remove", "NWFWTLSInspectionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.NetworkFirewall.Model.TLSInspectionConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DeleteTLSInspectionConfiguration API operation.", Operation = new[] {"DeleteTLSInspectionConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.TLSInspectionConfigurationResponse or Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.TLSInspectionConfigurationResponse object.",
        "The service call response (type Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveNWFWTLSInspectionConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TLSInspectionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the TLS inspection configuration.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TLSInspectionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter TLSInspectionConfigurationName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the TLS inspection configuration. You can't change the name
        /// of a TLS inspection configuration after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TLSInspectionConfigurationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TLSInspectionConfigurationResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TLSInspectionConfigurationResponse";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NWFWTLSInspectionConfiguration (DeleteTLSInspectionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse, RemoveNWFWTLSInspectionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TLSInspectionConfigurationArn = this.TLSInspectionConfigurationArn;
            context.TLSInspectionConfigurationName = this.TLSInspectionConfigurationName;
            
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
            var request = new Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationRequest();
            
            if (cmdletContext.TLSInspectionConfigurationArn != null)
            {
                request.TLSInspectionConfigurationArn = cmdletContext.TLSInspectionConfigurationArn;
            }
            if (cmdletContext.TLSInspectionConfigurationName != null)
            {
                request.TLSInspectionConfigurationName = cmdletContext.TLSInspectionConfigurationName;
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
        
        private Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DeleteTLSInspectionConfiguration");
            try
            {
                #if DESKTOP
                return client.DeleteTLSInspectionConfiguration(request);
                #elif CORECLR
                return client.DeleteTLSInspectionConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String TLSInspectionConfigurationArn { get; set; }
            public System.String TLSInspectionConfigurationName { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DeleteTLSInspectionConfigurationResponse, RemoveNWFWTLSInspectionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TLSInspectionConfigurationResponse;
        }
        
    }
}
