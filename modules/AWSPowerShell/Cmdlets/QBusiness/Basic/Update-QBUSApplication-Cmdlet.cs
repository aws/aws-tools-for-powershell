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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Updates an existing Amazon Q Business application.
    /// 
    ///  <note><para>
    /// Amazon Q Business applications may securely transmit data for processing across Amazon
    /// Web Services Regions within your geography. For more information, see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/cross-region-inference.html">Cross
    /// region inference in Amazon Q Business</a>.
    /// </para></note><note><para>
    /// An Amazon Q Apps service-linked role will be created if it's absent in the Amazon
    /// Web Services account when <c>QAppsConfiguration</c> is enabled in the request. For
    /// more information, see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/using-service-linked-roles-qapps.html">Using
    /// service-linked roles for Q Apps</a>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "QBUSApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.QBusiness.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.UpdateApplicationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.UpdateApplicationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateQBUSApplicationCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q Business application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AttachmentsConfiguration_AttachmentsControlMode
        /// <summary>
        /// <para>
        /// <para>Status information about whether file upload functionality is activated or deactivated
        /// for your end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.AttachmentsControlMode")]
        public Amazon.QBusiness.AttachmentsControlMode AttachmentsConfiguration_AttachmentsControlMode { get; set; }
        #endregion
        
        #region Parameter AutoSubscriptionConfiguration_AutoSubscribe
        /// <summary>
        /// <para>
        /// <para>Describes whether automatic subscriptions are enabled for an Amazon Q Business application
        /// using IAM identity federation for user management.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.AutoSubscriptionStatus")]
        public Amazon.QBusiness.AutoSubscriptionStatus AutoSubscriptionConfiguration_AutoSubscribe { get; set; }
        #endregion
        
        #region Parameter AutoSubscriptionConfiguration_DefaultSubscriptionType
        /// <summary>
        /// <para>
        /// <para>Describes the default subscription type assigned to an Amazon Q Business application
        /// using IAM identity federation for user management. If the value for <c>autoSubscribe</c>
        /// is set to <c>ENABLED</c> you must select a value for this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.SubscriptionType")]
        public Amazon.QBusiness.SubscriptionType AutoSubscriptionConfiguration_DefaultSubscriptionType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A name for the Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter IdentityCenterInstanceArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the IAM Identity Center instance you are either
        /// creating for—or connecting to—your Amazon Q Business application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityCenterInstanceArn { get; set; }
        #endregion
        
        #region Parameter PersonalizationConfiguration_PersonalizationControlMode
        /// <summary>
        /// <para>
        /// <para>An option to allow Amazon Q Business to customize chat responses using user specific
        /// metadata—specifically, location and job information—in your IAM Identity Center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.PersonalizationControlMode")]
        public Amazon.QBusiness.PersonalizationControlMode PersonalizationConfiguration_PersonalizationControlMode { get; set; }
        #endregion
        
        #region Parameter QAppsConfiguration_QAppsControlMode
        /// <summary>
        /// <para>
        /// <para>Status information about whether end users can create and use Amazon Q Apps in the
        /// web experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.QAppsControlMode")]
        public Amazon.QBusiness.QAppsControlMode QAppsConfiguration_QAppsControlMode { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Web Services Identity and Access Management (IAM) role that gives Amazon
        /// Q Business permission to access Amazon CloudWatch logs and metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.UpdateApplicationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QBUSApplication (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.UpdateApplicationResponse, UpdateQBUSApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttachmentsConfiguration_AttachmentsControlMode = this.AttachmentsConfiguration_AttachmentsControlMode;
            context.AutoSubscriptionConfiguration_AutoSubscribe = this.AutoSubscriptionConfiguration_AutoSubscribe;
            context.AutoSubscriptionConfiguration_DefaultSubscriptionType = this.AutoSubscriptionConfiguration_DefaultSubscriptionType;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.IdentityCenterInstanceArn = this.IdentityCenterInstanceArn;
            context.PersonalizationConfiguration_PersonalizationControlMode = this.PersonalizationConfiguration_PersonalizationControlMode;
            context.QAppsConfiguration_QAppsControlMode = this.QAppsConfiguration_QAppsControlMode;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.QBusiness.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate AttachmentsConfiguration
            var requestAttachmentsConfigurationIsNull = true;
            request.AttachmentsConfiguration = new Amazon.QBusiness.Model.AttachmentsConfiguration();
            Amazon.QBusiness.AttachmentsControlMode requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode = null;
            if (cmdletContext.AttachmentsConfiguration_AttachmentsControlMode != null)
            {
                requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode = cmdletContext.AttachmentsConfiguration_AttachmentsControlMode;
            }
            if (requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode != null)
            {
                request.AttachmentsConfiguration.AttachmentsControlMode = requestAttachmentsConfiguration_attachmentsConfiguration_AttachmentsControlMode;
                requestAttachmentsConfigurationIsNull = false;
            }
             // determine if request.AttachmentsConfiguration should be set to null
            if (requestAttachmentsConfigurationIsNull)
            {
                request.AttachmentsConfiguration = null;
            }
            
             // populate AutoSubscriptionConfiguration
            var requestAutoSubscriptionConfigurationIsNull = true;
            request.AutoSubscriptionConfiguration = new Amazon.QBusiness.Model.AutoSubscriptionConfiguration();
            Amazon.QBusiness.AutoSubscriptionStatus requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_AutoSubscribe = null;
            if (cmdletContext.AutoSubscriptionConfiguration_AutoSubscribe != null)
            {
                requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_AutoSubscribe = cmdletContext.AutoSubscriptionConfiguration_AutoSubscribe;
            }
            if (requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_AutoSubscribe != null)
            {
                request.AutoSubscriptionConfiguration.AutoSubscribe = requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_AutoSubscribe;
                requestAutoSubscriptionConfigurationIsNull = false;
            }
            Amazon.QBusiness.SubscriptionType requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_DefaultSubscriptionType = null;
            if (cmdletContext.AutoSubscriptionConfiguration_DefaultSubscriptionType != null)
            {
                requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_DefaultSubscriptionType = cmdletContext.AutoSubscriptionConfiguration_DefaultSubscriptionType;
            }
            if (requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_DefaultSubscriptionType != null)
            {
                request.AutoSubscriptionConfiguration.DefaultSubscriptionType = requestAutoSubscriptionConfiguration_autoSubscriptionConfiguration_DefaultSubscriptionType;
                requestAutoSubscriptionConfigurationIsNull = false;
            }
             // determine if request.AutoSubscriptionConfiguration should be set to null
            if (requestAutoSubscriptionConfigurationIsNull)
            {
                request.AutoSubscriptionConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.IdentityCenterInstanceArn != null)
            {
                request.IdentityCenterInstanceArn = cmdletContext.IdentityCenterInstanceArn;
            }
            
             // populate PersonalizationConfiguration
            var requestPersonalizationConfigurationIsNull = true;
            request.PersonalizationConfiguration = new Amazon.QBusiness.Model.PersonalizationConfiguration();
            Amazon.QBusiness.PersonalizationControlMode requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode = null;
            if (cmdletContext.PersonalizationConfiguration_PersonalizationControlMode != null)
            {
                requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode = cmdletContext.PersonalizationConfiguration_PersonalizationControlMode;
            }
            if (requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode != null)
            {
                request.PersonalizationConfiguration.PersonalizationControlMode = requestPersonalizationConfiguration_personalizationConfiguration_PersonalizationControlMode;
                requestPersonalizationConfigurationIsNull = false;
            }
             // determine if request.PersonalizationConfiguration should be set to null
            if (requestPersonalizationConfigurationIsNull)
            {
                request.PersonalizationConfiguration = null;
            }
            
             // populate QAppsConfiguration
            var requestQAppsConfigurationIsNull = true;
            request.QAppsConfiguration = new Amazon.QBusiness.Model.QAppsConfiguration();
            Amazon.QBusiness.QAppsControlMode requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode = null;
            if (cmdletContext.QAppsConfiguration_QAppsControlMode != null)
            {
                requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode = cmdletContext.QAppsConfiguration_QAppsControlMode;
            }
            if (requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode != null)
            {
                request.QAppsConfiguration.QAppsControlMode = requestQAppsConfiguration_qAppsConfiguration_QAppsControlMode;
                requestQAppsConfigurationIsNull = false;
            }
             // determine if request.QAppsConfiguration should be set to null
            if (requestQAppsConfigurationIsNull)
            {
                request.QAppsConfiguration = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.QBusiness.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "UpdateApplication");
            try
            {
                #if DESKTOP
                return client.UpdateApplication(request);
                #elif CORECLR
                return client.UpdateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public Amazon.QBusiness.AttachmentsControlMode AttachmentsConfiguration_AttachmentsControlMode { get; set; }
            public Amazon.QBusiness.AutoSubscriptionStatus AutoSubscriptionConfiguration_AutoSubscribe { get; set; }
            public Amazon.QBusiness.SubscriptionType AutoSubscriptionConfiguration_DefaultSubscriptionType { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String IdentityCenterInstanceArn { get; set; }
            public Amazon.QBusiness.PersonalizationControlMode PersonalizationConfiguration_PersonalizationControlMode { get; set; }
            public Amazon.QBusiness.QAppsControlMode QAppsConfiguration_QAppsControlMode { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.QBusiness.Model.UpdateApplicationResponse, UpdateQBUSApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
