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
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;

namespace Amazon.PowerShell.Cmdlets.RG
{
    /// <summary>
    /// Turns on or turns off optional features in Resource Groups.
    /// 
    ///  
    /// <para>
    /// The preceding example shows that the request to turn on group lifecycle events is
    /// <c>IN_PROGRESS</c>. You can call the <a>GetAccountSettings</a> operation to check
    /// for completion by looking for <c>GroupLifecycleEventsStatus</c> to change to <c>ACTIVE</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "RGAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResourceGroups.Model.AccountSettings")]
    [AWSCmdlet("Calls the AWS Resource Groups UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.ResourceGroups.Model.AccountSettings or Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse",
        "This cmdlet returns an Amazon.ResourceGroups.Model.AccountSettings object.",
        "The service call response (type Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateRGAccountSettingCmdlet : AmazonResourceGroupsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupLifecycleEventsDesiredStatus
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to turn <a href="https://docs.aws.amazon.com/ARG/latest/userguide/monitor-groups.html">group
        /// lifecycle events</a> on or off.</para><para>You can't turn on group lifecycle events if your resource groups quota is greater
        /// than 2,000. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.ResourceGroups.GroupLifecycleEventsDesiredStatus")]
        public Amazon.ResourceGroups.GroupLifecycleEventsDesiredStatus GroupLifecycleEventsDesiredStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountSettings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountSettings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupLifecycleEventsDesiredStatus parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupLifecycleEventsDesiredStatus' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupLifecycleEventsDesiredStatus' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupLifecycleEventsDesiredStatus), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RGAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse, UpdateRGAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupLifecycleEventsDesiredStatus;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GroupLifecycleEventsDesiredStatus = this.GroupLifecycleEventsDesiredStatus;
            
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
            var request = new Amazon.ResourceGroups.Model.UpdateAccountSettingsRequest();
            
            if (cmdletContext.GroupLifecycleEventsDesiredStatus != null)
            {
                request.GroupLifecycleEventsDesiredStatus = cmdletContext.GroupLifecycleEventsDesiredStatus;
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
        
        private Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonResourceGroups client, Amazon.ResourceGroups.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups", "UpdateAccountSettings");
            try
            {
                #if DESKTOP
                return client.UpdateAccountSettings(request);
                #elif CORECLR
                return client.UpdateAccountSettingsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ResourceGroups.GroupLifecycleEventsDesiredStatus GroupLifecycleEventsDesiredStatus { get; set; }
            public System.Func<Amazon.ResourceGroups.Model.UpdateAccountSettingsResponse, UpdateRGAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountSettings;
        }
        
    }
}
