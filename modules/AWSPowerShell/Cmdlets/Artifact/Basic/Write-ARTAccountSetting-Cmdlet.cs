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
using Amazon.Artifact;
using Amazon.Artifact.Model;

namespace Amazon.PowerShell.Cmdlets.ART
{
    /// <summary>
    /// Put the account settings for Artifact.
    /// </summary>
    [Cmdlet("Write", "ARTAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Artifact.Model.AccountSettings")]
    [AWSCmdlet("Calls the AWS Artifact PutAccountSettings API operation.", Operation = new[] {"PutAccountSettings"}, SelectReturnType = typeof(Amazon.Artifact.Model.PutAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.Artifact.Model.AccountSettings or Amazon.Artifact.Model.PutAccountSettingsResponse",
        "This cmdlet returns an Amazon.Artifact.Model.AccountSettings object.",
        "The service call response (type Amazon.Artifact.Model.PutAccountSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteARTAccountSettingCmdlet : AmazonArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NotificationSubscriptionStatus
        /// <summary>
        /// <para>
        /// <para>Desired notification subscription status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Artifact.NotificationSubscriptionStatus")]
        public Amazon.Artifact.NotificationSubscriptionStatus NotificationSubscriptionStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountSettings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Artifact.Model.PutAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.Artifact.Model.PutAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountSettings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NotificationSubscriptionStatus parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NotificationSubscriptionStatus' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NotificationSubscriptionStatus' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotificationSubscriptionStatus), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ARTAccountSetting (PutAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Artifact.Model.PutAccountSettingsResponse, WriteARTAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NotificationSubscriptionStatus;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NotificationSubscriptionStatus = this.NotificationSubscriptionStatus;
            
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
            var request = new Amazon.Artifact.Model.PutAccountSettingsRequest();
            
            if (cmdletContext.NotificationSubscriptionStatus != null)
            {
                request.NotificationSubscriptionStatus = cmdletContext.NotificationSubscriptionStatus;
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
        
        private Amazon.Artifact.Model.PutAccountSettingsResponse CallAWSServiceOperation(IAmazonArtifact client, Amazon.Artifact.Model.PutAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Artifact", "PutAccountSettings");
            try
            {
                #if DESKTOP
                return client.PutAccountSettings(request);
                #elif CORECLR
                return client.PutAccountSettingsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Artifact.NotificationSubscriptionStatus NotificationSubscriptionStatus { get; set; }
            public System.Func<Amazon.Artifact.Model.PutAccountSettingsResponse, WriteARTAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountSettings;
        }
        
    }
}
