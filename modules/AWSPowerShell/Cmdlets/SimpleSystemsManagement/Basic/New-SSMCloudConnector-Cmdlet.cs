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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Creates a cloud connector that establishes a connection between Systems Manager and
    /// a third-party cloud environment.
    /// </summary>
    [Cmdlet("New", "SSMCloudConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateCloudConnector API operation.", Operation = new[] {"CreateCloudConnector"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSSMCloudConnectorCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_AzureConfiguration_ApplicationDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the Azure application registration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AzureConfiguration_ApplicationDisplayName { get; set; }
        #endregion
        
        #region Parameter Configuration_AzureConfiguration_ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Azure application registration used for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AzureConfiguration_ApplicationId { get; set; }
        #endregion
        
        #region Parameter ConfigConnectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services Config connector associated with this cloud connector.</para>
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
        public System.String ConfigConnectorArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the cloud connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the cloud connector.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the cloud connector uses to communicate
        /// with the third-party cloud environment.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Configuration_AzureConfiguration_Targets_Subscription
        /// <summary>
        /// <para>
        /// <para>A list of Azure subscriptions to target.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AzureConfiguration_Targets_Subscriptions")]
        public Amazon.SimpleSystemsManagement.Model.AzureSubscription[] Configuration_AzureConfiguration_Targets_Subscription { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you assign to a resource. Tags enable you to categorize a resource
        /// in different ways, such as by purpose, owner, or environment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Configuration_AzureConfiguration_TenantDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the Azure tenant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AzureConfiguration_TenantDisplayName { get; set; }
        #endregion
        
        #region Parameter Configuration_AzureConfiguration_TenantId
        /// <summary>
        /// <para>
        /// <para>The ID of the Azure tenant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AzureConfiguration_TenantId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CloudConnectorId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CloudConnectorId";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DisplayName),
                nameof(this.ConfigConnectorArn),
                nameof(this.RoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMCloudConnector (CreateCloudConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse, NewSSMCloudConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigConnectorArn = this.ConfigConnectorArn;
            #if MODULAR
            if (this.ConfigConnectorArn == null && ParameterWasBound(nameof(this.ConfigConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Configuration_AzureConfiguration_ApplicationDisplayName = this.Configuration_AzureConfiguration_ApplicationDisplayName;
            context.Configuration_AzureConfiguration_ApplicationId = this.Configuration_AzureConfiguration_ApplicationId;
            if (this.Configuration_AzureConfiguration_Targets_Subscription != null)
            {
                context.Configuration_AzureConfiguration_Targets_Subscription = new List<Amazon.SimpleSystemsManagement.Model.AzureSubscription>(this.Configuration_AzureConfiguration_Targets_Subscription);
            }
            context.Configuration_AzureConfiguration_TenantDisplayName = this.Configuration_AzureConfiguration_TenantDisplayName;
            context.Configuration_AzureConfiguration_TenantId = this.Configuration_AzureConfiguration_TenantId;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorRequest();
            
            if (cmdletContext.ConfigConnectorArn != null)
            {
                request.ConfigConnectorArn = cmdletContext.ConfigConnectorArn;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.SimpleSystemsManagement.Model.CloudConnectorConfiguration();
            Amazon.SimpleSystemsManagement.Model.AzureConfiguration requestConfiguration_configuration_AzureConfiguration = null;
            
             // populate AzureConfiguration
            var requestConfiguration_configuration_AzureConfigurationIsNull = true;
            requestConfiguration_configuration_AzureConfiguration = new Amazon.SimpleSystemsManagement.Model.AzureConfiguration();
            System.String requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationDisplayName = null;
            if (cmdletContext.Configuration_AzureConfiguration_ApplicationDisplayName != null)
            {
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationDisplayName = cmdletContext.Configuration_AzureConfiguration_ApplicationDisplayName;
            }
            if (requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationDisplayName != null)
            {
                requestConfiguration_configuration_AzureConfiguration.ApplicationDisplayName = requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationDisplayName;
                requestConfiguration_configuration_AzureConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationId = null;
            if (cmdletContext.Configuration_AzureConfiguration_ApplicationId != null)
            {
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationId = cmdletContext.Configuration_AzureConfiguration_ApplicationId;
            }
            if (requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationId != null)
            {
                requestConfiguration_configuration_AzureConfiguration.ApplicationId = requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_ApplicationId;
                requestConfiguration_configuration_AzureConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantDisplayName = null;
            if (cmdletContext.Configuration_AzureConfiguration_TenantDisplayName != null)
            {
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantDisplayName = cmdletContext.Configuration_AzureConfiguration_TenantDisplayName;
            }
            if (requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantDisplayName != null)
            {
                requestConfiguration_configuration_AzureConfiguration.TenantDisplayName = requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantDisplayName;
                requestConfiguration_configuration_AzureConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantId = null;
            if (cmdletContext.Configuration_AzureConfiguration_TenantId != null)
            {
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantId = cmdletContext.Configuration_AzureConfiguration_TenantId;
            }
            if (requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantId != null)
            {
                requestConfiguration_configuration_AzureConfiguration.TenantId = requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TenantId;
                requestConfiguration_configuration_AzureConfigurationIsNull = false;
            }
            Amazon.SimpleSystemsManagement.Model.ConfigurationTargets requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets = null;
            
             // populate Targets
            var requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TargetsIsNull = true;
            requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets = new Amazon.SimpleSystemsManagement.Model.ConfigurationTargets();
            List<Amazon.SimpleSystemsManagement.Model.AzureSubscription> requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets_configuration_AzureConfiguration_Targets_Subscription = null;
            if (cmdletContext.Configuration_AzureConfiguration_Targets_Subscription != null)
            {
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets_configuration_AzureConfiguration_Targets_Subscription = cmdletContext.Configuration_AzureConfiguration_Targets_Subscription;
            }
            if (requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets_configuration_AzureConfiguration_Targets_Subscription != null)
            {
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets.Subscriptions = requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets_configuration_AzureConfiguration_Targets_Subscription;
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TargetsIsNull = false;
            }
             // determine if requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets should be set to null
            if (requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_TargetsIsNull)
            {
                requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets = null;
            }
            if (requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets != null)
            {
                requestConfiguration_configuration_AzureConfiguration.Targets = requestConfiguration_configuration_AzureConfiguration_configuration_AzureConfiguration_Targets;
                requestConfiguration_configuration_AzureConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_AzureConfiguration should be set to null
            if (requestConfiguration_configuration_AzureConfigurationIsNull)
            {
                requestConfiguration_configuration_AzureConfiguration = null;
            }
            if (requestConfiguration_configuration_AzureConfiguration != null)
            {
                request.Configuration.AzureConfiguration = requestConfiguration_configuration_AzureConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateCloudConnector");
            try
            {
                return client.CreateCloudConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigConnectorArn { get; set; }
            public System.String Configuration_AzureConfiguration_ApplicationDisplayName { get; set; }
            public System.String Configuration_AzureConfiguration_ApplicationId { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.AzureSubscription> Configuration_AzureConfiguration_Targets_Subscription { get; set; }
            public System.String Configuration_AzureConfiguration_TenantDisplayName { get; set; }
            public System.String Configuration_AzureConfiguration_TenantId { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreateCloudConnectorResponse, NewSSMCloudConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CloudConnectorId;
        }
        
    }
}
