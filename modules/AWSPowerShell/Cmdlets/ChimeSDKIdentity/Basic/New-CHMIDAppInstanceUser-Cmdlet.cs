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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Creates a user under an Amazon Chime <c>AppInstance</c>. The request consists of a
    /// unique <c>appInstanceUserId</c> and <c>Name</c> for that user.
    /// </summary>
    [Cmdlet("New", "CHMIDAppInstanceUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity CreateAppInstanceUser API operation.", Operation = new[] {"CreateAppInstanceUser"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse))]
    [AWSCmdletOutput("System.String or Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMIDAppInstanceUserCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppInstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstance</c> request.</para>
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
        public System.String AppInstanceArn { get; set; }
        #endregion
        
        #region Parameter AppInstanceUserId
        /// <summary>
        /// <para>
        /// <para>The user ID of the <c>AppInstance</c>.</para>
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
        public System.String AppInstanceUserId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique ID of the request. Use different tokens to request additional <c>AppInstances</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
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
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The request's metadata. Limited to a 1KB string in UTF-8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Metadata { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The user's name.</para>
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
        /// <para>Tags assigned to the <c>AppInstanceUser</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKIdentity.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppInstanceUserArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppInstanceUserArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppInstanceUserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMIDAppInstanceUser (CreateAppInstanceUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse, NewCHMIDAppInstanceUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppInstanceArn = this.AppInstanceArn;
            #if MODULAR
            if (this.AppInstanceArn == null && ParameterWasBound(nameof(this.AppInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppInstanceUserId = this.AppInstanceUserId;
            #if MODULAR
            if (this.AppInstanceUserId == null && ParameterWasBound(nameof(this.AppInstanceUserId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceUserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ExpirationSettings_ExpirationCriterion = this.ExpirationSettings_ExpirationCriterion;
            context.ExpirationSettings_ExpirationDay = this.ExpirationSettings_ExpirationDay;
            context.Metadata = this.Metadata;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKIdentity.Model.Tag>(this.Tag);
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
            var request = new Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserRequest();
            
            if (cmdletContext.AppInstanceArn != null)
            {
                request.AppInstanceArn = cmdletContext.AppInstanceArn;
            }
            if (cmdletContext.AppInstanceUserId != null)
            {
                request.AppInstanceUserId = cmdletContext.AppInstanceUserId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
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
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "CreateAppInstanceUser");
            try
            {
                #if DESKTOP
                return client.CreateAppInstanceUser(request);
                #elif CORECLR
                return client.CreateAppInstanceUserAsync(request).GetAwaiter().GetResult();
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
            public System.String AppInstanceArn { get; set; }
            public System.String AppInstanceUserId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public Amazon.ChimeSDKIdentity.ExpirationCriterion ExpirationSettings_ExpirationCriterion { get; set; }
            public System.Int32? ExpirationSettings_ExpirationDay { get; set; }
            public System.String Metadata { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ChimeSDKIdentity.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.CreateAppInstanceUserResponse, NewCHMIDAppInstanceUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppInstanceUserArn;
        }
        
    }
}
