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

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Returns an array that summarizes each privacy budget template in a specified collaboration.
    /// </summary>
    [Cmdlet("Get", "CRSCollaborationPrivacyBudgetTemplateList")]
    [OutputType("Amazon.CleanRooms.Model.CollaborationPrivacyBudgetTemplateSummary")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service ListCollaborationPrivacyBudgetTemplates API operation.", Operation = new[] {"ListCollaborationPrivacyBudgetTemplates"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.CollaborationPrivacyBudgetTemplateSummary or Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse",
        "This cmdlet returns a collection of Amazon.CleanRooms.Model.CollaborationPrivacyBudgetTemplateSummary objects.",
        "The service call response (type Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCRSCollaborationPrivacyBudgetTemplateListCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CollaborationIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for one of your collaborations.</para>
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
        public System.String CollaborationIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that are returned for an API request call. The service
        /// chooses a default number if you don't set one. The service might return a `nextToken`
        /// even if the `maxResults` value has not been met.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used to fetch the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CollaborationPrivacyBudgetTemplateSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CollaborationPrivacyBudgetTemplateSummaries";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse, GetCRSCollaborationPrivacyBudgetTemplateListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollaborationIdentifier = this.CollaborationIdentifier;
            #if MODULAR
            if (this.CollaborationIdentifier == null && ParameterWasBound(nameof(this.CollaborationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CollaborationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesRequest();
            
            if (cmdletContext.CollaborationIdentifier != null)
            {
                request.CollaborationIdentifier = cmdletContext.CollaborationIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "ListCollaborationPrivacyBudgetTemplates");
            try
            {
                return client.ListCollaborationPrivacyBudgetTemplatesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CollaborationIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CleanRooms.Model.ListCollaborationPrivacyBudgetTemplatesResponse, GetCRSCollaborationPrivacyBudgetTemplateListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CollaborationPrivacyBudgetTemplateSummaries;
        }
        
    }
}
