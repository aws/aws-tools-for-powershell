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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a protected job that is started by Clean Rooms.
    /// </summary>
    [Cmdlet("Start", "CRSProtectedJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ProtectedJob")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service StartProtectedJob API operation.", Operation = new[] {"StartProtectedJob"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.StartProtectedJobResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ProtectedJob or Amazon.CleanRooms.Model.StartProtectedJobResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ProtectedJob object.",
        "The service call response (type Amazon.CleanRooms.Model.StartProtectedJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCRSProtectedJobCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Member_AccountId
        /// <summary>
        /// <para>
        /// <para> The account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_OutputConfiguration_Member_AccountId")]
        public System.String Member_AccountId { get; set; }
        #endregion
        
        #region Parameter JobParameters_AnalysisTemplateArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the analysis template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobParameters_AnalysisTemplateArn { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the membership to run this job against. Currently accepts
        /// a membership ID.</para>
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para> The type of protected job to start.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.ProtectedJobType")]
        public Amazon.CleanRooms.ProtectedJobType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProtectedJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.StartProtectedJobResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.StartProtectedJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProtectedJob";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CRSProtectedJob (StartProtectedJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.StartProtectedJobResponse, StartCRSProtectedJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobParameters_AnalysisTemplateArn = this.JobParameters_AnalysisTemplateArn;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Member_AccountId = this.Member_AccountId;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.StartProtectedJobRequest();
            
            
             // populate JobParameters
            var requestJobParametersIsNull = true;
            request.JobParameters = new Amazon.CleanRooms.Model.ProtectedJobParameters();
            System.String requestJobParameters_jobParameters_AnalysisTemplateArn = null;
            if (cmdletContext.JobParameters_AnalysisTemplateArn != null)
            {
                requestJobParameters_jobParameters_AnalysisTemplateArn = cmdletContext.JobParameters_AnalysisTemplateArn;
            }
            if (requestJobParameters_jobParameters_AnalysisTemplateArn != null)
            {
                request.JobParameters.AnalysisTemplateArn = requestJobParameters_jobParameters_AnalysisTemplateArn;
                requestJobParametersIsNull = false;
            }
             // determine if request.JobParameters should be set to null
            if (requestJobParametersIsNull)
            {
                request.JobParameters = null;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            
             // populate ResultConfiguration
            var requestResultConfigurationIsNull = true;
            request.ResultConfiguration = new Amazon.CleanRooms.Model.ProtectedJobResultConfigurationInput();
            Amazon.CleanRooms.Model.ProtectedJobOutputConfigurationInput requestResultConfiguration_resultConfiguration_OutputConfiguration = null;
            
             // populate OutputConfiguration
            var requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration = new Amazon.CleanRooms.Model.ProtectedJobOutputConfigurationInput();
            Amazon.CleanRooms.Model.ProtectedJobMemberOutputConfigurationInput requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member = null;
            
             // populate Member
            var requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_MemberIsNull = true;
            requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member = new Amazon.CleanRooms.Model.ProtectedJobMemberOutputConfigurationInput();
            System.String requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId = null;
            if (cmdletContext.Member_AccountId != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId = cmdletContext.Member_AccountId;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member.AccountId = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member_member_AccountId;
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_MemberIsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member should be set to null
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_MemberIsNull)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member = null;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member != null)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration.Member = requestResultConfiguration_resultConfiguration_OutputConfiguration_resultConfiguration_OutputConfiguration_Member;
                requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_OutputConfiguration should be set to null
            if (requestResultConfiguration_resultConfiguration_OutputConfigurationIsNull)
            {
                requestResultConfiguration_resultConfiguration_OutputConfiguration = null;
            }
            if (requestResultConfiguration_resultConfiguration_OutputConfiguration != null)
            {
                request.ResultConfiguration.OutputConfiguration = requestResultConfiguration_resultConfiguration_OutputConfiguration;
                requestResultConfigurationIsNull = false;
            }
             // determine if request.ResultConfiguration should be set to null
            if (requestResultConfigurationIsNull)
            {
                request.ResultConfiguration = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.CleanRooms.Model.StartProtectedJobResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.StartProtectedJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "StartProtectedJob");
            try
            {
                return client.StartProtectedJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String JobParameters_AnalysisTemplateArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Member_AccountId { get; set; }
            public Amazon.CleanRooms.ProtectedJobType Type { get; set; }
            public System.Func<Amazon.CleanRooms.Model.StartProtectedJobResponse, StartCRSProtectedJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProtectedJob;
        }
        
    }
}
