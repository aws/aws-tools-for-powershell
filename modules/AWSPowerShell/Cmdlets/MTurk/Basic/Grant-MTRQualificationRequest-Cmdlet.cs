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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <c>AcceptQualificationRequest</c> operation approves a Worker's request for a
    /// Qualification. 
    /// 
    ///  
    /// <para>
    ///  Only the owner of the Qualification type can grant a Qualification request for that
    /// type. 
    /// </para><para>
    ///  A successful request for the <c>AcceptQualificationRequest</c> operation returns
    /// with no errors and an empty body. 
    /// </para>
    /// </summary>
    [Cmdlet("Grant", "MTRQualificationRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon MTurk Service AcceptQualificationRequest API operation.", Operation = new[] {"AcceptQualificationRequest"}, SelectReturnType = typeof(Amazon.MTurk.Model.AcceptQualificationRequestResponse))]
    [AWSCmdletOutput("None or Amazon.MTurk.Model.AcceptQualificationRequestResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MTurk.Model.AcceptQualificationRequestResponse) be returned by specifying '-Select *'."
    )]
    public partial class GrantMTRQualificationRequestCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IntegerValue
        /// <summary>
        /// <para>
        /// <para> The value of the Qualification. You can omit this value if you are using the presence
        /// or absence of the Qualification as the basis for a HIT requirement. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IntegerValue { get; set; }
        #endregion
        
        #region Parameter QualificationRequestId
        /// <summary>
        /// <para>
        /// <para>The ID of the Qualification request, as returned by the <c>GetQualificationRequests</c>
        /// operation.</para>
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
        public System.String QualificationRequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.AcceptQualificationRequestResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QualificationRequestId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Grant-MTRQualificationRequest (AcceptQualificationRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.AcceptQualificationRequestResponse, GrantMTRQualificationRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IntegerValue = this.IntegerValue;
            context.QualificationRequestId = this.QualificationRequestId;
            #if MODULAR
            if (this.QualificationRequestId == null && ParameterWasBound(nameof(this.QualificationRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter QualificationRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MTurk.Model.AcceptQualificationRequestRequest();
            
            if (cmdletContext.IntegerValue != null)
            {
                request.IntegerValue = cmdletContext.IntegerValue.Value;
            }
            if (cmdletContext.QualificationRequestId != null)
            {
                request.QualificationRequestId = cmdletContext.QualificationRequestId;
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
        
        private Amazon.MTurk.Model.AcceptQualificationRequestResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.AcceptQualificationRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "AcceptQualificationRequest");
            try
            {
                return client.AcceptQualificationRequestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? IntegerValue { get; set; }
            public System.String QualificationRequestId { get; set; }
            public System.Func<Amazon.MTurk.Model.AcceptQualificationRequestResponse, GrantMTRQualificationRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
