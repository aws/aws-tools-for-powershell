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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Updates a mobile device access rule for the specified WorkMail organization.
    /// </summary>
    [Cmdlet("Update", "WMMobileDeviceAccessRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail UpdateMobileDeviceAccessRule API operation.", Operation = new[] {"UpdateMobileDeviceAccessRule"}, SelectReturnType = typeof(Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWMMobileDeviceAccessRuleCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated rule description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DeviceModel
        /// <summary>
        /// <para>
        /// <para>Device models that the updated rule will match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceModels")]
        public System.String[] DeviceModel { get; set; }
        #endregion
        
        #region Parameter DeviceOperatingSystem
        /// <summary>
        /// <para>
        /// <para>Device operating systems that the updated rule will match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceOperatingSystems")]
        public System.String[] DeviceOperatingSystem { get; set; }
        #endregion
        
        #region Parameter DeviceType
        /// <summary>
        /// <para>
        /// <para>Device types that the updated rule will match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceTypes")]
        public System.String[] DeviceType { get; set; }
        #endregion
        
        #region Parameter DeviceUserAgent
        /// <summary>
        /// <para>
        /// <para>User agents that the updated rule will match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceUserAgents")]
        public System.String[] DeviceUserAgent { get; set; }
        #endregion
        
        #region Parameter Effect
        /// <summary>
        /// <para>
        /// <para>The effect of the rule when it matches. Allowed values are <code>ALLOW</code> or <code>DENY</code>.</para>
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
        
        #region Parameter MobileDeviceAccessRuleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the rule to be updated.</para>
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
        public System.String MobileDeviceAccessRuleId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated rule name.</para>
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
        
        #region Parameter NotDeviceModel
        /// <summary>
        /// <para>
        /// <para>Device models that the updated rule <b>will not</b> match. All other device models
        /// will match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceModels")]
        public System.String[] NotDeviceModel { get; set; }
        #endregion
        
        #region Parameter NotDeviceOperatingSystem
        /// <summary>
        /// <para>
        /// <para>Device operating systems that the updated rule <b>will not</b> match. All other device
        /// operating systems will match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceOperatingSystems")]
        public System.String[] NotDeviceOperatingSystem { get; set; }
        #endregion
        
        #region Parameter NotDeviceType
        /// <summary>
        /// <para>
        /// <para>Device types that the updated rule <b>will not</b> match. All other device types will
        /// match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceTypes")]
        public System.String[] NotDeviceType { get; set; }
        #endregion
        
        #region Parameter NotDeviceUserAgent
        /// <summary>
        /// <para>
        /// <para>User agents that the updated rule <b>will not</b> match. All other user agents will
        /// match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotDeviceUserAgents")]
        public System.String[] NotDeviceUserAgent { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The WorkMail organization under which the rule will be updated.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MobileDeviceAccessRuleId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MobileDeviceAccessRuleId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MobileDeviceAccessRuleId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MobileDeviceAccessRuleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WMMobileDeviceAccessRule (UpdateMobileDeviceAccessRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleResponse, UpdateWMMobileDeviceAccessRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MobileDeviceAccessRuleId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.MobileDeviceAccessRuleId = this.MobileDeviceAccessRuleId;
            #if MODULAR
            if (this.MobileDeviceAccessRuleId == null && ParameterWasBound(nameof(this.MobileDeviceAccessRuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter MobileDeviceAccessRuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleRequest();
            
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
            if (cmdletContext.MobileDeviceAccessRuleId != null)
            {
                request.MobileDeviceAccessRuleId = cmdletContext.MobileDeviceAccessRuleId;
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
        
        private Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "UpdateMobileDeviceAccessRule");
            try
            {
                #if DESKTOP
                return client.UpdateMobileDeviceAccessRule(request);
                #elif CORECLR
                return client.UpdateMobileDeviceAccessRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<System.String> DeviceModel { get; set; }
            public List<System.String> DeviceOperatingSystem { get; set; }
            public List<System.String> DeviceType { get; set; }
            public List<System.String> DeviceUserAgent { get; set; }
            public Amazon.WorkMail.MobileDeviceAccessRuleEffect Effect { get; set; }
            public System.String MobileDeviceAccessRuleId { get; set; }
            public System.String Name { get; set; }
            public List<System.String> NotDeviceModel { get; set; }
            public List<System.String> NotDeviceOperatingSystem { get; set; }
            public List<System.String> NotDeviceType { get; set; }
            public List<System.String> NotDeviceUserAgent { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Func<Amazon.WorkMail.Model.UpdateMobileDeviceAccessRuleResponse, UpdateWMMobileDeviceAccessRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
