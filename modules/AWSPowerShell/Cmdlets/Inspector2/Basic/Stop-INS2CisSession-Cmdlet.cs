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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Stops a CIS session. This API is used by the Amazon Inspector SSM plugin to communicate
    /// with the Amazon Inspector service. The Amazon Inspector SSM plugin calls this API
    /// to stop a CIS scan session for the scan ID supplied by the service.
    /// </summary>
    [Cmdlet("Stop", "INS2CisSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Inspector2 StopCisSession API operation.", Operation = new[] {"StopCisSession"}, SelectReturnType = typeof(Amazon.Inspector2.Model.StopCisSessionResponse))]
    [AWSCmdletOutput("None or Amazon.Inspector2.Model.StopCisSessionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Inspector2.Model.StopCisSessionResponse) be returned by specifying '-Select *'."
    )]
    public partial class StopINS2CisSessionCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Message_BenchmarkProfile
        /// <summary>
        /// <para>
        /// <para>The message benchmark profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Message_BenchmarkProfile { get; set; }
        #endregion
        
        #region Parameter Message_BenchmarkVersion
        /// <summary>
        /// <para>
        /// <para>The message benchmark version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Message_BenchmarkVersion { get; set; }
        #endregion
        
        #region Parameter Progress_ErrorCheck
        /// <summary>
        /// <para>
        /// <para>The progress' error checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_ErrorChecks")]
        public System.Int32? Progress_ErrorCheck { get; set; }
        #endregion
        
        #region Parameter Progress_FailedCheck
        /// <summary>
        /// <para>
        /// <para>The progress' failed checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_FailedChecks")]
        public System.Int32? Progress_FailedCheck { get; set; }
        #endregion
        
        #region Parameter Progress_InformationalCheck
        /// <summary>
        /// <para>
        /// <para>The progress' informational checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_InformationalChecks")]
        public System.Int32? Progress_InformationalCheck { get; set; }
        #endregion
        
        #region Parameter Progress_NotApplicableCheck
        /// <summary>
        /// <para>
        /// <para>The progress' not applicable checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_NotApplicableChecks")]
        public System.Int32? Progress_NotApplicableCheck { get; set; }
        #endregion
        
        #region Parameter Progress_NotEvaluatedCheck
        /// <summary>
        /// <para>
        /// <para>The progress' not evaluated checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_NotEvaluatedChecks")]
        public System.Int32? Progress_NotEvaluatedCheck { get; set; }
        #endregion
        
        #region Parameter ComputePlatform_Product
        /// <summary>
        /// <para>
        /// <para>The compute platform product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_ComputePlatform_Product")]
        public System.String ComputePlatform_Product { get; set; }
        #endregion
        
        #region Parameter Message_Reason
        /// <summary>
        /// <para>
        /// <para>The reason for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Message_Reason { get; set; }
        #endregion
        
        #region Parameter ScanJobId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the scan job.</para>
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
        public System.String ScanJobId { get; set; }
        #endregion
        
        #region Parameter CisSessionToken
        /// <summary>
        /// <para>
        /// <para>The unique token that identifies the CIS session.</para>
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
        public System.String CisSessionToken { get; set; }
        #endregion
        
        #region Parameter Message_Status
        /// <summary>
        /// <para>
        /// <para>The status of the message.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.StopCisSessionStatus")]
        public Amazon.Inspector2.StopCisSessionStatus Message_Status { get; set; }
        #endregion
        
        #region Parameter Progress_SuccessfulCheck
        /// <summary>
        /// <para>
        /// <para>The progress' successful checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_SuccessfulChecks")]
        public System.Int32? Progress_SuccessfulCheck { get; set; }
        #endregion
        
        #region Parameter Progress_TotalCheck
        /// <summary>
        /// <para>
        /// <para>The progress' total checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_TotalChecks")]
        public System.Int32? Progress_TotalCheck { get; set; }
        #endregion
        
        #region Parameter Progress_UnknownCheck
        /// <summary>
        /// <para>
        /// <para>The progress' unknown checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Progress_UnknownChecks")]
        public System.Int32? Progress_UnknownCheck { get; set; }
        #endregion
        
        #region Parameter ComputePlatform_Vendor
        /// <summary>
        /// <para>
        /// <para>The compute platform vendor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_ComputePlatform_Vendor")]
        public System.String ComputePlatform_Vendor { get; set; }
        #endregion
        
        #region Parameter ComputePlatform_Version
        /// <summary>
        /// <para>
        /// <para>The compute platform version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_ComputePlatform_Version")]
        public System.String ComputePlatform_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.StopCisSessionResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScanJobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-INS2CisSession (StopCisSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.StopCisSessionResponse, StopINS2CisSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Message_BenchmarkProfile = this.Message_BenchmarkProfile;
            context.Message_BenchmarkVersion = this.Message_BenchmarkVersion;
            context.ComputePlatform_Product = this.ComputePlatform_Product;
            context.ComputePlatform_Vendor = this.ComputePlatform_Vendor;
            context.ComputePlatform_Version = this.ComputePlatform_Version;
            context.Progress_ErrorCheck = this.Progress_ErrorCheck;
            context.Progress_FailedCheck = this.Progress_FailedCheck;
            context.Progress_InformationalCheck = this.Progress_InformationalCheck;
            context.Progress_NotApplicableCheck = this.Progress_NotApplicableCheck;
            context.Progress_NotEvaluatedCheck = this.Progress_NotEvaluatedCheck;
            context.Progress_SuccessfulCheck = this.Progress_SuccessfulCheck;
            context.Progress_TotalCheck = this.Progress_TotalCheck;
            context.Progress_UnknownCheck = this.Progress_UnknownCheck;
            context.Message_Reason = this.Message_Reason;
            context.Message_Status = this.Message_Status;
            #if MODULAR
            if (this.Message_Status == null && ParameterWasBound(nameof(this.Message_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Message_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanJobId = this.ScanJobId;
            #if MODULAR
            if (this.ScanJobId == null && ParameterWasBound(nameof(this.ScanJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CisSessionToken = this.CisSessionToken;
            #if MODULAR
            if (this.CisSessionToken == null && ParameterWasBound(nameof(this.CisSessionToken)))
            {
                WriteWarning("You are passing $null as a value for parameter CisSessionToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.StopCisSessionRequest();
            
            
             // populate Message
            var requestMessageIsNull = true;
            request.Message = new Amazon.Inspector2.Model.StopCisSessionMessage();
            System.String requestMessage_message_BenchmarkProfile = null;
            if (cmdletContext.Message_BenchmarkProfile != null)
            {
                requestMessage_message_BenchmarkProfile = cmdletContext.Message_BenchmarkProfile;
            }
            if (requestMessage_message_BenchmarkProfile != null)
            {
                request.Message.BenchmarkProfile = requestMessage_message_BenchmarkProfile;
                requestMessageIsNull = false;
            }
            System.String requestMessage_message_BenchmarkVersion = null;
            if (cmdletContext.Message_BenchmarkVersion != null)
            {
                requestMessage_message_BenchmarkVersion = cmdletContext.Message_BenchmarkVersion;
            }
            if (requestMessage_message_BenchmarkVersion != null)
            {
                request.Message.BenchmarkVersion = requestMessage_message_BenchmarkVersion;
                requestMessageIsNull = false;
            }
            System.String requestMessage_message_Reason = null;
            if (cmdletContext.Message_Reason != null)
            {
                requestMessage_message_Reason = cmdletContext.Message_Reason;
            }
            if (requestMessage_message_Reason != null)
            {
                request.Message.Reason = requestMessage_message_Reason;
                requestMessageIsNull = false;
            }
            Amazon.Inspector2.StopCisSessionStatus requestMessage_message_Status = null;
            if (cmdletContext.Message_Status != null)
            {
                requestMessage_message_Status = cmdletContext.Message_Status;
            }
            if (requestMessage_message_Status != null)
            {
                request.Message.Status = requestMessage_message_Status;
                requestMessageIsNull = false;
            }
            Amazon.Inspector2.Model.ComputePlatform requestMessage_message_ComputePlatform = null;
            
             // populate ComputePlatform
            var requestMessage_message_ComputePlatformIsNull = true;
            requestMessage_message_ComputePlatform = new Amazon.Inspector2.Model.ComputePlatform();
            System.String requestMessage_message_ComputePlatform_computePlatform_Product = null;
            if (cmdletContext.ComputePlatform_Product != null)
            {
                requestMessage_message_ComputePlatform_computePlatform_Product = cmdletContext.ComputePlatform_Product;
            }
            if (requestMessage_message_ComputePlatform_computePlatform_Product != null)
            {
                requestMessage_message_ComputePlatform.Product = requestMessage_message_ComputePlatform_computePlatform_Product;
                requestMessage_message_ComputePlatformIsNull = false;
            }
            System.String requestMessage_message_ComputePlatform_computePlatform_Vendor = null;
            if (cmdletContext.ComputePlatform_Vendor != null)
            {
                requestMessage_message_ComputePlatform_computePlatform_Vendor = cmdletContext.ComputePlatform_Vendor;
            }
            if (requestMessage_message_ComputePlatform_computePlatform_Vendor != null)
            {
                requestMessage_message_ComputePlatform.Vendor = requestMessage_message_ComputePlatform_computePlatform_Vendor;
                requestMessage_message_ComputePlatformIsNull = false;
            }
            System.String requestMessage_message_ComputePlatform_computePlatform_Version = null;
            if (cmdletContext.ComputePlatform_Version != null)
            {
                requestMessage_message_ComputePlatform_computePlatform_Version = cmdletContext.ComputePlatform_Version;
            }
            if (requestMessage_message_ComputePlatform_computePlatform_Version != null)
            {
                requestMessage_message_ComputePlatform.Version = requestMessage_message_ComputePlatform_computePlatform_Version;
                requestMessage_message_ComputePlatformIsNull = false;
            }
             // determine if requestMessage_message_ComputePlatform should be set to null
            if (requestMessage_message_ComputePlatformIsNull)
            {
                requestMessage_message_ComputePlatform = null;
            }
            if (requestMessage_message_ComputePlatform != null)
            {
                request.Message.ComputePlatform = requestMessage_message_ComputePlatform;
                requestMessageIsNull = false;
            }
            Amazon.Inspector2.Model.StopCisMessageProgress requestMessage_message_Progress = null;
            
             // populate Progress
            var requestMessage_message_ProgressIsNull = true;
            requestMessage_message_Progress = new Amazon.Inspector2.Model.StopCisMessageProgress();
            System.Int32? requestMessage_message_Progress_progress_ErrorCheck = null;
            if (cmdletContext.Progress_ErrorCheck != null)
            {
                requestMessage_message_Progress_progress_ErrorCheck = cmdletContext.Progress_ErrorCheck.Value;
            }
            if (requestMessage_message_Progress_progress_ErrorCheck != null)
            {
                requestMessage_message_Progress.ErrorChecks = requestMessage_message_Progress_progress_ErrorCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
            System.Int32? requestMessage_message_Progress_progress_FailedCheck = null;
            if (cmdletContext.Progress_FailedCheck != null)
            {
                requestMessage_message_Progress_progress_FailedCheck = cmdletContext.Progress_FailedCheck.Value;
            }
            if (requestMessage_message_Progress_progress_FailedCheck != null)
            {
                requestMessage_message_Progress.FailedChecks = requestMessage_message_Progress_progress_FailedCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
            System.Int32? requestMessage_message_Progress_progress_InformationalCheck = null;
            if (cmdletContext.Progress_InformationalCheck != null)
            {
                requestMessage_message_Progress_progress_InformationalCheck = cmdletContext.Progress_InformationalCheck.Value;
            }
            if (requestMessage_message_Progress_progress_InformationalCheck != null)
            {
                requestMessage_message_Progress.InformationalChecks = requestMessage_message_Progress_progress_InformationalCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
            System.Int32? requestMessage_message_Progress_progress_NotApplicableCheck = null;
            if (cmdletContext.Progress_NotApplicableCheck != null)
            {
                requestMessage_message_Progress_progress_NotApplicableCheck = cmdletContext.Progress_NotApplicableCheck.Value;
            }
            if (requestMessage_message_Progress_progress_NotApplicableCheck != null)
            {
                requestMessage_message_Progress.NotApplicableChecks = requestMessage_message_Progress_progress_NotApplicableCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
            System.Int32? requestMessage_message_Progress_progress_NotEvaluatedCheck = null;
            if (cmdletContext.Progress_NotEvaluatedCheck != null)
            {
                requestMessage_message_Progress_progress_NotEvaluatedCheck = cmdletContext.Progress_NotEvaluatedCheck.Value;
            }
            if (requestMessage_message_Progress_progress_NotEvaluatedCheck != null)
            {
                requestMessage_message_Progress.NotEvaluatedChecks = requestMessage_message_Progress_progress_NotEvaluatedCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
            System.Int32? requestMessage_message_Progress_progress_SuccessfulCheck = null;
            if (cmdletContext.Progress_SuccessfulCheck != null)
            {
                requestMessage_message_Progress_progress_SuccessfulCheck = cmdletContext.Progress_SuccessfulCheck.Value;
            }
            if (requestMessage_message_Progress_progress_SuccessfulCheck != null)
            {
                requestMessage_message_Progress.SuccessfulChecks = requestMessage_message_Progress_progress_SuccessfulCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
            System.Int32? requestMessage_message_Progress_progress_TotalCheck = null;
            if (cmdletContext.Progress_TotalCheck != null)
            {
                requestMessage_message_Progress_progress_TotalCheck = cmdletContext.Progress_TotalCheck.Value;
            }
            if (requestMessage_message_Progress_progress_TotalCheck != null)
            {
                requestMessage_message_Progress.TotalChecks = requestMessage_message_Progress_progress_TotalCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
            System.Int32? requestMessage_message_Progress_progress_UnknownCheck = null;
            if (cmdletContext.Progress_UnknownCheck != null)
            {
                requestMessage_message_Progress_progress_UnknownCheck = cmdletContext.Progress_UnknownCheck.Value;
            }
            if (requestMessage_message_Progress_progress_UnknownCheck != null)
            {
                requestMessage_message_Progress.UnknownChecks = requestMessage_message_Progress_progress_UnknownCheck.Value;
                requestMessage_message_ProgressIsNull = false;
            }
             // determine if requestMessage_message_Progress should be set to null
            if (requestMessage_message_ProgressIsNull)
            {
                requestMessage_message_Progress = null;
            }
            if (requestMessage_message_Progress != null)
            {
                request.Message.Progress = requestMessage_message_Progress;
                requestMessageIsNull = false;
            }
             // determine if request.Message should be set to null
            if (requestMessageIsNull)
            {
                request.Message = null;
            }
            if (cmdletContext.ScanJobId != null)
            {
                request.ScanJobId = cmdletContext.ScanJobId;
            }
            if (cmdletContext.CisSessionToken != null)
            {
                request.SessionToken = cmdletContext.CisSessionToken;
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
        
        private Amazon.Inspector2.Model.StopCisSessionResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.StopCisSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "StopCisSession");
            try
            {
                #if DESKTOP
                return client.StopCisSession(request);
                #elif CORECLR
                return client.StopCisSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String Message_BenchmarkProfile { get; set; }
            public System.String Message_BenchmarkVersion { get; set; }
            public System.String ComputePlatform_Product { get; set; }
            public System.String ComputePlatform_Vendor { get; set; }
            public System.String ComputePlatform_Version { get; set; }
            public System.Int32? Progress_ErrorCheck { get; set; }
            public System.Int32? Progress_FailedCheck { get; set; }
            public System.Int32? Progress_InformationalCheck { get; set; }
            public System.Int32? Progress_NotApplicableCheck { get; set; }
            public System.Int32? Progress_NotEvaluatedCheck { get; set; }
            public System.Int32? Progress_SuccessfulCheck { get; set; }
            public System.Int32? Progress_TotalCheck { get; set; }
            public System.Int32? Progress_UnknownCheck { get; set; }
            public System.String Message_Reason { get; set; }
            public Amazon.Inspector2.StopCisSessionStatus Message_Status { get; set; }
            public System.String ScanJobId { get; set; }
            public System.String CisSessionToken { get; set; }
            public System.Func<Amazon.Inspector2.Model.StopCisSessionResponse, StopINS2CisSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
