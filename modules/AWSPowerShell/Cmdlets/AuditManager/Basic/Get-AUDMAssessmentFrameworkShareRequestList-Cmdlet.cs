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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Returns a list of sent or received share requests for custom frameworks in Audit
    /// Manager.
    /// </summary>
    [Cmdlet("Get", "AUDMAssessmentFrameworkShareRequestList")]
    [OutputType("Amazon.AuditManager.Model.AssessmentFrameworkShareRequest")]
    [AWSCmdlet("Calls the AWS Audit Manager ListAssessmentFrameworkShareRequests API operation.", Operation = new[] {"ListAssessmentFrameworkShareRequests"}, SelectReturnType = typeof(Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.AssessmentFrameworkShareRequest or Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse",
        "This cmdlet returns a collection of Amazon.AuditManager.Model.AssessmentFrameworkShareRequest objects.",
        "The service call response (type Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAUDMAssessmentFrameworkShareRequestListCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RequestType
        /// <summary>
        /// <para>
        /// <para> Specifies whether the share request is a sent request or a received request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AuditManager.ShareRequestType")]
        public Amazon.AuditManager.ShareRequestType RequestType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> Represents the maximum number of results on a page or for an API request call. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The pagination token that's used to fetch the next set of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssessmentFrameworkShareRequests'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssessmentFrameworkShareRequests";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse, GetAUDMAssessmentFrameworkShareRequestListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RequestType = this.RequestType;
            #if MODULAR
            if (this.RequestType == null && ParameterWasBound(nameof(this.RequestType)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RequestType != null)
            {
                request.RequestType = cmdletContext.RequestType;
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
        
        private Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "ListAssessmentFrameworkShareRequests");
            try
            {
                #if DESKTOP
                return client.ListAssessmentFrameworkShareRequests(request);
                #elif CORECLR
                return client.ListAssessmentFrameworkShareRequestsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.AuditManager.ShareRequestType RequestType { get; set; }
            public System.Func<Amazon.AuditManager.Model.ListAssessmentFrameworkShareRequestsResponse, GetAUDMAssessmentFrameworkShareRequestListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssessmentFrameworkShareRequests;
        }
        
    }
}
