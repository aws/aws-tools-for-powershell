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
using Amazon.Wickr;
using Amazon.Wickr.Model;

namespace Amazon.PowerShell.Cmdlets.WIC
{
    /// <summary>
    /// Creates a new Wickr network with specified access level and configuration. This operation
    /// provisions a new communication network for your organization.
    /// </summary>
    [Cmdlet("New", "WICNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Wickr.Model.CreateNetworkResponse")]
    [AWSCmdlet("Calls the AWS Wickr Admin API CreateNetwork API operation.", Operation = new[] {"CreateNetwork"}, SelectReturnType = typeof(Amazon.Wickr.Model.CreateNetworkResponse))]
    [AWSCmdletOutput("Amazon.Wickr.Model.CreateNetworkResponse",
        "This cmdlet returns an Amazon.Wickr.Model.CreateNetworkResponse object containing multiple properties."
    )]
    public partial class NewWICNetworkCmdlet : AmazonWickrClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessLevel
        /// <summary>
        /// <para>
        /// <para>The access level for the network. Valid values are STANDARD or PREMIUM, which determine
        /// the features and capabilities available to network members.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Wickr.AccessLevel")]
        public Amazon.Wickr.AccessLevel AccessLevel { get; set; }
        #endregion
        
        #region Parameter EnablePremiumFreeTrial
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable a premium free trial for the network. It is optional and
        /// has a default value as false. When set to true, the network starts with premium features
        /// for a limited trial period. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePremiumFreeTrial { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services KMS customer managed key to use for encrypting
        /// sensitive data in the network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter NetworkName
        /// <summary>
        /// <para>
        /// <para>The name for the new network. Must be between 1 and 20 characters.</para>
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
        public System.String NetworkName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Wickr.Model.CreateNetworkResponse).
        /// Specifying the name of a property of type Amazon.Wickr.Model.CreateNetworkResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WICNetwork (CreateNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Wickr.Model.CreateNetworkResponse, NewWICNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessLevel = this.AccessLevel;
            #if MODULAR
            if (this.AccessLevel == null && ParameterWasBound(nameof(this.AccessLevel)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessLevel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnablePremiumFreeTrial = this.EnablePremiumFreeTrial;
            context.EncryptionKeyArn = this.EncryptionKeyArn;
            context.NetworkName = this.NetworkName;
            #if MODULAR
            if (this.NetworkName == null && ParameterWasBound(nameof(this.NetworkName)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Wickr.Model.CreateNetworkRequest();
            
            if (cmdletContext.AccessLevel != null)
            {
                request.AccessLevel = cmdletContext.AccessLevel;
            }
            if (cmdletContext.EnablePremiumFreeTrial != null)
            {
                request.EnablePremiumFreeTrial = cmdletContext.EnablePremiumFreeTrial.Value;
            }
            if (cmdletContext.EncryptionKeyArn != null)
            {
                request.EncryptionKeyArn = cmdletContext.EncryptionKeyArn;
            }
            if (cmdletContext.NetworkName != null)
            {
                request.NetworkName = cmdletContext.NetworkName;
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
        
        private Amazon.Wickr.Model.CreateNetworkResponse CallAWSServiceOperation(IAmazonWickr client, Amazon.Wickr.Model.CreateNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Wickr Admin API", "CreateNetwork");
            try
            {
                #if DESKTOP
                return client.CreateNetwork(request);
                #elif CORECLR
                return client.CreateNetworkAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Wickr.AccessLevel AccessLevel { get; set; }
            public System.Boolean? EnablePremiumFreeTrial { get; set; }
            public System.String EncryptionKeyArn { get; set; }
            public System.String NetworkName { get; set; }
            public System.Func<Amazon.Wickr.Model.CreateNetworkResponse, NewWICNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
