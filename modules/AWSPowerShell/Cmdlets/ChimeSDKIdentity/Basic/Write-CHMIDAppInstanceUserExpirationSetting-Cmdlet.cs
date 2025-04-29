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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Sets the number of days before the <c>AppInstanceUser</c> is automatically deleted.
    /// 
    ///  <note><para>
    /// A background process deletes expired <c>AppInstanceUsers</c> within 6 hours of expiration.
    /// Actual deletion times may vary.
    /// </para><para>
    /// Expired <c>AppInstanceUsers</c> that have not yet been deleted appear as active, and
    /// you can update their expiration settings. The system honors the new settings.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CHMIDAppInstanceUserExpirationSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity PutAppInstanceUserExpirationSettings API operation.", Operation = new[] {"PutAppInstanceUserExpirationSettings"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse",
        "This cmdlet returns an Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse object containing multiple properties."
    )]
    public partial class WriteCHMIDAppInstanceUserExpirationSettingCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppInstanceUserArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceUser</c>.</para>
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
        public System.String AppInstanceUserArn { get; set; }
        #endregion
        
        #region Parameter ExpirationSettings_ExpirationCriterion
        /// <summary>
        /// <para>
        /// <para>Specifies the conditions under which an <c>AppInstanceUser</c> will expire.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKIdentity.ExpirationCriterion")]
        public Amazon.ChimeSDKIdentity.ExpirationCriterion ExpirationSettings_ExpirationCriterion { get; set; }
        #endregion
        
        #region Parameter ExpirationSettings_ExpirationDay
        /// <summary>
        /// <para>
        /// <para>The period in days after which an <c>AppInstanceUser</c> will be automatically deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpirationSettings_ExpirationDays")]
        public System.Int32? ExpirationSettings_ExpirationDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppInstanceUserArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMIDAppInstanceUserExpirationSetting (PutAppInstanceUserExpirationSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse, WriteCHMIDAppInstanceUserExpirationSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppInstanceUserArn = this.AppInstanceUserArn;
            #if MODULAR
            if (this.AppInstanceUserArn == null && ParameterWasBound(nameof(this.AppInstanceUserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceUserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpirationSettings_ExpirationCriterion = this.ExpirationSettings_ExpirationCriterion;
            context.ExpirationSettings_ExpirationDay = this.ExpirationSettings_ExpirationDay;
            
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
            var request = new Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsRequest();
            
            if (cmdletContext.AppInstanceUserArn != null)
            {
                request.AppInstanceUserArn = cmdletContext.AppInstanceUserArn;
            }
            
             // populate ExpirationSettings
            var requestExpirationSettingsIsNull = true;
            request.ExpirationSettings = new Amazon.ChimeSDKIdentity.Model.ExpirationSettings();
            Amazon.ChimeSDKIdentity.ExpirationCriterion requestExpirationSettings_expirationSettings_ExpirationCriterion = null;
            if (cmdletContext.ExpirationSettings_ExpirationCriterion != null)
            {
                requestExpirationSettings_expirationSettings_ExpirationCriterion = cmdletContext.ExpirationSettings_ExpirationCriterion;
            }
            if (requestExpirationSettings_expirationSettings_ExpirationCriterion != null)
            {
                request.ExpirationSettings.ExpirationCriterion = requestExpirationSettings_expirationSettings_ExpirationCriterion;
                requestExpirationSettingsIsNull = false;
            }
            System.Int32? requestExpirationSettings_expirationSettings_ExpirationDay = null;
            if (cmdletContext.ExpirationSettings_ExpirationDay != null)
            {
                requestExpirationSettings_expirationSettings_ExpirationDay = cmdletContext.ExpirationSettings_ExpirationDay.Value;
            }
            if (requestExpirationSettings_expirationSettings_ExpirationDay != null)
            {
                request.ExpirationSettings.ExpirationDays = requestExpirationSettings_expirationSettings_ExpirationDay.Value;
                requestExpirationSettingsIsNull = false;
            }
             // determine if request.ExpirationSettings should be set to null
            if (requestExpirationSettingsIsNull)
            {
                request.ExpirationSettings = null;
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
        
        private Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "PutAppInstanceUserExpirationSettings");
            try
            {
                return client.PutAppInstanceUserExpirationSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppInstanceUserArn { get; set; }
            public Amazon.ChimeSDKIdentity.ExpirationCriterion ExpirationSettings_ExpirationCriterion { get; set; }
            public System.Int32? ExpirationSettings_ExpirationDay { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.PutAppInstanceUserExpirationSettingsResponse, WriteCHMIDAppInstanceUserExpirationSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
