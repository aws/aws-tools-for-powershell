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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Updates a group resource.
    /// </summary>
    [Cmdlet("Update", "XRGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.XRay.Model.Group")]
    [AWSCmdlet("Calls the AWS X-Ray UpdateGroup API operation.", Operation = new[] {"UpdateGroup"}, SelectReturnType = typeof(Amazon.XRay.Model.UpdateGroupResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.Group or Amazon.XRay.Model.UpdateGroupResponse",
        "This cmdlet returns an Amazon.XRay.Model.Group object.",
        "The service call response (type Amazon.XRay.Model.UpdateGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateXRGroupCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterExpression
        /// <summary>
        /// <para>
        /// <para>The updated filter expression defining criteria by which to group traces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter GroupARN
        /// <summary>
        /// <para>
        /// <para>The ARN that was generated upon creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GroupARN { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The case-sensitive name of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter InsightsConfiguration_InsightsEnabled
        /// <summary>
        /// <para>
        /// <para>Set the InsightsEnabled value to true to enable insights or false to disable insights.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InsightsConfiguration_InsightsEnabled { get; set; }
        #endregion
        
        #region Parameter InsightsConfiguration_NotificationsEnabled
        /// <summary>
        /// <para>
        /// <para>Set the NotificationsEnabled value to true to enable insights notifications. Notifications
        /// can only be enabled on a group with InsightsEnabled set to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InsightsConfiguration_NotificationsEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Group'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.UpdateGroupResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.UpdateGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Group";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-XRGroup (UpdateGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.UpdateGroupResponse, UpdateXRGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterExpression = this.FilterExpression;
            context.GroupARN = this.GroupARN;
            context.GroupName = this.GroupName;
            context.InsightsConfiguration_InsightsEnabled = this.InsightsConfiguration_InsightsEnabled;
            context.InsightsConfiguration_NotificationsEnabled = this.InsightsConfiguration_NotificationsEnabled;
            
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
            var request = new Amazon.XRay.Model.UpdateGroupRequest();
            
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
            }
            if (cmdletContext.GroupARN != null)
            {
                request.GroupARN = cmdletContext.GroupARN;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            
             // populate InsightsConfiguration
            var requestInsightsConfigurationIsNull = true;
            request.InsightsConfiguration = new Amazon.XRay.Model.InsightsConfiguration();
            System.Boolean? requestInsightsConfiguration_insightsConfiguration_InsightsEnabled = null;
            if (cmdletContext.InsightsConfiguration_InsightsEnabled != null)
            {
                requestInsightsConfiguration_insightsConfiguration_InsightsEnabled = cmdletContext.InsightsConfiguration_InsightsEnabled.Value;
            }
            if (requestInsightsConfiguration_insightsConfiguration_InsightsEnabled != null)
            {
                request.InsightsConfiguration.InsightsEnabled = requestInsightsConfiguration_insightsConfiguration_InsightsEnabled.Value;
                requestInsightsConfigurationIsNull = false;
            }
            System.Boolean? requestInsightsConfiguration_insightsConfiguration_NotificationsEnabled = null;
            if (cmdletContext.InsightsConfiguration_NotificationsEnabled != null)
            {
                requestInsightsConfiguration_insightsConfiguration_NotificationsEnabled = cmdletContext.InsightsConfiguration_NotificationsEnabled.Value;
            }
            if (requestInsightsConfiguration_insightsConfiguration_NotificationsEnabled != null)
            {
                request.InsightsConfiguration.NotificationsEnabled = requestInsightsConfiguration_insightsConfiguration_NotificationsEnabled.Value;
                requestInsightsConfigurationIsNull = false;
            }
             // determine if request.InsightsConfiguration should be set to null
            if (requestInsightsConfigurationIsNull)
            {
                request.InsightsConfiguration = null;
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
        
        private Amazon.XRay.Model.UpdateGroupResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.UpdateGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "UpdateGroup");
            try
            {
                #if DESKTOP
                return client.UpdateGroup(request);
                #elif CORECLR
                return client.UpdateGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String FilterExpression { get; set; }
            public System.String GroupARN { get; set; }
            public System.String GroupName { get; set; }
            public System.Boolean? InsightsConfiguration_InsightsEnabled { get; set; }
            public System.Boolean? InsightsConfiguration_NotificationsEnabled { get; set; }
            public System.Func<Amazon.XRay.Model.UpdateGroupResponse, UpdateXRGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Group;
        }
        
    }
}
