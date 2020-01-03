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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Updates user details for a specified user ID. Currently, only <code>LicenseType</code>
    /// updates are supported for this action.
    /// </summary>
    [Cmdlet("Update", "CHMUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.User")]
    [AWSCmdlet("Calls the Amazon Chime UpdateUser API operation.", Operation = new[] {"UpdateUser"}, SelectReturnType = typeof(Amazon.Chime.Model.UpdateUserResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.User or Amazon.Chime.Model.UpdateUserResponse",
        "This cmdlet returns an Amazon.Chime.Model.User object.",
        "The service call response (type Amazon.Chime.Model.UpdateUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCHMUserCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime account ID.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AlexaForBusinessMetadata_AlexaForBusinessRoomArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the room resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AlexaForBusinessMetadata_AlexaForBusinessRoomArn { get; set; }
        #endregion
        
        #region Parameter AlexaForBusinessMetadata_IsAlexaForBusinessEnabled
        /// <summary>
        /// <para>
        /// <para>Starts or stops Alexa for Business.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AlexaForBusinessMetadata_IsAlexaForBusinessEnabled { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The user license type to update. This must be a supported license type for the Amazon
        /// Chime account that the user belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Chime.License")]
        public Amazon.Chime.License LicenseType { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID.</para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter UserType
        /// <summary>
        /// <para>
        /// <para>The user type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Chime.UserType")]
        public Amazon.Chime.UserType UserType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'User'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.UpdateUserResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.UpdateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "User";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMUser (UpdateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.UpdateUserResponse, UpdateCHMUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AlexaForBusinessMetadata_AlexaForBusinessRoomArn = this.AlexaForBusinessMetadata_AlexaForBusinessRoomArn;
            context.AlexaForBusinessMetadata_IsAlexaForBusinessEnabled = this.AlexaForBusinessMetadata_IsAlexaForBusinessEnabled;
            context.LicenseType = this.LicenseType;
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserType = this.UserType;
            
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
            var request = new Amazon.Chime.Model.UpdateUserRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate AlexaForBusinessMetadata
            var requestAlexaForBusinessMetadataIsNull = true;
            request.AlexaForBusinessMetadata = new Amazon.Chime.Model.AlexaForBusinessMetadata();
            System.String requestAlexaForBusinessMetadata_alexaForBusinessMetadata_AlexaForBusinessRoomArn = null;
            if (cmdletContext.AlexaForBusinessMetadata_AlexaForBusinessRoomArn != null)
            {
                requestAlexaForBusinessMetadata_alexaForBusinessMetadata_AlexaForBusinessRoomArn = cmdletContext.AlexaForBusinessMetadata_AlexaForBusinessRoomArn;
            }
            if (requestAlexaForBusinessMetadata_alexaForBusinessMetadata_AlexaForBusinessRoomArn != null)
            {
                request.AlexaForBusinessMetadata.AlexaForBusinessRoomArn = requestAlexaForBusinessMetadata_alexaForBusinessMetadata_AlexaForBusinessRoomArn;
                requestAlexaForBusinessMetadataIsNull = false;
            }
            System.Boolean? requestAlexaForBusinessMetadata_alexaForBusinessMetadata_IsAlexaForBusinessEnabled = null;
            if (cmdletContext.AlexaForBusinessMetadata_IsAlexaForBusinessEnabled != null)
            {
                requestAlexaForBusinessMetadata_alexaForBusinessMetadata_IsAlexaForBusinessEnabled = cmdletContext.AlexaForBusinessMetadata_IsAlexaForBusinessEnabled.Value;
            }
            if (requestAlexaForBusinessMetadata_alexaForBusinessMetadata_IsAlexaForBusinessEnabled != null)
            {
                request.AlexaForBusinessMetadata.IsAlexaForBusinessEnabled = requestAlexaForBusinessMetadata_alexaForBusinessMetadata_IsAlexaForBusinessEnabled.Value;
                requestAlexaForBusinessMetadataIsNull = false;
            }
             // determine if request.AlexaForBusinessMetadata should be set to null
            if (requestAlexaForBusinessMetadataIsNull)
            {
                request.AlexaForBusinessMetadata = null;
            }
            if (cmdletContext.LicenseType != null)
            {
                request.LicenseType = cmdletContext.LicenseType;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            if (cmdletContext.UserType != null)
            {
                request.UserType = cmdletContext.UserType;
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
        
        private Amazon.Chime.Model.UpdateUserResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.UpdateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "UpdateUser");
            try
            {
                #if DESKTOP
                return client.UpdateUser(request);
                #elif CORECLR
                return client.UpdateUserAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String AlexaForBusinessMetadata_AlexaForBusinessRoomArn { get; set; }
            public System.Boolean? AlexaForBusinessMetadata_IsAlexaForBusinessEnabled { get; set; }
            public Amazon.Chime.License LicenseType { get; set; }
            public System.String UserId { get; set; }
            public Amazon.Chime.UserType UserType { get; set; }
            public System.Func<Amazon.Chime.Model.UpdateUserResponse, UpdateCHMUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.User;
        }
        
    }
}
