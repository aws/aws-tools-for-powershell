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
using Amazon.ApplicationInsights;
using Amazon.ApplicationInsights.Model;

namespace Amazon.PowerShell.Cmdlets.CWAI
{
    /// <summary>
    /// Updates the application.
    /// </summary>
    [Cmdlet("Update", "CWAIApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationInsights.Model.ApplicationInfo")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Insights UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.ApplicationInsights.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("Amazon.ApplicationInsights.Model.ApplicationInfo or Amazon.ApplicationInsights.Model.UpdateApplicationResponse",
        "This cmdlet returns an Amazon.ApplicationInsights.Model.ApplicationInfo object.",
        "The service call response (type Amazon.ApplicationInsights.Model.UpdateApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWAIApplicationCmdlet : AmazonApplicationInsightsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttachMissingPermission
        /// <summary>
        /// <para>
        /// <para>If set to true, the managed policies for SSM and CW will be attached to the instance
        /// roles if they are missing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AttachMissingPermission { get; set; }
        #endregion
        
        #region Parameter AutoConfigEnabled
        /// <summary>
        /// <para>
        /// <para> Turns auto-configuration on or off. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoConfigEnabled { get; set; }
        #endregion
        
        #region Parameter CWEMonitorEnabled
        /// <summary>
        /// <para>
        /// <para> Indicates whether Application Insights can listen to CloudWatch events for the application
        /// resources, such as <c>instance terminated</c>, <c>failed deployment</c>, and others.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CWEMonitorEnabled { get; set; }
        #endregion
        
        #region Parameter OpsCenterEnabled
        /// <summary>
        /// <para>
        /// <para> When set to <c>true</c>, creates opsItems for any problems detected on an application.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OpsCenterEnabled { get; set; }
        #endregion
        
        #region Parameter OpsItemSNSTopicArn
        /// <summary>
        /// <para>
        /// <para> The SNS topic provided to Application Insights that is associated to the created
        /// opsItem. Allows you to receive notifications for updates to the opsItem.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpsItemSNSTopicArn { get; set; }
        #endregion
        
        #region Parameter RemoveSNSTopic
        /// <summary>
        /// <para>
        /// <para> Disassociates the SNS topic from the opsItem created for detected problems.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveSNSTopic { get; set; }
        #endregion
        
        #region Parameter ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resource group.</para>
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
        public System.String ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationInfo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationInsights.Model.UpdateApplicationResponse).
        /// Specifying the name of a property of type Amazon.ApplicationInsights.Model.UpdateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationInfo";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWAIApplication (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationInsights.Model.UpdateApplicationResponse, UpdateCWAIApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AttachMissingPermission = this.AttachMissingPermission;
            context.AutoConfigEnabled = this.AutoConfigEnabled;
            context.CWEMonitorEnabled = this.CWEMonitorEnabled;
            context.OpsCenterEnabled = this.OpsCenterEnabled;
            context.OpsItemSNSTopicArn = this.OpsItemSNSTopicArn;
            context.RemoveSNSTopic = this.RemoveSNSTopic;
            context.ResourceGroupName = this.ResourceGroupName;
            #if MODULAR
            if (this.ResourceGroupName == null && ParameterWasBound(nameof(this.ResourceGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationInsights.Model.UpdateApplicationRequest();
            
            if (cmdletContext.AttachMissingPermission != null)
            {
                request.AttachMissingPermission = cmdletContext.AttachMissingPermission.Value;
            }
            if (cmdletContext.AutoConfigEnabled != null)
            {
                request.AutoConfigEnabled = cmdletContext.AutoConfigEnabled.Value;
            }
            if (cmdletContext.CWEMonitorEnabled != null)
            {
                request.CWEMonitorEnabled = cmdletContext.CWEMonitorEnabled.Value;
            }
            if (cmdletContext.OpsCenterEnabled != null)
            {
                request.OpsCenterEnabled = cmdletContext.OpsCenterEnabled.Value;
            }
            if (cmdletContext.OpsItemSNSTopicArn != null)
            {
                request.OpsItemSNSTopicArn = cmdletContext.OpsItemSNSTopicArn;
            }
            if (cmdletContext.RemoveSNSTopic != null)
            {
                request.RemoveSNSTopic = cmdletContext.RemoveSNSTopic.Value;
            }
            if (cmdletContext.ResourceGroupName != null)
            {
                request.ResourceGroupName = cmdletContext.ResourceGroupName;
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
        
        private Amazon.ApplicationInsights.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonApplicationInsights client, Amazon.ApplicationInsights.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Insights", "UpdateApplication");
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
            public System.Boolean? AttachMissingPermission { get; set; }
            public System.Boolean? AutoConfigEnabled { get; set; }
            public System.Boolean? CWEMonitorEnabled { get; set; }
            public System.Boolean? OpsCenterEnabled { get; set; }
            public System.String OpsItemSNSTopicArn { get; set; }
            public System.Boolean? RemoveSNSTopic { get; set; }
            public System.String ResourceGroupName { get; set; }
            public System.Func<Amazon.ApplicationInsights.Model.UpdateApplicationResponse, UpdateCWAIApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationInfo;
        }
        
    }
}
