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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates the configuration of an existing router network interface in AWS Elemental
    /// MediaConnect.
    /// </summary>
    [Cmdlet("Update", "EMCNRouterNetworkInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.RouterNetworkInterface")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateRouterNetworkInterface API operation.", Operation = new[] {"UpdateRouterNetworkInterface"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.RouterNetworkInterface or Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.RouterNetworkInterface object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMCNRouterNetworkInterfaceCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Public_AllowRule
        /// <summary>
        /// <para>
        /// <para>The list of allowed CIDR blocks for the public router network interface.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Public_AllowRules")]
        public Amazon.MediaConnect.Model.PublicRouterNetworkInterfaceRule[] Public_AllowRule { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the router network interface that you want to update.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name for the router network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Vpc_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups to associate with the router network interface within
        /// the VPC.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Vpc_SecurityGroupIds")]
        public System.String[] Vpc_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Vpc_SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet within the VPC to associate the router network interface with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Vpc_SubnetId")]
        public System.String Vpc_SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RouterNetworkInterface'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RouterNetworkInterface";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNRouterNetworkInterface (UpdateRouterNetworkInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse, UpdateEMCNRouterNetworkInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Public_AllowRule != null)
            {
                context.Public_AllowRule = new List<Amazon.MediaConnect.Model.PublicRouterNetworkInterfaceRule>(this.Public_AllowRule);
            }
            if (this.Vpc_SecurityGroupId != null)
            {
                context.Vpc_SecurityGroupId = new List<System.String>(this.Vpc_SecurityGroupId);
            }
            context.Vpc_SubnetId = this.Vpc_SubnetId;
            context.Name = this.Name;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.MediaConnect.Model.RouterNetworkInterfaceConfiguration();
            Amazon.MediaConnect.Model.PublicRouterNetworkInterfaceConfiguration requestConfiguration_configuration_Public = null;
            
             // populate Public
            var requestConfiguration_configuration_PublicIsNull = true;
            requestConfiguration_configuration_Public = new Amazon.MediaConnect.Model.PublicRouterNetworkInterfaceConfiguration();
            List<Amazon.MediaConnect.Model.PublicRouterNetworkInterfaceRule> requestConfiguration_configuration_Public_public_AllowRule = null;
            if (cmdletContext.Public_AllowRule != null)
            {
                requestConfiguration_configuration_Public_public_AllowRule = cmdletContext.Public_AllowRule;
            }
            if (requestConfiguration_configuration_Public_public_AllowRule != null)
            {
                requestConfiguration_configuration_Public.AllowRules = requestConfiguration_configuration_Public_public_AllowRule;
                requestConfiguration_configuration_PublicIsNull = false;
            }
             // determine if requestConfiguration_configuration_Public should be set to null
            if (requestConfiguration_configuration_PublicIsNull)
            {
                requestConfiguration_configuration_Public = null;
            }
            if (requestConfiguration_configuration_Public != null)
            {
                request.Configuration.Public = requestConfiguration_configuration_Public;
                requestConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.VpcRouterNetworkInterfaceConfiguration requestConfiguration_configuration_Vpc = null;
            
             // populate Vpc
            var requestConfiguration_configuration_VpcIsNull = true;
            requestConfiguration_configuration_Vpc = new Amazon.MediaConnect.Model.VpcRouterNetworkInterfaceConfiguration();
            List<System.String> requestConfiguration_configuration_Vpc_vpc_SecurityGroupId = null;
            if (cmdletContext.Vpc_SecurityGroupId != null)
            {
                requestConfiguration_configuration_Vpc_vpc_SecurityGroupId = cmdletContext.Vpc_SecurityGroupId;
            }
            if (requestConfiguration_configuration_Vpc_vpc_SecurityGroupId != null)
            {
                requestConfiguration_configuration_Vpc.SecurityGroupIds = requestConfiguration_configuration_Vpc_vpc_SecurityGroupId;
                requestConfiguration_configuration_VpcIsNull = false;
            }
            System.String requestConfiguration_configuration_Vpc_vpc_SubnetId = null;
            if (cmdletContext.Vpc_SubnetId != null)
            {
                requestConfiguration_configuration_Vpc_vpc_SubnetId = cmdletContext.Vpc_SubnetId;
            }
            if (requestConfiguration_configuration_Vpc_vpc_SubnetId != null)
            {
                requestConfiguration_configuration_Vpc.SubnetId = requestConfiguration_configuration_Vpc_vpc_SubnetId;
                requestConfiguration_configuration_VpcIsNull = false;
            }
             // determine if requestConfiguration_configuration_Vpc should be set to null
            if (requestConfiguration_configuration_VpcIsNull)
            {
                requestConfiguration_configuration_Vpc = null;
            }
            if (requestConfiguration_configuration_Vpc != null)
            {
                request.Configuration.Vpc = requestConfiguration_configuration_Vpc;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateRouterNetworkInterface");
            try
            {
                return client.UpdateRouterNetworkInterfaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public List<Amazon.MediaConnect.Model.PublicRouterNetworkInterfaceRule> Public_AllowRule { get; set; }
            public List<System.String> Vpc_SecurityGroupId { get; set; }
            public System.String Vpc_SubnetId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateRouterNetworkInterfaceResponse, UpdateEMCNRouterNetworkInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RouterNetworkInterface;
        }
        
    }
}
