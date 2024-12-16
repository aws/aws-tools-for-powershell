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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a user profile. A user profile represents a single user within a domain, and
    /// is the main way to reference a "person" for the purposes of sharing, reporting, and
    /// other user-oriented features. This entity is created when a user onboards to a domain.
    /// If an administrator invites a person by email or imports them from IAM Identity Center,
    /// a user profile is automatically created. A user profile is the primary holder of settings
    /// for an individual user and has a reference to the user's private Amazon Elastic File
    /// System home directory.
    /// </summary>
    [Cmdlet("New", "SMUserProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateUserProfile API operation.", Operation = new[] {"CreateUserProfile"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateUserProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateUserProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateUserProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMUserProfileCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the associated Domain.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter SingleSignOnUserIdentifier
        /// <summary>
        /// <para>
        /// <para>A specifier for the type of value specified in SingleSignOnUserValue. Currently, the
        /// only supported value is "UserName". If the Domain's AuthMode is IAM Identity Center,
        /// this field is required. If the Domain's AuthMode is not IAM Identity Center, this
        /// field cannot be specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SingleSignOnUserIdentifier { get; set; }
        #endregion
        
        #region Parameter SingleSignOnUserValue
        /// <summary>
        /// <para>
        /// <para>The username of the associated Amazon Web Services Single Sign-On User for this UserProfile.
        /// If the Domain's AuthMode is IAM Identity Center, this field is required, and must
        /// match a valid username of a user in your directory. If the Domain's AuthMode is not
        /// IAM Identity Center, this field cannot be specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SingleSignOnUserValue { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Each tag consists of a key and an optional value. Tag keys must be unique per resource.</para><para>Tags that you specify for the User Profile are also added to all Apps that the User
        /// Profile launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UserProfileName
        /// <summary>
        /// <para>
        /// <para>A name for the UserProfile. This value is not case sensitive.</para>
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
        public System.String UserProfileName { get; set; }
        #endregion
        
        #region Parameter UserSetting
        /// <summary>
        /// <para>
        /// <para>A collection of settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserSettings")]
        public Amazon.SageMaker.Model.UserSettings UserSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserProfileArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateUserProfileResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateUserProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserProfileArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMUserProfile (CreateUserProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateUserProfileResponse, NewSMUserProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SingleSignOnUserIdentifier = this.SingleSignOnUserIdentifier;
            context.SingleSignOnUserValue = this.SingleSignOnUserValue;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.UserProfileName = this.UserProfileName;
            #if MODULAR
            if (this.UserProfileName == null && ParameterWasBound(nameof(this.UserProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter UserProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserSetting = this.UserSetting;
            
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
            var request = new Amazon.SageMaker.Model.CreateUserProfileRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.SingleSignOnUserIdentifier != null)
            {
                request.SingleSignOnUserIdentifier = cmdletContext.SingleSignOnUserIdentifier;
            }
            if (cmdletContext.SingleSignOnUserValue != null)
            {
                request.SingleSignOnUserValue = cmdletContext.SingleSignOnUserValue;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserProfileName != null)
            {
                request.UserProfileName = cmdletContext.UserProfileName;
            }
            if (cmdletContext.UserSetting != null)
            {
                request.UserSettings = cmdletContext.UserSetting;
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
        
        private Amazon.SageMaker.Model.CreateUserProfileResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateUserProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateUserProfile");
            try
            {
                #if DESKTOP
                return client.CreateUserProfile(request);
                #elif CORECLR
                return client.CreateUserProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String SingleSignOnUserIdentifier { get; set; }
            public System.String SingleSignOnUserValue { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String UserProfileName { get; set; }
            public Amazon.SageMaker.Model.UserSettings UserSetting { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateUserProfileResponse, NewSMUserProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserProfileArn;
        }
        
    }
}
