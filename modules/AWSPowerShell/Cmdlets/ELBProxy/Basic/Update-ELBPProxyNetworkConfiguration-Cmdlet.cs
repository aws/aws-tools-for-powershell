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
using Amazon.ELBProxy;
using Amazon.ELBProxy.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ELBP
{
    /// <summary>
    /// Updates the network configuration for the specified proxy.
    /// </summary>
    [Cmdlet("Update", "ELBPProxyNetworkConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse")]
    [AWSCmdlet("Calls the Elastic Load Balancing for Envoy UpdateProxyNetworkConfiguration API operation.", Operation = new[] {"UpdateProxyNetworkConfiguration"}, SelectReturnType = typeof(Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse",
        "This cmdlet returns an Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateELBPProxyNetworkConfigurationCmdlet : AmazonELBProxyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProxyIdentifier
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the
        /// proxy.
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
        public System.String ProxyIdentifier { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// The updated security groups for the proxy.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SecurityGroups")]
        public Amazon.ELBProxy.Model.SecurityGroupDetails[] VpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// The updated subnets for the proxy.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_Subnets")]
        public Amazon.ELBProxy.Model.SubnetDetails[] VpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProxyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ELBPProxyNetworkConfiguration (UpdateProxyNetworkConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse, UpdateELBPProxyNetworkConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProxyIdentifier = this.ProxyIdentifier;
            #if MODULAR
            if (this.ProxyIdentifier == null && ParameterWasBound(nameof(this.ProxyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ProxyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcConfiguration_SecurityGroup != null)
            {
                context.VpcConfiguration_SecurityGroup = new List<Amazon.ELBProxy.Model.SecurityGroupDetails>(this.VpcConfiguration_SecurityGroup);
            }
            if (this.VpcConfiguration_Subnet != null)
            {
                context.VpcConfiguration_Subnet = new List<Amazon.ELBProxy.Model.SubnetDetails>(this.VpcConfiguration_Subnet);
            }
            
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
            var request = new Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationRequest();
            
            if (cmdletContext.ProxyIdentifier != null)
            {
                request.ProxyIdentifier = cmdletContext.ProxyIdentifier;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.ELBProxy.Model.UpdateProxyVpcConfiguration();
            List<Amazon.ELBProxy.Model.SecurityGroupDetails> requestVpcConfiguration_vpcConfiguration_SecurityGroup = null;
            if (cmdletContext.VpcConfiguration_SecurityGroup != null)
            {
                requestVpcConfiguration_vpcConfiguration_SecurityGroup = cmdletContext.VpcConfiguration_SecurityGroup;
            }
            if (requestVpcConfiguration_vpcConfiguration_SecurityGroup != null)
            {
                request.VpcConfiguration.SecurityGroups = requestVpcConfiguration_vpcConfiguration_SecurityGroup;
                requestVpcConfigurationIsNull = false;
            }
            List<Amazon.ELBProxy.Model.SubnetDetails> requestVpcConfiguration_vpcConfiguration_Subnet = null;
            if (cmdletContext.VpcConfiguration_Subnet != null)
            {
                requestVpcConfiguration_vpcConfiguration_Subnet = cmdletContext.VpcConfiguration_Subnet;
            }
            if (requestVpcConfiguration_vpcConfiguration_Subnet != null)
            {
                request.VpcConfiguration.Subnets = requestVpcConfiguration_vpcConfiguration_Subnet;
                requestVpcConfigurationIsNull = false;
            }
             // determine if request.VpcConfiguration should be set to null
            if (requestVpcConfigurationIsNull)
            {
                request.VpcConfiguration = null;
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
        
        private Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse CallAWSServiceOperation(IAmazonELBProxy client, Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing for Envoy", "UpdateProxyNetworkConfiguration");
            try
            {
                return client.UpdateProxyNetworkConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProxyIdentifier { get; set; }
            public List<Amazon.ELBProxy.Model.SecurityGroupDetails> VpcConfiguration_SecurityGroup { get; set; }
            public List<Amazon.ELBProxy.Model.SubnetDetails> VpcConfiguration_Subnet { get; set; }
            public System.Func<Amazon.ELBProxy.Model.UpdateProxyNetworkConfigurationResponse, UpdateELBPProxyNetworkConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
