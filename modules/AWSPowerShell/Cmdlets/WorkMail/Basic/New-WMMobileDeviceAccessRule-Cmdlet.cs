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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Creates a new mobile device access rule for the specified WorkMail organization.
    /// </summary>
    [Cmdlet("New", "WMMobileDeviceAccessRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkMail CreateMobileDeviceAccessRule API operation.", Operation = new[] {"CreateMobileDeviceAccessRule"}, SelectReturnType = typeof(Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewWMMobileDeviceAccessRuleCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The rule description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DeviceModel
        /// <summary>
        /// <para>
        /// <para>Device models that the rule will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceModels")]
        public System.String[] DeviceModel { get; set; }
        #endregion
        
        #region Parameter DeviceOperatingSystem
        /// <summary>
        /// <para>
        /// <para>Device operating systems that the rule will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceOperatingSystems")]
        public System.String[] DeviceOperatingSystem { get; set; }
        #endregion
        
        #region Parameter DeviceType
        /// <summary>
        /// <para>
        /// <para>Device types that the rule will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceTypes")]
        public System.String[] DeviceType { get; set; }
        #endregion
        
        #region Parameter DeviceUserAgent
        /// <summary>
        /// <para>
        /// <para>Device user agents that the rule will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceUserAgents")]
        public System.String[] DeviceUserAgent { get; set; }
        #endregion
        
        #region Parameter Effect
        /// <summary>
        /// <para>
        /// <para>The effect of the rule when it matches. Allowed values are <c>ALLOW</c> or <c>DENY</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkMail.MobileDeviceAccessRuleEffect")]
        public Amazon.WorkMail.MobileDeviceAccessRuleEffect Effect { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The rule name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NotDeviceModel
        /// <summary>
        /// <para>
        /// <para>Device models that the rule <b>will not</b> match. All other device models will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceModels")]
        public System.String[] NotDeviceModel { get; set; }
        #endregion
        
        #region Parameter NotDeviceOperatingSystem
        /// <summary>
        /// <para>
        /// <para>Device operating systems that the rule <b>will not</b> match. All other device operating
        /// systems will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceOperatingSystems")]
        public System.String[] NotDeviceOperatingSystem { get; set; }
        #endregion
        
        #region Parameter NotDeviceType
        /// <summary>
        /// <para>
        /// <para>Device types that the rule <b>will not</b> match. All other device types will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceTypes")]
        public System.String[] NotDeviceType { get; set; }
        #endregion
        
        #region Parameter NotDeviceUserAgent
        /// <summary>
        /// <para>
        /// <para>Device user agents that the rule <b>will not</b> match. All other device user agents
        /// will match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceUserAgents")]
        public System.String[] NotDeviceUserAgent { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The WorkMail organization under which the rule will be created.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token for the client request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MobileDeviceAccessRuleId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse).
        /// Specifying the name of a property of type Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MobileDeviceAccessRuleId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WMMobileDeviceAccessRule (CreateMobileDeviceAccessRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse, NewWMMobileDeviceAccessRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.DeviceModel != null)
            {
                context.DeviceModel = new List<System.String>(this.DeviceModel);
            }
            if (this.DeviceOperatingSystem != null)
            {
                context.DeviceOperatingSystem = new List<System.String>(this.DeviceOperatingSystem);
            }
            if (this.DeviceType != null)
            {
                context.DeviceType = new List<System.String>(this.DeviceType);
            }
            if (this.DeviceUserAgent != null)
            {
                context.DeviceUserAgent = new List<System.String>(this.DeviceUserAgent);
            }
            context.Effect = this.Effect;
            #if MODULAR
            if (this.Effect == null && ParameterWasBound(nameof(this.Effect)))
            {
                WriteWarning("You are passing $null as a value for parameter Effect which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NotDeviceModel != null)
            {
                context.NotDeviceModel = new List<System.String>(this.NotDeviceModel);
            }
            if (this.NotDeviceOperatingSystem != null)
            {
                context.NotDeviceOperatingSystem = new List<System.String>(this.NotDeviceOperatingSystem);
            }
            if (this.NotDeviceType != null)
            {
                context.NotDeviceType = new List<System.String>(this.NotDeviceType);
            }
            if (this.NotDeviceUserAgent != null)
            {
                context.NotDeviceUserAgent = new List<System.String>(this.NotDeviceUserAgent);
            }
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DeviceModel != null)
            {
                request.DeviceModels = cmdletContext.DeviceModel;
            }
            if (cmdletContext.DeviceOperatingSystem != null)
            {
                request.DeviceOperatingSystems = cmdletContext.DeviceOperatingSystem;
            }
            if (cmdletContext.DeviceType != null)
            {
                request.DeviceTypes = cmdletContext.DeviceType;
            }
            if (cmdletContext.DeviceUserAgent != null)
            {
                request.DeviceUserAgents = cmdletContext.DeviceUserAgent;
            }
            if (cmdletContext.Effect != null)
            {
                request.Effect = cmdletContext.Effect;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotDeviceModel != null)
            {
                request.NotDeviceModels = cmdletContext.NotDeviceModel;
            }
            if (cmdletContext.NotDeviceOperatingSystem != null)
            {
                request.NotDeviceOperatingSystems = cmdletContext.NotDeviceOperatingSystem;
            }
            if (cmdletContext.NotDeviceType != null)
            {
                request.NotDeviceTypes = cmdletContext.NotDeviceType;
            }
            if (cmdletContext.NotDeviceUserAgent != null)
            {
                request.NotDeviceUserAgents = cmdletContext.NotDeviceUserAgent;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
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
        
        private Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "CreateMobileDeviceAccessRule");
            try
            {
                return client.CreateMobileDeviceAccessRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<System.String> DeviceModel { get; set; }
            public List<System.String> DeviceOperatingSystem { get; set; }
            public List<System.String> DeviceType { get; set; }
            public List<System.String> DeviceUserAgent { get; set; }
            public Amazon.WorkMail.MobileDeviceAccessRuleEffect Effect { get; set; }
            public System.String Name { get; set; }
            public List<System.String> NotDeviceModel { get; set; }
            public List<System.String> NotDeviceOperatingSystem { get; set; }
            public List<System.String> NotDeviceType { get; set; }
            public List<System.String> NotDeviceUserAgent { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Func<Amazon.WorkMail.Model.CreateMobileDeviceAccessRuleResponse, NewWMMobileDeviceAccessRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MobileDeviceAccessRuleId;
        }
        
    }
}
