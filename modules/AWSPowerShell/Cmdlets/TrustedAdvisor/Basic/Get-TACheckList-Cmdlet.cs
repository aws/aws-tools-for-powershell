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
using Amazon.TrustedAdvisor;
using Amazon.TrustedAdvisor.Model;

namespace Amazon.PowerShell.Cmdlets.TA
{
    /// <summary>
    /// List a filterable set of Checks
    /// </summary>
    [Cmdlet("Get", "TACheckList")]
    [OutputType("Amazon.TrustedAdvisor.Model.CheckSummary")]
    [AWSCmdlet("Calls the Trusted Advisor ListChecks API operation.", Operation = new[] {"ListChecks"}, SelectReturnType = typeof(Amazon.TrustedAdvisor.Model.ListChecksResponse))]
    [AWSCmdletOutput("Amazon.TrustedAdvisor.Model.CheckSummary or Amazon.TrustedAdvisor.Model.ListChecksResponse",
        "This cmdlet returns a collection of Amazon.TrustedAdvisor.Model.CheckSummary objects.",
        "The service call response (type Amazon.TrustedAdvisor.Model.ListChecksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetTACheckListCmdlet : AmazonTrustedAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsService
        /// <summary>
        /// <para>
        /// <para>The aws service associated with the check</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsService { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The ISO 639-1 code for the language that you want your checks to appear in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationLanguage")]
        public Amazon.TrustedAdvisor.RecommendationLanguage Language { get; set; }
        #endregion
        
        #region Parameter Pillar
        /// <summary>
        /// <para>
        /// <para>The pillar of the check</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationPillar")]
        public Amazon.TrustedAdvisor.RecommendationPillar Pillar { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source of the check</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationSource")]
        public Amazon.TrustedAdvisor.RecommendationSource Source { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CheckSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TrustedAdvisor.Model.ListChecksResponse).
        /// Specifying the name of a property of type Amazon.TrustedAdvisor.Model.ListChecksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CheckSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.TrustedAdvisor.Model.ListChecksResponse, GetTACheckListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsService = this.AwsService;
            context.Language = this.Language;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Pillar = this.Pillar;
            context.Source = this.Source;
            
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
            var request = new Amazon.TrustedAdvisor.Model.ListChecksRequest();
            
            if (cmdletContext.AwsService != null)
            {
                request.AwsService = cmdletContext.AwsService;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Pillar != null)
            {
                request.Pillar = cmdletContext.Pillar;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
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
        
        private Amazon.TrustedAdvisor.Model.ListChecksResponse CallAWSServiceOperation(IAmazonTrustedAdvisor client, Amazon.TrustedAdvisor.Model.ListChecksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Trusted Advisor", "ListChecks");
            try
            {
                #if DESKTOP
                return client.ListChecks(request);
                #elif CORECLR
                return client.ListChecksAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsService { get; set; }
            public Amazon.TrustedAdvisor.RecommendationLanguage Language { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.TrustedAdvisor.RecommendationPillar Pillar { get; set; }
            public Amazon.TrustedAdvisor.RecommendationSource Source { get; set; }
            public System.Func<Amazon.TrustedAdvisor.Model.ListChecksResponse, GetTACheckListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CheckSummaries;
        }
        
    }
}
