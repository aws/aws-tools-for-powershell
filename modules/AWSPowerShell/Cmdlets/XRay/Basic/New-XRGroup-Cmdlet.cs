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
    /// Creates a group resource with a name and a filter expression.
    /// </summary>
    [Cmdlet("New", "XRGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.XRay.Model.Group")]
    [AWSCmdlet("Calls the AWS X-Ray CreateGroup API operation.", Operation = new[] {"CreateGroup"}, SelectReturnType = typeof(Amazon.XRay.Model.CreateGroupResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.Group or Amazon.XRay.Model.CreateGroupResponse",
        "This cmdlet returns an Amazon.XRay.Model.Group object.",
        "The service call response (type Amazon.XRay.Model.CreateGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewXRGroupCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterExpression
        /// <summary>
        /// <para>
        /// <para>The filter expression defining criteria by which to group traces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The case-sensitive name of the new group. Default is a reserved name and names must
        /// be unique.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map that contains one or more tag keys and tag values to attach to an X-Ray group.
        /// For more information about ways to use tags, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a> in the <i>Amazon Web Services General Reference</i>.</para><para>The following restrictions apply to tags:</para><ul><li><para>Maximum number of user-applied tags per resource: 50</para></li><li><para>Maximum tag key length: 128 Unicode characters</para></li><li><para>Maximum tag value length: 256 Unicode characters</para></li><li><para>Valid values for key and value: a-z, A-Z, 0-9, space, and the following characters:
        /// _ . : / = + - and @</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Don't use <code>aws:</code> as a prefix for keys; it's reserved for Amazon Web Services
        /// use.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.XRay.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Group'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.CreateGroupResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.CreateGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Group";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-XRGroup (CreateGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.CreateGroupResponse, NewXRGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FilterExpression = this.FilterExpression;
            context.GroupName = this.GroupName;
            #if MODULAR
            if (this.GroupName == null && ParameterWasBound(nameof(this.GroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InsightsConfiguration_InsightsEnabled = this.InsightsConfiguration_InsightsEnabled;
            context.InsightsConfiguration_NotificationsEnabled = this.InsightsConfiguration_NotificationsEnabled;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.XRay.Model.Tag>(this.Tag);
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
            var request = new Amazon.XRay.Model.CreateGroupRequest();
            
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
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
        
        private Amazon.XRay.Model.CreateGroupResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.CreateGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "CreateGroup");
            try
            {
                #if DESKTOP
                return client.CreateGroup(request);
                #elif CORECLR
                return client.CreateGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String GroupName { get; set; }
            public System.Boolean? InsightsConfiguration_InsightsEnabled { get; set; }
            public System.Boolean? InsightsConfiguration_NotificationsEnabled { get; set; }
            public List<Amazon.XRay.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.XRay.Model.CreateGroupResponse, NewXRGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Group;
        }
        
    }
}
