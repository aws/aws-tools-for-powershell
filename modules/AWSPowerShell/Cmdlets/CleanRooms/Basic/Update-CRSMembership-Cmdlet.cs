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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Updates a membership.
    /// </summary>
    [Cmdlet("Update", "CRSMembership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.Membership")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service UpdateMembership API operation.", Operation = new[] {"UpdateMembership"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.UpdateMembershipResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.Membership or Amazon.CleanRooms.Model.UpdateMembershipResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.Membership object.",
        "The service call response (type Amazon.CleanRooms.Model.UpdateMembershipResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCRSMembershipCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket to unload the protected query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultResultConfiguration_OutputConfiguration_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter S3_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 prefix to unload the protected query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultResultConfiguration_OutputConfiguration_S3_KeyPrefix")]
        public System.String S3_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the membership.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter QueryLogStatus
        /// <summary>
        /// <para>
        /// <para>An indicator as to whether query logging has been enabled or disabled for the collaboration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRooms.MembershipQueryLogStatus")]
        public Amazon.CleanRooms.MembershipQueryLogStatus QueryLogStatus { get; set; }
        #endregion
        
        #region Parameter S3_ResultFormat
        /// <summary>
        /// <para>
        /// <para>Intended file format of the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultResultConfiguration_OutputConfiguration_S3_ResultFormat")]
        [AWSConstantClassSource("Amazon.CleanRooms.ResultFormat")]
        public Amazon.CleanRooms.ResultFormat S3_ResultFormat { get; set; }
        #endregion
        
        #region Parameter DefaultResultConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The unique ARN for an IAM role that is used by Clean Rooms to write protected query
        /// results to the result location, given by the member who can receive results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultResultConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Membership'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.UpdateMembershipResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.UpdateMembershipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Membership";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MembershipIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MembershipIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MembershipIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CRSMembership (UpdateMembership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.UpdateMembershipResponse, UpdateCRSMembershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MembershipIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3_Bucket = this.S3_Bucket;
            context.S3_KeyPrefix = this.S3_KeyPrefix;
            context.S3_ResultFormat = this.S3_ResultFormat;
            context.DefaultResultConfiguration_RoleArn = this.DefaultResultConfiguration_RoleArn;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryLogStatus = this.QueryLogStatus;
            
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
            var request = new Amazon.CleanRooms.Model.UpdateMembershipRequest();
            
            
             // populate DefaultResultConfiguration
            var requestDefaultResultConfigurationIsNull = true;
            request.DefaultResultConfiguration = new Amazon.CleanRooms.Model.MembershipProtectedQueryResultConfiguration();
            System.String requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn = null;
            if (cmdletContext.DefaultResultConfiguration_RoleArn != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn = cmdletContext.DefaultResultConfiguration_RoleArn;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn != null)
            {
                request.DefaultResultConfiguration.RoleArn = requestDefaultResultConfiguration_defaultResultConfiguration_RoleArn;
                requestDefaultResultConfigurationIsNull = false;
            }
            Amazon.CleanRooms.Model.MembershipProtectedQueryOutputConfiguration requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration = null;
            
             // populate OutputConfiguration
            var requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfigurationIsNull = true;
            requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration = new Amazon.CleanRooms.Model.MembershipProtectedQueryOutputConfiguration();
            Amazon.CleanRooms.Model.ProtectedQueryS3OutputConfiguration requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 = null;
            
             // populate S3
            var requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = true;
            requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 = new Amazon.CleanRooms.Model.ProtectedQueryS3OutputConfiguration();
            System.String requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3.Bucket = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_Bucket;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            System.String requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix = null;
            if (cmdletContext.S3_KeyPrefix != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix = cmdletContext.S3_KeyPrefix;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3.KeyPrefix = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_KeyPrefix;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = false;
            }
            Amazon.CleanRooms.ResultFormat requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat = null;
            if (cmdletContext.S3_ResultFormat != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat = cmdletContext.S3_ResultFormat;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3.ResultFormat = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3_s3_ResultFormat;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull = false;
            }
             // determine if requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 should be set to null
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3IsNull)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 = null;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3 != null)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration.S3 = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration_defaultResultConfiguration_OutputConfiguration_S3;
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfigurationIsNull = false;
            }
             // determine if requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration should be set to null
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfigurationIsNull)
            {
                requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration = null;
            }
            if (requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration != null)
            {
                request.DefaultResultConfiguration.OutputConfiguration = requestDefaultResultConfiguration_defaultResultConfiguration_OutputConfiguration;
                requestDefaultResultConfigurationIsNull = false;
            }
             // determine if request.DefaultResultConfiguration should be set to null
            if (requestDefaultResultConfigurationIsNull)
            {
                request.DefaultResultConfiguration = null;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.QueryLogStatus != null)
            {
                request.QueryLogStatus = cmdletContext.QueryLogStatus;
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
        
        private Amazon.CleanRooms.Model.UpdateMembershipResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.UpdateMembershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "UpdateMembership");
            try
            {
                #if DESKTOP
                return client.UpdateMembership(request);
                #elif CORECLR
                return client.UpdateMembershipAsync(request).GetAwaiter().GetResult();
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
            public System.String S3_Bucket { get; set; }
            public System.String S3_KeyPrefix { get; set; }
            public Amazon.CleanRooms.ResultFormat S3_ResultFormat { get; set; }
            public System.String DefaultResultConfiguration_RoleArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public Amazon.CleanRooms.MembershipQueryLogStatus QueryLogStatus { get; set; }
            public System.Func<Amazon.CleanRooms.Model.UpdateMembershipResponse, UpdateCRSMembershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Membership;
        }
        
    }
}
