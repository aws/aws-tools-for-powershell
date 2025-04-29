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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates an Amazon SageMaker Partner AI App.
    /// </summary>
    [Cmdlet("New", "SMPartnerApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreatePartnerApp API operation.", Operation = new[] {"CreatePartnerApp"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreatePartnerAppResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreatePartnerAppResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreatePartnerAppResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMPartnerAppCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationConfig_AdminUser
        /// <summary>
        /// <para>
        /// <para>The list of users that are given admin access to the SageMaker Partner AI App.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationConfig_AdminUsers")]
        public System.String[] ApplicationConfig_AdminUser { get; set; }
        #endregion
        
        #region Parameter ApplicationConfig_Argument
        /// <summary>
        /// <para>
        /// <para>This is a map of required inputs for a SageMaker Partner AI App. Based on the application
        /// type, the map is populated with a key and value pair that is specific to the user
        /// and application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationConfig_Arguments")]
        public System.Collections.Hashtable ApplicationConfig_Argument { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The authorization type that users use to access the SageMaker Partner AI App.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.PartnerAppAuthType")]
        public Amazon.SageMaker.PartnerAppAuthType AuthType { get; set; }
        #endregion
        
        #region Parameter EnableIamSessionBasedIdentity
        /// <summary>
        /// <para>
        /// <para>When set to <c>TRUE</c>, the SageMaker Partner AI App sets the Amazon Web Services
        /// IAM session name or the authenticated IAM user as the identity of the SageMaker Partner
        /// AI App user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIamSessionBasedIdentity { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the partner application uses.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>SageMaker Partner AI Apps uses Amazon Web Services KMS to encrypt data at rest using
        /// an Amazon Web Services managed key by default. For more control, specify a customer
        /// managed key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaintenanceConfig_MaintenanceWindowStart
        /// <summary>
        /// <para>
        /// <para>The day and time of the week in Coordinated Universal Time (UTC) 24-hour standard
        /// time that weekly maintenance updates are scheduled. This value must take the following
        /// format: <c>3-letter-day:24-h-hour:minute</c>. For example: <c>TUE:03:30</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaintenanceConfig_MaintenanceWindowStart { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to give the SageMaker Partner AI App.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Each tag consists of a key and an optional value. Tag keys must be unique per resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>Indicates the instance type and size of the cluster attached to the SageMaker Partner
        /// AI App.</para>
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
        public System.String Tier { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of SageMaker Partner AI App to create. Must be one of the following: <c>lakera-guard</c>,
        /// <c>comet</c>, <c>deepchecks-llm-evaluation</c>, or <c>fiddler</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.PartnerAppType")]
        public Amazon.SageMaker.PartnerAppType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that guarantees that the call to this API is idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreatePartnerAppResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreatePartnerAppResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMPartnerApp (CreatePartnerApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreatePartnerAppResponse, NewSMPartnerAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ApplicationConfig_AdminUser != null)
            {
                context.ApplicationConfig_AdminUser = new List<System.String>(this.ApplicationConfig_AdminUser);
            }
            if (this.ApplicationConfig_Argument != null)
            {
                context.ApplicationConfig_Argument = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ApplicationConfig_Argument.Keys)
                {
                    context.ApplicationConfig_Argument.Add((String)hashKey, (System.String)(this.ApplicationConfig_Argument[hashKey]));
                }
            }
            context.AuthType = this.AuthType;
            #if MODULAR
            if (this.AuthType == null && ParameterWasBound(nameof(this.AuthType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EnableIamSessionBasedIdentity = this.EnableIamSessionBasedIdentity;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.MaintenanceConfig_MaintenanceWindowStart = this.MaintenanceConfig_MaintenanceWindowStart;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.Tier = this.Tier;
            #if MODULAR
            if (this.Tier == null && ParameterWasBound(nameof(this.Tier)))
            {
                WriteWarning("You are passing $null as a value for parameter Tier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreatePartnerAppRequest();
            
            
             // populate ApplicationConfig
            var requestApplicationConfigIsNull = true;
            request.ApplicationConfig = new Amazon.SageMaker.Model.PartnerAppConfig();
            List<System.String> requestApplicationConfig_applicationConfig_AdminUser = null;
            if (cmdletContext.ApplicationConfig_AdminUser != null)
            {
                requestApplicationConfig_applicationConfig_AdminUser = cmdletContext.ApplicationConfig_AdminUser;
            }
            if (requestApplicationConfig_applicationConfig_AdminUser != null)
            {
                request.ApplicationConfig.AdminUsers = requestApplicationConfig_applicationConfig_AdminUser;
                requestApplicationConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestApplicationConfig_applicationConfig_Argument = null;
            if (cmdletContext.ApplicationConfig_Argument != null)
            {
                requestApplicationConfig_applicationConfig_Argument = cmdletContext.ApplicationConfig_Argument;
            }
            if (requestApplicationConfig_applicationConfig_Argument != null)
            {
                request.ApplicationConfig.Arguments = requestApplicationConfig_applicationConfig_Argument;
                requestApplicationConfigIsNull = false;
            }
             // determine if request.ApplicationConfig should be set to null
            if (requestApplicationConfigIsNull)
            {
                request.ApplicationConfig = null;
            }
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnableIamSessionBasedIdentity != null)
            {
                request.EnableIamSessionBasedIdentity = cmdletContext.EnableIamSessionBasedIdentity.Value;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate MaintenanceConfig
            var requestMaintenanceConfigIsNull = true;
            request.MaintenanceConfig = new Amazon.SageMaker.Model.PartnerAppMaintenanceConfig();
            System.String requestMaintenanceConfig_maintenanceConfig_MaintenanceWindowStart = null;
            if (cmdletContext.MaintenanceConfig_MaintenanceWindowStart != null)
            {
                requestMaintenanceConfig_maintenanceConfig_MaintenanceWindowStart = cmdletContext.MaintenanceConfig_MaintenanceWindowStart;
            }
            if (requestMaintenanceConfig_maintenanceConfig_MaintenanceWindowStart != null)
            {
                request.MaintenanceConfig.MaintenanceWindowStart = requestMaintenanceConfig_maintenanceConfig_MaintenanceWindowStart;
                requestMaintenanceConfigIsNull = false;
            }
             // determine if request.MaintenanceConfig should be set to null
            if (requestMaintenanceConfigIsNull)
            {
                request.MaintenanceConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
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
        
        private Amazon.SageMaker.Model.CreatePartnerAppResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreatePartnerAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreatePartnerApp");
            try
            {
                return client.CreatePartnerAppAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ApplicationConfig_AdminUser { get; set; }
            public Dictionary<System.String, System.String> ApplicationConfig_Argument { get; set; }
            public Amazon.SageMaker.PartnerAppAuthType AuthType { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? EnableIamSessionBasedIdentity { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MaintenanceConfig_MaintenanceWindowStart { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String Tier { get; set; }
            public Amazon.SageMaker.PartnerAppType Type { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreatePartnerAppResponse, NewSMPartnerAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
